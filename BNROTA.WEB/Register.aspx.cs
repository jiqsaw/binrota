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
using BINROTA.COM;

public partial class Register : BasePage
{
    string ActivationNumber ="";

    private string CreateActivationNumber()
    {

        Random random = new Random();
        int RandomNumber = 0;
        char ch;
        string ActivationKey = "";

        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                RandomNumber = random.Next(48, 57);
            }
            else
            {
                RandomNumber = random.Next(65, 90);
            }
            ch = Convert.ToChar(RandomNumber);
            ActivationKey = ActivationKey + ch.ToString();
        }
        return ActivationKey;
    }

    private void SendActivationEMail()
    {

        MailMessage objMessage = new MailMessage();
        string smtpServer = "mail.caretta.net";
        string smtpUser = "oray.kan@caretta.net";
        string smtpPass = "123456";

        //System.Configuration.ConfigurationManager.AppSettings["SMTPServer"];

        objMessage.From = new MailAddress("oray.kan@caretta.net", "oray");
        objMessage.To.Add(new MailAddress(txtEMail.Text, "oray"));

        string subject = "Binrota aktivasyon maili";
        string msgBody = "<p>Binrota hesabýnýzý aþaðýdaki linke týklayarak aktive edebilirsiniz</p>"
                          + "<p>&nbsp</p>"
                          + ActivationNumber;


        objMessage.Subject = subject;
        objMessage.Body = msgBody;
        objMessage.IsBodyHtml = true;

        SmtpClient smtpClient = new SmtpClient(smtpServer);
        smtpClient.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPass);

        smtpClient.Send(objMessage);
        lbMessage.Text = "E-Mail adresinize bir aktivasyon maili gönderilmiþtir. Lütfen E-Maillerinizi kontrol ediniz";

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CARETTA.COM.DDLHelper.LoadNumberDDL(ref drpBirthYear, 2000, 1, 1900);
            CARETTA.COM.DDLHelper.BindDDL(ref drpCountry, BINROTA.BUS.Subjects.GetSubjectForDDL((int)Enumerations.SubjectType.Ulke), "Name", "SubjectID", "");
            CARETTA.COM.DDLHelper.BindDDL(ref drpCity, BINROTA.BUS.Subjects.GetSubjectBySubjectID(int.Parse(drpCountry.SelectedValue), (int)Enumerations.SubjectType.Sehir), "Name", "SubjectID", "");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //ActivationNumber = CreateActivationNumber();
        //BINROTA.BUS.Members.MemberInsert(txtName.Text, txtSurname.Text, txtNickName.Text, txtEMail.Text, clBirthDate.SelectedDate, txtJob.Text, int.Parse(drpCity.SelectedValue), CARETTA.COM.Encryption.Encrypt(txtPassword.Text.ToString()), bool.Parse(rblGender.SelectedValue), DateTime.Now);
        //lbMessage.Text = "Kayýt iþlemi gerçekleþmiþtir. Ana sayfaya dönüp sisteme giriþ yapabilirsiniz.";
        //// SendActivationEMail();
    }
    protected void drpBirthYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DateTime date = new DateTime(int.Parse(drpBirthYear.SelectedValue), clBirthDate.SelectedDate.Month, clBirthDate.SelectedDate.Day);
        clBirthDate.SelectedDate = date;
        clBirthDate.VisibleDate = date;
    }
    protected void btnMainPage_Click(object sender, EventArgs e)
    {
        Common.GotoDefaultPage(this.Response);
    }
    protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        CARETTA.COM.DDLHelper.BindDDL(ref drpCity, BINROTA.BUS.Subjects.GetSubjectBySubjectID(int.Parse(drpCountry.SelectedValue ), (int)Enumerations.SubjectType.Sehir), "Name", "SubjectID", "");
    }
}