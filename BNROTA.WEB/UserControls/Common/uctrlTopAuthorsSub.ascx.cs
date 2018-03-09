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
using BINROTA.COM;

public partial class UserControls_Common_uctrlTopAuthorsSub : BaseUserControl
{

    protected void Page_Load(object sender, EventArgs e) 
    {
    }

    public void FillAuthors(string PageName, int SubjectID)
    {
        DataTable dt = BINROTA.BUS.Members.GetMemberPointsBySubjectID(SubjectID);
        if (dt.Rows.Count > 0)
        {
            lbMembersTitle.Text = PageName;
            rptTopAuthors.DataSource = dt;
            rptTopAuthors.DataBind();
        }
        else {
            this.Visible = false;
        }
    }
}
