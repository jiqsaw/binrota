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

public partial class UserControls_Pages_uctrlCityDetail : BaseUserControl
{
    private string PageName;

    public int SubjectID
    {
        get { return (ViewState["SubjectID"] == null ? -1 : int.Parse(ViewState["SubjectID"].ToString())); }
        set { ViewState["SubjectID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (CARETTA.COM.Util.IsNumeric(Request.QueryString["SubjectID"]))
            {
                this.SubjectID = int.Parse(Request.QueryString["SubjectID"]);
            }
            else { BINROTA.COM.Common.GotoDefaultPage(); }

            FillDetails();
            FillLastPages();
            UctrlTopAuthorsSub1.FillAuthors(this.PageName , this.SubjectID);
            hplAddPAge.NavigateUrl = "javascript:OpenAddPagesBySubjectID(" + this.SubjectID.ToString() + ")";
        }
    }

    private void FillDetails()
    {
        DataTable dt = BINROTA.BUS.Subjects.GetNameAndParentNameBySubjectID(this.SubjectID);
        if (dt.Rows.Count > 0)
        {
            this.PageName = CARETTA.COM.Util.ToUpper(dt.Rows[0]["ParentName"].ToString());
            lblSubjectName.Text = CARETTA.COM.Util.ToUpper(dt.Rows[0]["Name"].ToString());
            UctrlSearchSub1.Title = CARETTA.COM.Util.ToUpper(dt.Rows[0]["Name"].ToString());
        }
        else { BINROTA.COM.Common.GotoDefaultPage(); }

    }

    private void FillLastPages()
    {
        int PageCount = 0;
        DataTable dt = BINROTA.BUS.PageCategories.GetPageCategoriesAll();
        DataTable dtPages = null;
        DataTable dtPageExistanceControl = null;
        foreach (DataRow dr in dt.Rows)
        {
            dtPageExistanceControl = BINROTA.BUS.Pages.GetPageAndMemberDetailBySubjectdIDAndPageTypeID(this.SubjectID, Enumerations.PageType.TravelPage, int.Parse(dr["PageCategoryID"].ToString()));
            if (dtPageExistanceControl.Rows.Count < 1)
            {
                dr.Delete();
            }
            else { 
                //TODO: Oray Çok çakma oldu düzelt
                PageCount = PageCount + 1; }
        
        }
        if (PageCount < 1)
        {
            lbNoPageFound.Visible = true;
        }
        else { lbNoPageFound.Visible = false; }
        dlLastCategories.DataSource = dt;
        dlLastCategories.DataBind();
        foreach (DataListItem dtlItem in dlLastCategories.Items)
        {
            dt = BINROTA.BUS.PageCategories.GetPageCategoriesAll();
            foreach (DataRow dr in dt.Rows)
            {
                if (((Label)dtlItem.FindControl("lbPageCategoryID")).Text == dr["PageCategoryID"].ToString())
                {
                    dtPages = BINROTA.BUS.Pages.GetPageAndMemberDetailBySubjectdIDAndPageTypeID(this.SubjectID, Enumerations.PageType.TravelPage, int.Parse(dr["PageCategoryID"].ToString()));
                    if (dtPages.Rows.Count < 1)
                    {
                        DataRow drPages = dtPages.NewRow();
                        drPages["NickName"] = "";
                        drPages["Title"] = "Henüz bu kategori ile ilgili hiçbir yazý girilmemiþtir.";
                        drPages["MemberID"] = 0;
                        dtPages.Rows.Add(drPages);
                    }
                    ((Repeater)dtlItem.FindControl("rptPages")).DataSource = dtPages;
                    ((Repeater)dtlItem.FindControl("rptPages")).DataBind();
                }
            }

        }
    }
}
