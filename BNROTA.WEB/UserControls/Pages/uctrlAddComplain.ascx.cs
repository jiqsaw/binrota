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
using System.Net.Mail;

public partial class UserControls_Pages_uctrlAddComplain : BaseUserControl
{
    public int PageID
    {
        get { return (ViewState["PID"] == null ? -1 : int.Parse(ViewState["PID"].ToString())); }
        set { ViewState["PID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(CARETTA.COM.Util.IsNumeric(Request.QueryString["PageID"]))
            {
                this.PageID = int.Parse(Request.QueryString["PageID"]);
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string msgHeader = "";
        try
        {
            BINROTA.BUS.Mail myMail = new BINROTA.BUS.Mail();
            myMail.AddToList(ConfigurationManager.AppSettings["SMTPToAddress"].ToString());

            string subject = SessRoot.NickName.ToString() + " adlý kullanýcýdan þikayet maili";

            DataTable dt = BINROTA.BUS.Pages.GetPageForExistanceControl(this.PageID);
            if (dt.Rows.Count > 0)
            {
                DataTable dtMember = BINROTA.BUS.Members.GetMemberDetailsByMemberID(System.Convert.ToInt32(dt.Rows[0]["MemberID"]));
                if (dtMember.Rows.Count > 0)
                {
                    //myMail.From = new MailAddress(dtMember.Rows[0]["Email"].ToString(), SessRoot.FullName);
                    msgHeader = msgHeader + "<p>";
                    msgHeader = msgHeader + dtMember.Rows[0]["NickName"].ToString() + " kullanýcýsýnýn ";
                    msgHeader = msgHeader + dt.Rows[0]["Title"].ToString() + " baþlýklý sayfasýndan þikayet maili";
                    msgHeader = msgHeader + "</p><br/><br/>";
                }
            }

            string msgBody = msgHeader + txtMessage.Text;

            myMail.SendEmail(subject, subject, msgBody);

            lbMessage.Text = "Þikayet mailiniz gönderilmiþtir";
            pnlForm.Visible = false;
            pnlMessage.Visible = true;

        }
        catch (Exception)
        {
            lbMessage.Text = "Þikayet mailiniz gönderilirken bir hata oluþmuþtur. Lütfen tekrar deneyin.";
            pnlForm.Visible = false;
            pnlMessage.Visible = true;
        }
    }
}
