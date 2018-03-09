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

public partial class UserControls_MainPage_uctrlLastTripSubjects : BaseUserControl
{
    #region Properties
    public int DivWidth
    {
        get
        {
            return (int)(ViewState["DW"] == null ? 334 : ViewState["DW"]);
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
            BindTripSubjects();

            dvContent.Attributes.Add("style", "width: " + DivWidth.ToString() + "; height:" + DivHeight.ToString());
        }
    }

    private void BindTripSubjects()
    {
        DataTable dt = BINROTA.BUS.Pages.GetLast5PagesRecorded((int)Enumerations.PageType.TravelPage);

        rptLastTripSubjects.DataSource = dt;
        rptLastTripSubjects.DataBind();
    }
}
