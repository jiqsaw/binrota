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
using BINROTA.COM;

public partial class UserControls_Pages_uctrlAddPage : BaseUserControl
{
    #region Properties
    public int PageID
    {
        get
        {
            return int.Parse(ViewState["pID"].ToString());
        }
        set
        {
            ViewState["pID"] = value;
        }
    }

    public int SubjectID
    {
        get 
        {
            return (ViewState["sID"] == null ? 0 : int.Parse(ViewState["sID"].ToString()));
        }

        set
        {
            ViewState["sID"] = value;
        }

    }

    private Enumerations.SaveMode SaveMode
    {
        get
        {
            return (Enumerations.SaveMode)((int)ViewState["SaveMode"]);
        }
        set
        {
            ViewState["SaveMode"] = value;
        }
    }

    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (SessRoot != null)
            {
                DDLHelper.LoadNumberDDL(ref drpDay, 31);
                DDLHelper.LoadNumberDDL(ref drpMonth, 12);
                DDLHelper.LoadNumberDDL(ref drpYear, DateTime.Today.Year, 1, 1920);
                UctrlPageCategories1.BindCategories();
                if (Request.QueryString["PageID"] == "0" || Request.QueryString["PageID"] == null)
                {
                    if (Request.QueryString["SubjectID"] != null)
                    {
                        if (Util.IsNumeric(Request.QueryString["SubjectID"]))
                        {
                            this.SubjectID = int.Parse(Request.QueryString["SubjectID"].ToString());
                        }
                    }
                    this.SaveMode = Enumerations.SaveMode.Insert;
                    BindDDL();


                }
                else
                {
                    if (Util.IsNumeric(Request.QueryString["PageID"]))
                    {
                        this.PageID = int.Parse(Request.QueryString["PageID"]);
                        this.SaveMode = Enumerations.SaveMode.Update;
                        FillForm();
                    }
                    else
                    {
                        Response.Write("<script language='javascript'> { window.close();}</script>");
                    }
                }
            }
            else
                BINROTA.COM.Common.GotoDefaultPage(this.Response);
        }
    }

    private void FillForm()
    {
        DDLHelper.BindDDL(ref drpPageCategory, BINROTA.BUS.PageCategories.GetPageCategoriesAll(), "PageCategoryName", "PageCategoryID", "");
        DDLHelper.BindDDL(ref drpContinent, BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(0), "Name", "SubjectID", "");
        DataTable dt = BINROTA.BUS.Pages.GetPageForExistanceControl(PageID);
        if (dt.Rows.Count > 0)
        {
            if (SessRoot.UserID == Convert.ToInt32(dt.Rows[0]["MemberID"]))
            {
                ftbPageContent.Text = dt.Rows[0]["PageContent"].ToString();
                txtTitle.Text = dt.Rows[0]["Title"].ToString();
                DateTime travelDate = Convert.ToDateTime(dt.Rows[0]["TravelDate"]);
                drpDay.SelectedValue = travelDate.Day.ToString();
                drpMonth.SelectedValue = travelDate.Month.ToString();
                drpYear.SelectedValue = travelDate.Year.ToString();
                drpPageCategory.SelectedValue = dt.Rows[0]["PageCategoryID"].ToString();

                BindDLLBySubjectID(int.Parse(dt.Rows[0]["SubjectID"].ToString()));
            }
            else
            {
                Response.Write("<script language='javascript'> { window.close();}</script>");
                Response.End();
            }

        }
        else 
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
            Response.End();
        }

        DataTable dtCategories = BINROTA.BUS.Categories.GetCategories();

        foreach (DataRow dr in dtCategories.Rows)
        {
            dt = BINROTA.BUS.Pages.GetPageForExistanceControl(PageID, int.Parse(dr["CategoryID"].ToString()));
            foreach (DataRow dr1 in dt.Rows)
            {
                UctrlPageCategories1.SetCategoryContent(int.Parse(dr1["CategoryID"].ToString()), dr1["PageContent"].ToString());
            }
        }
    }

    private void BindDLLBySubjectID(int SubjectID)
    {
        DataTable dt = BINROTA.BUS.Subjects.GetSubject(SubjectID);
        try
        {
            if (dt.Rows.Count > 0)
            {
                if (int.Parse(dt.Rows[0]["SubjectTypeID"].ToString()) == (int)Enumerations.SubjectType.Ulke)
                {
                    drpContinent.SelectedValue = dt.Rows[0]["ParentSubjectID"].ToString();
                    DDLHelper.BindDDL(ref drpCountry, BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(drpContinent.SelectedValue)), "Name", "SubjectID", "");
                    drpCountry.SelectedValue = dt.Rows[0]["SubjectID"].ToString();
                    DDLHelper.BindDDL(ref drpCity, BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(drpCountry.SelectedValue)), "Name", "SubjectID", "", "Ülke Genel", "0");
                }
                else
                    if (int.Parse(dt.Rows[0]["SubjectTypeID"].ToString()) == (int)Enumerations.SubjectType.Sehir)
                    {
                        int subjectID = int.Parse(dt.Rows[0]["SubjectID"].ToString());
                        DataTable dtCountry = BINROTA.BUS.Subjects.GetSubject(int.Parse(dt.Rows[0]["ParentSubjectID"].ToString()));
                        drpContinent.SelectedValue = dtCountry.Rows[0]["ParentSubjectID"].ToString();
                        DDLHelper.BindDDL(ref drpCountry, BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(drpContinent.SelectedValue)), "Name", "SubjectID", "");
                        drpCountry.SelectedValue = dt.Rows[0]["ParentSubjectID"].ToString();
                        DDLHelper.BindDDL(ref drpCity, BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(drpCountry.SelectedValue)), "Name", "SubjectID", "", "Ülke Genel", "0");
                        drpCity.SelectedValue = subjectID.ToString();
                    }
            }
            else
            {
                Response.Write("<script language='javascript'> { window.close();}</script>");
                Response.End();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    private void BindDDL()
    {
        DDLHelper.BindDDL(ref drpPageCategory, BINROTA.BUS.PageCategories.GetPageCategoriesAll(), "PageCategoryName", "PageCategoryID", "");
        DDLHelper.BindDDL(ref drpContinent, BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(0), "Name", "SubjectID", "");
        if (this.SubjectID != 0)
        {
            BindDLLBySubjectID(this.SubjectID);
        }
        else
        {
            DDLHelper.BindDDL(ref drpCountry, BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(drpContinent.SelectedValue)), "Name", "SubjectID", "");
            DDLHelper.BindDDL(ref drpCity, BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(drpCountry.SelectedValue)), "Name", "SubjectID", "", "Ülke Genel", "0");
        }
    }

    protected void drpContinent_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLHelper.BindDDL(ref drpCountry, BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(drpContinent.SelectedValue)), "Name", "SubjectID", "");
        DDLHelper.BindDDL(ref drpCity, BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(drpCountry.SelectedValue)), "Name", "SubjectID", "", "Ülke Genel", "0");
    }

    protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLHelper.BindDDL(ref drpCity, BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(drpCountry.SelectedValue)), "Name", "SubjectID", "", "Ülke Genel", "0");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (isDateValid(drpDay.SelectedValue + "." + drpMonth.SelectedValue + "." + drpYear.SelectedValue))
        {
            DateTime TravelDate = new DateTime(int.Parse(drpYear.SelectedValue), int.Parse(drpMonth.SelectedValue), int.Parse(drpDay.SelectedValue));
            if (txtTitle.Text != "" && ftbPageContent.Text != "")
            {
                try
                {
                    if (this.SaveMode == Enumerations.SaveMode.Insert)
                    {
                        if (drpCity.SelectedValue == "0")
                        {
                            BINROTA.BUS.Pages.PagesInsert(
            SessRoot.UserID, int.Parse(drpCountry.SelectedValue), (int)Enumerations.PageType.TravelPage,
            int.Parse(drpPageCategory.SelectedValue),
            txtTitle.Text,
            ftbPageContent.Text, TravelDate, "PhotoPathKonulacak",
            "PhotoCaptionKonulacak", 0, DateTime.Now, SessRoot.UserID, UctrlPageCategories1.GetCategoryContents());
                        }
                        else
                        {
                            BINROTA.BUS.Pages.PagesInsert(
                                SessRoot.UserID, int.Parse(drpCity.SelectedValue), (int)Enumerations.PageType.TravelPage,
                                int.Parse(drpPageCategory.SelectedValue),
                                txtTitle.Text,
                                ftbPageContent.Text, TravelDate, "PhotoPathKonulacak",
                                "PhotoCaptionKonulacak", 0, DateTime.Now, SessRoot.UserID, UctrlPageCategories1.GetCategoryContents());
                        }
                        ftbPageContent.Text = "";
                        txtTitle.Text = "";
                        //UctrlPageCategories1.ClearTextBoxes();
                        //lbMessage.Text = "Gezi yazýsý baþarýyla eklenmiþtir";
                    }
                    else if (this.SaveMode == Enumerations.SaveMode.Update)
                    {
                        if (drpCity.SelectedValue == "0")
                        {
                            BINROTA.BUS.Pages.PagesUpdate(this.PageID, int.Parse(drpCountry.SelectedValue),
                            int.Parse(drpPageCategory.SelectedValue), txtTitle.Text, ftbPageContent.Text, TravelDate,
                            "PhotoPathKonulacak", "PhotoCaptionKonulacak", DateTime.Now, SessRoot.UserID,
                            UctrlPageCategories1.GetCategoryContentsHT());
                        }
                        else
                        {
                            BINROTA.BUS.Pages.PagesUpdate(this.PageID, int.Parse(drpCity.SelectedValue),
                            int.Parse(drpPageCategory.SelectedValue), txtTitle.Text, ftbPageContent.Text, TravelDate,
                            "PhotoPathKonulacak", "PhotoCaptionKonulacak", DateTime.Now, SessRoot.UserID,
                            UctrlPageCategories1.GetCategoryContentsHT());
                        }
                    }
                    //lbMessage.Text = "Yazýnýz baþarýyla kaydedilmiþtir. Teþekkür ederiz";
                    UctrlPageCategories1.ClearForm();
                }
                catch (Exception)
                {
                    Response.Redirect("Result.aspx?Message=Yazý girilirken bir hata oluþtu. Lütfen tekrar deneyin");
                    throw;
                }

                Response.Write("<script>window.opener.location.reload()</script>");
                Response.Redirect("Result.aspx?Message=Yazýnýz baþarýyla kaydedilmiþtir. Teþekkür ederiz");
                //pnlMessage.Visible = true;
                //pnlPageContent.Visible = false;
                //pnlButtons.Visible = false;
            }
        }
        else 
        {
            Response.Redirect("Result.aspx?Message=Girmiþ olduðunuz tarih geçerli bir tarih deðildir. Lütfen doðru bir tarih giriniz."); 
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

    private void ClearForm()
    {
        txtTitle.Text = "";
        ftbPageContent.Text = "";
        UctrlPageCategories1.ClearForm();
    
    }
}
