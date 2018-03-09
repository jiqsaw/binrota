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

public partial class RegisterForm : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            if (BINROTA.COM.Common.ReturnPageReferrerName() != "MemberWarning.aspx") Common.GotoDefaultPage(this.Response);

    }

    public void HandleError(object sender, AsyncPostBackErrorEventArgs e)
    {
        //ScrMng1.AsyncPostBackErrorMessage = "hata";
    }
}
