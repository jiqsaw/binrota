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

public partial class Forum_UserControls_uctrlArticle : BaseUserControl 
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
            if (IsAdmin) return true;

            if (SessRoot != null)
                return (SessRoot.LoginType == (int)Enumerations.LoginType.Member);

            return false;
        }
    }
    private int CategoryID
    {
        get
        {
            return (int)(ViewState["CID"] == null ? -1 : ViewState["CID"]);
        }
        set
        {
            ViewState["CID"] = value;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (CARETTA.COM.Util.IsNumeric(Request.QueryString["CategoryID"]))
            {
                this.CategoryID = int.Parse(Request.QueryString["CategoryID"].ToString());
                
                string CategoryName="";
                if (Forum.GetCategoryName(CategoryID,ref CategoryName))
                    lblCategoryName.Text = CategoryName;
                else               
                    Forum.GotoDefaultPage(this.Response);
            }
            else
                Common.GotoDefaultPage(this.Response);

            UctrlPaging1.ItemName = "konu";

            BindArticles();
        }
        UctrlPaging1.PagerChanged += new EventHandler(UctrlPaging1_PagerChanged);
        UctrlNewItem1.RefreshData += new EventHandler(RefreshData);
    }

    protected void RefreshData(object sender, EventArgs e)
    {
        BindArticles();
    }

    private void BindArticles()
    {
        PagedDataSource pds = new PagedDataSource();
        DataTable dtArticles = null;
        pds.AllowPaging = true;

        if (IsAdmin)
        {
            dtArticles= Forum.GetArticles(CategoryID,Forum.ArticleStatus.All);
        }
        else
        {
            dtArticles = Forum.GetArticles(CategoryID, Forum.ArticleStatus.Active);
        }

        pds.DataSource =dtArticles.DefaultView;

        UctrlPaging1.RecordCount = pds.DataSourceCount;
        pds.PageSize = UctrlPaging1.PageSize;
        pds.CurrentPageIndex = UctrlPaging1.CurrentPage - 1;

        rptArticles.DataSource = pds;
        rptArticles.DataBind();

        #region Setting Article Status
        if (SessRoot != null)
        {
            foreach (RepeaterItem rptitem in rptArticles.Items)
            {
                if ((((Label)(rptitem.FindControl("lblCreatedBy"))).Text == SessRoot.UserID.ToString() && (int.Parse(((Label)rptitem.FindControl("lblAStatus")).Text) < (int)Forum.ArticleStatus.Locked)) || IsAdmin)
                {
                    
                   
                    ((Panel)(rptitem.FindControl("pnlAStatus"))).Visible = false;
                    ((Panel)(rptitem.FindControl("pnlAStatusSet"))).Visible = true;
                    DropDownList ddlAS = ((DropDownList)(rptitem.FindControl("ddlArticleStatus")));

                    if (IsAdmin)
                        ddlAS.DataSource = Forum.GetAllArticlesStatusDescForAdmin();
                    else
                        ddlAS.DataSource = Forum.GetAllArticlesStatusDescForUser();

                    ddlAS.DataTextField = "Text";
                    ddlAS.DataValueField = "Value";
                    ddlAS.DataBind();

                    ddlAS.SelectedValue = dtArticles.Rows[rptitem.ItemIndex]["ArticleStatus"].ToString();
                   

                }
            }
        }
        #endregion
    }

    protected string CheckIfAdminInserted(string NickName) 
    {
        if (NickName == "")
            return "<span class=\"FText12\">ADMIN</span>";
        return "";
    }
    protected void UctrlPaging1_PagerChanged(object sender, EventArgs e)
    {
        BindArticles();
    }
    protected void btnSaveStatus_Click(object sender, EventArgs e)
    {
        RepeaterItem rptitem=((RepeaterItem)(((ImageButton)sender).NamingContainer));
        DropDownList ddlAS = ((DropDownList)(rptitem.FindControl("ddlArticleStatus")));
        Label lblAID= ((Label)(rptitem.FindControl("lblArticleID")));
        Forum.UpdateArticleStatus(int.Parse(lblAID.Text),(Forum.ArticleStatus)int.Parse(ddlAS.SelectedValue));
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        UctrlNewItem1.ResetControl();
        UctrlNewItem1.ItemType = Forum.ItemType.Article;
        UctrlNewItem1.ItemID = int.Parse(((ImageButton)sender).CommandArgument);
        UctrlNewItem1.CategoryID = CategoryID;

        UctrlNewItem1.Open(); 
    }
    protected void btnAddTopic_Click(object sender, ImageClickEventArgs e)
    {
        AddNewTopic();
    }
    protected void btnAddTopic2_Click(object sender, ImageClickEventArgs e)
    {
        AddNewTopic();
    }
    private void AddNewTopic()
    {
        Forum.CheckLogin(IsMember, this.Response);

        UctrlNewItem1.ResetControl();
        UctrlNewItem1.ItemType = Forum.ItemType.Article;
        UctrlNewItem1.CategoryID = CategoryID;

        UctrlNewItem1.Open();
    }
}
