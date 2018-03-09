using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BINROTA.COM;

public partial class UserControls_uctrlMemberVisitorPageCategories : BaseUserControl
{
    public int PageID
    {
        get
        {
            return (int)(ViewState["PID"] == null ? 0 : ViewState["PID"]);
        }
        set
        {
            ViewState["PID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategories();
            FillCategories(int.Parse(Request.QueryString["PageID"]));
        }
    }

    private void BindCategories()
    {
        DataTable dtCategories = BINROTA.BUS.Categories.GetCategories();

        rptPageCategories.DataSource = dtCategories;
        rptPageCategories.DataBind();

        foreach (RepeaterItem rptitem in rptPageCategories.Items)
        {
            ((Label)rptitem.FindControl("lblCategoryName")).Text = ((int)(rptitem.ItemIndex + 1)).ToString() + " - " + dtCategories.Rows[rptitem.ItemIndex]["Name"].ToString();
        }
    }

    public string GetCategoryContent(int CategoryID)
    {
        foreach (RepeaterItem rptitem in rptPageCategories.Items)
        {
            if (int.Parse(((Label)rptitem.FindControl("lblCategoryID")).Text) == CategoryID)
                return ((TextBox)rptitem.FindControl("txtCategoryContent")).Text;
        }
        return "";
    }

    public DataTable GetCategoryContents()
    {
        DataTable dtCategories = new DataTable();
        dtCategories.Columns.Add("CategoryID");
        dtCategories.Columns.Add("CategoryContent");

        foreach (RepeaterItem rptitem in rptPageCategories.Items)
        {
            DataRow dr = dtCategories.NewRow();

            dr["CategoryID"] = ((Label)rptitem.FindControl("lblCategoryID")).Text;
            dr["CategoryContent"] = ((TextBox)rptitem.FindControl("txtCategoryContent")).Text;
            dtCategories.Rows.Add(dr);
        }

        return dtCategories;
    }

    public Hashtable GetCategoryContentsHT()
    {
        Hashtable htCategories = new Hashtable();

        foreach (RepeaterItem rptitem in rptPageCategories.Items)
        {
            htCategories.Add(((Label)rptitem.FindControl("lblCategoryID")).Text, ((TextBox)rptitem.FindControl("txtCategoryContent")).Text);
        }

        return htCategories;
    }

    public void SetCategoryContent(int CategoryID, string CategoryContent)
    {
        foreach (RepeaterItem rptitem in rptPageCategories.Items)
        {
            if (int.Parse(((Label)rptitem.FindControl("lblCategoryID")).Text) == CategoryID)
                ((TextBox)rptitem.FindControl("txtCategoryContent")).Text = CategoryContent;
        }
    }

    private void FillCategories(int ParentPageID)
    {
        int CategoryID;
        DataTable dt = BINROTA.BUS.Categories.GetCategories();
        foreach (DataRow dr in dt.Rows)
        {
            CategoryID = int.Parse(dr["CategoryID"].ToString());
            DataTable dtPages = (BINROTA.BUS.Pages.GetPageForExistanceControl(ParentPageID, CategoryID));
            if (dtPages.Rows.Count > 0)
                SetCategoryContent(CategoryID, dtPages.Rows[0]["PageContent"].ToString());
        }
    }


    protected void lnbAddComment_Click(object sender, EventArgs e)
    {
        if (SessRoot == null)
            Common.GotoDefaultPage(this.Response);
    }
}
