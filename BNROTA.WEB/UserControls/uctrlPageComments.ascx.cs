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

public partial class UserControls_uctrlPageComments : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void SetComments(int PageID)
    {
        DataTable dt = BINROTA.BUS.PageComments.GetPageComments(PageID);
        DataTable dtComments = new DataTable();
        dtComments.Columns.Add("Comment");
        dtComments.Columns.Add("NickName");

        foreach (DataRow dr in dt.Rows)
        {
            DataRow drComments = dtComments.NewRow();
            drComments["Comment"] = dr["Comment"];
            drComments["NickName"] = (BINROTA.BUS.Members.GetMemberDetailsByMemberID(int.Parse(dr["MemberID"].ToString()))).Rows[0]["NickName"];
            dtComments.Rows.Add(drComments);
        }
        rptMemberComment.DataSource = dtComments;
        rptMemberComment.DataBind();
    }
}
