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
/// Summary description for BaseUserControl
/// </summary>
public class BaseUserControl : System.Web.UI.UserControl
{
    public BaseUserControl()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public SessionRoot SessRoot
    {
        get
        {
            return (SessionRoot)Session["SessionRoot"];
        }
    }
}
