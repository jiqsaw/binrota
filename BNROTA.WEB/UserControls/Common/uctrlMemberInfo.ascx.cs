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
using CARETTA.COM;

public partial class UserControls_Common_uctrlMemberInfo : BaseUserControl 
{
    public int MemberID
    {
        get { return (ViewState["MemberID"] == null ? -1 : int.Parse(ViewState["MemberID"].ToString())); }
        set { ViewState["MemberID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DDLHelper.LoadNumberDDL(ref drpDay, 31);
            DDLHelper.LoadNumberDDL(ref drpMonth, 12);
            DDLHelper.LoadNumberDDL(ref drpYear, DateTime.Today.Year, 1, 1920);
            UserControl();
            lnbDeletePortrait.Attributes.Add("onclick", "return confirm('Resmi silmek istediðinizden emin misiniz?');");
            imgMemberPortrait.Attributes.Add("onerror", "this.src='Images/Design/NoPicture.jpg';");
        }

    }

    private void FillMemberDetailsForMember(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
            hplAllPages.NavigateUrl = "~/PagesView.aspx?MemberID=" + dt.Rows[0]["MemberID"].ToString();
            txtLastName.Text = dt.Rows[0]["LastName"].ToString();
            DateTime BirthDate = Convert.ToDateTime(dt.Rows[0]["BirthDay"]);
            drpDay.SelectedValue = BirthDate.Day.ToString();
            drpMonth.SelectedValue = BirthDate.Month.ToString();
            drpYear.SelectedValue = BirthDate.Year.ToString();

            DDLHelper.BindDDL(ref drpCountry, BINROTA.BUS.Subjects.GetSubjectForDDL((int)Enumerations.SubjectType.Ulke), "Name", "SubjectID", "");
            DataTable dtLivingPlace = BINROTA.BUS.Subjects.GetParentSubjectBySubjectID(int.Parse(dt.Rows[0]["LivingPlace"].ToString()));
            if (dtLivingPlace.Rows.Count > 0)
            {
                drpCountry.SelectedValue = dtLivingPlace.Rows[0]["SubjectID"].ToString();
                DDLHelper.BindDDL(ref drpCity, BINROTA.BUS.Subjects.GetSubjectBySubjectID(int.Parse(drpCountry.SelectedValue), (int)Enumerations.SubjectType.Sehir), "Name", "SubjectID", "");
                drpCity.SelectedValue = dt.Rows[0]["LivingPlace"].ToString();
            }

            DDLHelper.BindDDL(ref drpJob, BINROTA.BUS.Jobs.GetJobs(), "Job", "JobID", "");
            drpJob.SelectedValue = dt.Rows[0]["JobID"].ToString();

            txtInterests.Text = dt.Rows[0]["Interests"].ToString();
            txtVisitedPlaces.Text = dt.Rows[0]["VisitedPlaces"].ToString();
            txtMotto.Text = dt.Rows[0]["Motto"].ToString();
            lbNickName.Text = dt.Rows[0]["NickName"].ToString();
            lbEmail.Text = dt.Rows[0]["Email"].ToString();
            //TODO: Oray && System.IO.File.Exists(Common.ReturnImagePath(dt.Rows[0]["PhotoPath"].ToString(), ConfigurationManager.AppSettings["MemberImagesUrl"].ToString())) eklenecek
            if (dt.Rows[0]["PhotoPath"].ToString() != "")
            {
                imgMemberPortrait.ImageUrl = Common.ReturnImagePath(dt.Rows[0]["PhotoPath"].ToString(), ConfigurationManager.AppSettings["MemberImagesUrl"].ToString());
            }
            else 
            {
                imgMemberPortrait.ImageUrl = "~/Images/Design/NoPicture.jpg";
            }
                

            dt = BINROTA.BUS.Pages.GetUserPages(SessRoot.UserID, (int)Enumerations.PageType.HomePage);
            if (dt.Rows.Count > 0)
                ltrMemberContentPage.Text = dt.Rows[0]["PageContent"].ToString();
        }
        else
            Common.GotoDefaultPage(this.Response);
    }

