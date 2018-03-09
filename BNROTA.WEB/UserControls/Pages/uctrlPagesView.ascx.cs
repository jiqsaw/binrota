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

public partial class UserControls_Pages_uctrlPagesView : BaseUserControl
{
    public int MemberID
    {
        get { return (ViewState["MemberID"] == null ? -1 : int.Parse(ViewState["MemberID"].ToString())); }
        set { ViewState["MemberID"] = value; }
    }

    public int PageLoadType
    {
        get { return (int)(ViewState["PLT"] == null ? -1 : ViewState["PLT"]); }
        set { ViewState["PLT"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
                UserControl();
                FillPages();
                FillCommands();
            
        }
    }

    private void UserControl()
    {
        DataTable dt = null;
        if (CARETTA.COM.Util.IsNumeric(Request.QueryString["MemberID"]))
        {
            this.MemberID = int.Parse(Request.QueryString["MemberID"]);
            dt = BINROTA.BUS.Members.GetMemberDetailsByMemberID(this.MemberID);
            if (SessRoot == null)
            {
                this.MemberID = int.Parse(Request.QueryString["MemberID"]);
                this.PageLoadType = (int)Enumerations.PageLoadType.Visitor;
            }
            else if (SessRoot.UserID != this.MemberID)
            {
                this.MemberID = int.Parse(Request.QueryString["MemberID"]);
                this.PageLoadType = (int)Enumerations.PageLoadType.Visitor;
            }
            else if (SessRoot.UserID == this.MemberID)
            {
                this.MemberID = SessRoot.UserID;
                this.PageLoadType = (int)Enumerations.PageLoadType.Member;
            }
        }
        else if (SessRoot != null)
        {
            this.MemberID = SessRoot.UserID;
            this.PageLoadType = (int)Enumerations.PageLoadType.Member;
        }
        else Common.GotoDefaultPage(this.Response);


    }
    protected void rptPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((Enumerations.PageLoadType)this.PageLoadType == Enumerations.PageLoadType.Visitor)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                e.Item.FindControl("hplEdit").Visible = false;
                e.Item.FindControl("btnPageDelete").Visible = false;
            }
        }
    }

    private void FillPages()
    {
        DataTable dt = BINROTA.BUS.Pages.GetUserPages(this.MemberID, (int)Enumerations.PageType.TravelPage);
        if (dt.Rows.Count < 1)
        {
            trPages.Visible = true;
        }

        UctrlPagings1.GeneratePager(ref dt, rptPages);
        

        foreach (RepeaterItem rptitem in rptPages.Items)
        {
            ((ImageButton)rptitem.FindControl("btnPageDelete")).Attributes.Add("onclick", "return confirm('Yazýyý silmek istediðinizden emin misiniz?');");
        }
    }

    protected void btnPageDelete_Click(object sender, EventArgs e)
    {
        BINROTA.BUS.Pages.DeletePage(int.Parse(((ImageButton)sender).CommandArgument));
        FillPages();
    }

    private void FillCommands()
    {
        DataTable dt = BINROTA.BUS.PageComments.GetMemberComments(this.MemberID);
        //DataTable dtComments = new DataTable();
        //dtComments.Columns.Add("Comment");
        //dtComments.Columns.Add("NavigateUrl");

        //foreach (DataRow dr in dt.Rows)
        //{
        //    DataRow drComments = dtComments.NewRow();
        //    drComments["Comment"] = dr["Comment"].ToString();
        //    //TODO: Oray. Nereye gideceði belli olunca NavigateUrl eklenecek
        //    drComments["NavigateUrl"] = "~/MainPageN.aspx";

        //    dtComments.Rows.Add(drComments);
        //}
        //foreach (DataRow dr in dt.Rows)
        //{
        //    dr["Comment"] = CARETTA.COM.Util.Left(dr["Comment"].ToString(), 80);
        //}


        if (dt.Rows.Count < 1)
        {
            trComments.Visible = true;
        }
        rptComments.DataSource = dt;
        rptComments.DataBind();
    }


}
