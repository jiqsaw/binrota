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

public partial class ADMIN_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblError.Text = "";
            tblError.Visible = false;
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

        DataTable dtUser = new DataTable();
        try
        {
            dtUser = BINROTA.BUS.Users.GetUserIDForLogin(CARETTA.COM.Util.ClearString(txtUserName.Text.Trim()), CARETTA.COM.Encryption.Encrypt(CARETTA.COM.Util.ClearString(txtPassword.Text.Trim())));
            if (dtUser.Rows.Count > 0) {
                Session["Online"] = true;
                Response.Redirect("~/ADMIN/AdminDefault.aspx");
            }
            else
            {
                tblError.Visible = true;
                lblError.Text = "Giriþ Baþarýsýz!..";
            }
        }
        catch (Exception) { }

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        txtUserName.Text = "admin";
        txtPassword.Text = "1234";
        btnLogin_Click(new object(), new EventArgs());
    }

}
