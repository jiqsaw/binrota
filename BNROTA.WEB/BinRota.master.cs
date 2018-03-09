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

public partial class BinRota : MasterPage
{
    public SessionRoot SessRoot
    {
        get
        {
            return (SessionRoot)Session["SessionRoot"];
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbLogout.Visible = true;
            hlUserLogin.Visible = true;
            hlMemberLogin.Visible = true;
            hlRegister.Visible = true;

            if (SessRoot == null)
                lbLogout.Visible = false;
            else
            {
                if (SessRoot.LoginType == (int)Enumerations.LoginType.Member || SessRoot.LoginType == (int)Enumerations.LoginType.User)
                {
                    hlMemberLogin.Visible = false;
                    hlUserLogin.Visible = false;
                    hlRegister.Visible = false;
                }
            }
        }

        //CheckPagePerm();

    }
    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Common.GotoDefaultPage(this.Response); 
    }
    public void SetPageDesc(string Desc)
    {
        lblPageDesc.Text = Desc;  
    }
    
}
