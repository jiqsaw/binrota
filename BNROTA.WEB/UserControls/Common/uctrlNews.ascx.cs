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

public partial class UserControls_Common_uctrlNews : BaseUserControl
{
    #region Properties
    public int DivWidth
    {
        get
        {
            return (int)(ViewState["DW"] == null ? 257 : ViewState["DW"]);
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
            return (int)(ViewState["DH"] == null ? 207 : ViewState["DH"]);
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
            FillNews();
        }
    }

    private void FillNews()
    {
        DataTable dt = BINROTA.BUS.Activity.GetActivity((int)Enumerations.ActivityType.News, true, true);
        rptNews.DataSource = dt;
        rptNews.DataBind();
    }

    protected void rptNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            Image imgNews = ((Image)e.Item.FindControl("imgNews"));
            string FileName = ((Image)e.Item.FindControl("imgNews")).ImageUrl;
            string ImagePath = ConfigurationManager.AppSettings["ActivityImagesUrl"].ToString();
            imgNews.ImageUrl = BINROTA.COM.Common.ReturnImagePath(FileName, ImagePath);
        }
    }
}
