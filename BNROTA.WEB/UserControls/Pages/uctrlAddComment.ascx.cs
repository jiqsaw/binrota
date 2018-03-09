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

public partial class UserControls_Pages_uctrlAddComment : BaseUserControl
{
    public int PageID
    {
        get { return (ViewState["pID"] == null ? -1 : int.Parse(ViewState["pID"].ToString())); }
        set { ViewState["pID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (CARETTA.COM.Util.IsNumeric(Request.QueryString["PageID"]) && SessRoot != null)
            {
                this.PageID = int.Parse(Request.QueryString["PageID"]);
            }
            else
            {
                Response.Write("<script language='javascript'> { window.close();}</script>");
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataTable dt = BINROTA.BUS.Pages.GetPageForExistanceControl(this.PageID);
        if (dt.Rows.Count > 0)
        {
            BINROTA.BUS.PageComments.PageCommnetInsert(SessRoot.UserID, this.PageID, txtComment.Text, 0, (int)Enumerations.PageCommentStatus.WaitingApproved);
            Response.Write("<script>window.opener.location.reload()</script>");
            Response.Redirect("Result.aspx?Message=Yorumunuz eklenmiþtir. Teþekkür ederiz.");

        }
    }
}
