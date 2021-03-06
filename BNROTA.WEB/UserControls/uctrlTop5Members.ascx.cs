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

public partial class UserControls_uctrlTop5Members : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = BINROTA.BUS.Members.GetMemberByPoints((int)Enumerations.PageType.TravelPage);
            
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("MemberID");
            dt1.Columns.Add("MemberName");

            foreach (DataRow dr in dt.Rows)
            {
                DataRow dr1 = dt1.NewRow();
                dr1["MemberID"] = dr["MemberID"];
                dr1["MemberName"] = dr["NickName"] + " (" + dr["Point"] + ")";
                dt1.Rows.Add(dr1);
             }
             if (dt1.Rows.Count > 0)
             {
                 rptTop5Member.DataSource = dt1;
                 rptTop5Member.DataBind();
             }

        }
    }
}
