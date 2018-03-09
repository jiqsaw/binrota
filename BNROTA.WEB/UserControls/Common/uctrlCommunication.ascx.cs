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

public partial class UserControls_Common_uctrlCommunication : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SendEmail();
    }

    private void SendEmail()
    {
        try
        {
            BINROTA.BUS.Mail myMail = new BINROTA.BUS.Mail();
            myMail.From = new MailAddress(txtEmail.Text, txtFullName.Text);
            myMail.AddToList(ConfigurationManager.AppSettings["SMTPToAddress"].ToString());


            string subject = "Binrota Ýletiþim";
            string msgBody =  txtMessage.Text;

            myMail.SendEmail(subject, subject, msgBody);

            ltrEmailSuccess.Text = "Ýletiþim mailiniz gönderilmiþtir";
            pnlForm.Visible = false;
            pnlEmailSuccess.Visible = true;

        }
        catch (Exception)
        {
            ltrEmailSuccess.Text = "Ýletiþim maili gönderilirken bir hata oluþmuþtur. Lütfen tekrar deneyin.";
            pnlForm.Visible = false;
            pnlEmailSuccess.Visible = true;
            throw;
        }

    }
    
}
