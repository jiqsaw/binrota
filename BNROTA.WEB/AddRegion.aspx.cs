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

public partial class AddRegion : BasePage
{

    #region Properties
    private Enumerations.SaveMode SaveMode
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
            DDLHelper.BindDDL(ref drpContinents, BINROTA.BUS.Subjects.GetSubjectForDDL((int)Enumerations.SubjectType.Kita), "Name", "SubjectID", "");
            DDLHelper.BindDDL(ref drpCountry, BINROTA.BUS.Subjects.GetSubjectForDDL((int)Enumerations.SubjectType.Ulke), "Name", "SubjectID", "");
            ModeControl();

            btnDelete.Attributes.Add("onclick", "return confirm('Kaydý silmek istediðinizden emin misiniz ?');");
            UctrlImageUpload1.UploadType = Enumerations.FileUploadType.SubjectImages;
        }
    }
    private void ModeControl()
    {
        SaveMode = Enumerations.SaveMode.Update;

        if ((Request.QueryString["SubjectID"] != null) && (CARETTA.COM.Util.IsNumeric(Request.QueryString["SubjectID"])))
        {
            SubjectID = (int.Parse(Request.QueryString["SubjectID"].ToString()));
        }
        else
        {
            Common.GotoDefaultPage(this.Response);
        }

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

            //load
            ((BinRota)this.Master).SetPageDesc("Bölge Güncelleme");
            btnDelete.Visible = true;
            DataTable dtSubject = BINROTA.BUS.Subjects.GetSubjectRegion(SubjectID);

            if (dtSubject.Rows.Count > 0)
            {
                BindSubject(dtSubject);
            }
            else
            {
                Common.GotoDefaultPage(this.Response);
            }
        }
        else if (SaveMode == Enumerations.SaveMode.Insert)
        {
            ((BinRota)this.Master).SetPageDesc("Bölge Ekleme");
            SelectDrpValues(Request.QueryString["SubjectID"].ToString());
        }


    }

    private void BindSubject(DataTable dtSubject)
    {
        txtName.Text = dtSubject.Rows[0]["Name"].ToString();
        txtDescription.Text = dtSubject.Rows[0]["Description"].ToString();
        txtPhotoCaption.Text = dtSubject.Rows[0]["PhotoCaption"].ToString();

        SelectDrpValues(dtSubject.Rows[0]["ParentSubjectID"].ToString());
    }

    private void SelectDrpValues(string ParentSubjectID)
    {
        DataTable dtSubject;
        drpCountry.SelectedValue = ParentSubjectID;

        dtSubject = BINROTA.BUS.Subjects.GetSubject(int.Parse(ParentSubjectID));//country

        drpContinents.SelectedValue = dtSubject.Rows[0]["ParentSubjectID"].ToString();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.SaveMode == Enumerations.SaveMode.Update)
        {
            if (UctrlImageUpload1.FileName == "")
            {
                BINROTA.BUS.Subjects.SubjectsCityUpdate(SubjectID, txtName.Text, txtDescription.Text, txtPhotoCaption.Text, int.Parse(drpCountry.SelectedValue), SessRoot.UserID);
            }
            else
            {
                BINROTA.BUS.Subjects.SubjectsCityUpdate(SubjectID, txtName.Text, txtDescription.Text, UctrlImageUpload1.SendFile(Enumerations.SubjectType.Bolge.ToString() + "\\" + txtName.Text), txtPhotoCaption.Text, int.Parse(drpCountry.SelectedValue), SessRoot.UserID);
            }


            lbMessage.Text = "Bölge güncellenmiþtir";
        }
        else if (this.SaveMode == Enumerations.SaveMode.Insert)
        {
            Enumerations.SubjectInsertResult Result;
            Result = BINROTA.BUS.Subjects.SubjectsInsertRegion(txtName.Text, txtDescription.Text, UctrlImageUpload1.SendFile(Enumerations.SubjectType.Bolge.ToString() + "\\" + txtName.Text), txtPhotoCaption.Text, int.Parse(drpCountry.SelectedValue), (int)Enumerations.SubjectType.Bolge, DateTime.Now, SessRoot.UserID);
            if (Result == Enumerations.SubjectInsertResult.Success)
            {
                lbMessage.Text = "Bölge eklenmiþtir";
            }
            else if (Result == Enumerations.SubjectInsertResult.AlreadyExist)
            {
                lbMessage.Text = "Bu isimde bir bölge daha önceden eklenmiþtir";
            }
            else if (Result == Enumerations.SubjectInsertResult.Failure)
            {
                lbMessage.Text = "Bölge eklerken bir hata oluþtu. Lütfen tekrar deneyin";
            }
        }
        else
        {
            Common.GotoDefaultPage(this.Response);
        }
    }
    protected void drpContinents_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLHelper.BindDDL(ref drpCountry, BINROTA.BUS.Subjects.GetSubjectBySubjectID(int.Parse(drpContinents.SelectedValue), (int)Enumerations.SubjectType.Ulke), "Name", "SubjectID", "");
    }
    protected void btnMainPage_Click(object sender, EventArgs e)
    {
        Common.GotoDefaultPage(this.Response);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        BINROTA.BUS.Subjects.SubjectsDelete(SubjectID);
    }
}
