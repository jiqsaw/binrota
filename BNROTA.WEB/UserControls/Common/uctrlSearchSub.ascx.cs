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

public partial class UserControls_Common_uctrlSearchSub : System.Web.UI.UserControl
{

    public string Title
    {
        get { return lblSearchTitle.Text.ToUpperInvariant(); }
        set { lblSearchTitle.Text = value.ToUpperInvariant() + " YAZILARINDA ARA"; }
    }




    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DDLHelper.BindDDL(ref drpCategories, BINROTA.BUS.PageCategories.GetPageCategoriesAll(), "PageCategoryName", "PageCategoryID", "", "Tüm Kategoriler", "0");
        }
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Search.aspx?SearchText=" + txtSearch.Text + "&SubjectID=" + int.Parse(Request.QueryString["SubjectID"]) + "&PageCategoryID=" + int.Parse(drpCategories.SelectedValue));
    }
}
