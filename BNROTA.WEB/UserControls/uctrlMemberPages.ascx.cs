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

public partial class UserControls_uctrlMemberPages : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillUserPages();
        }
    }

    private void FillUserPages()
    {
        DataTable dt = BINROTA.BUS.Pages.GetUserPages(SessRoot.UserID, (int)Enumerations.PageType.TravelPage);
        DataTable dtTravel = new DataTable();
        dtTravel.Columns.Add("PageID");
        dtTravel.Columns.Add("TravelContentName");
        foreach (DataRow dr in dt.Rows)
        {
            string TravelName = "";

            DataRow drTravel = dtTravel.NewRow();

            drTravel["PageID"] = int.Parse(dt.Rows[0]["PageID"].ToString());

            TravelName = BINROTA.BUS.Subjects.GetSubject(int.Parse(dr["SubjectID"].ToString())).Rows[0]["Name"].ToString() + " ";
            TravelName = TravelName + BINROTA.BUS.PageCategories.GetPageCategoriesByPageCategoryID(int.Parse(dr["PageCategoryID"].ToString())).Rows[0]["PageCategoryName"].ToString();

            drTravel["TravelContentName"] = TravelName;
            dtTravel.Rows.Add(drTravel);
        }
        rptPages.DataSource = dtTravel;
        rptPages.DataBind();
    }
    protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}
