using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Net.Mail;

namespace BINROTA.BUS
{
    public class Mail
    {
        private ArrayList ToList;
        public string MailTemplate = " <html><head><title>BINROTA</title><style>body {margin: 0px 0px 0px 0px;color: #2e3c3f;background-color: #a3d2ed;} Table{font-family: Verdana;font-size: 10px;} .PageBack {background: #FFFFFF url('http://www.binrota.com/Images/Mail/Back.jpg') repeat-x;} .Treb {font-family: Trebuchet MS;font-size: 12px;color: #4a75a0;}</style></head><body><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\"><tr><td height=\"60\" bgcolor=\"#FFFFFF\" align=\"center\"><table width=\"400\"><tr><td><img src=\"http://www.binrota.com/Images/Mail/Logo.jpg\"></td><td align=\"right\" style=\"padding-right: 5px;\"><a target=\"_blank\" href=\"http://www.binrota.com \">www.binrota.com</a></td></tr></table></td></tr><tr><td class=\"PageBack\" style=\"text-align: center;\"><table bgcolor=\"#FFFFFF\" width=\"400\"><tr><td align=\"center\"><table><tr><td><img src=\"http://www.binrota.com/Images/Mail/Map.jpg\"></td></tr><tr><td style=\"padding-bottom:20px;\"><br><font class=\"Treb\">||MAILHEADER||</font><br><br>||MAILCONTENT||</td></tr></table></td></tr></table></td></tr></table></body></html> ";
        public MailAddress From = new MailAddress(ConfigurationManager.AppSettings["SMTPUserName"].ToString(), ConfigurationManager.AppSettings["SMTPFromAddress"].ToString());

        public Mail()
        {
            ToList = new ArrayList();
        }

        public void ClearToList()
        {
            ToList.Clear();
        }
        public void AddToList(string Email)
        {
            ToList.Add(Email);
        }
        public bool SendEmail(string Subject,string Header,string Content)
        {
            try
            {
                MailMessage objMessage = new MailMessage();
                string smtpServer = ConfigurationManager.AppSettings["SMTPServer"].ToString();
                string smtpUser = ConfigurationManager.AppSettings["SMTPUserName"].ToString();
                string smtpPass = ConfigurationManager.AppSettings["SMTPPassword"].ToString();

                objMessage.From = From;

                //////////////////////Setting Mail To
                for (int i = 0; i < ToList.Count; i++)
                    objMessage.To.Add(new MailAddress((ToList[i].ToString())));
                //////////////////////

                MailTemplate = MailTemplate.Replace("||MAILHEADER||", Header).Replace("||MAILCONTENT||", Content);

                objMessage.Subject = Subject;
                objMessage.Body = MailTemplate;
                objMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient(smtpServer);
                smtpClient.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPass);

                smtpClient.Send(objMessage);

                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
            return false;
        }
    }
}
