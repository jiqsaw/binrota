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

public partial class Continent : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (SessRoot != null)
            {
                if (SessRoot.LoginType == (int)Enumerations.LoginType.User)
                {
                    btnAdd.Visible = true;
                    btnUpdate.Visible = true;
                }
            }

            if (Request.QueryString["SubjectID"] != null)
            {
                ((BinRota)this.Master).SetPageDesc("Kýta Bilgileri");
                DataTable dt = new DataTable();
                rptCountries.DataSource = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(int.Parse(Request.QueryString["SubjectID"]));
                rptCountries.DataBind();
                dt = BINROTA.BUS.Subjects.GetSubject(int.Parse(Request.QueryString["SubjectID"]));

                if (dt.Rows.Count > 0)
                {
                    lbName.Text = dt.Rows[0]["Name"].ToString();
                    txtDescription.Text = dt.Rows[0]["Description"].ToString();
                }
                else
                    Common.GotoDefaultPage(this.Response);
            }
            else
                Common.GotoDefaultPage(this.Response);
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCountry.aspx?SaveMode=" + (int)Enumerations.SaveMode.Insert + "&ContinentSubjectID=" + int.Parse(Request.QueryString["SubjectID"]));
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddContinent.aspx?SaveMode=" + (int)Enumerations.SaveMode.Update + "&SubjectID=" + int.Parse(Request.QueryString["SubjectID"]).ToString());
    }
}
