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

public partial class MainPage : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (SessRoot != null)
            {
                if (SessRoot.LoginType == (int)Enumerations.LoginType.User)
                {
                    btnAddContinent.Visible = true;
                }
            }
            rptMenu.DataSource = BINROTA.BUS.Subjects.GetSubjectForDDL((int)Enumerations.SubjectType.Kita);
            rptMenu.DataBind();
        }
    }
    protected void btnAddContinent_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddContinent.aspx?SaveMode=" + (int)Enumerations.SaveMode.Insert);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (SessRoot != null)
            if (SessRoot.UserID == 3)
                Response.Redirect("TryReport.aspx");

    }
}
