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
using BINROTA.BUS;

public partial class AddCountry : BasePage
{
    #region Properties
    public Enumerations.SaveMode SaveMode
    {
        get
        {
            return (ViewState["SaveMode"] == null ? Enumerations.SaveMode.Insert : ((Enumerations.SaveMode)((int)ViewState["SaveMode"])));
        }
        set
        {
            ViewState["SaveMode"] = value;
        }
    }
    private int SubjectID
    {
        get
        {
            return (ViewState["SID"] == null ? -1 : int.Parse(ViewState["SID"].ToString()));
        }
        set
        {
            ViewState["SID"] = value;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessRoot == null) Common.GotoDefaultPage(this.Response);
        if (SessRoot.LoginType == (int)Enumerations.LoginType.Member) Common.GotoDefaultPage(this.Response);
        if (!IsPostBack)
        {
            DDLHelper.BindDDL(ref drpContinents, BINROTA.BUS.Subjects.GetSubjectForDDL(1), "Name", "SubjectID", "");
            ModeControl();

            btnDelete.Attributes.Add("onclick", "return confirm('Kaydý silmek istediðinizden emin misiniz ?');");
            UctrlImageUpload1.UploadType = Enumerations.FileUploadType.SubjectImages; 
        }
    }
    private void ModeControl()
    {
        Enumerations.SaveMode SaveMode;
        SaveMode = Enumerations.SaveMode.Update;
        if ((Request.QueryString["SaveMode"] != null) && (CARETTA.COM.Util.IsNumeric(Request.QueryString["SaveMode"])))
        {
            SaveMode = ((Enumerations.SaveMode)int.Parse(Request.QueryString["SaveMode"].ToString()));
            this.SaveMode = SaveMode;
        }
        else
        {
            Common.GotoDefaultPage(this.Response);
        }

        if (SaveMode == Enumerations.SaveMode.Update)
        {
            ((BinRota)this.Master).SetPageDesc("Ülke Güncelleme");
            if ((Request.QueryString["SubjectID"] != null) && (CARETTA.COM.Util.IsNumeric(Request.QueryString["SubjectID"])))
            {
                SubjectID = (int.Parse(Request.QueryString["SubjectID"].ToString()));
                DataTable dtContinent = BINROTA.BUS.Subjects.GetParentSubjectBySubjectID(SubjectID);
                if (dtContinent.Rows.Count > 0)
                    drpContinents.SelectedValue = dtContinent.Rows[0]["SubjectID"].ToString();
            }
            else
            {
                Common.GotoDefaultPage(this.Response);
            }

            btnDelete.Visible = true;
            DataTable dtSubject = BINROTA.BUS.SubjectCustomization.GetSubjectCustomization(SubjectID);

            if (dtSubject.Rows.Count > 0)
            {
                if (dtSubject.Rows[0]["PhotoPath"].ToString() == "")
                {
                    imgCountry.ImageUrl = "~/Images/Design/NoPictureForSubject.png";
                    imgCountry.BorderStyle = BorderStyle.None;
                }
                else
                {
                    imgCountry.ImageUrl = Common.ReturnImagePath(dtSubject.Rows[0]["PhotoPath"].ToString(), ConfigurationManager.AppSettings["SubjectImagesUrl"].ToString());
                }
                txtName.Text = dtSubject.Rows[0]["Name"].ToString();
                txtArea.Text = dtSubject.Rows[0]["Area"].ToString();
                txtAreaCode.Text = dtSubject.Rows[0]["AreaCode"].ToString();
                txtCapital.Text = dtSubject.Rows[0]["Capital"].ToString();
                txtCurrency.Text = dtSubject.Rows[0]["Currency"].ToString();
                txtDescription.Text = dtSubject.Rows[0]["Description"].ToString();
                txtLanguage.Text = dtSubject.Rows[0]["Language"].ToString();
                txtLocation.Text = dtSubject.Rows[0]["Location"].ToString();
                txtNeighbourhood.Text = dtSubject.Rows[0]["Neighbourhood"].ToString();
                txtPhotoCaption.Text = dtSubject.Rows[0]["PhotoCaption"].ToString();
                txtPopulation.Text = dtSubject.Rows[0]["Population"].ToString();
                txtReligion.Text = dtSubject.Rows[0]["Religion"].ToString();
                txtTimeZone.Text = dtSubject.Rows[0]["TimeZone"].ToString();
            }
            else
            {
                Common.GotoDefaultPage(this.Response);
            }
        }
        else if (SaveMode == Enumerations.SaveMode.Insert)
        {
            ((BinRota)this.Master).SetPageDesc("Ülke Ekleme");
            drpContinents.SelectedValue = Request.QueryString["ContinentSubjectID"];
        }
    }
    protected void btnMainPage_Click(object sender, EventArgs e)
    {
        Common.GotoDefaultPage(this.Response);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.SaveMode == Enumerations.SaveMode.Update)
        {
            if (UctrlImageUpload1.FileName == "")
            {
                Subjects.SubjectsCountryUpdate(SubjectID, txtName.Text, txtDescription.Text, txtPhotoCaption.Text, SessRoot.UserID, txtLocation.Text, txtCapital.Text, txtArea.Text, txtNeighbourhood.Text, txtPopulation.Text, txtCurrency.Text, txtAreaCode.Text, txtTimeZone.Text, txtLanguage.Text, txtReligion.Text, int.Parse(drpContinents.SelectedValue));
            }
            else
            {
                UctrlImageUpload1.UploadType = Enumerations.FileUploadType.SubjectImages;
                Subjects.SubjectsCountryUpdate(SubjectID, txtName.Text, txtDescription.Text, UctrlImageUpload1.SendFile(Enumerations.SubjectType.Ulke.ToString() + "//" + txtName.Text), txtPhotoCaption.Text, SessRoot.UserID, txtLocation.Text, txtCapital.Text, txtArea.Text, txtNeighbourhood.Text, txtPopulation.Text, txtCurrency.Text, txtAreaCode.Text, txtTimeZone.Text, txtLanguage.Text, txtReligion.Text, int.Parse(drpContinents.SelectedValue));


            }

            LabelMessage.Text = "Ülke güncellenmiþtir";
            ModeControl();
        }
        else if (this.SaveMode == Enumerations.SaveMode.Insert)
        {
            Enumerations.SubjectInsertResult Result;
            Result = BINROTA.BUS.Subjects.SubjectsInsertCountry(txtName.Text, txtDescription.Text, UctrlImageUpload1.SendFile(Enumerations.SubjectType.Ulke.ToString() + "\\" + txtName.Text), txtPhotoCaption.Text, int.Parse(drpContinents.SelectedValue), (int)Enumerations.SubjectType.Ulke, DateTime.Now, SessRoot.UserID, txtLocation.Text, txtCapital.Text, txtArea.Text, txtNeighbourhood.Text, txtPopulation.Text, txtCurrency.Text, txtAreaCode.Text, txtTimeZone.Text, txtLanguage.Text, txtReligion.Text);
            if (Result == Enumerations.SubjectInsertResult.Success)
            {
                LabelMessage.Text = "Ülke eklenmiþtir";
            }
            else if (Result == Enumerations.SubjectInsertResult.AlreadyExist)
            {
                LabelMessage.Text = "Daha önce bu isimde bir ülke eklenmiþtir";
            }
            else if (Result == Enumerations.SubjectInsertResult.Failure)
            {
                LabelMessage.Text = "Ülke eklerken bir hata oluþtu. Lütfen tekrar deneyin";
            }
        }
        else
        {
            Common.GotoDefaultPage(this.Response);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        BINROTA.BUS.Subjects.SubjectsDelete(SubjectID);
    }
}