    private void FillMemberDetailsForVisitor(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            SetVisibles();
            lbFirstName.Text = dt.Rows[0]["FirstName"].ToString();
            hplAllPages.NavigateUrl = "~/PagesView.aspx?MemberID=" + dt.Rows[0]["MemberID"].ToString();
            lbLastName.Text = dt.Rows[0]["LastName"].ToString();
            DateTime BirthDate = DateTime.Parse(dt.Rows[0]["BirthDay"].ToString());
            lbBirthDate.Text = BirthDate.Day.ToString() + "." + BirthDate.Month.ToString() + "." + BirthDate.Year.ToString();
            DataTable dtLivingPlace = BINROTA.BUS.Subjects.GetNameAndParentNameBySubjectID(int.Parse(dt.Rows[0]["LivingPlace"].ToString()));
            if (dtLivingPlace.Rows.Count > 0)
            {
                lbLivingPlace.Text = dtLivingPlace.Rows[0]["ParentName"].ToString() + " > " + dtLivingPlace.Rows[0]["Name"].ToString();
            }
            lbJob.Text = dt.Rows[0]["Job"].ToString();
            lbInterests.Text = dt.Rows[0]["Interests"].ToString();
            lbVisitedPlaces.Text = dt.Rows[0]["VisitedPlaces"].ToString();
            lbMotto.Text = dt.Rows[0]["Motto"].ToString();
            lbNickName.Text = dt.Rows[0]["NickName"].ToString();
            lbEmail.Text = dt.Rows[0]["Email"].ToString();
            //TODO: Oray && System.IO.File.Exists(Common.ReturnImagePath(dt.Rows[0]["PhotoPath"].ToString(), ConfigurationManager.AppSettings["MemberImagesUrl"].ToString())) eklenecek
            if (dt.Rows[0]["PhotoPath"].ToString() != "")
            {
                imgMemberPortrait.ImageUrl = Common.ReturnImagePath(dt.Rows[0]["PhotoPath"].ToString(), ConfigurationManager.AppSettings["MemberImagesUrl"].ToString());
            }
            else
            {
                imgMemberPortrait.ImageUrl = "~/Images/Design/NoPicture.jpg";
            } 
            dt = BINROTA.BUS.Pages.GetUserPages(int.Parse(dt.Rows[0]["MemberID"].ToString()), (int)Enumerations.PageType.HomePage);
            if (dt.Rows.Count > 0)
            {
                ltrMemberContentPage.Text = dt.Rows[0]["PageContent"].ToString();
            }
            else { ltrMemberContentPage.Text = "Kiþisel yazý bulunamadý"; }

        }
        else
            Common.GotoDefaultPage(this.Response);
    }

    private void SetVisibles()
    {
        txtFirstName.Visible = false;
        txtLastName.Visible = false;
        drpDay.Visible = false;
        drpMonth.Visible = false;
        drpYear.Visible = false;
        txtVisitedPlaces.Visible = false;
        drpCountry.Visible = false;
        drpCity.Visible = false;
        drpJob.Visible = false;
        txtInterests.Visible = false;
        txtMotto.Visible = false;
        btnSubmit.Visible = false;
        lnbDeletePortrait.Visible = false;
        lnbUpdatePortrait.Visible = false;
        hlpUpdatePersonelPage2.Visible = false;

        lbFirstName.Visible = true;
        lbLastName.Visible = true;
        lbBirthDate.Visible = true;
        lbLivingPlace.Visible = true;
        lbJob.Visible = true;
        lbInterests.Visible = true;
        lbVisitedPlaces.Visible = true;
        lbMotto.Visible = true;
    }

    private void UserControl()
    {
        DataTable dt=null;
        if (CARETTA.COM.Util.IsNumeric(Request.QueryString["MemberID"]))
        {
            this.MemberID = int.Parse(Request.QueryString["MemberID"]);
            dt = BINROTA.BUS.Members.GetMemberDetailsByMemberID(this.MemberID);
            if(SessRoot == null) { FillMemberDetailsForVisitor(dt); }
            else if (SessRoot.UserID != this.MemberID) { FillMemberDetailsForVisitor(dt); }
            else if (SessRoot.UserID == this.MemberID) { FillMemberDetailsForMember(dt); }
        }
        else if (SessRoot != null)
        {
            dt = BINROTA.BUS.Members.GetMemberDetailsByMemberID(SessRoot.UserID);
            FillMemberDetailsForMember(dt);
        }
        else Common.GotoDefaultPage(this.Response);
        

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string BirthDate = drpDay.SelectedValue + "." + drpMonth.SelectedValue + "." + drpYear.SelectedValue;
        if (isDateValid(BirthDate))
        {
            BINROTA.BUS.Members.MemberUpdate(SessRoot.UserID, txtFirstName.Text, txtLastName.Text, int.Parse(drpJob.SelectedValue), int.Parse(drpCity.SelectedValue), txtInterests.Text, txtMotto.Text, txtVisitedPlaces.Text, Convert.ToDateTime(BirthDate));
        }
    }

    private bool isDateValid(string date)
    {
        try
        {
            DateTime BirthDay = Convert.ToDateTime(date);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    protected void lnbDeletePortrait_Click(object sender, EventArgs e)
    {
        DataTable dt = BINROTA.BUS.Members.GetMemberDetailsByMemberID(SessRoot.UserID);
        if (dt.Rows.Count > 0)
        {
            if (Common.DeleteImage(dt.Rows[0]["PhotoPath"].ToString(), Request.MapPath(ConfigurationManager.AppSettings["MemberImagesPath"].ToString())))
            { 
                BINROTA.BUS.Members.MemberPortraitUpdate(SessRoot.UserID, "");
                dt = BINROTA.BUS.Members.GetMemberDetailsByMemberID(SessRoot.UserID);
            }
            else
            { }
            FillMemberDetailsForMember(dt);
        }
    }

    protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLHelper.BindDDL(ref drpCity, BINROTA.BUS.Subjects.GetSubjectBySubjectID(int.Parse(drpCountry.SelectedValue), (int)Enumerations.SubjectType.Sehir), "Name", "SubjectID", "");
    }
}
