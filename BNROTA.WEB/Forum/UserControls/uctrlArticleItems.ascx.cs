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

public partial class Forum_UserControls_uctrlArticleItems : BaseUserControl 
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
    private int ArticleID
    {
        get
        {
            return (int)(ViewState["AID"] == null ? -1 : ViewState["AID"]);
        }
        set
        {
            ViewState["AID"] = value;
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
            if (CARETTA.COM.Util.IsNumeric(Request.QueryString["ArticleID"]))
            {              
                this.ArticleID = int.Parse(Request.QueryString["ArticleID"].ToString());

                DataTable dtArticleTitles = Forum.GetArticleTitles(ArticleID);

                if (dtArticleTitles.Rows.Count > 0)
                {
                    lblArticleName.Text = dtArticleTitles.Rows[0]["ArticleSubject"].ToString();
                    hlCategoryName.Text = dtArticleTitles.Rows[0]["CategoryName"].ToString();
                    hlCategoryName.NavigateUrl = "~/Category.aspx?CategoryID=" + dtArticleTitles.Rows[0]["CategoryID"].ToString();
                    CategoryID = int.Parse(dtArticleTitles.Rows[0]["CategoryID"].ToString());
                }
                else
                    Forum.GotoDefaultPage(this.Response);
            }
            else
                Common.GotoDefaultPage(this.Response);

            BindArticleItems();
        }
        UctrlNewItem1.RefreshData += new EventHandler(RefreshData);
        UctrlPaging1.PagerChanged += new EventHandler(UctrlPaging1_PagerChanged);
        UctrlPaging2.PagerChanged += new EventHandler(UctrlPaging2_PagerChanged);
    }


    protected void RefreshData(object sender, EventArgs e)
    {
        BindArticleItems();
    }
    private void BindArticleItems()
    {
        PagedDataSource pds = new PagedDataSource();
        DataTable dtArticleItems = null;
        pds.AllowPaging = true;

        if (IsAdmin)
        {
            dtArticleItems = Forum.GetArticleItems(ArticleID, Forum.ArticleItemStatus.All);
        }
        else
        {
            dtArticleItems = Forum.GetArticleItems(ArticleID, Forum.ArticleItemStatus.Active);
        }


        Forum.ArticleStatus ForumAStatus = Forum.GetArticleStatus(ArticleID);

        if (ForumAStatus == Forum.ArticleStatus.Deactive) Forum.GotoDefaultPage(this.Response);

        if (ForumAStatus == Forum.ArticleStatus.Locked && (!IsAdmin))
        {
            btnReply.Visible = false;
            btnReply2.Visible = false;
        }

        pds.DataSource =dtArticleItems.DefaultView;

        UctrlPaging2.RecordCount=UctrlPaging1.RecordCount = pds.DataSourceCount;
        pds.PageSize = UctrlPaging1.PageSize = UctrlPaging2.PageSize;
        pds.CurrentPageIndex = UctrlPaging1.CurrentPage - 1;

        rptArticleItems.DataSource = pds;
        rptArticleItems.DataBind();

        #region Edit and ddlScore

            DataTable dtScores=Forum.GetItemScores();
            foreach (RepeaterItem rptitem in rptArticleItems.Items)
            {
                DropDownList ddlScore = ((DropDownList)(rptitem.FindControl("ddlScore")));

                ddlScore.DataSource=dtScores;
                ddlScore.DataTextField="Text";
                ddlScore.DataValueField="Value";
                ddlScore.DataBind();

                if (SessRoot != null)
                {
                    int MemberID=int.Parse(((Label)rptitem.FindControl("lblMemberID")).Text);

                    if (MemberID == SessRoot.UserID || IsAdmin)
                        ((Panel)(rptitem.FindControl("pnlEdit"))).Visible = true;
                }

                if (ForumAStatus == Forum.ArticleStatus.Locked && (!IsAdmin))
                {
                    ((ImageButton)rptitem.FindControl("btnEdit")).Visible=false;
                    ((ImageButton)rptitem.FindControl("btnReply")).Visible = false;
                }

                if (((Label)rptitem.FindControl("lblRMemberID")).Text == "" || ((Label)rptitem.FindControl("lblRMemberID")).Text == "-1")
                {
                    ((Panel)rptitem.FindControl("pnlMemberCreated")).Visible = false;
                    ((Panel)rptitem.FindControl("pnlAdminCreated")).Visible = true;
                }
            }
        
        #endregion
    }

    protected void UctrlPaging1_PagerChanged(object sender, EventArgs e)
    {
        UctrlPaging2.CurrentPage = UctrlPaging1.CurrentPage;
        UctrlPaging2.PageSize = UctrlPaging1.PageSize;
        UctrlPaging2.GeneratePager();
        BindArticleItems();
    }
    protected void UctrlPaging2_PagerChanged(object sender, EventArgs e)
    {
        UctrlPaging1.CurrentPage = UctrlPaging2.CurrentPage;
        UctrlPaging1.PageSize = UctrlPaging2.PageSize;
        UctrlPaging1.GeneratePager();
        BindArticleItems();
    }

    #region Buttons
    protected void btnAddTopic_Click(object sender, EventArgs e)
    {
        Forum.CheckLogin(IsMember, this.Response);

        UctrlNewItem1.ResetControl();
        UctrlNewItem1.ItemType = Forum.ItemType.Article;
        UctrlNewItem1.CategoryID = CategoryID;
        UctrlNewItem1.ArticleID = ArticleID;

        UctrlNewItem1.Open();
    }
    protected void btnReply_Click(object sender, EventArgs e)
    {
        Forum.CheckLogin(IsMember, this.Response);
        
        UctrlNewItem1.ResetControl();
        UctrlNewItem1.ItemType = Forum.ItemType.ArticleItem;
        UctrlNewItem1.CategoryID = CategoryID;
        UctrlNewItem1.ArticleID = ArticleID;

        UctrlNewItem1.Open();
    }
    protected void btnGivePoint_Click(object sender, EventArgs e)
    {
        Forum.CheckLogin(IsMember, this.Response);

        int ArticleItemID=int.Parse(((Label)((RepeaterItem)(((ImageButton)sender).NamingContainer)).FindControl("lblAItemID")).Text) ;
        DropDownList ddlScore=((DropDownList)((RepeaterItem)(((ImageButton)sender).NamingContainer)).FindControl("ddlScore"));
        if (ddlScore.SelectedIndex==-1) ddlScore.SelectedIndex=0;

        Forum.GivePoint(ArticleItemID, int.Parse(ddlScore.SelectedValue));
        BindArticleItems(); 
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Forum.CheckLogin(IsMember, this.Response);
        Forum.CheckLogin(IsMember, this.Response);

        UctrlNewItem1.ResetControl();
        UctrlNewItem1.ItemType = Forum.ItemType.ArticleItem;
        UctrlNewItem1.CategoryID = CategoryID;
        UctrlNewItem1.ArticleID = ArticleID;
        UctrlNewItem1.ItemID = int.Parse(((Label)((RepeaterItem)((ImageButton)sender).NamingContainer).FindControl("lblAItemID")).Text);
        if (((RepeaterItem)((ImageButton)sender).NamingContainer).ItemIndex == 0) UctrlNewItem1.isMainArticleItem = true;

        UctrlNewItem1.Open();
    }
    protected void btnQuote_Click(object sender, EventArgs e)
    {
        Forum.CheckLogin(IsMember, this.Response);

        UctrlNewItem1.ResetControl();
        UctrlNewItem1.ItemType = Forum.ItemType.ArticleItem;
        UctrlNewItem1.CategoryID = CategoryID;
        UctrlNewItem1.ArticleID = ArticleID;

        UctrlNewItem1.Open();

        string Title = "";
        string Content = "";
        try
        {

            Title = ((Label)((RepeaterItem)((ImageButton)sender).NamingContainer).FindControl("lblTitle")).Text;
            Content = ((Label)((RepeaterItem)((ImageButton)sender).NamingContainer).FindControl("lblContent")).Text;
        }
        catch
        {
        }
        UctrlNewItem1.Reply(Title, Content);
    }
    
    #endregion
}
