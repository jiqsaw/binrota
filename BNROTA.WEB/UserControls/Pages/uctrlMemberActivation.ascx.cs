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

public partial class UserControls_Pages_uctrlMemberActivation : BaseUserControl
{
    public string ActivationKey
    {
        get
        {
            return ViewState["AcK"].ToString();
        }
        set
        {
            ViewState["AcK"] = value;
        }
    }

    public string MemberID
    {
        get
        {
            return ViewState["mID"].ToString();
        }
        set
        {
            ViewState["mID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ActivationKey"] != null && Request.QueryString["MemberID"] != null)
            {
                this.ActivationKey = Request.QueryString["ActivationKey"];
                this.MemberID = Request.QueryString["MemberID"];
                if (BINROTA.BUS.Members.ActivateMember(this.ActivationKey, int.Parse(this.MemberID)))
                {
                    lbMessage.Text = "Hesab�n�z aktif hale getirilmi�tir. Anasayfaya d�n�p kullan�c� ad� ve �ifrenizi yazarak giri� yapabiliriniz";
                }
                else
                {
                    lbMessage.Text = "Hesab�n�z aktive edilememi�tir.";
                }
            }
        }
    }
}
