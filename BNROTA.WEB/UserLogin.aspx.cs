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

public partial class UserLogin : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UctrlLogin1.myLoginType = Enumerations.LoginType.User;
    }
}
