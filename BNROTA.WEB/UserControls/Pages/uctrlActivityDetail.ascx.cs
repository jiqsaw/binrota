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

public partial class UserControls_Pages_uctrlActivityDetail : BaseUserControl
{
    public int ActivityID
    {
        get
        {
            return int.Parse(ViewState["aID"].ToString());
        }
        set
        {
            ViewState["aID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (CARETTA.COM.Util.IsNumeric(Request.QueryString["ActivityID"]))
            {
                this.ActivityID = int.Parse(Request.QueryString["ActivityID"]);

            }
            else
            {
                this.ActivityID = 0;
            }

            BindDDL();
            FillActivityContent();
        }
    }

    private void BindDDL()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Date");
        dt.Columns.Add("Value");
        for (int i = 2007; i <= DateTime.Today.Year; i++)
            for (int j = 1; j <= DateTime.Today.Month; j++)
            {
                DataRow dr = dt.NewRow();
                DateTime date = new DateTime(i, j, 1);
                dr["Date"] = string.Format("{0:Y}", date);
                dr["Value"] = date.Month.ToString() + date.Year.ToString();
                dt.Rows.Add(dr);
            }
        DDLHelper.BindDDL(ref drpActivityDate, dt, "Date", "Value", "", "Tarih Seçiniz", "0");
    }

    private void FillActivityContent()
    {
        DataTable dt = new DataTable();
        if (this.ActivityID == 0)
        {
            dt = BINROTA.BUS.Activity.GetLastActivity((int)Enumerations.ActivityType.Activity, true);
        }
        else
        {
            dt = BINROTA.BUS.Activity.GetActivity(this.ActivityID, true);
        }
        if (dt.Rows.Count > 0)
        {
            lbTitle.Text = dt.Rows[0]["ActivityTitle"].ToString();
            ltrActivityContent.Text = dt.Rows[0]["ActivityContent"].ToString();
            DateTime date = DateTime.Parse(dt.Rows[0]["StartDate"].ToString());
            FillActivities(date.Year, date.Month);
            drpActivityDate.SelectedValue = date.Month.ToString() + date.Year.ToString();
        }
    }

    private void FillActivities(int Year, int Month)
    {
        DataTable dt = BINROTA.BUS.Activity.GetActivityByDate((int)Enumerations.ActivityType.Activity, Year, Month, true);

        foreach (DataRow dr in dt.Rows)
        {
            dr["PhotoPath"] = BINROTA.COM.Common.ReturnImagePath(dr["PhotoPath"].ToString(), ConfigurationManager.AppSettings["ActivityImagesUrl"].ToString()); ;
        }

        rptActivity.DataSource = dt;
        rptActivity.DataBind();
    }
    protected void drpActivityDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        int date = int.Parse(drpActivityDate.SelectedValue);
        FillActivities(date % 10000, date / 10000);
        lbTitle.Text = "";
        ltrActivityContent.Text = "";
    }
}
