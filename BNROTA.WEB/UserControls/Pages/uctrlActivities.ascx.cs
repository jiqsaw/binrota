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
using BINROTA.BUS;
using CARETTA.COM;

public partial class UserControls_Pages_uctrlActivities : BaseUserControl
{
    #region Properties
    public DateTime ActivityDate
    {
        get { return (DateTime)(ViewState["AD"] == null ? new DateTime(DateTime.Now.Year,DateTime.Now.Month,1) :  (DateTime)ViewState["AD"]); }
        set { ViewState["AD"]=value; }
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDateDDL();
            BindCalendar();
        }
    }

    private void BindDateDDL()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Date");
        dt.Columns.Add("Value");
        for (int i = 2007; i <= 2008; i++)
            for (int j = 1; j <= 12; j++)
            {
                if ((i == 2008) || (j > 10 && i == 2007))
                {
                    DataRow dr = dt.NewRow();
                    DateTime date = new DateTime(i, j, 1);
                    dr["Date"] = string.Format("{0:Y}", date);
                    dr["Value"] = date.Month.ToString() + date.Year.ToString();
                    dt.Rows.Add(dr);
                }
            }

        DDLHelper.BindDDL(ref ddlDate, dt, "Date", "Value", "", "", "");

        ddlDate.SelectedValue = ActivityDate.Month.ToString() + ActivityDate.Year.ToString();
    }

    private void BindCalendar()
    {
        //////////////////////Days
        DataTable dtDays = new DataTable();
        dtDays.Columns.Add("DayName");

        for (int i = 0; i < 7; i++)
        {
            DataRow dr = dtDays.NewRow();
            dr["DayName"] = ((Activity.DaysOfWeek)i).ToString();
            dtDays.Rows.Add(dr);
        }

        rptDays.DataSource = dtDays;
        rptDays.DataBind();

        /////////////////////Activities
        int DaysBeforeMonth;
        int DaysAfterMonth;
        int MaxDaysBeforeMonth;
        int DaysCount;
        DataTable dtActivities = new DataTable();

        dtActivities.Columns.Add("CssClass");
        dtActivities.Columns.Add("DayNo");
        dtActivities.Columns.Add("Activities"); 


        DateTime tmpDate = new DateTime(ActivityDate.Year, ActivityDate.Month, 1);
        DaysCount = Convert.ToInt32(Common.DateDiff("DD", tmpDate, tmpDate.AddMonths(1)));
        MaxDaysBeforeMonth = Convert.ToInt32(Common.DateDiff("DD", tmpDate.AddMonths(-1), tmpDate));

        DaysBeforeMonth = ((int)Activity.ConvertDayOfWeek(tmpDate.DayOfWeek));
        DateTime CStartDate = tmpDate.AddDays(DaysBeforeMonth * -1);
        DateTime CEndDate = tmpDate.AddDays(DaysCount-1);

        DaysAfterMonth = 6 - (int)Activity.ConvertDayOfWeek(CEndDate.DayOfWeek);
        CEndDate = CEndDate.AddDays(DaysAfterMonth);


        DataTable dtDBActivities = Activity.GetActivityByDate((int) Enumerations.ActivityType.Activity,CStartDate,CEndDate.AddDays(1), true);

        tmpDate = CStartDate;
        dtDBActivities.DefaultView.Sort = "StartDate asc";
        int ActiveActivity = 0;

        for (int i = 1; i <= (DaysBeforeMonth + DaysAfterMonth + DaysCount); i++)
        {
            DataRow dr = dtActivities.NewRow();

            dr["CssClass"] = "CalendarPassive";

            if (DaysBeforeMonth >= i)
            {
                dr["DayNo"] = ((int)(MaxDaysBeforeMonth - DaysBeforeMonth + i)).ToString();
                dr["CssClass"] = "CalendarOutDate";
            }
            else if (i <= ((DaysBeforeMonth + DaysAfterMonth + DaysCount) - DaysAfterMonth))
                dr["DayNo"] = ((int)(i - DaysBeforeMonth)).ToString();
            else
            {
                dr["DayNo"] = ((int)(i - DaysCount - DaysBeforeMonth)).ToString();
                dr["CssClass"] = "CalendarOutDate";
            }

            bool HasActivity = false;

            //Activity.ConvertDayOfWeek(tmpDate.DayOfWeek) = dtDBActivities.Rows.Count % 7;

            for(;;)
            {
                if (ActiveActivity < dtDBActivities.Rows.Count)
                {
                    DateTime StartDate = DateTime.Parse(dtDBActivities.DefaultView[ActiveActivity]["StartDate"].ToString());
                    if (StartDate.Day == tmpDate.Day)
                    { 
                        dr["CssClass"] = "CalendarActive";
                        dr["Activities"] =dr["Activities"]+ "<a href='ActivityDetail.aspx?ActiviyID=" + dtDBActivities.DefaultView[ActiveActivity]["ActivityTitle"] + "' class='Treb clWhite'> -" + dtDBActivities.DefaultView[ActiveActivity]["ActivityTitle"] + "</a><br>";
                        ActiveActivity += 1;
                        HasActivity = true;
                    }
                    else
                    {
                        if (HasActivity == false)
                        {
                            dr["Activities"] = "";
                        }

                        break;
                    }
                }
                else
                    break;
            }

            dtActivities.Rows.Add(dr);
            tmpDate = tmpDate.AddDays(1);
        }

        dlCalendar.DataSource = dtActivities;
        dlCalendar.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int date = int.Parse(ddlDate.SelectedValue);
        this.ActivityDate = new DateTime(date % 10000, date / 10000, 1);
        BindCalendar(); 
    }
}
