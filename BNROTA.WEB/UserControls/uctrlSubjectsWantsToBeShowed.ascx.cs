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

public partial class UserControls_uctrlSubjectsWantsToBeShowed : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = BINROTA.BUS.MarketingGroupsItems.GetSubjectsWantToBeShowed((int)Enumerations.MarketingGroups.OnPlanaCikarilmakIstenenYerler, (DateTime.Now).Date);
            rptSubjectsWantsToBeShowed.DataSource = dt;
            rptSubjectsWantsToBeShowed.DataBind();
        }
    }
}
