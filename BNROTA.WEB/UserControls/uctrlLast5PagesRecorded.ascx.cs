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

public partial class UserControls_uctrlLast5PagesRecorded : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = BINROTA.BUS.Pages.GetLast5PagesRecorded((int)Enumerations.PageType.TravelPage);

        if (dt.Rows.Count > 0)
        {
            rptLast5PageRecorded.DataSource = dt;
            rptLast5PageRecorded.DataBind();
        }
    }
}
