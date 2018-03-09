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
using CARETTA.COM;

public partial class UserControls_uctrlAddComment : BaseUserControl
{
    public string TitleText
    {
        get { return lbTitle.Text; }
        set { lbTitle.Text = value; }
    }

    public int PageID
    {
        get
        {
            return (ViewState["PID"] == null ? -1 : int.Parse(ViewState["PID"].ToString()));
        }
        set
        {
            ViewState["PID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("CategoryID");
            DataTable dtCategories = BINROTA.BUS.Categories.GetCategories();
            DataRow dr = dt.NewRow();

            dr["Name"] = "Ana Yazý";
            dr["CategoryID"] = "0";
            dt.Rows.Add(dr);

            foreach (DataRow drCategories in dtCategories.Rows)
            {
                dr = dt.NewRow();
                dr["Name"] = drCategories["Name"];
                dr["CategoryID"] = drCategories["CategoryID"];

                dt.Rows.Add(dr);
            }

            DDLHelper.BindDDL(ref drpCategories, dt, "Name", "CategoryID", "");
        }

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (int.Parse(drpCategories.SelectedValue) == 0)
        {
            BINROTA.BUS.PageComments.PageCommnetInsert(SessRoot.UserID, PageID, txtComment.Text, int.Parse(rblPoints.SelectedItem.Value.ToString()), (int)Enumerations.PageCommentStatus.WaitingApproved);
        }
        else
        {
            DataTable dt = BINROTA.BUS.Pages.GetPageForExistanceControl(PageID, int.Parse(drpCategories.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                BINROTA.BUS.PageComments.PageCommnetInsert(SessRoot.UserID, int.Parse(dt.Rows[0]["PageID"].ToString()), txtComment.Text, int.Parse(rblPoints.SelectedItem.Value.ToString()), (int)Enumerations.PageCommentStatus.WaitingApproved);
            }
        }
        txtComment.Text = "";
        lbMessage.Text = "Yorumunuz eklenmiþtir";
    }
}
