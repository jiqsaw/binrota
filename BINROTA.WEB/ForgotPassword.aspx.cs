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

public partial class ForgotPassword : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
 
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Enumerations.LoginType LoginType;
            LoginType = ((Enumerations.LoginType)int.Parse(Request.QueryString["LoginType"].ToString()));
            DataTable dt = new DataTable();
            if(LoginType == Enumerations.LoginType.Member)
            {
                dt = BINROTA.BUS.Members.GetPassword(txtEMail.Text);
            }
            else if (LoginType == Enumerations.LoginType.User)
            {
                dt = BINROTA.BUS.Users.GetPassword(txtEMail.Text);
            }


            if (dt.Rows.Count == 1)
            {

                MailMessage objMessage = new MailMessage();
                string smtpServer = "mail.caretta.net";
                string smtpUser = "oray.kan@caretta.net";
                string smtpPass = "123456";


                objMessage.From = new MailAddress("oray.kan@caretta.net", "oray");
                objMessage.To.Add(new MailAddress(txtEMail.Text, "oray"));

                string subject = "Binrota sifre hatirlatma";
                string msgBody = "<p>Sayin <b>" + CARETTA.COM.Encryption.Decrypt(dt.Rows[0]["FullName"].ToString()) + "</b>,</p>"
                                 + "<p>&nbsp</p>"
                                 + "<p>Unutmus oldugunuz binrota sifreniz</p>" + dt.Rows[0]["Password"].ToString();

                objMessage.Subject = subject;
                objMessage.Body = msgBody;
                objMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient(smtpServer);
                smtpClient.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPass);

                smtpClient.Send(objMessage);
                lbError.Text = "Þifreniz Mail adresinize gönderilmiþtir";
            }
            else {
                lbError.Text = "Sisteme kayýtlý böyle bir mail adresi yoktur";
            }



        }
        catch (Exception)
        {
            
            throw;
        }

    }
}
