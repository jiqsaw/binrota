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
using CARETTA.COM;

public partial class UserControls_Pages_uctrlPageDetail : BaseUserControl
{
    public int PageID 
    {
        get { return (ViewState["PageID"] == null ? -1 : int.Parse(ViewState["PageID"].ToString())); }
        set { ViewState["PageID"] = value; }
    }
    public int MemberID 
    {
        get { return (ViewState["MemberID"] == null ? -1 : int.Parse(ViewState["MemberID"].ToString())); }
        set { ViewState["MemberID"] = value; }
    }

    public int MemberVisitorID
    {
        get { return (ViewState["MemberVID"] == null ? -1 : int.Parse(ViewState["MemberVID"].ToString())); }
        set { ViewState["MemberVID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (SessRoot == null) { this.MemberVisitorID = 0; } else { this.MemberVisitorID = SessRoot.UserID; }
            DDLHelper.LoadNumberDDL(ref drpPoints, 5, 1, 1);
            DDLHelper.LoadNumberDDL(ref drpPoints2, 5, 1, 1);
            PageIDControl();

            FillPageDetail();

            FillMemberDetail();

            FillComment();

        }
    }

    private void PageIDControl()
    {
        if (CARETTA.COM.Util.IsNumeric(Request.QueryString["PageID"]))
        {
            this.PageID = int.Parse(Request.QueryString["PageID"]);
        }
        else
        {
            BINROTA.COM.Common.GotoDefaultPage(this.Response);
        }
    }

    private void FillPageDetail()
    {
        DataTable dtPageDetail = BINROTA.BUS.Pages.GetPageForExistanceControl(this.PageID);
        if (dtPageDetail.Rows.Count < 1) { BINROTA.COM.Common.GotoDefaultPage(this.Response); }
        if (Convert.ToInt32(dtPageDetail.Rows[0]["PageTypeID"]) != (int)Enumerations.PageType.TravelPage) { BINROTA.COM.Common.GotoDefaultPage(this.Response); }
        this.MemberID = Convert.ToInt32(dtPageDetail.Rows[0]["MemberID"]);

        ltlPageDate.Text = String.Format("{0:D}", dtPageDetail.Rows[0]["TravelDate"]);
        ltlPageCategory.Text = BINROTA.BUS.PageCategories.GetPageCategoriesByPageCategoryID(Convert.ToInt32(dtPageDetail.Rows[0]["PageCategoryID"])).Rows[0]["PageCategoryName"].ToString();
        lblPageTitle.Text = dtPageDetail.Rows[0]["Title"].ToString();
        
        DataTable dtSubjectNames = BINROTA.BUS.Subjects.GetNameAndParentNameBySubjectID(Convert.ToInt32(dtPageDetail.Rows[0]["SubjectID"]));
        lblParentName.Text = dtSubjectNames.Rows[0]["ParentName"].ToString();
        lblSubjectName.Text = dtSubjectNames.Rows[0]["Name"].ToString();
        dvPageDetail.InnerHtml = dtPageDetail.Rows[0]["PageContent"].ToString();

        DataTable dtPageCategoriesContent = BINROTA.BUS.Categories.GetCategoriesContentByPageID(this.PageID);
        foreach (DataRow dr in dtPageCategoriesContent.Rows)
        {
            if (dr["PageContent"].ToString() == "")
            {
                dr.Delete();
            }
        }

        rptPageContent.DataSource = dtPageCategoriesContent;
        rptPageContent.DataBind();

        hlAddComment.NavigateUrl = "javascript:OpenAddComment(" + this.PageID.ToString() + ")";
        hlAddComplain.NavigateUrl = "javascript:OpenAddComplain(" + this.PageID.ToString() + ")";

        hlAddComment2.NavigateUrl = "javascript:OpenAddComment(" + this.PageID.ToString() + ")";
        hlAddComplain2.NavigateUrl = "javascript:OpenAddComplain(" + this.PageID.ToString() + ")";

    }

    private void FillMemberDetail()
    {
        DataTable dtMember = BINROTA.BUS.Members.GetMemberDetailsByMemberID(this.MemberID);
        if (dtMember.Rows.Count < 1) { BINROTA.COM.Common.GotoDefaultPage(this.Response); }

        if (dtMember.Rows[0]["PhotoPath"].ToString() == "")
        {
            imgUserPicture.ImageUrl = "~/Images/Design/NoPicture.jpg";
        }
        else
        {
            imgUserPicture.ImageUrl = ConfigurationManager.AppSettings["MemberImagesPath"].ToString() + dtMember.Rows[0]["PhotoPath"].ToString();
        }
        hlMemberNick.Text = dtMember.Rows[0]["NickName"].ToString();
        hlMemberNick.NavigateUrl = "~/MemberPage.aspx?MemberID=" + Convert.ToInt32(dtMember.Rows[0]["MemberID"]);
        hplMemberOtherPages.NavigateUrl = "~/PagesView.aspx?MemberID=" + Convert.ToInt32(dtMember.Rows[0]["MemberID"]);
        lblMotto.Text = dtMember.Rows[0]["Motto"].ToString();
        ltlMemberVisited.Text = dtMember.Rows[0]["VisitedPlaces"].ToString();
        lblMemberPoint.Text = dtMember.Rows[0]["Point"].ToString();
    }

    private void FillComment()
    {
        DataTable dtComment = BINROTA.BUS.PageComments.GetPageComments(this.PageID);
        if (dtComment.Rows.Count > 0)
        {
            pnlComments.Visible = true;
            trSubButtons.Visible = true;
            rptComments.DataSource = dtComment;
            rptComments.DataBind();
        }
        else 
        {
            trSubButtons.Visible = false;
        }
    }

    private void AddPointsToPage(int Points)
    {
        if (BINROTA.BUS.PagePoints.PagePointsInsert(this.PageID, this.MemberVisitorID, Points))
        {
            Response.Write("<script language='javascript'> {window.open('Result.aspx?Message=' + 'Puanýnýz eklenmiþtir. Teþekkür ederiz.', 'BinrotaResult', 'width=490,height=300,toolbar=no,resizable=no,scrollbars=no,');}</script>");
        }
        else
        {
            Response.Write("<script language='javascript'> {window.open('Result.aspx?Message=' + 'Ayný yazýya yalnýzca bir kez puan ekleyebilirsiniz.', 'BinrotaResult', 'width=490,height=300,toolbar=no,resizable=no,scrollbars=no,');}</script>");
        }
    }

    protected void btnAddPoints_Click(object sender, EventArgs e)
    {
        AddPointsToPage(int.Parse(drpPoints.SelectedValue));
    }
    protected void btnAddPoints2_Click(object sender, EventArgs e)
    {
        AddPointsToPage(int.Parse(drpPoints2.SelectedValue));
    }
}
