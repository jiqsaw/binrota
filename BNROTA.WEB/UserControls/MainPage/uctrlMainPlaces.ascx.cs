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

public partial class UserControls_MainPage_uctrlMainPlaces : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMainPlaces();
        }
    }

    private void BindMainPlaces()
    {
        DataTable dt = BINROTA.BUS.MarketingGroupsItems.GetSubjectsWantToBeShowed((int)Enumerations.MarketingGroups.OnPlanaCikarilmakIstenenYerler, (DateTime.Now).Date);

        DataTable dtMainPlaces = new DataTable();

        dtMainPlaces.Columns.Add("PhotoPath");
        dtMainPlaces.Columns.Add("Name");
        dtMainPlaces.Columns.Add("SubjectUrl");


        foreach (DataRow dr in dt.Rows)
        {
            DataRow drMainPlaces = dtMainPlaces.NewRow();
            drMainPlaces["PhotoPath"] = dr["PhotoPath"].ToString();
            drMainPlaces["Name"] = dr["Name"].ToString();

            if (int.Parse(dr["SubjectTypeID"].ToString()) == (int)Enumerations.SubjectType.Ulke)
            {
                drMainPlaces["SubjectUrl"] = "CountryDetail.aspx?SubjectID=" + dr["SubjectID"].ToString();
            }
            else if (int.Parse(dr["SubjectTypeID"].ToString()) == (int)Enumerations.SubjectType.Sehir)
            {
                drMainPlaces["SubjectUrl"] = "City.aspx?SubjectID=" + dr["SubjectID"].ToString();
            }
            dtMainPlaces.Rows.Add(drMainPlaces);
        }

        rptMainPlaces.DataSource = dtMainPlaces;
        rptMainPlaces.DataBind();
    }

    protected void rptMainPlaces_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            Image imgMainPlaces = ((Image)e.Item.FindControl("imgMainPlaces"));
            string FileName = ((Image)e.Item.FindControl("imgMainPlaces")).ImageUrl;
            string ImagePath = ConfigurationManager.AppSettings["SubjectImagesUrl"].ToString();
            imgMainPlaces.ImageUrl = BINROTA.COM.Common.ReturnImagePath(FileName, ImagePath);
        }
    }

}
