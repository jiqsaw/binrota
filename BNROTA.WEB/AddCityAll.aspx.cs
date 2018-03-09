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

public partial class AddCityAll : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (SessRoot == null) Common.GotoDefaultPage(this.Response);
            FillSubjects();
        }
    }

    private void FillSubjects()
    {
        if ((Request.QueryString["SubjectID"] != null) && (CARETTA.COM.Util.IsNumeric(Request.QueryString["SubjectID"])))
        {
        }
        else
        {
            Common.GotoDefaultPage(this.Response);
        }
        DDLHelper.BindDDL(ref drpContinents, BINROTA.BUS.Subjects.GetSubjectForDDL((int)Enumerations.SubjectType.Kita), "Name", "SubjectID", "");
        DDLHelper.BindDDL(ref drpCountry, BINROTA.BUS.Subjects.GetSubjectForDDL((int)Enumerations.SubjectType.Ulke), "Name", "SubjectID", "");
        DataTable dt = BINROTA.BUS.Subjects.GetParentSubjectBySubjectID(int.Parse(Request.QueryString["SubjectID"]));
        if (dt.Rows.Count > 0)
        {
            drpContinents.SelectedValue = dt.Rows[0]["SubjectID"].ToString();
            drpCountry.SelectedValue = Request.QueryString["SubjectID"];
        }
    }

    protected void drpContinents_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLHelper.BindDDL(ref drpCountry, BINROTA.BUS.Subjects.GetSubjectBySubjectID(int.Parse(drpContinents.SelectedValue), (int)Enumerations.SubjectType.Ulke), "Name", "SubjectID", "");
    }
    protected void btnAddAllCities_Click(object sender, EventArgs e)
    {
        char[] sep = {'\r', '\n'};
        string[] arrNames = txtName.Text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < arrNames.Length; i++)
        {
            string SubjectName = arrNames.GetValue(i).ToString();
            if (SubjectName.Length > 1)
            {
                BINROTA.BUS.Subjects.SubjectsInsertCity(SubjectName, "...", "", "", int.Parse(drpCountry.SelectedValue), (int)Enumerations.SubjectType.Sehir, DateTime.Now, SessRoot.UserID);
            }
        }
        lbMessage.Text = "Þehirler Eklenmiþtir";
    }
}
