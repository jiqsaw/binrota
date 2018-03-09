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

public partial class MemberPage : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CARETTA.COM.DDLHelper.BindDDL(ref drpCategories, BINROTA.BUS.Categories.GetCategories(), "Name", "CategoryID", "");
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = BINROTA.BUS.Pages.GetPageForExistanceControl(SessRoot.UserID, int.Parse(Request.QueryString["SubjectID"].ToString()), int.Parse(drpCategories.SelectedValue.ToString()));
        if (dt.Rows.Count == 0)
        {
            BINROTA.BUS.Pages.PagesInsert(SessRoot.UserID, int.Parse(Request.QueryString["SubjectID"].ToString()), int.Parse(drpCategories.SelectedValue.ToString()), (int)Enumerations.PageType.TravelCategoryPage, ftbPageContent.Text, ftbPageContent.Text);
            lbMessage.Text = "Görüþ eklendi";
            ftbPageContent.Text = "";
            txtTitle.Text = "";
            lbMessage.Text = "";
        }
        else {
            lbMessage.Text = "Ayný Kategori için tekrar görüþ ekleyemessiniz"; 
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
