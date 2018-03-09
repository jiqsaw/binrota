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
using BINROTA.BUS;

public partial class Forum_UserControls_uctCategories : BaseUserControl
{
    #region Properties
    protected bool IsAdmin
    {
        get
        {
            if (SessRoot != null)
                return (SessRoot.LoginType == (int)Enumerations.LoginType.User);

            return false;
        }
    }
    protected bool IsMember
    {
        get
        {
            if (SessRoot != null)
                return (SessRoot.LoginType == (int)Enumerations.LoginType.Member);

            if (IsAdmin) return true;

            return false;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategories();
            UctrlPaging1.PageSize = 30;
            UctrlPaging1.ItemName = "kategori";
        }
        UctrlPaging1.PagerChanged += new EventHandler(UctrlPaging1_PagerChanged);
        UctrlNewItem1.RefreshData += new EventHandler(RefreshData);
    }

    private void BindCategories()
    {
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;

        if (IsAdmin)
        {
            pds.DataSource = Forum.GetCategories(Forum.CategoryStatus.All).DefaultView;
        }
        else
        {
            pds.DataSource = Forum.GetCategories(Forum.CategoryStatus.Active).DefaultView;
        }

        UctrlPaging1.RecordCount = pds.DataSourceCount;
        pds.PageSize = UctrlPaging1.PageSize;
        pds.CurrentPageIndex = UctrlPaging1.CurrentPage - 1;

        rptCategories.DataSource = pds;
        rptCategories.DataBind();
    }

    protected void RefreshData(object sender, EventArgs e)
    {
        BindCategories();
    }
    protected void UctrlPaging1_PagerChanged(object sender, EventArgs e)
    {
        BindCategories();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        UctrlNewItem1.ResetControl();
        UctrlNewItem1.ItemType = Forum.ItemType.Category;
        UctrlNewItem1.ItemID = int.Parse(((ImageButton)sender).CommandArgument);

        UctrlNewItem1.Open(); 
    }
    protected void btnAddCategory_Click(object sender, EventArgs e)
    {
        UctrlNewItem1.ResetControl();
        UctrlNewItem1.ItemType = Forum.ItemType.Category;
        UctrlNewItem1.Open(); 
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dtOrders = new DataTable();

        dtOrders.Columns.Add("CategoryID");
        dtOrders.Columns.Add("Order");

        foreach (RepeaterItem rptitem in rptCategories.Items)
        {
            DataRow dr = dtOrders.NewRow();

            dr["CategoryID"] = ((Label)rptitem.FindControl("lblCategoryID")).Text.Trim();
            dr["Order"]=((TextBox)rptitem.FindControl("txtOrder")).Text.Trim();

            dtOrders.Rows.Add(dr);
        }

        Forum.UpdateCategoryOrder(dtOrders);
        BindCategories();
    }
}
