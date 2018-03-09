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

public partial class UserControls_MainPage_uctrlMainNews : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindNews();
        }
    }

    private void BindNews()
    {
        DataTable dt = BINROTA.BUS.Activity.GetActivity((int)Enumerations.ActivityType.News, true, true);
        if (dt.Rows.Count > 0)
        {
            imgMNews.ImageUrl = BINROTA.COM.Common.ReturnImagePath(dt.Rows[0]["PhotoPath"].ToString(), ConfigurationManager.AppSettings["ActivityImagesUrl"].ToString());
            hplMTitle.Text = dt.Rows[0]["ActivityTitle"].ToString();
            hplMTitle.NavigateUrl = "~/News.aspx?ActivityID=" + dt.Rows[0]["ActivityID"].ToString();
            lbMDescription.Text = dt.Rows[0]["Description"].ToString();
            hplDetails.NavigateUrl = "~/News.aspx?ActivityID=" + dt.Rows[0]["ActivityID"].ToString();

            dt.Rows[0].Delete();

            rptNews.DataSource = dt;
            rptNews.DataBind();
        }

    }
    protected void rptNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) {
            string FileName = ((Image)e.Item.FindControl("imgNews")).ImageUrl;
            string ImagePath = ConfigurationManager.AppSettings["ActivityImagesUrl"].ToString();
            ((Image)e.Item.FindControl("imgNews")).ImageUrl = BINROTA.COM.Common.ReturnImagePath(FileName, ImagePath);
        }
    }
}
