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
//TODO: Devx
//using DevExpress.XtraReports.UI;
using BINROTA.COM;

public partial class MemberPageUpdate2 : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UctrlPageTree1.ChildChange += new ChildChangeEventHandler(TreeChildChange);
        if (!IsPostBack)
        {
            if (SessRoot == null)
            {
                Common.GotoDefaultPage(this.Response);
            }
            ((BinRota)this.Master).SetPageDesc("Ana Sayfam");
            MultiView1.ActiveViewIndex = 0;
            PopulateRepeater();
        }
    }

    private void TreeChildChange(int SubjectID)
    {
        try
        {


            //DataTable dt = BINROTA.BUS.Pages.GetPageForExistanceControl(SessRoot.UserID, SubjectID, (int)Enumerations.PageType.TravelPage);
            DataTable dt = BINROTA.BUS.Pages.GetPageForExistanceControl(SubjectID);//SubjectID aslýnda PageID
            if (dt.Rows.Count > 0)
            {
                DataTable dtCategories = new DataTable();
                int PageID = int.Parse(dt.Rows[0]["PageID"].ToString());
                ((DropDownList)UctrlPageContent1.FindControl("drpPageCategory")).SelectedValue = dt.Rows[0]["PageCategoryID"].ToString();
                ((TextBox)UctrlPageContent1.FindControl("txtTitle")).Text = dt.Rows[0]["Title"].ToString();
                UctrlPageContent1.ContentText = dt.Rows[0]["PageContent"].ToString();

                DateTime TravelDate = DateTime.Parse(dt.Rows[0]["ModifyDate"].ToString());
                UctrlPageContent1.ContentYear = TravelDate.Year;
                UctrlPageContent1.ContentMonth = TravelDate.Month;
                UctrlPageContent1.ContentDay = TravelDate.Day;

                dtCategories = BINROTA.BUS.Categories.GetCategories();
                if (dtCategories.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCategories.Rows.Count; i++)
                    {
                        int CategoryID = int.Parse(dtCategories.Rows[i]["CategoryID"].ToString());
                        UctrlPageCategories1.SetCategoryContent(CategoryID, (BINROTA.BUS.Pages.GetPageForExistanceControl(PageID, CategoryID).Rows[0]["PageContent"]).ToString());
                    }
                }
            }
        }
        catch (Exception)
        {
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataTable dt = BINROTA.BUS.Pages.GetPageForExistanceControl(UctrlPageTree1.SelectedSubjectID);
        if (dt.Rows.Count > 0)
        {
            DateTime TravelDate = new DateTime(UctrlPageContent1.ContentYear, UctrlPageContent1.ContentMonth, UctrlPageContent1.ContentDay);
            BINROTA.BUS.Pages.PagesUpdate(int.Parse(dt.Rows[0]["PageID"].ToString()), int.Parse(dt.Rows[0]["SubjectID"].ToString()),
                int.Parse(((DropDownList)UctrlPageContent1.FindControl("drpPageCategory")).SelectedValue),
                ((TextBox)(UctrlPageContent1.FindControl("txtTitle"))).Text,
                UctrlPageContent1.ContentText, TravelDate,
                "PhotoPathKonulacak", "PhotoCaptionKonulacak", DateTime.Now, SessRoot.UserID, UctrlPageCategories1.GetCategoryContentsHT());
            PopulateRepeater();
        }
    }

    protected void lnbMyMainPage_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        ((BinRota)this.Master).SetPageDesc("Ana Sayfam");
        UctrlUpdateUserDetails1.FillMemberDetails();
    }

    protected void lnbMyTravelPage_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        ((BinRota)this.Master).SetPageDesc("Gezi Yazýlarým");
    }

    protected void lnbUpdateMemberInformation_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        ((BinRota)this.Master).SetPageDesc("Kiþisel Bilgilerim");
    }

    protected void lnbChangePassword_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
        ((BinRota)this.Master).SetPageDesc("Þifremi Deðiþtir");
    }

    protected void btnSaveToPdf_Click(object sender, EventArgs e)
    {
        //TODO: Devx
        //XtraRptForPdfConvert ReportPdf = new XtraRptForPdfConvert();
        //((XRRichText)ReportPdf.FindControl("rtbPageContent", true)).Text = UctrlPageContent1.ContentText;
        //ReportPdf.CreatePdfDocument("c:/pdf/asd.pdf");
    }

    protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            int PageID = int.Parse(e.CommandArgument.ToString());
            //SetComments(PageID);
            DataTable dt = BINROTA.BUS.Pages.GetPageForExistanceControl(PageID);
            if (dt.Rows.Count > 0)
            {
                UctrlPageContent1.ContentText = dt.Rows[0]["PageContent"].ToString();
                UctrlPageContent1.Title = dt.Rows[0]["Title"].ToString();
                DateTime TravelDate = DateTime.Parse(dt.Rows[0]["TravelDate"].ToString());
                UctrlPageContent1.ContentDay = int.Parse( TravelDate.Day.ToString());
                UctrlPageContent1.ContentMonth = int.Parse(TravelDate.Month.ToString());
                UctrlPageContent1.ContentYear = int.Parse(TravelDate.Year.ToString());
                UctrlPageContent1.ContentCategory = int.Parse(dt.Rows[0]["PageCategoryID"].ToString());
            }

            DataTable dtCategories = BINROTA.BUS.Categories.GetCategories();
            UctrlPageCategories1.BindCategories();
            foreach (DataRow dr in dtCategories.Rows)
            {
                dt = BINROTA.BUS.Pages.GetPageForExistanceControl(PageID, int.Parse(dr["CategoryID"].ToString()));
                foreach (DataRow dr1 in dt.Rows)
                {
                    UctrlPageCategories1.SetCategoryContent(int.Parse(dr1["CategoryID"].ToString()), dr1["PageContent"].ToString());
                }
            }
        }
    }

    private void PopulateRepeater()
    {
        string PageContentName;
        DataTable dt = new DataTable();
        try
        {
            dt = BINROTA.BUS.Pages.GetUserPages(SessRoot.UserID, (int)Enumerations.PageType.TravelPage);

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
        catch (Exception)
        {
            
            throw;
        }

    }
}
