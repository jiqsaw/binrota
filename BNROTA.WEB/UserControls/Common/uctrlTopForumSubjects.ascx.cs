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

public partial class UserControls_MainPage_uctrlTopForumSubjects : BaseUserControl
{
    #region Properties
    public int DivWidth
    {
        get
        {
            return (int)(ViewState["DW"] == null ? 232 : ViewState["DW"]);
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
            BindForumSubjects();
        }

    }

    private void BindForumSubjects()
    {
        DataTable dt = BINROTA.BUS.Forum.GetArticles(1, BINROTA.BUS.Forum.ArticleStatus.NotAnswered);
        rptForumSubjects.DataSource = dt;
        rptForumSubjects.DataBind();
    }
}
