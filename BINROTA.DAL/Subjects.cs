using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL
{

    public class Subjects : BINROTA.DAL.Entities.bSubjects
	{
        public static int InsertSubject(string Name, string Description, string PhotoPath, string PhotoCaption, int ParentSubjectID, int SubjectTypeID, DateTime ModifyDate, int ModifiedBy ,ref int InsertResult)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cSubjectsInsert", conn);
            SqlParameter param;

            param = new SqlParameter("@Name", SqlDbType.NVarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = Name;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar, 4000);
            param.Direction = ParameterDirection.Input;
            param.Value = Description;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoPath", SqlDbType.NVarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = PhotoPath;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = PhotoCaption;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ParentSubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ParentSubjectID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SubjectTypeID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectTypeID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.DateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = ModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ModifiedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@InsertResult", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);

            conn.Open();

            cmd.ExecuteNonQuery();

            InsertResult = (int)cmd.Parameters["@InsertResult"].Value;

            int retval=0;
            if (int.TryParse(cmd.Parameters["@SubjectID"].Value.ToString(),out retval))
                return retval;
            else
                return -1;
        }
        public static int InsertSubject(string Name, string Description, string PhotoPath, string PhotoCaption, int ParentSubjectID, int SubjectTypeID, DateTime ModifyDate, int ModifiedBy, ref int InsertResult, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("cSubjectsInsert", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            param = new SqlParameter("@Name", SqlDbType.NVarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = Name;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar, 4000);
            param.Direction = ParameterDirection.Input;
            param.Value = Description;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoPath", SqlDbType.NVarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = PhotoPath;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = PhotoCaption;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ParentSubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ParentSubjectID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SubjectTypeID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectTypeID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.DateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = ModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ModifiedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@InsertResult", SqlDbType.Int,4);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            InsertResult = (int)cmd.Parameters["@InsertResult"].Value;
            return (int)cmd.Parameters["@SubjectID"].Value; 
        }

        public static DataTable GetSubject(int SubjectID)
        {         
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cSubjectsSelect", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetParentSubjectBySubjectID(int SubjectID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cSubjectsParentSelectBySubjectID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetSubjectCity(int SubjectID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cSubjectsSelectCity", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetSubjectForDDL(int SubjectTypeID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cSubjectsSelectForDDL", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@SubjectTypeID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectTypeID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetSubjectBySubjectID(int SubjectID, int SubjectTypeID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cSubjectsSelectBySubjectID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SubjectTypeID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectTypeID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetSubjectByParentSubjectIDSelect(int ParentSubjectID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cSubjectsByParentSubjectIDSelect", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@ParentSubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ParentSubjectID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static int SubjectsInsertCountry(string Name, string Description, string PhotoPath, string PhotoCaption, int ParentSubjectID, int SubjectTypeID, DateTime ModifyDate, int ModifiedBy, string Location, string Capital, string Area, string Neighbourhood, string Population, string Currency, string AreaCode, string TimeZone, string Language, string Religion)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationInsert", conn); ;
            SqlParameter param;

            conn.Open();
            
            SqlTransaction Tran = conn.BeginTransaction(IsolationLevel.Serializable);
            cmd.Transaction = Tran;

            int SubjectID;
            int SubjectInsertResult = 0;//0: Success ,1: Dublicate, 2: Failure
            try
            {

                SubjectID = InsertSubject(Name, Description, PhotoPath, PhotoCaption, ParentSubjectID, SubjectTypeID, ModifyDate, ModifiedBy, ref SubjectInsertResult, conn, Tran);

                if (SubjectInsertResult == 0)
                {
                    //ikinci insert baþlýyor
                    param = new SqlParameter("@SubjectTypeID", SqlDbType.Int, 4);
                    param.Direction = ParameterDirection.Input;
                    param.Value = SubjectTypeID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
                    param.Direction = ParameterDirection.Input;
                    param.Value = SubjectID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Location", SqlDbType.NVarChar, 50);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Location;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Capital", SqlDbType.NVarChar, 50);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Capital;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@Area", SqlDbType.NVarChar, 50);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Area;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Neighbourhood", SqlDbType.NVarChar, 255);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Neighbourhood;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Population", SqlDbType.NVarChar, 50);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Population;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Currency", SqlDbType.VarChar, 50);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Currency;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AreaCode", SqlDbType.NVarChar, 10);
                    param.Direction = ParameterDirection.Input;
                    param.Value = AreaCode;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@TimeZone", SqlDbType.NVarChar, 50);
                    param.Direction = ParameterDirection.Input;
                    param.Value = TimeZone;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Language", SqlDbType.NVarChar, 100);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Language;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Religion", SqlDbType.NVarChar, 200);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Religion;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                }

                Tran.Commit();
            }
            catch (Exception)
            {
                SubjectInsertResult = 2;
                Tran.Rollback();
                throw;
            }
            finally { 
                conn.Close();
            }

            return SubjectInsertResult;
        }

        public static void SubjectsCountryUpdate(int SubjectID, string Name, string Description, string PhotoPath, string PhotoCaption, int ModifiedBy, string Location, string Capital, string Area, string Neighbourhood, string Population, string Currency, string AreaCode, string TimeZone, string Language, string Religion, int NewParentSubjectID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cSubjectsCountryUpdate", conn);
            SqlParameter param;

            conn.Open();

            SqlTransaction Tran = conn.BeginTransaction(IsolationLevel.Serializable);
            cmd.Transaction = Tran;
            try
            {

                param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Input;
                param.Value = SubjectID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Name", SqlDbType.NVarChar, 255);
                param.Direction = ParameterDirection.Input;
                param.Value = Name;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description", SqlDbType.NVarChar, 4000);
                param.Direction = ParameterDirection.Input;
                param.Value = Description;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PhotoPath", SqlDbType.NVarChar, 255);
                param.Direction = ParameterDirection.Input;
                param.Value = PhotoPath;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar, 255);
                param.Direction = ParameterDirection.Input;
                param.Value = PhotoCaption;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Input;
                param.Value = ModifiedBy;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Location", SqlDbType.NVarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = Location;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Capital", SqlDbType.NVarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = Capital;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Area", SqlDbType.NVarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = Area;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Neighbourhood", SqlDbType.NVarChar, 255);
                param.Direction = ParameterDirection.Input;
                param.Value = Neighbourhood;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Population", SqlDbType.NVarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = Population;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Currency", SqlDbType.NVarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = Currency;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AreaCode", SqlDbType.NVarChar, 10);
                param.Direction = ParameterDirection.Input;
                param.Value = AreaCode;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TimeZone", SqlDbType.NVarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = TimeZone;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Language", SqlDbType.NVarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = Language;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Religion", SqlDbType.NVarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = Population;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                SubjectsMoveTree(SubjectID, NewParentSubjectID, conn, Tran);

                Tran.Commit();
            }
            catch (Exception)
            {
                Tran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        public static void SubjectsCountryUpdate(int SubjectID, string Name, string Description, string PhotoCaption, int ModifiedBy, string Location, string Capital, string Area, string Neighbourhood, string Population, string Currency, string AreaCode, string TimeZone, string Language, string Religion, int NewParentSubjectID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cSubjectsCountryUpdate", conn);
            SqlParameter param;

            conn.Open();

            SqlTransaction Tran = conn.BeginTransaction(IsolationLevel.Serializable);
            cmd.Transaction = Tran;
            try
            {

                param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Input;
                param.Value = SubjectID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Name", SqlDbType.NVarChar, 255);
                param.Direction = ParameterDirection.Input;
                param.Value = Name;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description", SqlDbType.NVarChar, 4000);
                param.Direction = ParameterDirection.Input;
                param.Value = Description;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar, 255);
                param.Direction = ParameterDirection.Input;
                param.Value = PhotoCaption;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Input;
                param.Value = ModifiedBy;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Location", SqlDbType.NVarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = Location;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Capital", SqlDbType.NVarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = Capital;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Area", SqlDbType.NVarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = Area;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Neighbourhood", SqlDbType.NVarChar, 255);
                param.Direction = ParameterDirection.Input;
                param.Value = Neighbourhood;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Population", SqlDbType.NVarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = Population;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Currency", SqlDbType.NVarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = Currency;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AreaCode", SqlDbType.NVarChar, 10);
                param.Direction = ParameterDirection.Input;
                param.Value = AreaCode;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TimeZone", SqlDbType.NVarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = TimeZone;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Language", SqlDbType.NVarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = Language;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Religion", SqlDbType.NVarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = Religion;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                SubjectsMoveTree(SubjectID, NewParentSubjectID, conn, Tran);

                Tran.Commit();
            }
            catch (Exception)
            {
                Tran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        public static void SubjectsCityUpdate(int SubjectID, string Name, string Description, string PhotoCaption, int ModifiedBy, int NewParentSubjectID)
        {
            SqlConnection conn = DBHelper.getConnection();
            conn.Open();
            SqlTransaction Tran = conn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                BINROTA.DAL.Subjects objSub = new BINROTA.DAL.Subjects();
                objSub.Load(SubjectID);
                objSub.Name = Name;
                objSub.Description = Description; 
                objSub.PhotoCaption = PhotoCaption;
                objSub.ModifiedBy = ModifiedBy;
                objSub.Update(conn, Tran);

                SubjectsMoveTree(SubjectID, NewParentSubjectID, conn, Tran);

                Tran.Commit();
            }
            catch (Exception)
            {
                Tran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        public static string SubjectsCityUpdate(int SubjectID, string Name, string Description, string PhotoPath, string PhotoCaption, int ModifiedBy, int NewParentSubjectID)
        {
            SqlConnection conn = DBHelper.getConnection();
            conn.Open();
            SqlTransaction Tran = conn.BeginTransaction(IsolationLevel.Serializable);

            string oldPhotoPath="";

            try
            {
                BINROTA.DAL.Subjects objSub = new BINROTA.DAL.Subjects();
                objSub.Load(SubjectID);
                objSub.Name = Name;
                objSub.Description = Description;
                oldPhotoPath = objSub.PhotoPath;
                objSub.PhotoPath = PhotoPath;
                objSub.ModifiedBy = ModifiedBy;
                objSub.PhotoCaption = PhotoCaption;
                objSub.Update(conn, Tran);

                SubjectsMoveTree(SubjectID, NewParentSubjectID, conn, Tran);

                Tran.Commit();
            }
            catch (Exception)
            {
                Tran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
            return oldPhotoPath;
        }

        public int Update(SqlConnection conn, SqlTransaction Tran)
        {
            //	construct new connection and command objects

            SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsUpdate", conn);
            cmd.Transaction = Tran;

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            // parameter for SubjectID column
            param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intSubjectID;
            cmd.Parameters.Add(param);

            // parameter for Name column
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strName;
            cmd.Parameters.Add(param);

            // parameter for Description column
            param = new SqlParameter("@Description", SqlDbType.NVarChar, 4000);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strDescription;
            cmd.Parameters.Add(param);

            // parameter for PhotoPath column
            param = new SqlParameter("@PhotoPath", SqlDbType.VarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoPath;
            cmd.Parameters.Add(param);

            // parameter for PhotoCaption column
            param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoCaption;
            cmd.Parameters.Add(param);

            // parameter for ParentSubjectID column
            param = new SqlParameter("@ParentSubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intParentSubjectID;
            cmd.Parameters.Add(param);

            // parameter for LeftBound column
            param = new SqlParameter("@LeftBound", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intLeftBound;
            cmd.Parameters.Add(param);

            // parameter for RightBound column
            param = new SqlParameter("@RightBound", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intRightBound;
            cmd.Parameters.Add(param);

            // parameter for SubjectTypeID column
            param = new SqlParameter("@SubjectTypeID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intSubjectTypeID;
            cmd.Parameters.Add(param);

            // parameter for ModifyDate column
            param = new SqlParameter("@ModifyDate", SqlDbType.DateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtModifyDate;
            cmd.Parameters.Add(param);

            // parameter for ModifiedBy column
            param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intModifiedBy;
            cmd.Parameters.Add(param);

            //	open connection
            
            //	Execute command
            cmd.ExecuteNonQuery();
            //	get return value
            int retValue = 0;
            try
            {
                //	get return value of the sproc
                retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
            }
            catch (System.Exception)
            {	//	catch all possible exceptions
                retValue = 0;	//	set retValue To 0 (all ok)
            }

            //	close connection
            

            //	set dirty flag To false
            m_bIsDirty = false;

            return retValue;
        }


        private static void SubjectsMoveTree(int SubjectID, int NewParentSubjectID, SqlConnection conn, SqlTransaction Tran) 
        {
            SqlCommand cmd = DBHelper.getSprocCmd("cSubjectsMoveTree", conn);
            SqlParameter param;
            cmd.Transaction = Tran;

            param = new SqlParameter("@NewParentSubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = NewParentSubjectID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectID;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }
       
        public static void SubjectsDelete(int SubjectID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cSubjectsDelete", conn);
            SqlParameter param;

            param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectID;
            cmd.Parameters.Add(param);

            conn.Open();

            cmd.ExecuteNonQuery();

        }

        public static DataTable GetNameAndParentNameBySubjectID(int SubjectID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cGetNameAndParentNameBySubjectID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

	}
}
