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

public partial class UserControls_Pages_uctrlMemberWarning : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'> { window.close();}</script>");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegisterForm.aspx");
    }
}
