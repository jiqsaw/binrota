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
        if (!IsPostBack)
        {
            ModeControl();
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
            
            if ((Request.QueryString["SubjectID"] != null) && (CARETTA.COM.Util.IsNumeric(Request.QueryString["SubjectID"])))
            {
                SubjectID = (int.Parse(Request.QueryString["SubjectID"].ToString()));
            }
            else
            {
                Common.GotoDefaultPage(this.Response);
            }

            DataTable dtSubject = BINROTA.BUS.Subjects.GetSubjectCity(SubjectID);

            if (dtSubject.Rows.Count > 0)
            {
                txtName.Text = dtSubject.Rows[0]["Name"].ToString();
                txtDescription.Text = dtSubject.Rows[0]["Description"].ToString();
                txtPhotoCaption.Text = dtSubject.Rows[0]["PhotoCaption"].ToString();
                txtPhotoPath.Text = dtSubject.Rows[0]["PhotoPath"].ToString();
            }
            else
            {
                Common.GotoDefaultPage(this.Response);
            }
        }
        else
        {
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.SaveMode == Enumerations.SaveMode.Update)
        {
            BINROTA.BUS.Subjects.SubjectsUpdate(SubjectID, txtName.Text, txtDescription.Text, txtPhotoPath.Text, txtPhotoCaption.Text);
            lbMessage.Text = "Kýta güncellenmiþtir";
        }
        else if (this.SaveMode == Enumerations.SaveMode.Insert)
        {
            BINROTA.BUS.Subjects.SubjectsInsertContinent(txtName.Text, txtDescription.Text, txtPhotoPath.Text, txtPhotoCaption.Text, (int)Enumerations.SubjectType.Kita, DateTime.Now, 1);
            lbMessage.Text = "Kýta eklenmiþtir";
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
}
