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
using CARETTA.COM;

public partial class UserControls_uctrlChangePassword : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
       DataTable dt = BINROTA.BUS.Members.GetMemberDetailsByMemberID(SessRoot.UserID);
       if (dt.Rows.Count > 0)
       {
           if (Encryption.Encrypt(txtOldPassword.Text.Trim()) == dt.Rows[0]["Password"].ToString())
           {
               BINROTA.BUS.Members.MemberPasswordUpdate(SessRoot.UserID, Encryption.Encrypt(txtNewPassword.Text));
               lbMessage.Text = "Þifreniz Deðiþtirilmiþtir.";
                
           }
           else
               lbMessage.Text = "Girmiþ olduðunuz þifre doðru deðildir.";
       }
    }
}
