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
using CARETTA.COM;

public partial class UserControls_Pages_uctrlMemberForm : BaseUserControl 
{
    string ActivationNumber;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillDropDowns();
    }

    private void FillDropDowns()
    {
        DDLHelper.BindDDL(ref drpCountry, BINROTA.BUS.Subjects.GetSubjectForDDL((int)Enumerations.SubjectType.Ulke), "Name", "SubjectID", "", "Bir �lke Se�iniz", "0");
        drpCountry.SelectedValue = "4658";
        DDLHelper.BindDDL(ref drpCity, BINROTA.BUS.Subjects.GetSubjectBySubjectID(int.Parse(drpCountry.SelectedValue), (int)Enumerations.SubjectType.Sehir), "Name", "SubjectID", "", "Bir �ehir Se�iniz", "");
        DDLHelper.BindDDL(ref drpJob, BINROTA.BUS.Jobs.GetJobs(), "Job", "JobID", "", "Bir Meslek Se�iniz", "");
        DDLHelper.LoadNumberDDL(ref drpDay, 31);
        DDLHelper.LoadNumberDDL(ref drpMonth, 12);
        DDLHelper.LoadNumberDDL(ref drpYear, DateTime.Today.Year, 1, 1920);
    }

    protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLHelper.BindDDL(ref drpCity, BINROTA.BUS.Subjects.GetSubjectBySubjectID(int.Parse(drpCountry.SelectedValue), (int)Enumerations.SubjectType.Sehir), "Name", "SubjectID", "", "Bir �ehir Se�iniz", "");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (isDateValid(drpDay.SelectedValue + "." + drpMonth.SelectedValue + "." + drpYear.SelectedValue))
        {
            ActivationNumber = CreateActivationNumber();
            Enumerations.MemberRegisterControl MemberExisitControl;
            MemberExisitControl = BINROTA.BUS.Members.MemberRegisterControl(txtNickName.Text, txtEmail.Text);
            if (MemberExisitControl == Enumerations.MemberRegisterControl.Success)
            {
                DateTime BirthDay = new DateTime(int.Parse(drpYear.SelectedValue), int.Parse(drpMonth.SelectedValue), int.Parse(drpDay.SelectedValue));
                int MemberID = 0;

                MemberID = BINROTA.BUS.Members.MemberInsert(txtFirtsName.Text, txtSurname.Text, txtNickName.Text, txtEmail.Text, BirthDay, int.Parse(drpJob.SelectedValue), int.Parse(drpCity.SelectedValue), CARETTA.COM.Encryption.Encrypt(txtPassword.Text.ToString()), bool.Parse(rblGender.SelectedValue), DateTime.Now, this.ActivationNumber);
                SendActivationEMail(MemberID);
                lbMessage.Text = "Belirtti�iniz e-posta adresinize aktivasyon kodunuz g�nderilmi�tir. Hesab�n�z� aktif hale getirdikten sonra siteye giri� yapabilirsiniz";
            }
            else if (MemberExisitControl == Enumerations.MemberRegisterControl.EmailExist)
            {
                lbMessage.Text = "Bu emaile kay�tl� bir kullan�c� daha �nceden kay�t olmu�. L�tfen emaili de�i�tirip tekrar deneyin.";
            }
            else if (MemberExisitControl == Enumerations.MemberRegisterControl.NickNameExist)
            {
                lbMessage.Text = "Bu kullan�c� ad�yla kay�tl� bir kullan�c� daha �nceden kay�t olmu�. L�tfen kullan�c� ad�n� de�i�tirip tekrar deneyin";
            }
        }
        else 
        {
            lbMessage.Text = "Girmi� oldu�unuz tarih ge�erli bir tarih de�ildir. L�tfen do�ru bir tarih giriniz.";
        }
        pnlMemberForm.Visible = false;
        pnlMessage.Visible = true;
    }

    private bool isDateValid(string date)
    {
        try
        {
            DateTime BirthDay = Convert.ToDateTime(date);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

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

    private void SendActivationEMail(int MemberID)
    {
        BINROTA.BUS.Mail myMail = new BINROTA.BUS.Mail();
        myMail.AddToList(txtEmail.Text);

        string MailLink = "http://www.binrota.com/MemberActivation.aspx?ActivationKey=" + ActivationNumber + "&MemberID=" + MemberID.ToString();

        string subject = "Binrota aktivasyon maili";
        string msgBody = "<p>Binrota hesab�n�z� a�a��daki linke t�klayarak aktive edebilirsiniz</p>"
                          + "<p>&nbsp</p>"
                          + "<a href=\"" + MailLink + "\">" + MailLink + "</a>";
        
        myMail.SendEmail(subject, subject, msgBody);
    }

}
