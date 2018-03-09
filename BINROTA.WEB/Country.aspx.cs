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

public partial class Country : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (SessRoot != null)
            {
                if (SessRoot.LoginType == (int)Enumerations.LoginType.User)
                {
                    btnAddCity.Visible = true;
                    btnUpdate.Visible = true;
                }
            }
            DataTable dt = new DataTable();

            if (Request.QueryString["SubjectID"] == null) Common.GotoDefaultPage(this.Response);

            dt = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(Request.QueryString["SubjectID"]));

            if (dt.Rows.Count <= 0) Common.GotoDefaultPage(this.Response);

            if (int.Parse(dt.Rows[0]["SubjectTypeID"].ToString()) == (int)Enumerations.SubjectType.Bolge)
            {
                drpRegion.Visible = true;
                CARETTA.COM.DDLHelper.BindDDL(ref drpRegion, BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(Request.QueryString["SubjectID"])), "Name", "SubjectID", "");
                drpRegion.DataBind();
                rptCities.DataSource = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(drpRegion.SelectedValue.ToString()));
                rptCities.DataBind();
                if (SessRoot.LoginType == (int)Enumerations.LoginType.User)
                {

                    btnAddRegion.Visible = true;
                }
            }
            else
            {
                rptCities.DataSource = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(Request.QueryString["SubjectID"]));
                rptCities.DataBind();
            }


            dt = BINROTA.BUS.SubjectCustomization.GetSubjectCustomization(int.Parse(Request.QueryString["SubjectID"]));

            if (dt.Rows.Count <= 0) Common.GotoDefaultPage(this.Response);

            txtArea.Text = dt.Rows[0]["Area"].ToString();
            txtAreaCode.Text = dt.Rows[0]["AreaCode"].ToString();
            txtCapital.Text = dt.Rows[0]["Capital"].ToString();
            txtCurrency.Text = dt.Rows[0]["Currency"].ToString();
            txtLanguage.Text = dt.Rows[0]["Language"].ToString();
            txtLocation.Text = dt.Rows[0]["Language"].ToString();
            txtNeighbourhood.Text = dt.Rows[0]["Neighbourhood"].ToString();
            txtPopulation.Text = dt.Rows[0]["Population"].ToString();
            txtReligion.Text = dt.Rows[0]["Religion"].ToString();
            txtTimeZone.Text = dt.Rows[0]["TimeZone"].ToString();
            lbName.Text = dt.Rows[0]["Name"].ToString();
            txtDescription.Text = dt.Rows[0]["Description"].ToString();

        }
    }
    protected void btnAddCity_Click(object sender, EventArgs e)
    {
        if (drpRegion.Visible == true) {
         Response.Redirect("AddCity.aspx?SaveMode=" + (int)Enumerations.SaveMode.Insert + "&SubjectID=" + drpRegion.SelectedValue.ToString());
        }
        else { Response.Redirect("AddCity.aspx?SaveMode=" + (int)Enumerations.SaveMode.Insert + "&SubjectID=" + Request.QueryString["SubjectID"].ToString());
        } 
        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCountry.aspx?SaveMode=" + (int)Enumerations.SaveMode.Update + "&SubjectID=" + int.Parse(Request.QueryString["SubjectID"]).ToString());

    }
    protected void drpRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        rptCities.DataSource = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(drpRegion.SelectedValue.ToString()));
        rptCities.DataBind();
    }
    protected void btnAddRegion_Click(object sender, EventArgs e)
    {
         Response.Redirect("AddRegion.aspx?SaveMode=" + (int)Enumerations.SaveMode.Insert + "&SubjectID=" + int.Parse(Request.QueryString["SubjectID"].ToString()));
    }
    protected void btnUpdateRegion_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddRegion.aspx?SaveMode=" + (int)Enumerations.SaveMode.Update + "&SubjectID=" + int.Parse(drpRegion.SelectedValue));
    }
}
