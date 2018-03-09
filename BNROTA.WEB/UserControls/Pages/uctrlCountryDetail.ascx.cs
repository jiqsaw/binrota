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
using BINROTA.COM;

public partial class UserControls_Pages_uctrlCountryDetail : BaseUserControl
{

    private string PageName;

    public int SubjectID
    {
        get
        {
            return int.Parse(ViewState["sID"].ToString());
        }
        set
        {
            ViewState["sID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["SubjectID"] == null || !Util.IsNumeric(Request.QueryString["SubjectID"]) || Request.QueryString["SubjectID"] == "") Common.GotoDefaultPage(this.Response);
            ViewState["sID"] = int.Parse(Request.QueryString["SubjectID"]);
            FillCountryDetail();
            FillCities();
            FillCountryPages();
            uctrlTopAuthorsSub1.FillAuthors(this.PageName, this.SubjectID);
            hplAddPAge.NavigateUrl = "javascript:OpenAddPagesBySubjectID(" + this.SubjectID.ToString() + ")";
            imgCountry.Attributes.Add("onerror", "this.src='Images/Design/NoPictureForSubject.png';");
        }
    }

    private void FillCountryDetail()
    {
        DataTable dt = BINROTA.BUS.Subjects.GetSubject(this.SubjectID);
        if (dt.Rows.Count > 0)
        {
            if (int.Parse(dt.Rows[0]["SubjectTypeID"].ToString()) != (int)Enumerations.SubjectType.Ulke) Common.GotoDefaultPage(this.Response);
            lbCountryName.Text = CARETTA.COM.Util.ToUpper(dt.Rows[0]["Name"].ToString());

            uctrlSearchSub1.Title = CARETTA.COM.Util.ToUpper(dt.Rows[0]["Name"].ToString());

            this.PageName = CARETTA.COM.Util.ToUpper(dt.Rows[0]["Name"].ToString());
            lbPagesTitle.Text = CARETTA.COM.Util.ToUpper(dt.Rows[0]["Name"].ToString());
            lbDescription.Text = dt.Rows[0]["Description"].ToString();
            if (dt.Rows[0]["PhotoPath"].ToString() == "")
            {
                imgCountry.ImageUrl = "~/Images/Design/NoPictureForSubject.png";
                imgCountry.BorderStyle = BorderStyle.None;
                //tdImage.Visible = false;
            }
            else
            {
                imgCountry.ImageUrl = Common.ReturnImagePath(dt.Rows[0]["PhotoPath"].ToString(), ConfigurationManager.AppSettings["SubjectImagesUrl"].ToString());
            }

            dt = BINROTA.BUS.SubjectCustomization.GetSubjectCustomization(this.SubjectID);

            if (dt.Rows.Count > 0)
            {
                lbArea.Text = dt.Rows[0]["Area"].ToString();
                lbAreaCode.Text = dt.Rows[0]["AreaCode"].ToString();
                lbCapital.Text = dt.Rows[0]["Capital"].ToString();
                lbCurrency.Text = dt.Rows[0]["Currency"].ToString();
                lbLanuage.Text = dt.Rows[0]["Language"].ToString();
                lbLocation.Text = dt.Rows[0]["Location"].ToString();
                lbNeighbourhood.Text = dt.Rows[0]["Neighbourhood"].ToString();
                lbPopulatiob.Text = dt.Rows[0]["Population"].ToString();
                lbReligion.Text = dt.Rows[0]["Religion"].ToString();
                lbTimeZone.Text = dt.Rows[0]["TimeZone"].ToString();
                lbDescription.Text = dt.Rows[0]["Description"].ToString();
            }
        }
        else
            Common.GotoDefaultPage(this.Response);
    }

    private void FillCities()
    {
        DataTable dt = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(this.SubjectID);
        DataTable dtNew = new DataTable();
        dtNew.Columns.Add("Name");
        dtNew.Columns.Add("Url");
        DataRow dr = dtNew.NewRow();
        dr["Name"] = "Ülke Genel";
        dr["Url"] = "Search.aspx?SubjectID=" + this.SubjectID;
        dtNew.Rows.Add(dr);
        foreach (DataRow dr1 in dt.Rows)
        {
            DataRow drNew = dtNew.NewRow();
            drNew["Name"] = dr1["Name"];
            drNew["Url"] = "CityDetail.aspx?SubjectID=" + dr1["SubjectID"].ToString();
            dtNew.Rows.Add(drNew);
        }

        dlCities.DataSource = dtNew;
        dlCities.DataBind();

    }

    private void FillCountryPages()
    {
        //DataTable dtPages = new DataTable();
        //dtPages.Columns.Add("Name");
        //dtPages.Columns.Add("NickName");
        //dtPages.Columns.Add("Title");

        DataTable dt = BINROTA.BUS.Pages.GetLast5PagesRecorded((int)Enumerations.PageType.TravelPage, this.SubjectID);

        //foreach (DataRow dr in dt.Rows)
        //{
        //    DataRow drPages = dtPages.NewRow();

        //    drPages["Name"] = dr["Name"].ToString();
        //    drPages["NickName"] = dr["NickName"].ToString();
        //    drPages["Title"] = dr["Title"].ToString();

        //    dtPages.Rows.Add(drPages);
        //}

        if (dt.Rows.Count > 0)
        {
            rptLastPages.DataSource = dt;
            rptLastPages.DataBind();
        }
        else {
            trLastPages.Visible = false;
        }
    }

}
