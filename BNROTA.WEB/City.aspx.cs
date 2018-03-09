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

public partial class City : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            if (Request.QueryString["SubjectID"] != null)
            {
                ((BinRota)this.Master).SetPageDesc("Þehir Bilgileri");
                dt = BINROTA.BUS.Subjects.GetSubject(int.Parse(Request.QueryString["SubjectID"].ToString()));
                if (SessRoot != null)
                    if (SessRoot.LoginType == (int)Enumerations.LoginType.User)
                    {
                        btnUpdate.Visible = true;
                    }
                    else if (SessRoot.LoginType == (int)Enumerations.LoginType.Member)
                    {
                        hpAddDetail.Visible = true;
                    }

                if (dt.Rows.Count > 0)
                {
                    hpAddDetail.NavigateUrl = "MemberPage.aspx?" + "SubjectID=" + dt.Rows[0]["SubjectID"];
                    lbName.Text = dt.Rows[0]["Name"].ToString();
                    txtDescription.Text = dt.Rows[0]["Description"].ToString();
                    if (dt.Rows[0]["PhotoPath"].ToString() == "")
                    {
                        imgCity.ImageUrl = "~/Images/Design/NoPictureForSubject.png";
                        imgCity.BorderStyle = BorderStyle.None;
                    }
                    else
                    {
                        imgCity.ImageUrl = Common.ReturnImagePath(dt.Rows[0]["PhotoPath"].ToString(), ConfigurationManager.AppSettings["SubjectImagesUrl"].ToString());
                    }
                }
                else
                    Common.GotoDefaultPage(this.Response);
            }
            else
                Common.GotoDefaultPage(this.Response);

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCity.aspx?SaveMode=" + (int)Enumerations.SaveMode.Update + "&SubjectID=" + int.Parse(Request.QueryString["SubjectID"]).ToString());
    }
}
