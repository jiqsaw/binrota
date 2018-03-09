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

public partial class UserControls_uctrlRecordedPageCategoryCount : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = BINROTA.BUS.Pages.GetPageCountByPageCategoryID((int)Enumerations.PageType.TravelPage);
            
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("PageCategoryName");
            dt1.Columns.Add("PageCategoryID");

            foreach (DataRow dr in dt.Rows)
            {
                DataRow dr1 = dt1.NewRow();
                dr1["PageCategoryName"] = dr["PageCategoryName"] + " (" + dr["PageCount"] + ")";
                dr1["PageCategoryID"] = dr["PageCategoryID"];
                dt1.Rows.Add(dr1);
            }
            if (dt1.Rows.Count > 0)
            {
                rptPageCategoryCount.DataSource = dt1;
                rptPageCategoryCount.DataBind();
            }
        }
    }
}
