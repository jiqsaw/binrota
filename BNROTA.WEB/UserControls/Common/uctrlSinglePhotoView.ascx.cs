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

public partial class UserControls_Common_uctrlSinglePhotoView : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["PhotoPath"] != null)
            {
                imgPhoto.ImageUrl = BINROTA.COM.Common.ReturnImagePath(CARETTA.COM.Util.ClearString(Request.QueryString["PhotoPath"]), ConfigurationManager.AppSettings["MemberAlbumImagesUrlBig"].ToString());
            }
        }
    }

}
