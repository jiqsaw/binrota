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

public partial class UserControls_MainPage_uctrlMainHeader : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtUserName.Attributes.Add("onfocus", "if (this.value == 'Kullanýcý Adý') this.value='';");
            txtUserName.Attributes.Add("onblur", "if (this.value=='') this.value='Kullanýcý Adý';");
            txtPassword.Attributes.Add("onfocus", "if (this.value == 'Þifre') this.value='';");
            txtSearch.Attributes.Add("onfocus", "if (this.value == 'Arama') this.value='';");
            txtSearch.Attributes.Add("onblur", "if (this.value=='') this.value='Arama';");

            lbTodaysDate.Text = string.Format("{0:D}", DateTime.Today);
            if (SessRoot == null)
            {
                pnlLogin.Visible = true;
                pnlUserInfo.Visible = false;
            }
            else
            {
                ArrangeUserInfo();
            }
        }
    }

    private void ArrangeUserInfo()
    {
        pnlLogin.Visible = false;
        pnlUserInfo.Visible = true;
        lblUserName.Text = SessRoot.FullName;
    }

    protected void imbLogin_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dt = BINROTA.BUS.Members.GetMemberInfoForLogin(txtUserName.Text, CARETTA.COM.Encryption.Encrypt(txtPassword.Text.Trim()));
        if (dt.Rows.Count > 0)
        {
            if (bool.Parse(dt.Rows[0]["isActive"].ToString()))
            {
                SessionRoot objSession = new SessionRoot(int.Parse(dt.Rows[0]["MemberID"].ToString()));
                objSession.FullName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                objSession.NickName = dt.Rows[0]["NickName"].ToString();
                objSession.LoginType = (int)Enumerations.LoginType.Member;
                Session.Add("SessionRoot", objSession);
                Common.GotoDefaultPage(this.Response);
            }
            else
            { 
                Response.Write("<script language='javascript'> {window.open('Result.aspx?Message=' + 'Henüz hesabýnýz aktif edilmemiþtir. Lütfen tekrar deneyin', 'BinrotaResult', 'width=490,height=300,toolbar=no,resizable=no,scrollbars=no,');}</script>");
            }
        }
        else
        {
            dt = BINROTA.BUS.Users.GetUserInfoForLogin(txtUserName.Text, CARETTA.COM.Encryption.Encrypt(txtPassword.Text.Trim()));
            if (dt.Rows.Count > 0)
            {
                SessionRoot objSession = new SessionRoot(int.Parse(dt.Rows[0]["UserID"].ToString()));
                objSession.FullName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                objSession.NickName = objSession.FullName;
                objSession.LoginType = (int)Enumerations.LoginType.User;
                Session.Add("SessionRoot", objSession);
                Common.GotoDefaultPage(this.Response);
            }
            else 
            {
                Response.Write("<script language='javascript'> {window.open('Result.aspx?Message=' + 'Yanlýþ kullanýcý adý ya da þifre girdiniz. Lütfen tekrar deneyin', 'BinrotaResult', 'width=490,height=300,toolbar=no,resizable=no,scrollbars=no,');}</script>");
            }
        }
    }
    protected void lbLogOut_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Common.GotoDefaultPage(this.Response);
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Search.aspx?SearchText=" + txtSearch.Text);
    }
}
