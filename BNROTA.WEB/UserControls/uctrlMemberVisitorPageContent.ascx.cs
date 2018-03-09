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

public partial class UserControls_uctrlMemberVisitorPageContent : BaseUserControl
{
    public event Common.CommentAddClickHandler CommentAddClicked;

    public string Title
    {
        get { return lbTitle.Text; }
        set { lbTitle.Text = value; }
    }

    public string PageCategory
    {
        get { return lbPageCategory.Text;}
        set { lbPageCategory.Text = value; }
    }

    public string TravelDate
    {
        get { return lbTravelDate.Text;}
        set { lbTravelDate.Text = value;}
    }

    public string PageContent
    {
        get { return txtPageContent.Text;}
        set { txtPageContent.Text = value;}
    }

    public int PageID
    {
        get
        {
            return (int)(ViewState["PID"]==null?0:ViewState["PID"]);
        }
        set
        {
            ViewState["PID"] = value;
        }
    }

    private void FillDetails(int PageID)
    {
        this.PageID = PageID; 
        DataTable dt = BINROTA.BUS.Pages.GetPageForExistanceControlByPageType(PageID, (int)Enumerations.PageType.TravelPage);
        DateTime TravelDate;
        if (dt.Rows.Count > 0)
        {
            lbPageCategory.Text = dt.Rows[0]["PageCategoryID"].ToString();
            lbTitle.Text = dt.Rows[0]["Title"].ToString();
            TravelDate = DateTime.Parse(dt.Rows[0]["TravelDate"].ToString());
            lbTravelDate.Text = TravelDate.Day.ToString() + "." + TravelDate.Month.ToString() + "." + TravelDate.Year.ToString();
            txtPageContent.Text = dt.Rows[0]["PageContent"].ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.QueryString["PageID"] != null)
            {
                FillDetails(int.Parse(Request.QueryString["PageID"]));
            }
            else
            {
                Common.GotoDefaultPage(this.Response);
            }
        }
    }
    protected void lnbAddComment_Click(object sender, EventArgs e)
    {
        if (SessRoot == null)
            Common.GotoDefaultPage(this.Response);

        if (CommentAddClicked != null) CommentAddClicked(lbTitle.Text,PageID);
    }
}
