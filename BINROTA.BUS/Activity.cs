using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BINROTA.COM;

namespace BINROTA.BUS
{
    public class Activity
    {
        public enum DaysOfWeek
        { 
            Pazartesi=0,
            Salý=1,
            Çarþamba=2,
            Perþembe=3,
            Cuma=4,
            Cumartesi=5,
            Pazar =6
        }

        public static DaysOfWeek ConvertDayOfWeek(DayOfWeek day)
        {
            if (day == DayOfWeek.Sunday)
                return (DaysOfWeek)6;

            return (DaysOfWeek)(((int)day) - 1);
        }

        public static DataTable GetActivity(int ActivityType, bool isActive, bool isMain)
        {
            BINROTA.DAL.Activity objAct = new BINROTA.DAL.Activity();
            objAct.ActivityType = ActivityType;
            objAct.isActive = isActive;
            objAct.isMain = isMain;
            return objAct.LoadByParams().Tables[0];
        }

        public static DataTable GetActivity(int ActivtyID, bool isActive)
        {
            BINROTA.DAL.Activity objAct = new BINROTA.DAL.Activity();
            objAct.ActivityID = ActivtyID;
            objAct.isActive = isActive;
            return objAct.LoadByParams().Tables[0];
        }

        public static DataTable GetActivityByDate(int ActivityType, DateTime StartDate, DateTime EndDate, bool isActive)
        {
            return BINROTA.DAL.Activity.GetActivityByDate(ActivityType,StartDate,EndDate, isActive);
        }

        public static DataTable GetActivityByDate(int ActivityType, int ActivityYear, int ActivityMonth, bool isActive)
        {
            return BINROTA.DAL.Activity.GetActivityByDate(ActivityType, ActivityYear, ActivityMonth, isActive);
        }

        public static DataTable GetLastActivity(int ActivityType, bool isActive)
        {
            return BINROTA.DAL.Activity.GetLastActivity(ActivityType, isActive);
        }
        
    }
}
