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

public partial class UserControls_uctrlMemberVisitorHomePage : BaseUserControl
{

    private void FillUserDetails()
    {
        DataTable dt = BINROTA.BUS.Members.GetMemberDetailsByMemberID(int.Parse(Request.QueryString["MemberID"]));
        if (dt.Rows.Count > 0)
        {
            lbBirthDate.Text = dt.Rows[0]["BirthDay"].ToString();
            lbBirthPlace.Text = dt.Rows[0]["LivingPlace"].ToString();
            lbEducation.Text = dt.Rows[0]["Education"].ToString();
            lbJob.Text = dt.Rows[0]["JobID"].ToString();
            lbName.Text = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
            lbPoints.Text = dt.Rows[0]["Point"].ToString();
            lbInterests.Text = dt.Rows[0]["Interests"].ToString();
            lbMotto.Text = dt.Rows[0]["Motto"].ToString();
            lbTravelPagesHeader.Text = dt.Rows[0]["NickName"].ToString() + " " + "Gezi Sayfalarý";

        }
        dt = BINROTA.BUS.Pages.GetUserPages(int.Parse(Request.QueryString["MemberID"]), (int)Enumerations.PageType.HomePage);
        if (dt.Rows.Count > 0)
            txtHomePageContent.Text = dt.Rows[0]["PageContent"].ToString();
    }

    private void FillUserPages()
    {
        DataTable dt = BINROTA.BUS.Pages.GetUserPages(int.Parse(Request.QueryString["MemberID"]), (int)Enumerations.PageType.TravelPage);

        DataTable dtTravel = new DataTable();
        dtTravel.Columns.Add("PageID");
        dtTravel.Columns.Add("TravelContentName");
        foreach (DataRow dr in dt.Rows)
        {
            string TravelName = "";

            DataRow drTravel = dtTravel.NewRow();

            drTravel["PageID"] = int.Parse(dr["PageID"].ToString());

            TravelName = BINROTA.BUS.Subjects.GetSubject(int.Parse(dr["SubjectID"].ToString())).Rows[0]["Name"].ToString() + " ";
            TravelName = TravelName + BINROTA.BUS.PageCategories.GetPageCategoriesByPageCategoryID(int.Parse(dr["PageCategoryID"].ToString())).Rows[0]["PageCategoryName"].ToString();

            drTravel["TravelContentName"] = TravelName;
            dtTravel.Rows.Add(drTravel);
        }
        rptPages.DataSource = dtTravel;
        rptPages.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            if (Request.QueryString["MemberID"] != null)
            {
                FillUserDetails();
                FillUserPages();
            }
            else
            {
                Common.GotoDefaultPage(this.Response);
            }
        }
    }
}
