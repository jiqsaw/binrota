using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BINROTA.DAL;
using CARETTA.COM;

namespace BINROTA.BUS
{
    public class Subjects
    {
        public static DataTable GetSubject(int SubjectID)
        {

            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.Subjects.GetSubject(SubjectID);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetSubjectCity(int SubjectID)
        {

            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.Subjects.GetSubjectCity(SubjectID);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetSubjectRegion(int SubjectID)
        {

            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.Subjects.GetSubjectCity(SubjectID);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static Enumerations.SubjectInsertResult SubjectsInsertCountry(string Name, string Description, string PhotoPath, string PhotoCaption, int ParentSubjectID, int SubjectTypeID, DateTime ModifyDate, int ModifiedBy, string Location, string Capital, string Area, string Neighbourhood, string Population, string Currency, string AreaCode, string TimeZone, string Language, string Religion)
        {
            {
                try
                {
                    return (Enumerations.SubjectInsertResult)BINROTA.DAL.Subjects.SubjectsInsertCountry(Name, Description, PhotoPath, PhotoCaption, ParentSubjectID, SubjectTypeID, ModifyDate, ModifiedBy, Location, Capital, Area, Neighbourhood, Population, Currency, AreaCode, TimeZone, Language, Religion);
                }
                catch (Exception)
                {
                    throw;
                }

            }

        }

        public static Enumerations.SubjectInsertResult SubjectsInsertCity(string Name, string Description, string PhotoPath, string PhotoCaption, int ParentSubjectID, int SubjectTypeID, DateTime ModifyDate, int ModifiedBy)
        {
            try
            {
                int InsertResult=0;
                BINROTA.DAL.Subjects.InsertSubject(Name, Description, PhotoPath, PhotoCaption, ParentSubjectID, SubjectTypeID, ModifyDate, ModifiedBy,ref InsertResult);
                return (Enumerations.SubjectInsertResult)InsertResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Enumerations.SubjectInsertResult SubjectsInsertRegion(string Name, string Description, string PhotoPath, string PhotoCaption, int ParentSubjectID, int SubjectTypeID, DateTime ModifyDate, int ModifiedBy)
        {
            try
            {
                int InsertResult =0;
                BINROTA.DAL.Subjects.InsertSubject(Name, Description, PhotoPath, PhotoCaption, ParentSubjectID, SubjectTypeID, ModifyDate, ModifiedBy,ref InsertResult);

                return (Enumerations.SubjectInsertResult)InsertResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Enumerations.SubjectInsertResult SubjectsInsertContinent(string Name, string Description, string PhotoPath, string PhotoCaption, int SubjectTypeID, DateTime ModifyDate, int ModifiedBy)
        {
            try
            {
                int InsertResult=0;
                BINROTA.DAL.Subjects.InsertSubject(Name, Description, PhotoPath, PhotoCaption,0, SubjectTypeID, ModifyDate, ModifiedBy,ref InsertResult);

                return (Enumerations.SubjectInsertResult)InsertResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SubjectsCountryUpdate(int SubjectID, string Name, string Description, string PhotoPath, int ModifiedBy, string Location, string Capital, string Area, string Neighbourhood, string Population, string Currency, string AreaCode, string TimeZoneCountry, string Language, string Religion, int NewParentSubjectID)
        {
            try
            {
                BINROTA.DAL.Subjects.SubjectsCountryUpdate(SubjectID, Name, Description, PhotoPath, ModifiedBy, Location, Capital, Area, Neighbourhood, Population, Currency, AreaCode, TimeZoneCountry, Language, Religion, NewParentSubjectID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SubjectsCountryUpdate(int SubjectID, string Name, string Description, string PhotoPath, string PhotoCaption, int ModifiedBy, string Location, string Capital, string Area, string Neighbourhood, string Population, string Currency, string AreaCode, string TimeZoneCountry, string Language, string Religion, int NewParentSubjectID)
        {
            string oldFile = "";

                BINROTA.DAL.Subjects objSub = new BINROTA.DAL.Subjects();
                objSub.Load(SubjectID);
                try
                {
                    if (objSub.PhotoPath != null)
                    {
                        oldFile = objSub.PhotoPath;
                    }
                    else
                    {
                        oldFile = "";
                    }
                }
                catch (Exception)
                {
                    oldFile = "";
                }

                BINROTA.DAL.Subjects.SubjectsCountryUpdate(SubjectID, Name, Description, PhotoPath, PhotoCaption, ModifiedBy, Location, Capital, Area, Neighbourhood, Population, Currency, AreaCode, TimeZoneCountry, Language, Religion, NewParentSubjectID);
                if (System.IO.File.Exists(oldFile))
                    System.IO.File.Delete(oldFile);
                

        }

        public static void SubjectsCityUpdate(int SubjectID, string Name, string Description, string PhotoCaption, int NewParentSubjectID, int ModifiedBy)
        {
            try
            {
                BINROTA.DAL.Subjects.SubjectsCityUpdate(SubjectID, Name, Description, PhotoCaption, ModifiedBy, NewParentSubjectID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SubjectsCityUpdate(int SubjectID, string Name, string Description, string PhotoPath, string PhotoCaption, int NewParentSubjectID, int ModifiedBy)
        {
            try
            {
                string oldfile = BINROTA.DAL.Subjects.SubjectsCityUpdate(SubjectID, Name, Description, PhotoPath, PhotoCaption, ModifiedBy, NewParentSubjectID);
                if (System.IO.File.Exists(oldfile))
                    System.IO.File.Delete(oldfile); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SubjectsRegionUpdate(int SubjectID, string Name, string Description, string PhotoPath, string PhotoCaption, int NewParentSubjectID, int ModifiedBy)
        {
            try
            {
                BINROTA.DAL.Subjects.SubjectsCityUpdate(SubjectID, Name, Description, PhotoPath, PhotoCaption, ModifiedBy, NewParentSubjectID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SubjectsUpdate(int SubjectID, string Name, string Description, string PhotoCaption, int ModifiedBy)
        {
            try
            {
                BINROTA.DAL.Subjects objSub = new BINROTA.DAL.Subjects();
                objSub.Load(SubjectID);
                objSub.Name = Name;
                objSub.Description = Description;
                objSub.PhotoCaption = PhotoCaption;
                objSub.ModifiedBy = ModifiedBy;
                objSub.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SubjectsUpdate(int SubjectID, string Name, string Description, string PhotoPath, string PhotoCaption, int ModifiedBy)
        {
            string oldFile = "";
            try
            {
                BINROTA.DAL.Subjects objSub = new BINROTA.DAL.Subjects();
                objSub.Load(SubjectID);
                oldFile = objSub.PhotoPath;
                objSub.Name = Name;
                objSub.Description = Description;
                objSub.PhotoPath = PhotoPath;
                objSub.PhotoCaption = PhotoCaption;
                objSub.ModifiedBy = ModifiedBy;
                objSub.Save();
                if (System.IO.File.Exists(oldFile))
                    System.IO.File.Delete(oldFile); 

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SubjectsDelete(int SubjectID)
        {
            try
            {
                BINROTA.DAL.Subjects.SubjectsDelete(SubjectID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetSubjectBySubjectID(int SubjectID, int SubjectTypeID)
        {

            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.Subjects.GetSubjectBySubjectID(SubjectID, SubjectTypeID);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetParentSubjectBySubjectID(int SubjectID)
        {

            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.Subjects.GetParentSubjectBySubjectID(SubjectID);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetSubjectByParentSubjectID(int ParentSubjectID)
        {

            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.Subjects.GetSubjectByParentSubjectIDSelect(ParentSubjectID);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetSubjectTypes()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.SubjectTypes.LoadAll().Tables[0];
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetSubjectForDDL(int SubjectTypeID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.Subjects.GetSubjectForDDL(SubjectTypeID);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetNameAndParentNameBySubjectID(int SubjectID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.Subjects.GetNameAndParentNameBySubjectID(SubjectID);
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
