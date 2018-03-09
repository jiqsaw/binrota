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

public partial class UserControls_Common_uctrlFavoritePlaces : BaseUserControl
{
    #region Properties
    public int DivWidth
    {
        get
        {
            return (int)(ViewState["DW"] == null ? 252 : ViewState["DW"]);
        }
        set
        {
            ViewState["DW"] = value;
        }
    }
    public int DivHeight
    {
        get
        {
            return (int)(ViewState["DH"] == null ? 220 : ViewState["DH"]);
        }
        set
        {
            ViewState["DH"] = value;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dvContent.Attributes.Add("style", "width: " + DivWidth.ToString() + "; height:" + DivHeight.ToString());
            FillFavoritePlaces();
        }
    }

    private void FillFavoritePlaces()
    {
        DataTable dt = BINROTA.BUS.MarketingGroupsItems.GetSubjectsWantToBeShowed((int)Enumerations.MarketingGroups.OnPlanaCikarilmakIstenenYerler, (DateTime.Now).Date);

        DataTable dtFavoritePlaces = new DataTable();

        dtFavoritePlaces.Columns.Add("PhotoPath");
        dtFavoritePlaces.Columns.Add("Name");
        dtFavoritePlaces.Columns.Add("SubjectUrl");
        dtFavoritePlaces.Columns.Add("PageCount");

        foreach (DataRow dr in dt.Rows)
        {
            DataRow drFaviroitePlaces = dtFavoritePlaces.NewRow();
            drFaviroitePlaces["PhotoPath"] = dr["PhotoPath"].ToString();
            drFaviroitePlaces["Name"] = dr["Name"].ToString();

            if (int.Parse(dr["SubjectTypeID"].ToString()) == (int)Enumerations.SubjectType.Ulke)
            {
                drFaviroitePlaces["SubjectUrl"] = "CountryDetail.aspx?SubjectID=" + dr["SubjectID"].ToString();
            }
            else if (int.Parse(dr["SubjectTypeID"].ToString()) == (int)Enumerations.SubjectType.Sehir)
            {
                drFaviroitePlaces["SubjectUrl"] = "City.aspx?SubjectID=" + dr["SubjectID"].ToString();
            }
            DataTable dtPagesCount = BINROTA.BUS.Pages.GetPageCountByPageTypeIDAndSubjectID((int)Enumerations.PageType.TravelPage, int.Parse(dr["SubjectID"].ToString()));
            if (dtPagesCount.Rows.Count > 0)
                drFaviroitePlaces["PageCount"] = "Gezi Yazýsý(" + dtPagesCount.Rows[0]["PageCount"].ToString() + ")";

            dtFavoritePlaces.Rows.Add(drFaviroitePlaces);
        }

        rptFavoritePlaces.DataSource = dtFavoritePlaces;
        rptFavoritePlaces.DataBind();

    }

    protected void rptFavoritePlaces_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            Image imgFavoritePlaces = ((Image)e.Item.FindControl("imgFavoritePlaces"));
            string FileName = ((Image)e.Item.FindControl("imgFavoritePlaces")).ImageUrl;
            string ImagePath = ConfigurationManager.AppSettings["SubjectImagesUrl"].ToString();
            imgFavoritePlaces.ImageUrl = BINROTA.COM.Common.ReturnImagePath(FileName, ImagePath);
        }
    }
}
