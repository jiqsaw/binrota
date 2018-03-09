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

public partial class UserControls_Members_uctrlOurMembers : BaseUserControl
{
    public string SearchText
    {
        get { return (ViewState["SearchText"] == null ? "" : ViewState["SearchText"].ToString()); }
        set { ViewState["SearchText"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["SearchText"] != null)
            {
                txtSearch.Text = Request.QueryString["SearchText"];
                DataTable dt = BINROTA.BUS.Members.MemberSearch(txtSearch.Text);
                FillSearchResults(dt);
            }
        }
    }



    private void FillSearchResults(DataTable dt)
    {

        DataTable dtMemberResults = new DataTable();
        dtMemberResults.Columns.Add("PhotoPath");
        dtMemberResults.Columns.Add("NickName");
        dtMemberResults.Columns.Add("MemberID");
        dtMemberResults.Columns.Add("CreateDate");
        dtMemberResults.Columns.Add("Motto");

        foreach (DataRow dr in dt.Rows)
        {
            DataRow drMemberResults = dtMemberResults.NewRow();

            if (dr["PhotoPath"].ToString() == "")
            {
                drMemberResults["PhotoPath"] = "~/Images/Design/NoPicture.jpg";
            }
            else
            {
                drMemberResults["PhotoPath"] = BINROTA.COM.Common.ReturnImagePath(dr["Photopath"].ToString(), ConfigurationManager.AppSettings["MemberImagesUrl"].ToString());
            }
            DateTime date = DateTime.Parse(dr["CreateDate"].ToString());
            drMemberResults["CreateDate"] = date.Day.ToString() + "/" + date.Month.ToString() + "/" + date.Year.ToString();
            drMemberResults["NickName"] = dr["NickName"].ToString();
            drMemberResults["MemberID"] = dr["MemberID"].ToString();
            drMemberResults["Motto"] = dr["Motto"].ToString();

            dtMemberResults.Rows.Add(drMemberResults);
        }
        rptMembersResults.DataSource = dtMemberResults;
        rptMembersResults.DataBind();
    }

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (txtSearch.Text != "")
        {
            DataTable dt = BINROTA.BUS.Members.MemberSearch(txtSearch.Text);
            FillSearchResults(dt);
        } 
    }
    //Sonra eklenecek
    //protected void lnkTodaysBirthDay_Click(object sender, EventArgs e)
    //{
    //    DataTable dt = BINROTA.BUS.Members.MemberSearchByBirthDay(DateTime.Today);
    //    FillSearchResults(dt);
    //}
}
