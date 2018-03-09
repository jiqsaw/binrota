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

public partial class UserControls_uctrlLoginPage : BaseUserControl
{
    public string PageReferrer
    {
        get { return (ViewState["PageReferrer"] == null ? "" : ViewState["PageReferrer"].ToString()); }
        set { ViewState["PageReferrer"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (SessRoot != null)
            {
                BINROTA.COM.Common.GotoDefaultPage(this.Response);
            }
            else {
                this.PageReferrer = BINROTA.COM.Common.ReturnPageReferrerName();
                rdRememberList.Items[0].Value = ((int)Enumerations.RememberType.EmailAndPassword).ToString();
                rdRememberList.Items[1].Value = ((int)Enumerations.RememberType.Email).ToString();
                rdRememberList.Items[2].Value = ((int)Enumerations.RememberType.NoRemember).ToString();
                rdRememberList.Items[2].Selected = true;
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataTable dt = BINROTA.BUS.Members.GetMemberInfoForLogin(txtUserName.Text, CARETTA.COM.Encryption.Encrypt(txtPassword.Text.Trim()));
        if (dt.Rows.Count > 0)
        {
            SessionRoot objSession = new SessionRoot(int.Parse(dt.Rows[0]["MemberID"].ToString()));
            objSession.FullName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
            objSession.NickName = dt.Rows[0]["NickName"].ToString();
            objSession.LoginType = (int)Enumerations.LoginType.Member;
            Session.Add("SessionRoot", objSession);
            WriteLoginCookie();
            Response.Redirect(this.PageReferrer);
        }
        else
        {
            dt = BINROTA.BUS.Users.GetUserInfoForLogin(txtUserName.Text, CARETTA.COM.Encryption.Encrypt(txtPassword.Text.Trim()));
            if (dt.Rows.Count > 0)
            {
                SessionRoot objSession = new SessionRoot(int.Parse(dt.Rows[0]["UserID"].ToString()));
                objSession.FullName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                objSession.NickName = dt.Rows[0]["NickName"].ToString();
                objSession.LoginType = (int)Enumerations.LoginType.User;
                WriteLoginCookie();
                Response.Redirect(this.PageReferrer);
            }
        }
    }

    private void WriteLoginCookie()
    {
        string strLoginCookieName;
        int intLoginCookieTimeout;

        strLoginCookieName = System.Configuration.ConfigurationManager.AppSettings["LoginCookieName"];
        intLoginCookieTimeout = int.Parse(System.Configuration.ConfigurationManager.AppSettings["LoginCookieTimeoutInMinutes"].ToString());

        if ((Request != null))
        {
            if (((Request.Cookies[strLoginCookieName] != null)))
            {
                Response.Cookies.Set(Request.Cookies[strLoginCookieName]);
            }
            else
            {
                Response.Cookies.Set(new HttpCookie(strLoginCookieName));
            }

            Response.Cookies[strLoginCookieName]["UserID"] = this.SessRoot.UserID.ToString();
            Response.Cookies[strLoginCookieName]["RememberType"] = rdRememberList.SelectedValue;
            string UserName = String.Empty;
            string Password = String.Empty;
            Enumerations.RememberType enRdRememberValue = (Enumerations.RememberType)(int.Parse(rdRememberList.SelectedValue));
            if ((enRdRememberValue == Enumerations.RememberType.Email) || (enRdRememberValue == Enumerations.RememberType.EmailAndPassword)) {
                UserName =  txtUserName.Text;
            }

            if (enRdRememberValue == Enumerations.RememberType.EmailAndPassword) {
                Password = txtPassword.Text;
            }

            Response.Cookies[strLoginCookieName]["UserName"] = UserName;
            Response.Cookies[strLoginCookieName]["Password"] = Password;
            Response.Cookies[strLoginCookieName].Expires = DateTime.Now.AddMinutes(intLoginCookieTimeout);
        }
    }

    protected void Page_PreRender(object sender, EventArgs e) {
        ReadCookie();
    }

    private void ReadCookie() {

        string strLoginCookieName;
        strLoginCookieName = System.Configuration.ConfigurationManager.AppSettings["LoginCookieName"];
        if (Request.Cookies[strLoginCookieName] != null) {
            for (int i = Request.Cookies.Count - 1; i==0; i--) {
                if (Request.Cookies[i].Name == strLoginCookieName) {
                    try {
                        txtUserName.Text = Request.Cookies[i]["UserName"] == null ? "" : Request.Cookies[i]["UserName"].ToString();
                        txtPassword.Text = Request.Cookies[i]["Password"] == null ? "" : JsDiv.InnerHtml = "<script>SetPassword('" + txtPassword.ClientID + "', '" + Request.Cookies[i]["Password"].ToString() + "')</script>";
                        rdRememberList.SelectedValue = Request.Cookies[i]["RememberType"] == null ? ((int)Enumerations.RememberType.NoRemember).ToString() : Request.Cookies[i]["RememberType"].ToString();
                    } catch (Exception) {
                    }
                }
            }
        }

    }
}
