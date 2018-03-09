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

public partial class AddCity : BasePage
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
        if (!IsPostBack)
        {
            DDLHelper.BindDDL(ref drpContinents, BINROTA.BUS.Subjects.GetSubjectForDDL((int)Enumerations.SubjectType.Kita), "Name", "SubjectID", "");
            DDLHelper.BindDDL(ref drpCountry, BINROTA.BUS.Subjects.GetSubjectForDDL((int)Enumerations.SubjectType.Ulke), "Name", "SubjectID", "");
            ModeControl();
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
            FillRegions();
            DataTable dtSubject = BINROTA.BUS.Subjects.GetSubjectCity(SubjectID);

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
            FillRegions();
            SelectDrpValues(Request.QueryString["SubjectID"].ToString());
        }


    }

    private void BindSubject(DataTable dtSubject)
    {
        txtName.Text = dtSubject.Rows[0]["Name"].ToString();
        txtDescription.Text = dtSubject.Rows[0]["Description"].ToString();
        txtPhotoCaption.Text = dtSubject.Rows[0]["PhotoCaption"].ToString();
        txtPhotoPath.Text = dtSubject.Rows[0]["PhotoPath"].ToString();

        SelectDrpValues(dtSubject.Rows[0]["ParentSubjectID"].ToString());
    }

    private void SelectDrpValues(string ParentSubjectID)
    {
        DataTable dtSubject;
        if (drpRegion.Visible == true)
        {
            drpRegion.SelectedValue = ParentSubjectID;

            dtSubject = BINROTA.BUS.Subjects.GetSubject(int.Parse(ParentSubjectID));//region

            drpCountry.SelectedValue = dtSubject.Rows[0]["ParentSubjectID"].ToString();

            DDLHelper.BindDDL(ref drpRegion, BINROTA.BUS.Subjects.GetSubjectBySubjectID(int.Parse(dtSubject.Rows[0]["ParentSubjectID"].ToString()),(int)Enumerations.SubjectType.Bolge), "Name", "SubjectID", "");

            dtSubject = BINROTA.BUS.Subjects.GetSubject(int.Parse(dtSubject.Rows[0]["ParentSubjectID"].ToString()));//country

            drpContinents.SelectedValue = dtSubject.Rows[0]["ParentSubjectID"].ToString();

        }
        else
        {

            drpCountry.SelectedValue = ParentSubjectID;

            dtSubject = BINROTA.BUS.Subjects.GetSubject(int.Parse(ParentSubjectID));//country

            drpContinents.SelectedValue = dtSubject.Rows[0]["ParentSubjectID"].ToString();
        }
    }
    private void FillRegions()
    {
        DataTable dtRegions=null;
        if (SaveMode == Enumerations.SaveMode.Update)
            dtRegions = BINROTA.BUS.Subjects.GetParentSubjectBySubjectID(SubjectID);
        else if (SaveMode == Enumerations.SaveMode.Insert)
            dtRegions = BINROTA.BUS.Subjects.GetSubject(SubjectID);


        if (dtRegions.Rows.Count > 0)
            if (int.Parse(dtRegions.Rows[0]["SubjectTypeID"].ToString()) == (int)Enumerations.SubjectType.Bolge)
            {
                drpRegion.Visible = true;
            }
            else
                drpRegion.Visible = false;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.SaveMode == Enumerations.SaveMode.Update)
        {
            if (drpRegion.Visible == true) { BINROTA.BUS.Subjects.SubjectsCityUpdate(SubjectID, txtName.Text, txtDescription.Text, txtPhotoPath.Text, txtPhotoCaption.Text, int.Parse(drpRegion.SelectedValue)); }
            else
            {
                BINROTA.BUS.Subjects.SubjectsCityUpdate(SubjectID, txtName.Text, txtDescription.Text, txtPhotoPath.Text, txtPhotoCaption.Text, int.Parse(drpCountry.SelectedValue));
            }

            lbMessage.Text = "�ehir g�ncellenmi�tir";
        }
        else if (this.SaveMode == Enumerations.SaveMode.Insert)
        {
            BINROTA.BUS.Subjects.SubjectsInsertCity(txtName.Text, txtDescription.Text, txtPhotoPath.Text, txtPhotoCaption.Text, (drpRegion.Visible == true ? int.Parse(drpRegion.SelectedValue) : int.Parse(drpCountry.SelectedValue)), (int)Enumerations.SubjectType.Sehir, DateTime.Now, SessRoot.UserID);
            lbMessage.Text = "�ehir eklenmi�tir";
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
    protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillRegions();
    }
}