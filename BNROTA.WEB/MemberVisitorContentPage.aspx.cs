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

public partial class MemberVisitorContentPage : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["PageID"] != null)
            {
                ((BinRota)this.Master).SetPageDesc("Ziyaretçi Gezi Sayfasý");
                lbTitle.Text = "Yazarýn Diðer Yazýlarý";
                PopulateRepeater();
                SetComments(int.Parse(Request.QueryString["PageID"]));

            }
            else
            {
                Common.GotoDefaultPage(this.Response);
            }
        }

        UctrlMemberVisitorPageContent1.CommentAddClicked += new Common.CommentAddClickHandler(OpenCommentDialog);
    }

    private void OpenCommentDialog(string Header, int PageID)
    {
        UctrlAddComment1.Visible = true;
        UctrlAddComment1.TitleText = Header;
        UctrlAddComment1.PageID = PageID;  
    }

    private void PopulateRepeater()
    {
        string PageContentName;
        DataTable dt = BINROTA.BUS.Pages.GetPageForExistanceControlByPageType(int.Parse(Request.QueryString["PageID"]), (int)Enumerations.PageType.TravelPage);
        if (dt.Rows.Count > 0)
            dt = BINROTA.BUS.Pages.GetUserPages(int.Parse(dt.Rows[0]["MemberID"].ToString()), (int)Enumerations.PageType.TravelPage);

        DataTable dtRep = new DataTable();
        dtRep.Columns.Add("PageContentName");
        dtRep.Columns.Add("PageID");

        foreach (DataRow dr in dt.Rows)
        {
            DataRow drRep = dtRep.NewRow();
            PageContentName = BINROTA.BUS.Subjects.GetSubject(int.Parse(dr["SubjectID"].ToString())).Rows[0]["Name"].ToString() + " ";
            PageContentName = PageContentName + BINROTA.BUS.PageCategories.GetPageCategoriesByPageCategoryID(int.Parse(dr["PageCategoryID"].ToString())).Rows[0]["PageCategoryName"].ToString();
            drRep["PageContentName"] = PageContentName;

            drRep["PageID"] = dr["PageID"];
            dtRep.Rows.Add(drRep);
        }

        rptPages.DataSource = dtRep;
        rptPages.DataBind();
    }

    protected void SetComments(int PageID)
    {
        UctrlPageComments1.SetComments(PageID);
    }

    protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            int PageID = int.Parse(e.CommandArgument.ToString());
            SetComments(PageID);
            DataTable dt = BINROTA.BUS.Pages.GetPageForExistanceControl(PageID);
            if (dt.Rows.Count > 0)
            {
                UctrlAddComment1.PageID = int.Parse(dt.Rows[0]["PageID"].ToString());
                UctrlAddComment1.TitleText = dt.Rows[0]["Title"].ToString();
                UctrlMemberVisitorPageContent1.PageContent = dt.Rows[0]["PageContent"].ToString();
                UctrlMemberVisitorPageContent1.Title = dt.Rows[0]["Title"].ToString();
                UctrlMemberVisitorPageContent1.PageCategory = dt.Rows[0]["PageCategoryID"].ToString();
                DateTime TravelDate = DateTime.Parse(dt.Rows[0]["TravelDate"].ToString());
                UctrlMemberVisitorPageContent1.TravelDate = TravelDate.Day + "." + TravelDate.Month + "." + TravelDate.Year;
            }

            DataTable dtCategories = BINROTA.BUS.Categories.GetCategories();

            foreach (DataRow dr in dtCategories.Rows)
            {
                dt = BINROTA.BUS.Pages.GetPageForExistanceControl(PageID, int.Parse(dr["CategoryID"].ToString()));
                foreach (DataRow dr1 in dt.Rows)
                {
                    UctrlMemberVisitorPageCategories1.SetCategoryContent(int.Parse(dr1["CategoryID"].ToString()), dr1["PageContent"].ToString());
                }
            }
        }
    }
}
