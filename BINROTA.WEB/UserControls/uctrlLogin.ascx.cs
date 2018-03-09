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
using BINROTA.BUS;
using BINROTA.COM;


public partial class UserControls_uctrlLogin : System.Web.UI.UserControl
{
    public Enumerations.LoginType myLoginType
    {
        get
        {
            return (Enumerations.LoginType)ViewState["LT"];
        }
        set
        {
            ViewState.Add("LT", value);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlForgotPassword.NavigateUrl = hlForgotPassword.NavigateUrl + "?LoginType=" + (int)myLoginType;
        }

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        if (myLoginType == Enumerations.LoginType.Member)
        {
            dt = BINROTA.BUS.Members.GetMemberIDForLogin(txtUserName.Text, CARETTA.COM.Encryption.Encrypt(txtPassword.Text.ToString()));
            if (dt.Rows.Count == 1)
            {
                SessionRoot objSession = new SessionRoot(int.Parse(dt.Rows[0]["MemberID"].ToString()));
                objSession.FullName = dt.Rows[0]["FullName"].ToString();
                objSession.LoginType = (int)Enumerations.LoginType.Member;
                Session.Add("SessionRoot", objSession);
                Response.Redirect("MainPage.aspx");
            }
            else
            {
                lbMessage.Text = "Yanlýþ kullanýcý adý veya þifre girdiniz";
            }
        }
        else if (myLoginType == Enumerations.LoginType.User)
        {
            dt = BINROTA.BUS.Users.GetUserIDForLogin(txtUserName.Text, CARETTA.COM.Encryption.Encrypt(txtPassword.Text.ToString()));
            if (dt.Rows.Count == 1)
            {
                SessionRoot objSession = new SessionRoot(int.Parse(dt.Rows[0]["UserID"].ToString()));
                objSession.FullName = dt.Rows[0]["FullName"].ToString();
                objSession.LoginType = (int)Enumerations.LoginType.User;
                Session.Add("SessionRoot", objSession);
                Response.Redirect("MainPage.aspx");
            }
            else
            {
                lbMessage.Text = "Yanlýþ kullanýcý adý veya þifre girdiniz";
            }
        }
    }
}
