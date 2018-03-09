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
using CARETTA.COM;

public partial class UserControls_Common_uctrlSearch : BaseUserControl
{
    public string SearchText
    {
        get { return (ViewState["sTX"] == null ? "" : ViewState["sTX"].ToString()); }
        set { ViewState["sTX"] = value; }
    }

    public int PageCategoryID
    {
        get { return (ViewState["cID"] == null ? 0 : int.Parse(ViewState["cID"].ToString())); }
        set { ViewState["cID"] = value; }
    }

    public int SubjectID
    {
        get { return (ViewState["sID"] == null ? 0 : int.Parse(ViewState["sID"].ToString())); }
        set { ViewState["sID"] = value; }
    }    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = null;
            if (Request.QueryString["SearchText"] != null)
            {
                if (Util.IsNumeric(Request.QueryString["SubjectID"]) && Util.IsNumeric(Request.QueryString["PageCategoryID"]))
                {

                    this.SearchText = Request.QueryString["SearchText"];
                    this.SubjectID = int.Parse(Request.QueryString["SubjectID"]);
                    this.PageCategoryID = int.Parse(Request.QueryString["PageCategoryID"]);
                    dt = BINROTA.BUS.Pages.PageSearch(this.SearchText, this.PageCategoryID, this.SubjectID);
                }
                else
                {
                    this.SearchText = Request.QueryString["SearchText"];
                    dt = BINROTA.BUS.Pages.PageSearchForSubject(this.SearchText);
                }
            }
            else if (Util.IsNumeric(Request.QueryString["PageCategoryID"]))
            {
                this.PageCategoryID = int.Parse(Request.QueryString["PageCategoryID"]);
                dt = BINROTA.BUS.Pages.PageSearch("", this.PageCategoryID);
            }
            else if (Util.IsNumeric(Request.QueryString["SubjectID"]))
            {
                this.SubjectID = int.Parse(Request.QueryString["SubjectID"]);
                this.SearchText = "";
                this.PageCategoryID = 0;
                dt = BINROTA.BUS.Pages.PageSearch(this.SearchText, this.PageCategoryID, this.SubjectID);
            }
            else { BINROTA.COM.Common.GotoDefaultPage(this.Response); }
            
            txtSearch.Text = this.SearchText;
            FillSearchResults(dt);
            DDLHelper.BindDDL(ref drpCategories, BINROTA.BUS.PageCategories.GetPageCategoriesAll(), "PageCategoryName", "PageCategoryID", "", "Bir Kategori Seçiniz", "0");
        }
    }

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dt = BINROTA.BUS.Pages.PageSearch(txtSearch.Text, int.Parse(drpCategories.SelectedValue.ToString()));
        FillSearchResults(dt);
    }

    private void FillSearchResults(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            rptList.DataSource = dt;
            rptList.DataBind();
        }
        else 
        {
            lbMessage.Text = "Aradýðýnýz kelime ile ilgili herhangi bir sonuç bulunamamýþtýr";
            lbMessage.Visible = true;
        }
    }
}
