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

public partial class ADMIN_UserControls_uctSurvey : System.Web.UI.UserControl
{
    private bool isSuccess;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SaveCtrl();
        }
    }

    private void SaveCtrl()
    {
        if (CARETTA.COM.Util.IsNumeric(Request.QueryString["isSuccess"]))
        {
            this.isSuccess = Convert.ToBoolean(Convert.ToInt16(Request.QueryString["isSuccess"].ToString()));
            if (isSuccess)
            {
                dvAlert.InnerHtml = "<script>alert('ANKET BAÞARIYLA KAYDEDÝLDÝ')</script>";
            }
            else
            {
                dvAlert.InnerHtml = "<script>alert('HATA!.. Anket eklenirken hata Oluþtu')</script>";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e) { 
    
    }
}
