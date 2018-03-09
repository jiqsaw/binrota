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

public partial class UserControls_uctrlPageContent : BaseUserControl
{

    public string ContentText
    {
        get { return ftbPageContent.Text; }
        set { ftbPageContent.Text = value; }
    }

    public string Title
    {
        get { return txtTitle.Text; }
        set { txtTitle.Text = value; }
    }

    public int ContentYear
    {
        get { return int.Parse(drpYear.SelectedValue); }
        set { drpYear.SelectedValue = value.ToString(); }
    }

    public int ContentMonth
    {
        get { return int.Parse(drpMonth.SelectedValue); }
        set { drpMonth.SelectedValue = value.ToString(); }
    }

    public int ContentDay
    {
        get { return int.Parse(drpDay.SelectedValue); }
        set { drpDay.SelectedValue = value.ToString(); }
    }

    public int ContentCategory
    {
        get { return int.Parse(drpPageCategory.SelectedValue); }
        set { drpPageCategory.SelectedValue = value.ToString(); }
    }

    public void ClearForm()
    {
        txtTitle.Text = "";
        ftbPageContent.Text = "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack) {
            DDLHelper.LoadNumberDDL(ref drpDay, 31, 1, 1);
            DDLHelper.LoadNumberDDL(ref drpMonth, 12, 1, 1);
            DDLHelper.LoadNumberDDL(ref drpYear, 2010, 1, 2000);
            DDLHelper.BindDDL(ref drpPageCategory, BINROTA.BUS.PageCategories.GetPageCategoriesAll(), "PageCategoryName", "PageCategoryID", "");
        }
    }
}
