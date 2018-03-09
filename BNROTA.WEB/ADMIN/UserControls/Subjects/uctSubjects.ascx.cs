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

public partial class ADMIN_UserControls_Subjects_uctSubjects : System.Web.UI.UserControl
{
    #region Properties 
    public Enumerations.SaveMode SaveMode
    {
        get
        {
            return (ViewState["SMO"] == null ? Enumerations.SaveMode.Insert :  ((Enumerations.SaveMode)ViewState["SMO"]));
        }
        set
        {
            ViewState["SMO"] = value;
        }
    }

    public Enumerations.SubjectType SubjectType
    {
        get
        {
            return (ViewState["STY"] == null ? Enumerations.SubjectType.Kita : (Enumerations.SubjectType)ViewState["STY"]);
        }
        set
        {
            ViewState["STY"] = value;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DDLHelper.BindDDL(ref drpContinents, BINROTA.BUS.Subjects.GetSubjectForDDL((int)Enumerations.SubjectType.Kita), "Name", "SubjectID", "");
            imgSubjectPhoto.Attributes.Add("onerror", "this.src='Images/NoPictureForSubject.png';");
            UctrlImageUpload1.UploadType = Enumerations.FileUploadType.SubjectImages;
            ((Button)UctrlImageUpload1.FindControl("btnSend")).Visible = false;
            FillSubjectTree();
        }
    }

    private void FillSubjectTree()
    {
        tvSubjects.Nodes.Clear();
        tvSubjects.Nodes.Add(new TreeNode("Mekanlar", "0"));
        PopulateTreeView(tvSubjects.Nodes[0], 0);
    }

    //void PopulateTreeView(TreeNode tn, int ParentSubjectID)
    //{
    //    DataTable dt = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(ParentSubjectID);
    //    TreeNode objTreeNode;
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        objTreeNode = new TreeNode(dr["Name"].ToString(), dr["SubjectID"].ToString());
    //        tn.ChildNodes.Add(objTreeNode);
    //        if (Convert.ToInt32(dr["SubjectTypeID"]) != (int)Enumerations.SubjectType.Sehir)
    //        {
    //            PopulateTreeView(objTreeNode, int.Parse(dr["SubjectID"].ToString()));
    //        }

    //    }
    //}

    private void PopulateTreeView(TreeNode tn, int ParentSubjectID)
    {
        DataTable dt = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(ParentSubjectID);
        TreeNode objTreeNode;
        foreach (DataRow dr in dt.Rows)
        {
            objTreeNode = new TreeNode(dr["Name"].ToString(), dr["SubjectID"].ToString());
            objTreeNode.SelectAction = TreeNodeSelectAction.SelectExpand;
            tn.ChildNodes.Add(objTreeNode);
        }
    }

    private void FillSubjectDetails()
    {
        DataTable dt = BINROTA.BUS.Subjects.GetSubject(int.Parse(tvSubjects.SelectedNode.Value));
        if (dt.Rows.Count > 0)
        {
            if (Convert.ToInt32(dt.Rows[0]["SubjectTypeID"]) == (int)Enumerations.SubjectType.Ulke)
            {
                DataTable dtSubject = BINROTA.BUS.SubjectCustomization.GetSubjectCustomization(Convert.ToInt32(dt.Rows[0]["SubjectID"]));
                txtArea.Text = dtSubject.Rows[0]["Area"].ToString();
                txtAreaCode.Text = dtSubject.Rows[0]["AreaCode"].ToString();
                txtCapital.Text = dtSubject.Rows[0]["Capital"].ToString();
                txtCurrency.Text = dtSubject.Rows[0]["Currency"].ToString();
                txtLanguage.Text = dtSubject.Rows[0]["Language"].ToString();
                txtLocation.Text = dtSubject.Rows[0]["Location"].ToString();
                txtNeighbourhood.Text = dtSubject.Rows[0]["Neighbourhood"].ToString();
                txtPopulation.Text = dtSubject.Rows[0]["Population"].ToString();
                txtReligion.Text = dtSubject.Rows[0]["Religion"].ToString();
                txtTimeZone.Text = dtSubject.Rows[0]["TimeZone"].ToString();
                pnlCountry.Visible = true;
            }
            else
            {
                pnlCountry.Visible = false;
            }
            imgSubjectPhoto.ImageUrl = Common.ReturnImagePath(dt.Rows[0]["PhotoPath"].ToString(), ConfigurationManager.AppSettings["SubjectImagesUrl"].ToString());
            txtDescription.Text = dt.Rows[0]["Description"].ToString();
            txtName.Text = dt.Rows[0]["Name"].ToString();
            txtPhotoCaption.Text = dt.Rows[0]["PhotoCaption"].ToString();
        }
        ArrangeDropDowns(Convert.ToInt32(dt.Rows[0]["ParentSubjectID"]), (Enumerations.SubjectType)dt.Rows[0]["SubjectTypeID"]);
    }

