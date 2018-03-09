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

public partial class UserControls_uctrlUpdateUserDetails : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillMemberDetails();
        }

    }

    public void FillMemberDetails()
    {
        DataTable dt = BINROTA.BUS.Members.GetMemberDetailsByMemberID(SessRoot.UserID);
        if (dt.Rows.Count > 0)
        {
            txtEducation.Text = dt.Rows[0]["Education"].ToString();
            txtJob.Text = dt.Rows[0]["Job"].ToString();
            txtLivingPlace.Text = dt.Rows[0]["LivingPlace"].ToString();
            txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
            txtLastName.Text = dt.Rows[0]["LastName"].ToString();
            txtMotto.Text = dt.Rows[0]["Motto"].ToString();
            txtInterest.Text = dt.Rows[0]["Interests"].ToString();
        }
        dt = BINROTA.BUS.Pages.GetUserPages(SessRoot.UserID, (int)Enumerations.PageType.HomePage);
        if (dt.Rows.Count > 0)
        {
            ftbHomePageContent.Text = dt.Rows[0]["PageContent"].ToString();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            //BINROTA.BUS.Members.MemberUpdate(SessRoot.UserID, txtFirstName.Text, txtLastName.Text, txtJob.Text, txtLivingPlace.Text, txtInterest.Text, txtMotto.Text);
            //lbMessage.Text = "Bilgileriniz Güncellenmiþtir";
        }
        catch (Exception)
        {
            
        }

    }
}
