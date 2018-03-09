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

public partial class UserControls_Pages_uctrlForgatPassword : BaseUserControl
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
            //Enumerations.LoginType LoginType;
            //LoginType = ((Enumerations.LoginType)int.Parse(Request.QueryString["LoginType"].ToString()));
            DataTable dt = BINROTA.BUS.Members.GetPassword(txtEmail.Text);
            
            if (dt.Rows.Count > 0)
            {
                //MailMessage objMessage = new MailMessage();
                //string smtpServer = ConfigurationManager.AppSettings["SMTPServer"].ToString();
                //string smtpUser = ConfigurationManager.AppSettings["SMTPUserName"].ToString();
                //string smtpPass = ConfigurationManager.AppSettings["SMTPPassword"].ToString();
                //objMessage.From = new MailAddress(ConfigurationManager.AppSettings["SMTPUserName"].ToString(), ConfigurationManager.AppSettings["SMTPFromAddress"].ToString());
                //objMessage.Subject = subject;
                //objMessage.Body = msgBody;
                //objMessage.IsBodyHtml = true;
                //SmtpClient smtpClient = new SmtpClient(smtpServer);
                //smtpClient.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPass);
                //smtpClient.Send(objMessage);

                BINROTA.BUS.Mail myMail = new BINROTA.BUS.Mail();

                myMail.AddToList(txtEmail.Text);
             
                string subject = "Binrota sifre hatirlatma";
                string msgBody = "<p>Sayin <b>" + dt.Rows[0]["FullName"].ToString() + "</b>,</p>"
                                 + "<p>&nbsp</p>"
                                 + "<p>Unutmus oldugunuz binrota sifreniz</p>" + CARETTA.COM.Encryption.Decrypt(dt.Rows[0]["Password"].ToString());

                myMail.SendEmail(subject, subject, msgBody);

                pnlForgotPassword.Visible = false;
                pnlEmailSuccess.Visible = true;
            }
            else
            {
                pnlForgotPassword.Visible = false;
                pnlEmailError.Visible = true;
            }



        }
        catch (Exception)
        {

            throw;
        }

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtEmail.Text = "";
    }
}
