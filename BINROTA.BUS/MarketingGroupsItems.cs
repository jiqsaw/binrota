using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BINROTA.DAL;
using CARETTA.COM;
using BINROTA.COM; 

namespace BINROTA.BUS
{
    public class MarketingGroupsItems
    {
        public static DataTable GetSubjectsWantToBeShowed(int MarketingGroupID, DateTime ValidityDate)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.MarketingGroupsItems.GetSubjectsWantsToBeShowed(MarketingGroupID, ValidityDate);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }
    }
}
