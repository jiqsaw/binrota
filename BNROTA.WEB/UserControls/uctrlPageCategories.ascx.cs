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

public partial class UserControls_uctrlPageCategories : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
            //BindCategories();
    }

    public void BindCategories()
    {
        DataTable dtCategories = BINROTA.BUS.Categories.GetCategories();

        rptPageCategories.DataSource = dtCategories;
        rptPageCategories.DataBind();

        foreach (RepeaterItem rptitem in rptPageCategories.Items)
        {
            ((Label)rptitem.FindControl("lblCategoryName")).Text = ((int)(rptitem.ItemIndex+1)).ToString() + " - " + dtCategories.Rows[rptitem.ItemIndex]["Name"].ToString(); 
        }
    }

    public string GetCategoryContent(int CategoryID)
    {
        foreach (RepeaterItem rptitem in rptPageCategories.Items)
        {
            if (int.Parse(((Label)rptitem.FindControl("lblCategoryID")).Text) == CategoryID)
                return ((TextBox)rptitem.FindControl("txtCategoryContent")).Text; 
        }
        return  "";
    }

    public DataTable GetCategoryContents()
    {
        DataTable dtCategories=new DataTable();
        dtCategories.Columns.Add("CategoryID");
        dtCategories.Columns.Add("CategoryContent");

        foreach (RepeaterItem rptitem in rptPageCategories.Items)
        {
            DataRow dr=dtCategories.NewRow();

            dr["CategoryID"]=((Label)rptitem.FindControl("lblCategoryID")).Text;
            dr["CategoryContent"]=((TextBox)rptitem.FindControl("txtCategoryContent")).Text;
            dtCategories.Rows.Add(dr);
        }

        return dtCategories;
    }

    public Hashtable GetCategoryContentsHT()
    {
        Hashtable htCategories=new Hashtable();

        foreach (RepeaterItem rptitem in rptPageCategories.Items)
        {
            htCategories.Add(((Label)rptitem.FindControl("lblCategoryID")).Text, ((TextBox)rptitem.FindControl("txtCategoryContent")).Text);
        }

        return htCategories;
    }

    public void SetCategoryContent(int CategoryID,string CategoryContent)
    {
        foreach (RepeaterItem rptitem in rptPageCategories.Items)
        {
            if (int.Parse(((Label)rptitem.FindControl("lblCategoryID")).Text) == CategoryID)
                ((TextBox)rptitem.FindControl("txtCategoryContent")).Text = CategoryContent; 
        }
    }

    public void ClearForm()
    {
        foreach (RepeaterItem rptitem in rptPageCategories.Items)
        {
            ((Label)rptitem.FindControl("lblCategoryID")).Text = "";
            ((TextBox)rptitem.FindControl("txtCategoryContent")).Text = "";
        }
    }

    public void ClearTextBoxes()
    {
        foreach(RepeaterItem rptitem in rptPageCategories.Items)
            ((TextBox)rptitem.FindControl("txtCategoryContent")).Text = "";
    }
}
