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

public partial class UserControls_MainPage_uctrlTripCategories : BaseUserControl
{
    public int RepeatColumns
    {
        set
        {
            dlTripCategories.RepeatColumns = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTripCategories();
        }
    }

    private void BindTripCategories()
    {
        DataTable dt = BINROTA.BUS.Pages.GetPageCountByPageCategoryID((int)Enumerations.PageType.TravelPage);
        dlTripCategories.DataSource=dt;
        dlTripCategories.DataBind();
    }



    protected void dlTripCategories_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            int PageCount = Convert.ToInt32(((HyperLink)e.Item.FindControl("hplPageCategory")).ToolTip);
            if (PageCount < 1) { ((HyperLink)e.Item.FindControl("hplPageCategory")).NavigateUrl = ""; }
        }
    }
}


