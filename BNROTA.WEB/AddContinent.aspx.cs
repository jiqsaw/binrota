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

public partial class AddContinent : BasePage
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
            ((BinRota)this.Master).SetPageDesc("Kýta Güncelleme");
            if ((Request.QueryString["SubjectID"] != null) && (CARETTA.COM.Util.IsNumeric(Request.QueryString["SubjectID"])))
            {
                SubjectID = (int.Parse(Request.QueryString["SubjectID"].ToString()));
            }
            else
            {
                Common.GotoDefaultPage(this.Response);
            }

            DataTable dtSubject = BINROTA.BUS.Subjects.GetSubjectCity(SubjectID);
            btnDelete.Visible = true;
            if (dtSubject.Rows.Count > 0)
            {
                txtName.Text = dtSubject.Rows[0]["Name"].ToString();
                txtDescription.Text = dtSubject.Rows[0]["Description"].ToString();
                txtPhotoCaption.Text = dtSubject.Rows[0]["PhotoCaption"].ToString();
            }
            else
            {
                Common.GotoDefaultPage(this.Response);
            }
        }
        else
        {
            ((BinRota)this.Master).SetPageDesc("Kýta Ekleme");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.SaveMode == Enumerations.SaveMode.Update)
        {
            if (UctrlImageUpload1.FileName == "")
            {
                BINROTA.BUS.Subjects.SubjectsUpdate(SubjectID, txtName.Text, txtDescription.Text, txtPhotoCaption.Text, SessRoot.UserID);
            }
            else
            {
                BINROTA.BUS.Subjects.SubjectsUpdate(SubjectID, txtName.Text, txtDescription.Text, UctrlImageUpload1.SendFile(Enumerations.SubjectType.Kita.ToString() + "\\" + txtName.Text), txtPhotoCaption.Text, SessRoot.UserID);


            }
            lbMessage.Text = "Kýta güncellenmiþtir";
        }
        else if (this.SaveMode == Enumerations.SaveMode.Insert)
        {
            Enumerations.SubjectInsertResult Result;
            Result = BINROTA.BUS.Subjects.SubjectsInsertContinent(txtName.Text, txtDescription.Text, UctrlImageUpload1.SendFile(Enumerations.SubjectType.Kita.ToString() + "\\" + txtName.Text), txtPhotoCaption.Text, (int)Enumerations.SubjectType.Kita, DateTime.Now, SessRoot.UserID);
            if (Result == Enumerations.SubjectInsertResult.Success)
            {
                lbMessage.Text = "Kýta eklenmiþtir";
            }
            else if (Result == Enumerations.SubjectInsertResult.AlreadyExist)
            {
                lbMessage.Text = "Bu isimde bir kýta zaten var";
            }
            else if (Result == Enumerations.SubjectInsertResult.Failure)
            {
                lbMessage.Text = "Kýta eklerken bir hata oluþtu. Lütfen tekrar deneyin";
            }
        }
        else
        {
            Common.GotoDefaultPage(this.Response);
        }
    }
    protected void btnMainPage_Click(object sender, EventArgs e)
    {
        Common.GotoDefaultPage(this.Response);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        BINROTA.BUS.Subjects.SubjectsDelete(SubjectID);
        // Bunu bilerek "Common.GotoDefaultPage(this.Response)" yapmadým
        Response.Redirect("MainPage.aspx");
    }
}
