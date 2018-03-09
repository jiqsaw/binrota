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

public partial class UserControls_MainPage_uctrlQuestionnaire : BaseUserControl
{
    double TotalVote = 0;

    public string SurveyQuestionID
    {
        get
        {
            return ViewState["sID"].ToString();
        }
        set
        {
            ViewState["sID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateSurvey();
        }
    }

    private void PopulateSurvey()
    {
        DataTable dt = BINROTA.BUS.Survey.GetMainSurveyQuestion();
        if (dt.Rows.Count > 0)
        {
            lbSurveyQuestion.Text = dt.Rows[0]["SurveyQuestion"].ToString();
            this.SurveyQuestionID = dt.Rows[0]["SurveyQuestionID"].ToString();
            dt = BINROTA.BUS.Survey.GetSurveyChoices(int.Parse(dt.Rows[0]["SurveyQuestionID"].ToString()));
            rblSurveyChoices.DataSource = dt;
            rblSurveyChoices.DataBind();
            rblSurveyChoices.SelectedIndex = 0;
        }
    }

    private void ShowSurveyResult()
    {
        DataTable dt = BINROTA.BUS.Survey.GetSurveyResult(int.Parse(this.SurveyQuestionID));
        DataTable dtSurvey = new DataTable();
        double SurveyPercent = 0;

        dtSurvey.Columns.Add("SurveyChoice");
        dtSurvey.Columns.Add("SurveyAnswer");
        dtSurvey.Columns.Add("SurveyResultPercent");

        foreach (DataRow dr in dt.Rows)
            TotalVote = TotalVote + double.Parse(dr["SurveyVoteNumber"].ToString());

        foreach (DataRow dr in dt.Rows)
        {
            DataRow drSurvey = dtSurvey.NewRow();
            drSurvey["SurveyChoice"] = dr["SurveyChoice"].ToString();
            if (TotalVote == 0)
            {
                SurveyPercent = 0;
            }
            else
                SurveyPercent = System.Math.Round(double.Parse(dr["SurveyVoteNumber"].ToString()) * 100 / TotalVote, 2);
            drSurvey["SurveyAnswer"] = "%" + SurveyPercent.ToString() + " | " + dr["SurveyVoteNumber"].ToString() + " Oy";
            dtSurvey.Rows.Add(drSurvey);
        }

        rptSurveyResult.DataSource = dtSurvey;
        rptSurveyResult.DataBind();
        BindSurveyBar();
        pnlSurvey.Visible = false;
        pnlSurveyResult.Visible = true;
    }

    private void BindSurveyBar()
    {
        DataTable dt = BINROTA.BUS.Survey.GetSurveyResult(int.Parse(this.SurveyQuestionID));

        foreach (DataRow dr in dt.Rows)
        {
            double SurveyPercent = 0;
            if (TotalVote == 0)
                SurveyPercent = 0;
            else
                SurveyPercent = double.Parse(dr["SurveyVoteNumber"].ToString()) * 100 / TotalVote;

            foreach (RepeaterItem rptitem in rptSurveyResult.Items)
            {
                if (((Label)rptitem.FindControl("lbSurveyChoice")).Text == dr["SurveyChoice"].ToString())
                    ((Image)rptitem.FindControl("imgSurveyResultBar")).Width = Convert.ToInt16(SurveyPercent);
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (SessRoot == null)
        {
            BINROTA.BUS.Survey.AnswerInsert(0, int.Parse(this.SurveyQuestionID), int.Parse(rblSurveyChoices.SelectedValue));
        }
        else
        {
            DataTable dt = BINROTA.BUS.Survey.GetUserAnswer(SessRoot.UserID, int.Parse(this.SurveyQuestionID));
            if (dt.Rows.Count == 0)
            {
                BINROTA.BUS.Survey.AnswerInsert(SessRoot.UserID, int.Parse(this.SurveyQuestionID), int.Parse(rblSurveyChoices.SelectedValue));
            }
            else
            {
                lbSurveyQuestion.Text = "Ankete sadece bir kere oy kullanabilirsiniz";

            }
        }
        ShowSurveyResult();
    }

    protected void lnbSurveyResult_Click(object sender, EventArgs e)
    {
        ShowSurveyResult();
    }

}
