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

public partial class UserControls_uctrlPagesRecordedSubjectCount : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = BINROTA.BUS.Pages.GetPageCountBySubjectID((int)Enumerations.PageType.TravelPage);

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("SubjectID");
            dt1.Columns.Add("SubjectName");

            foreach(DataRow dr in dt.Rows)
            {
                DataRow dr1 = dt1.NewRow();
                dr1["SubjectID"] = dr["SubjectID"];
                dr1["SubjectName"] = dr["Name"] + " (" + dr["PageCount"] + ")";
                dt1.Rows.Add(dr1);
            }
            if (dt1.Rows.Count > 0)
            {
                rptPageSubjectCount.DataSource = dt1;
                rptPageSubjectCount.DataBind();
            }
        }

    }
}
