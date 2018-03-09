using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for BaseMemberPage
/// </summary>
public class BaseMemberPage : System.Web.UI.Page
{
    public BaseMemberPage()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private void Page_Init(object sender, System.EventArgs e) {
        if ((Session["UserID"]==null) || (Session["UserID"] < 1)) {
            Response.Redirect("Login.aspx");
        }
    }

    public SessionRoot SessRoot
    {
        get
        {
            return (SessionRoot)Session["SessionRoot"];
        }
    }

}
