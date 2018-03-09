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

public partial class UserControls_Common_uctrlMemberPersonelPage : BaseUserControl
{
    public int PageID
    {
        get
        {
            return int.Parse(ViewState["pID"].ToString());
        }
        set
        {
            ViewState["pID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (SessRoot == null) Common.GotoDefaultPage(this.Response);
            FillDetails();
        }
    }

    private void FillDetails()
    {
        DataTable dt = BINROTA.BUS.Pages.MemberHomePageLoad(SessRoot.UserID);
        if (dt.Rows.Count > 0)
        {
            ftbPageContent.Text = dt.Rows[0]["PageContent"].ToString();
            this.PageID = int.Parse(dt.Rows[0]["PageID"].ToString());
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            BINROTA.BUS.Pages.MemberHomePageUpdate(SessRoot.UserID, ftbPageContent.Text);
            //lbMessage.Text = "Yazýnýz Güncellenmiþtir";
            //pnlContent.Visible = false;
            //pnlMessage.Visible = true;
            Response.Write("<script>window.opener.location.reload()</script>");
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }
        catch (Exception)
        {
            //lbMessage.Text = "Yazý Güncellenirken bir hata oluþmuþtur";
            throw;
        }

    }
}