    private void ArrangeDropDowns(int ParentSubjectID, Enumerations.SubjectType SubjectTypeID)
    {
        switch (SubjectTypeID)
        {
            case Enumerations.SubjectType.Kita:
                drpContinents.Visible = false;
                drpCountries.Visible = false;
                break;
            case Enumerations.SubjectType.Ulke:
                drpContinents.SelectedValue = ParentSubjectID.ToString();
                drpContinents.Visible = true;
                break;
            case Enumerations.SubjectType.Sehir:
                DataTable dt = BINROTA.BUS.Subjects.GetParentSubjectBySubjectID(ParentSubjectID);
                if (dt.Rows.Count > 0)
                {
                    drpContinents.SelectedValue = dt.Rows[0]["SubjectID"].ToString();
                }
                DDLHelper.BindDDL(ref drpCountries, BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(Convert.ToInt32(dt.Rows[0]["SubjectID"])), "Name", "SubjectID", "");
                drpCountries.SelectedValue = ParentSubjectID.ToString();
                drpContinents.Visible = true;
                drpCountries.Visible = true;
                break;
        }
    }

    protected void tvSubjects_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (tvSubjects.SelectedNode.Value != "0")
        {
            if (tvSubjects.SelectedNode.ChildNodes.Count == 0)
            {
                PopulateTreeView(tvSubjects.SelectedNode, int.Parse(tvSubjects.SelectedNode.Value));
            }
            FillSubjectDetails();
            DataTable dt = BINROTA.BUS.Subjects.GetSubject(int.Parse(tvSubjects.SelectedNode.Value));
            this.SubjectType = (Enumerations.SubjectType)dt.Rows[0]["SubjectTypeID"];
            this.SaveMode = Enumerations.SaveMode.Update;
        }
        lbMessage.Text = "";
    }
    protected void drpContinents_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLHelper.BindDDL(ref drpCountries, BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(drpContinents.SelectedValue)), "Name", "SubjectID", "");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int SubjectID = int.Parse(tvSubjects.SelectedNode.Value);
        switch (this.SubjectType)
        {
            case Enumerations.SubjectType.Kita:
                if (this.SaveMode == Enumerations.SaveMode.Update)
                {
                    if (UctrlImageUpload1.FileName == "")
                    {
                        BINROTA.BUS.Subjects.SubjectsUpdate(SubjectID, txtName.Text, txtDescription.Text, txtPhotoCaption.Text, 5);
                    }
                    else
                    {
                        BINROTA.BUS.Subjects.SubjectsUpdate(SubjectID, txtName.Text, txtDescription.Text, UctrlImageUpload1.SendFile(Enumerations.SubjectType.Kita.ToString() + "//" + txtName.Text), txtPhotoCaption.Text, 5);


                    }
                    lbMessage.Text = "Kýta güncellenmiþtir";
                }
                else if (this.SaveMode == Enumerations.SaveMode.Insert)
                {
                    Enumerations.SubjectInsertResult Result;
                    Result = BINROTA.BUS.Subjects.SubjectsInsertContinent(txtName.Text, txtDescription.Text, UctrlImageUpload1.SendFile(Enumerations.SubjectType.Kita.ToString() + "//" + txtName.Text), txtPhotoCaption.Text, (int)Enumerations.SubjectType.Kita, DateTime.Now, 5);
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
                break;
            case Enumerations.SubjectType.Ulke:
                if (this.SaveMode == Enumerations.SaveMode.Update)
                {
                    if (UctrlImageUpload1.FileName == "")
                    {
                        BINROTA.BUS.Subjects.SubjectsCountryUpdate(SubjectID, txtName.Text, txtDescription.Text, txtPhotoCaption.Text, 5, txtLocation.Text, txtCapital.Text, txtArea.Text, txtNeighbourhood.Text, txtPopulation.Text, txtCurrency.Text, txtAreaCode.Text, txtTimeZone.Text, txtLanguage.Text, txtReligion.Text, int.Parse(drpContinents.SelectedValue));
                    }
                    else
                    {
                        UctrlImageUpload1.UploadType = Enumerations.FileUploadType.SubjectImages;
                        BINROTA.BUS.Subjects.SubjectsCountryUpdate(SubjectID, txtName.Text, txtDescription.Text, UctrlImageUpload1.SendFile(Enumerations.SubjectType.Ulke.ToString() + "//" + txtName.Text), txtPhotoCaption.Text, 5, txtLocation.Text, txtCapital.Text, txtArea.Text, txtNeighbourhood.Text, txtPopulation.Text, txtCurrency.Text, txtAreaCode.Text, txtTimeZone.Text, txtLanguage.Text, txtReligion.Text, int.Parse(drpContinents.SelectedValue));
                    }

                    lbMessage.Text = "Ülke güncellenmiþtir";
                }
                else if (this.SaveMode == Enumerations.SaveMode.Insert)
                {
                    Enumerations.SubjectInsertResult Result;
                    Result = BINROTA.BUS.Subjects.SubjectsInsertCountry(txtName.Text, txtDescription.Text, UctrlImageUpload1.SendFile(Enumerations.SubjectType.Ulke.ToString() + "//" + txtName.Text), txtPhotoCaption.Text, int.Parse(drpContinents.SelectedValue), (int)Enumerations.SubjectType.Ulke, DateTime.Now, 5, txtLocation.Text, txtCapital.Text, txtArea.Text, txtNeighbourhood.Text, txtPopulation.Text, txtCurrency.Text, txtAreaCode.Text, txtTimeZone.Text, txtLanguage.Text, txtReligion.Text);
                    if (Result == Enumerations.SubjectInsertResult.Success)
                    {
                        lbMessage.Text = "Ülke eklenmiþtir";
                    }
                    else if (Result == Enumerations.SubjectInsertResult.AlreadyExist)
                    {
                        lbMessage.Text = "Daha önce bu isimde bir ülke eklenmiþtir";
                    }
                    else if (Result == Enumerations.SubjectInsertResult.Failure)
                    {
                        lbMessage.Text = "Ülke eklerken bir hata oluþtu. Lütfen tekrar deneyin";
                    }
                }
                else
                {
                    Common.GotoDefaultPage(this.Response);
                }
                break;
            case Enumerations.SubjectType.Sehir:
                if (this.SaveMode == Enumerations.SaveMode.Update)
                {
                    if (UctrlImageUpload1.FileName == "")
                        BINROTA.BUS.Subjects.SubjectsCityUpdate(SubjectID, txtName.Text, txtDescription.Text, txtPhotoCaption.Text, int.Parse(drpCountries.SelectedValue), 5);
                    else
                    {
                        BINROTA.BUS.Subjects.SubjectsCityUpdate(SubjectID, txtName.Text, txtDescription.Text, UctrlImageUpload1.SendFile(Enumerations.SubjectType.Sehir.ToString() + "//" + txtName.Text), txtPhotoCaption.Text, int.Parse(drpCountries.SelectedValue), 5);
                    }
                    lbMessage.Text = "Þehir güncellenmiþtir";
                }
                else if (this.SaveMode == Enumerations.SaveMode.Insert)
                {
                    Enumerations.SubjectInsertResult Result;
                    Result = BINROTA.BUS.Subjects.SubjectsInsertCity(txtName.Text, txtDescription.Text, UctrlImageUpload1.SendFile(Enumerations.SubjectType.Sehir.ToString() + "//" + txtName.Text), txtPhotoCaption.Text, int.Parse(drpCountries.SelectedValue), (int)Enumerations.SubjectType.Sehir, DateTime.Now, 5);
                    if (Result == Enumerations.SubjectInsertResult.Success)
                    {
                        lbMessage.Text = "Þehir eklenmiþtir";
                    }
                    else if (Result == Enumerations.SubjectInsertResult.AlreadyExist)
                    {
                        lbMessage.Text = "Bu isimde bir þehir daha önceden eklenmiþ.";
                    }
                    else if (Result == Enumerations.SubjectInsertResult.Failure)
                    {
                        lbMessage.Text = "Þehir eklerken bir hata oluþtu. Lütfen tekrar deneyin";
                    }
                }
                else
                {
                    Common.GotoDefaultPage(this.Response);
                }
                break;
        }
    }
}
