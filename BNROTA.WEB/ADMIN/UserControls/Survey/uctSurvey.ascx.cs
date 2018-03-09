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
    private int m_SurveyID;
    public int SurveyID
    {
        get { return m_SurveyID; }
        set { m_SurveyID = value; }
    }

    public DataTable dtNewChoices
    {
        get { return (ViewState["dtChoices"] == null ? InitailizeNewChoices() : (DataTable)ViewState["dtChoices"]); }
        set { ViewState["dtChoices"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EditCtrl();
        }
    }

    private void EditCtrl()
    {

        if (CARETTA.COM.Util.IsNumeric(Request.QueryString["SurveyID"]))
        {
            this.SurveyID = int.Parse(Request.QueryString["SurveyID"]);
            DataTable dtSurveyDetail = BINROTA.BUS.Survey.GetSurveyDetails(this.SurveyID);

            DataTable dtChoices = InitailizeNewChoices();
            foreach (DataRow dr in dtSurveyDetail.Rows)
            {
                dtChoices.Rows.Add(dr["SurveyChoiceID"].ToString(), dr["SurveyChoice"].ToString(), dr["SurveyVoteNumber"].ToString());
            }
            this.dtNewChoices = dtChoices;
            if (dtSurveyDetail.Rows.Count > 0) {
                pnlEdit.Visible = true;
                txtSurveyQuestion.Text = dtSurveyDetail.Rows[0]["SurveyQuestion"].ToString();
                ddlisMain.SelectedValue = dtSurveyDetail.Rows[0]["isMain"].ToString();
                ddlisActive.SelectedValue = dtSurveyDetail.Rows[0]["isActive"].ToString();
                rptChoises.DataSource = this.dtNewChoices;
                rptChoises.DataBind();
            }
        }
    }

    public void ToFinish(string Message) {
        dvAlert.Visible = true;
        ltlMessage.Text = Message;
    }

    protected void btnSave_Click(object sender, EventArgs e) {
        if (this.dtNewChoices.Rows.Count > 0)
        {
            BINROTA.BUS.Survey objSurvey = new BINROTA.BUS.Survey();
            objSurvey.Save(this.SurveyID, bool.Parse(ddlisActive.SelectedValue), bool.Parse(ddlisMain.SelectedValue), txtSurveyQuestion.Text, this.dtNewChoices);
            ToFinish("ANKET BAÞARIYLA KAYDEDÝLDÝ");
        }
        else {
            ToFinish("HATA!.. Anket için seçenekleri ekleyiniz.");
        }
    }
    protected void lnkAddChoice_Click(object sender, EventArgs e)
    {
        AddChoice(txtNewChoice.Text.Trim(), Convert.ToInt32(txtNewChoiceVote.Text.Trim()));
        pnlEdit.Visible = true;
        rptChoises.DataSource = this.dtNewChoices;
        rptChoises.DataBind();
    }

    private void AddChoice(string Choice, int VoteNumber) {
        DataTable dtChoice = this.dtNewChoices;
        DataRow drChoice = dtChoice.NewRow();
        drChoice["SurveyChoiceID"] = dtChoice.Rows.Count + 1;
        drChoice["SurveyChoice"] = Choice;
        drChoice["SurveyVoteNumber"] = VoteNumber;
        dtChoice.Rows.Add(drChoice);
        this.dtNewChoices = dtChoice;
    }
    private DataTable InitailizeNewChoices() {
        DataTable dtNewChoice = new DataTable();
        dtNewChoice.Columns.AddRange(new DataColumn[] { new DataColumn("SurveyChoiceID"), new DataColumn("SurveyChoice"), new DataColumn("SurveyVoteNumber") });
        return dtNewChoice;
    }

    protected void rptChoises_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            int ChoiceID = Convert.ToInt32(e.CommandArgument);
            DataTable dtChoices = this.dtNewChoices;
            foreach (DataRow dr in dtChoices.Rows)
            {
                if (Convert.ToInt32(dr["SurveyChoiceID"]) == ChoiceID) {
                    dtChoices.Rows.Remove(dr);
                    break;
                }
            }
            this.dtNewChoices = dtChoices;
            rptChoises.DataSource = dtChoices;
            rptChoises.DataBind();
        }
    }
}
