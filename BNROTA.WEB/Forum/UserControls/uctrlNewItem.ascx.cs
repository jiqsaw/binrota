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
using BINROTA.BUS;
using BINROTA.COM;

public partial class Forum_UserControls_uctrlNewItem : BaseUserControl
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
    public int ItemID
    {
        get
        {
            return (int)(ViewState["IID"] == null ? -1 : ViewState["IID"]);
        }
        set
        {
            ViewState["IID"] = value;
        }
    }
    public Forum.ItemType ItemType
    {
        get
        {
            return (Forum.ItemType)(ViewState["IT"] == null ? Forum.ItemType.ArticleItem : ViewState["IT"]);
        }
        set
        {
            ViewState["IT"] = value;
        }
    }
    public int ArticleID
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
    public int CategoryID
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
    public bool isMainArticleItem
    {
        get
        {
            return (bool)(ViewState["IMAI"] == null ? false : ViewState["IMAI"]);
        }
        set
        {
            ViewState["IMAI"] = value;
        }
    }
    #endregion

    public event EventHandler RefreshData;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsMember)
            {
                lblLoggedUser.Text = SessRoot.NickName;
            }
            //else
            //    Forum.GotoDefaultPage(this.Response);
            
            if (ItemID != -1)
                BindItem();
        }
    }

    public void ResetControl()
    {
        ItemID = -1;
        ArticleID = -1;
        CategoryID = -1;
        txtSubject.Text = "";
        ForumTextBox1.Text = "";
        ddlCategory.SelectedIndex = -1;
        ddlState.SelectedIndex = -1;
    }
    public void Open()
    {
        this.Visible = true;

        ddlState.DataSource = Forum.GetItemStates(ItemType, IsAdmin);
        ddlState.DataTextField = "Text";
        ddlState.DataValueField = "Value";
        ddlState.DataBind();

        if (ItemType == Forum.ItemType.Article)
        {
            ddlCategory.DataSource = Forum.GetCategories(Forum.CategoryStatus.All);
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();
            ddlCategory.SelectedValue = CategoryID.ToString();
        }

        if (IsMember)
        {
            lblLoggedUser.Text = SessRoot.NickName;
        }

        if (!IsAdmin)
            ddlCategory.Enabled = false;
        //else
        //    Forum.GotoDefaultPage(this.Response);

        SetTitle();

        if (ItemID != -1)
            BindItem();
    }
    public void Reply(string Title, string Content)
    {
        txtSubject.Text = "Re : " + Title;
        ForumTextBox1.Text = Forum.Reply(Title, Content); 
    }

    private void SetTitle()
    {
        switch (ItemType)
        {
            case Forum.ItemType.Article :
                
                if (ItemID == -1)
                    lblTitle.Text = "YENÝ KONU EKLE";
                else
                    lblTitle.Text = "KONU DEÐÝÞTÝR";

                break;
            case Forum.ItemType.Category :
                
                if (ItemID == -1)
                    lblTitle.Text = "YENÝ KATEGORÝ EKLE";
                else
                    lblTitle.Text = "KATEGORÝ DEÐÝÞTÝR";

                break;
            case Forum.ItemType.ArticleItem :
                
                if (ItemID == -1)
                    lblTitle.Text = "YENÝ YAZI EKLE";
                else
                    lblTitle.Text = "YAZI DEÐÝÞTÝR";

                break;
        }
        
    }
    private void BindItem()
    {
        DataTable dtItem = null;

        switch (ItemType)
        {
            case Forum.ItemType.Category:

                dtItem = Forum.GetCategory(ItemID);

                if (dtItem.Rows.Count==0) Forum.GotoDefaultPage(this.Response);

                txtSubject.Text=dtItem.Rows[0]["CategoryName"].ToString();
                ForumTextBox1.Text = dtItem.Rows[0]["CategoryDesc"].ToString();
                ddlState.SelectedValue = dtItem.Rows[0]["CategoryStatus"].ToString();

                break;
            case Forum.ItemType.Article: 
             
                dtItem = Forum.GetArticle(ItemID);

                if (dtItem.Rows.Count == 0) Forum.GotoDefaultPage(this.Response);

                txtSubject.Text = dtItem.Rows[0]["ArticleSubject"].ToString();
                ForumTextBox1.Text = dtItem.Rows[0]["ArticleMessage"].ToString();
                ddlState.SelectedValue = dtItem.Rows[0]["ArticleStatus"].ToString();
                
                break;
            case Forum.ItemType.ArticleItem:

                dtItem = Forum.GetArticleItem(ItemID);

                if (dtItem.Rows.Count == 0) Forum.GotoDefaultPage(this.Response);

                txtSubject.Text = dtItem.Rows[0]["Subject"].ToString();
                ForumTextBox1.Text = dtItem.Rows[0]["Reply"].ToString();
                ddlState.SelectedValue = dtItem.Rows[0]["Status"].ToString();
                
                break;
        }
    }

    #region ButtonEvents
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        this.Visible = false;
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        switch (ItemType)
        {
            case Forum.ItemType.Category:
                {
                    Forum.CategoryStatus state = Forum.CategoryStatus.Active;

                    if (ddlState.SelectedIndex == -1)
                        state = (Forum.CategoryStatus)int.Parse(ddlState.Items[0].Value);
                    else
                        state = (Forum.CategoryStatus)int.Parse(ddlState.SelectedValue);

                    if (ItemID == -1)
                    {
                        Forum.InsertCategory(txtSubject.Text.Trim(), ForumTextBox1.Text, state, SessRoot.UserID);
                    }
                    else
                    {
                        Forum.UpdateCategory(ItemID, txtSubject.Text.Trim(), ForumTextBox1.Text, state);
                    }
                    break;
                }
            case Forum.ItemType.Article:
                {
                    Forum.ArticleStatus state = Forum.ArticleStatus.Active;

                    if (ddlState.SelectedIndex == -1)
                        state = (Forum.ArticleStatus)int.Parse(ddlState.Items[0].Value);
                    else
                        state = (Forum.ArticleStatus)int.Parse(ddlState.SelectedValue);


                    if (ItemID == -1)
                    {
                        int UserID = SessRoot.UserID;
                        if (IsAdmin) UserID = -1;
                        Forum.InsertArticle(txtSubject.Text.Trim(), ForumTextBox1.Text, state, CategoryID, UserID, SessRoot.NickName);
                    }
                    else
                    {
                        Forum.UpdateArticle(ItemID, txtSubject.Text.Trim(), ForumTextBox1.Text, state, int.Parse(ddlCategory.SelectedValue));
                    }
                }
                break;
            case Forum.ItemType.ArticleItem:
                {
                    Forum.ArticleItemStatus state = Forum.ArticleItemStatus.Active;

                    if (ddlState.SelectedIndex == -1)
                        state = (Forum.ArticleItemStatus)int.Parse(ddlState.Items[0].Value);
                    else
                        state = (Forum.ArticleItemStatus)int.Parse(ddlState.SelectedValue);

                    if (ItemID == -1)
                    {
                        int UserID = SessRoot.UserID;
                        if (IsAdmin) UserID = -1;

                        Forum.InsertArticleItem(CategoryID, ArticleID, txtSubject.Text.Trim(), ForumTextBox1.Text, state, UserID, SessRoot.NickName);
                    }
                    else
                    {
                        if(isMainArticleItem)
                            Forum.UpdateArticleItem(ItemID,ArticleID, txtSubject.Text.Trim(), ForumTextBox1.Text, state);
                        else
                            Forum.UpdateArticleItem(ItemID, txtSubject.Text.Trim(), ForumTextBox1.Text, state);
                    }
                }
                break;
        }

        if (RefreshData!=null) RefreshData(null, EventArgs.Empty);
        this.Visible = false;

        if (ItemType == Forum.ItemType.Article && ArticleID != -1)
            Response.Redirect("Category.aspx?CategoryID="+ CategoryID.ToString());
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        switch (ItemType)
        {
            case Forum.ItemType.Category:
                Forum.DeleteCategory(ItemID);
                break;
            case Forum.ItemType.Article:
                Forum.DeleteArticle(ItemID); 
                break;
            case Forum.ItemType.ArticleItem:
                Forum.DeleteArticleItem(ItemID); 
                break;
        }

        RefreshData(null, EventArgs.Empty);
        this.Visible = false;
    }
    #endregion
}
