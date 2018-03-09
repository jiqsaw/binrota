using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BINROTA.DAL;
using CARETTA.COM;

namespace BINROTA.BUS
{
    public class SubjectCustomization
    {

    /*    public int SaveSubjectCustomization(BINROTA.BUS.Enumerations.SaveMode SaveMode, int SubjectCustomizationID, int SubjectTypeID, int SubjectID, string Location, string Capital, string Area, string Neighbourhood, int Population, string Currency, string AreaCode, string TimeZone, string Language, string Religion)
        {
            BINROTA.DAL.SubjectCustomization objSub = new BINROTA.DAL.SubjectCustomization();
            if (SaveMode == Enumerations.SaveMode.Update)
            {
               objSub.Load(SubjectCustomizationID);
            }
            objSub.SubjectTypeID = SubjectTypeID;
            objSub.SubjectID = SubjectID;
            objSub.Location = Location;
            objSub.Capital = Capital;
            objSub.Area = Area;
            objSub.Neighbourhood = Neighbourhood;
            objSub.Population = Population;
            objSub.Currency = Currency;
            objSub.AreaCode = AreaCode;
            objSub.TimeZone = TimeZone;
            objSub.Language = Language;
            objSub.Religion = Religion;
            return objSub.Save();
        }*/
        public static int SubjectCustomizationInsert(int SubjectTypeID, int SubjectID, string Location, string Capital, string Area, string Neighbourhood, string Population, string Currency, string AreaCode, string TimeZone, string Language, string Religion)
        {
            BINROTA.DAL.SubjectCustomization objSub = new BINROTA.DAL.SubjectCustomization();
            objSub.Area = Area;
            objSub.AreaCode = AreaCode;
            objSub.Capital = Capital;
            objSub.Currency = Currency;
            objSub.Language = Language;
            objSub.Location = Location;
            objSub.Neighbourhood = Neighbourhood;
            objSub.Population = Population;
            objSub.SubjectID = SubjectID;
            objSub.SubjectTypeID = SubjectTypeID;
            objSub.TimeZone = TimeZone;
            return objSub.Save();
        }

        public static DataTable GetSubjectCustomization(int SubjectID)
        {

            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.SubjectCustomization.GetSubjectCustomization(SubjectID);
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
