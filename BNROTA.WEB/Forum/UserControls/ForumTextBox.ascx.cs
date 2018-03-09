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

public partial class Forum_UserControls_ForumTextBox : System.Web.UI.UserControl
{
    public string Text
    {
        get { return Request.Form[FreeTextBox1.ClientID]; }
        set { FreeTextBox1.Text = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
