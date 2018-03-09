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

public partial class ADMIN_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        Response.Cache.SetNoStore();
        if ((Session["Online"] == null) || ((bool)Session["Online"] != true))
        {
            Response.Redirect("~/ADMIN/Default.aspx");
        }
    }

    protected void lnkLogout_Click(object sender, EventArgs e) {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("http://www.binrota.com");
    }

}
