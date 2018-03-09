using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities
{

    public class bActivity
    {
        //transactions
        //	enum types
        protected enum Action { Insert, Update, Delete };
        //	Sub-types
        public struct PK
        {
            public SqlInt32 ActivityID;
        }


        protected Action m_aAction;
        protected bool m_bIsDirty;

        #region Table Members
        protected SqlInt32 m_intActivityID;
        protected SqlString m_strActivityTitle;
        protected SqlString m_strDescription;
        protected SqlString m_strActivityContent;
        protected SqlString m_strPhotoPath;
        protected SqlDateTime m_dtStartDate;
        protected SqlDateTime m_dtEndDate;
        protected SqlInt32 m_intActivityType;
        protected SqlDateTime m_dtModifyDate;
        protected SqlInt32 m_intCreatedBy;
        protected SqlDateTime m_dtCreateDate;
        protected SqlDateTime m_FindBefore_dtCreateDate;
        protected SqlDateTime m_FindAfter_dtCreateDate;
        protected SqlInt32 m_intModifiedBy;
        protected SqlBoolean m_bolisActive;
        protected SqlBoolean m_bolisMain;
        #endregion

        #region Properties

        public PK PrimaryKey
        {
            get
            {
                PK pk;
                pk.ActivityID = m_intActivityID;
                return pk;
            }
        }


        public int ActivityID
        {
            get
            {
                return (int)m_intActivityID;
            }
            set
            {
                m_intActivityID = value;
                m_bIsDirty = true;
            }
        }



        public string ActivityTitle
        {
            get
            {
                return (string)m_strActivityTitle;
            }
            set
            {
                m_strActivityTitle = value;
                m_bIsDirty = true;
            }
        }



        public string Description
        {
            get
            {
                return (string)m_strDescription;
            }
            set
            {
                m_strDescription = value;
                m_bIsDirty = true;
            }
        }



        public string ActivityContent
        {
            get
            {
                return (string)m_strActivityContent;
            }
            set
            {
                m_strActivityContent = value;
                m_bIsDirty = true;
            }
        }



        public string PhotoPath
        {
            get
            {
                return (string)m_strPhotoPath;
            }
            set
            {
                m_strPhotoPath = value;
                m_bIsDirty = true;
            }
        }



        public DateTime StartDate
        {
            get
            {
                return (DateTime)m_dtStartDate;
            }
            set
            {
                m_dtStartDate = value;
                m_bIsDirty = true;
            }
        }



        public DateTime EndDate
        {
            get
            {
                return (DateTime)m_dtEndDate;
            }
            set
            {
                m_dtEndDate = value;
                m_bIsDirty = true;
            }
        }



        public int ActivityType
        {
            get
            {
                return (int)m_intActivityType;
            }
            set
            {
                m_intActivityType = value;
                m_bIsDirty = true;
            }
        }



        public DateTime ModifyDate
        {
            get
            {
                return (DateTime)m_dtModifyDate;
            }
            set
            {
                m_dtModifyDate = value;
                m_bIsDirty = true;
            }
        }



        public int CreatedBy
        {
            get
            {
                return (int)m_intCreatedBy;
            }
            set
            {
                m_intCreatedBy = value;
                m_bIsDirty = true;
            }
        }

        public DateTime FindBefore_CreateDate
        {
            get
            {
                return (DateTime)m_FindBefore_dtCreateDate;
            }
            set
            {
                m_FindBefore_dtCreateDate = value;
                m_bIsDirty = true;
            }
        }

        public DateTime FindAfter_CreateDate
        {
            get
            {
                return (DateTime)m_FindAfter_dtCreateDate;
            }
            set
            {
                m_FindAfter_dtCreateDate = value;
                m_bIsDirty = true;
            }
        }



        public DateTime CreateDate
        {
            get
            {
                return (DateTime)m_dtCreateDate;
            }
            set
            {
                m_dtCreateDate = value;
                m_bIsDirty = true;
            }
        }



        public int ModifiedBy
        {
            get
            {
                return (int)m_intModifiedBy;
            }
            set
            {
                m_intModifiedBy = value;
                m_bIsDirty = true;
            }
        }



        public bool isActive
        {
            get
            {
                return (bool)m_bolisActive;
            }
            set
            {
                m_bolisActive = value;
                m_bIsDirty = true;
            }
        }



        public bool isMain
        {
            get
            {
                return (bool)m_bolisMain;
            }
            set
            {
                m_bolisMain = value;
                m_bIsDirty = true;
            }
        }

        #endregion

        #region Constructers

        public bActivity()
        {
            Init();	//	init Object
        }
        #endregion

        #region Static Functions

        /// <summary>
        /// Gets all Activity from the database, using the default connection string, into a SQLDataReader
        /// </summary>
        /// <returns>The SQLDataReader With the Activity</returns>

        public static SqlDataReader LoadAllReader()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocActivitySelectAll", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        public static DataSet LoadAll()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocActivitySelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        /// <summary>
        /// Gets all Activity from the database, using the default connection string, into a hashtable SQLReader
        /// </summary>
        /// <returns></returns>
        public static Hashtable LoadAllHashTable()
        {
            SqlDataReader dr = LoadAllReader();
            return ConvertReaderToHashTable(dr);
        }

        /// <summary>
        /// Creates Activity for records In the prefilled DataReader, And puts them into a HashTable
        /// </summary>
        /// <param name="dr">The DataReader prefilled With the Activity records</param>
        /// <returns>The Hashtable containing Activity objects And their ID As key.</returns>
        protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr)
        {
            Hashtable result = new Hashtable();
            while (dr.Read())
            {
                Activity myActivity = new Activity();

                myActivity.m_intActivityID = dr.GetSqlInt32(0);
                myActivity.m_strActivityTitle = dr.GetSqlString(1);
                myActivity.m_strDescription = dr.GetSqlString(2);
                myActivity.m_strActivityContent = dr.GetSqlString(3);
                myActivity.m_strPhotoPath = dr.GetSqlString(4);
                myActivity.m_dtStartDate = dr.GetSqlDateTime(5);
                myActivity.m_dtEndDate = dr.GetSqlDateTime(6);
                myActivity.m_intActivityType = dr.GetSqlInt32(7);
                myActivity.m_dtModifyDate = dr.GetSqlDateTime(8);
                myActivity.m_intCreatedBy = dr.GetSqlInt32(9);
                myActivity.m_dtCreateDate = dr.GetSqlDateTime(10);
                myActivity.m_intModifiedBy = dr.GetSqlInt32(11);
                myActivity.m_bolisActive = dr.GetSqlBoolean(12);
                myActivity.m_bolisMain = dr.GetSqlBoolean(13);

                result.Add(myActivity.ActivityID, myActivity);
            }

            return result;
        }

        public static int Insert(bActivity objActivity)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocActivityInsert", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ActivityID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityTitle", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strActivityTitle;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strDescription;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityContent", SqlDbType.NText);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strActivityContent;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoPath", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strPhotoPath;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@StartDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtStartDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intActivityType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intModifiedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_bolisActive;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isMain", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_bolisMain;
            cmd.Parameters.Add(param);


            //	open connection
            conn.Open();
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
            conn.Close();

            //	set dirty flag To false
            if (retValue != 0)
                objActivity.ActivityID = retValue;
            return retValue;
        }

        public static int Insert(bActivity objActivity, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocActivityInsert", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ActivityID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intActivityID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityTitle", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strActivityTitle;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strDescription;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityContent", SqlDbType.NText);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strActivityContent;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoPath", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strPhotoPath;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@StartDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtStartDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intActivityType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intModifiedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_bolisActive;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isMain", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_bolisMain;
            cmd.Parameters.Add(param);



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

            //	set dirty flag To false
            if (retValue != 0)
                objActivity.ActivityID = retValue;
            return retValue;
        }

        public static int Update(bActivity objActivity)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocActivityUpdate", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            param = new SqlParameter("@ActivityID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intActivityID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityTitle", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strActivityTitle;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strDescription;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityContent", SqlDbType.NText);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strActivityContent;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoPath", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strPhotoPath;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@StartDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtStartDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intActivityType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intModifiedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_bolisActive;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isMain", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_bolisMain;
            cmd.Parameters.Add(param);

            //	open connection
            conn.Open();
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
            conn.Close();


            return retValue;
        }

        public static int Update(bActivity objActivity, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocActivityUpdate", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            param = new SqlParameter("@ActivityID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intActivityID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityTitle", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strActivityTitle;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strDescription;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityContent", SqlDbType.NText);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strActivityContent;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoPath", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strPhotoPath;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@StartDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtStartDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intActivityType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intModifiedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_bolisActive;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isMain", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_bolisMain;
            cmd.Parameters.Add(param);


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


            return retValue;
        }

        public static int Delete(bActivity objActivity)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocActivityDeleteByParams", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ActivityID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intActivityID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityTitle", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strActivityTitle;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strDescription;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoPath", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strPhotoPath;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@StartDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtStartDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intActivityType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intModifiedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_bolisActive;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isMain", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_bolisMain;
            cmd.Parameters.Add(param);

            //	open connection
            conn.Open();
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
            conn.Close();

            return retValue;
        }

        public static int Delete(bActivity objActivity, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocActivityDeleteByParams", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ActivityID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intActivityID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityTitle", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strActivityTitle;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strDescription;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoPath", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_strPhotoPath;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@StartDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtStartDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intActivityType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_intModifiedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_bolisActive;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isMain", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objActivity.m_bolisMain;
            cmd.Parameters.Add(param);


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


            return retValue;
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
        /// </summary>
        /// <param name="pk">PK struct</param>
        /// <returns>true member variables filled.</returns>
        public bool Load(PK pk)
        {
            return Load(pk.ActivityID.Value);
        }

        /// <summary>
        /// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
        /// </summary>
        /// <param name="intActivityID"> ActivityID key value</param>
        /// <returns>true if success</returns>
        public bool Load(Int32 intActivityID)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocActivitySelect", conn);

            SqlParameter param;

            //	Add params
            // parameter for ActivityID column
            param = new SqlParameter("@ActivityID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = intActivityID;
            cmd.Parameters.Add(param);

            //	open connection
            conn.Open();
            //	Execute command And get reader
            SqlDataReader reader = cmd.ExecuteReader();

            bool found = false;	//	false solution

            //	check if  anything was found
            if (reader.Read())
            {
                found = true;	//	corresponding row found
                m_aAction = Action.Update;	//	future action

                //	set member values
                m_intActivityID = reader.GetSqlInt32(0);
                m_strActivityTitle = reader.GetSqlString(1);
                m_strDescription = reader.GetSqlString(2);
                m_strActivityContent = reader.GetSqlString(3);
                m_strPhotoPath = reader.GetSqlString(4);
                m_dtStartDate = reader.GetSqlDateTime(5);
                m_dtEndDate = reader.GetSqlDateTime(6);
                m_intActivityType = reader.GetSqlInt32(7);
                m_dtModifyDate = reader.GetSqlDateTime(8);
                m_intCreatedBy = reader.GetSqlInt32(9);
                m_dtCreateDate = reader.GetSqlDateTime(10);
                m_intModifiedBy = reader.GetSqlInt32(11);
                m_bolisActive = reader.GetSqlBoolean(12);
                m_bolisMain = reader.GetSqlBoolean(13);

            }
            else
            {
                //	set key values
                m_intActivityID = intActivityID;
            }

            //	close connection
            conn.Close();
            //	set dirty flag To false
            m_bIsDirty = false;
            //	return true if  a row found, otherwise false
            return found;

        }

        /// <summary>
        /// Updates the DB.
        /// </summary>
        /// <returns>0 if success</returns>
        public int Save()
        {
            int retValue;
            switch (m_aAction)
            {
                case Action.Insert:
                    //	insert row
                    retValue = ins();
                    //	future action To be update
                    m_aAction = Action.Update;
                    //	return retValue from insert
                    return retValue;
                case Action.Update:
                    //	check if  Objectstringdirty
                    if (m_bIsDirty)
                    {
                        //	update row And return retValue
                        return upd();
                    }
                    else
                    {
                        //	return 0 (all ok)
                        return 0;
                    }
                case Action.Delete:
                    //	delete row
                    retValue = del();
                    //	future action To be insert
                    m_aAction = Action.Insert;
                    //	return retValue from delete
                    return retValue;
            }

            throw new System.Exception("Unknown action.");
        }

        /// <summary>
        /// Deletes the Object from the DB.
        /// </summary>
        /// <returns>0 if success</returns>
        public int Delete()
        {
            m_aAction = Action.Delete;	//	actionstringdelete
            return Save();
        }

        public DataSet LoadByParams()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocActivitySelectByParams", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ActivityID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intActivityID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityTitle", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strActivityTitle;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strDescription;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoPath", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoPath;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@StartDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtStartDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intActivityType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Before_CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindBefore_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@After_CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindAfter_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intModifiedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = m_bolisActive;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isMain", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = m_bolisMain;
            cmd.Parameters.Add(param);


            //	open connection
            conn.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        public DataSet LoadByParams(SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocActivitySelectByParams", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ActivityID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intActivityID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityTitle", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strActivityTitle;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Description", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strDescription;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoPath", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoPath;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@StartDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtStartDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intActivityType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.SmallDateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Before_CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindBefore_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@After_CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindAfter_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intModifiedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = m_bolisActive;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isMain", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = m_bolisMain;
            cmd.Parameters.Add(param);


            //	open connection
            conn.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        #endregion

        #region Private Functions

        /// <summary>
        /// The init Function.
        /// </summary>
        protected void Init()
        {
            m_aAction = Action.Insert;	//	initial action
            m_bIsDirty = false;	//	Objectstring"clean" upon init
        }

        protected int ins()
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocActivityInsert", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            // parameter for ActivityID column
            param = new SqlParameter("@ActivityID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intActivityID;
            cmd.Parameters.Add(param);

            // parameter for ActivityTitle column
            param = new SqlParameter("@ActivityTitle", SqlDbType.NVarChar, 500);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strActivityTitle;
            cmd.Parameters.Add(param);

            // parameter for Description column
            param = new SqlParameter("@Description", SqlDbType.NVarChar, 2000);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strDescription;
            cmd.Parameters.Add(param);

            // parameter for ActivityContent column
            param = new SqlParameter("@ActivityContent", SqlDbType.NText, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strActivityContent;
            cmd.Parameters.Add(param);

            // parameter for PhotoPath column
            param = new SqlParameter("@PhotoPath", SqlDbType.NVarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoPath;
            cmd.Parameters.Add(param);

            // parameter for StartDate column
            param = new SqlParameter("@StartDate", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtStartDate;
            cmd.Parameters.Add(param);

            // parameter for EndDate column
            param = new SqlParameter("@EndDate", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtEndDate;
            cmd.Parameters.Add(param);

            // parameter for ActivityType column
            param = new SqlParameter("@ActivityType", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intActivityType;
            cmd.Parameters.Add(param);

            // parameter for ModifyDate column
            param = new SqlParameter("@ModifyDate", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtModifyDate;
            cmd.Parameters.Add(param);

            // parameter for CreatedBy column
            param = new SqlParameter("@CreatedBy", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCreatedBy;
            cmd.Parameters.Add(param);

            // parameter for CreateDate column
            param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtCreateDate;
            cmd.Parameters.Add(param);

            // parameter for ModifiedBy column
            param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intModifiedBy;
            cmd.Parameters.Add(param);

            // parameter for isActive column
            param = new SqlParameter("@isActive", SqlDbType.Bit, 1);
            param.Direction = ParameterDirection.Input;
            param.Value = m_bolisActive;
            cmd.Parameters.Add(param);

            // parameter for isMain column
            param = new SqlParameter("@isMain", SqlDbType.Bit, 1);
            param.Direction = ParameterDirection.Input;
            param.Value = m_bolisMain;
            cmd.Parameters.Add(param);


            //	open connection
            conn.Open();
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
            conn.Close();

            //	set dirty flag To false
            m_bIsDirty = false;
            if (retValue != 0)
                ActivityID = retValue;
            return retValue;
        }

        /// <summary>
        /// Updates the Object To the DB.
        /// </summary>
        /// <returns>0 if success</returns>
        protected int upd()
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocActivityUpdate", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            // parameter for ActivityID column
            param = new SqlParameter("@ActivityID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intActivityID;
            cmd.Parameters.Add(param);

            // parameter for ActivityTitle column
            param = new SqlParameter("@ActivityTitle", SqlDbType.NVarChar, 500);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strActivityTitle;
            cmd.Parameters.Add(param);

            // parameter for Description column
            param = new SqlParameter("@Description", SqlDbType.NVarChar, 2000);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strDescription;
            cmd.Parameters.Add(param);

            // parameter for ActivityContent column
            param = new SqlParameter("@ActivityContent", SqlDbType.NText, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strActivityContent;
            cmd.Parameters.Add(param);

            // parameter for PhotoPath column
            param = new SqlParameter("@PhotoPath", SqlDbType.NVarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoPath;
            cmd.Parameters.Add(param);

            // parameter for StartDate column
            param = new SqlParameter("@StartDate", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtStartDate;
            cmd.Parameters.Add(param);

            // parameter for EndDate column
            param = new SqlParameter("@EndDate", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtEndDate;
            cmd.Parameters.Add(param);

            // parameter for ActivityType column
            param = new SqlParameter("@ActivityType", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intActivityType;
            cmd.Parameters.Add(param);

            // parameter for ModifyDate column
            param = new SqlParameter("@ModifyDate", SqlDbType.SmallDateTime, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtModifyDate;
            cmd.Parameters.Add(param);

            // parameter for CreatedBy column
            param = new SqlParameter("@CreatedBy", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCreatedBy;
            cmd.Parameters.Add(param);

            // parameter for CreateDate column
            param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtCreateDate;
            cmd.Parameters.Add(param);

            // parameter for ModifiedBy column
            param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intModifiedBy;
            cmd.Parameters.Add(param);

            // parameter for isActive column
            param = new SqlParameter("@isActive", SqlDbType.Bit, 1);
            param.Direction = ParameterDirection.Input;
            param.Value = m_bolisActive;
            cmd.Parameters.Add(param);

            // parameter for isMain column
            param = new SqlParameter("@isMain", SqlDbType.Bit, 1);
            param.Direction = ParameterDirection.Input;
            param.Value = m_bolisMain;
            cmd.Parameters.Add(param);

            //	open connection
            conn.Open();
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
            conn.Close();

            //	set dirty flag To false
            m_bIsDirty = false;

            return retValue;
        }

        /// <summary>
        /// Deletes the Object from the DB.
        /// </summary>
        /// <returns>0 if success</returns>
        protected int del()
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocActivityDelete", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            // parameter for ActivityID column
            param = new SqlParameter("@ActivityID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intActivityID;
            cmd.Parameters.Add(param);

            //	open connection
            conn.Open();
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
            conn.Close();

            //	set dirty flag To false
            m_bIsDirty = false;

            return retValue;
        }
        #endregion

        #region Operator Functions


        //	operators
        /// <summary>
        /// Compares two objects
        /// </summary>
        /// <param name="t1">The first Object To compare</param>
        /// <param name="t2">The Second Object To compare</param>
        /// <returns>true if success</returns>
        public static bool operator ==(bActivity t1, bActivity t2)
        {
            //	compare values
            if (t1.m_intActivityID != t2.m_intActivityID)
            {
                return false;	//	because "ActivityID" values are Not equal
            }

            if (t1.m_strActivityTitle != t2.m_strActivityTitle)
            {
                return false;	//	because "ActivityTitle" values are Not equal
            }

            if (t1.m_strDescription != t2.m_strDescription)
            {
                return false;	//	because "Description" values are Not equal
            }

            if (t1.m_strActivityContent != t2.m_strActivityContent)
            {
                return false;	//	because "ActivityContent" values are Not equal
            }

            if (t1.m_strPhotoPath != t2.m_strPhotoPath)
            {
                return false;	//	because "PhotoPath" values are Not equal
            }

            if (t1.m_dtStartDate != t2.m_dtStartDate)
            {
                return false;	//	because "StartDate" values are Not equal
            }

            if (t1.m_dtEndDate != t2.m_dtEndDate)
            {
                return false;	//	because "EndDate" values are Not equal
            }

            if (t1.m_intActivityType != t2.m_intActivityType)
            {
                return false;	//	because "ActivityType" values are Not equal
            }

            if (t1.m_dtModifyDate != t2.m_dtModifyDate)
            {
                return false;	//	because "ModifyDate" values are Not equal
            }

            if (t1.m_intCreatedBy != t2.m_intCreatedBy)
            {
                return false;	//	because "CreatedBy" values are Not equal
            }

            if (t1.m_dtCreateDate != t2.m_dtCreateDate)
            {
                return false;	//	because "CreateDate" values are Not equal
            }

            if (t1.m_intModifiedBy != t2.m_intModifiedBy)
            {
                return false;	//	because "ModifiedBy" values are Not equal
            }

            if (t1.m_bolisActive != t2.m_bolisActive)
            {
                return false;	//	because "isActive" values are Not equal
            }

            if (t1.m_bolisMain != t2.m_bolisMain)
            {
                return false;	//	because "isMain" values are Not equal
            }

            return true;	//	because every Valuestringequal
        }

        /// <summary>
        /// Compares two objects
        /// </summary>
        /// <param name="t1">The first Object To compare</param>
        /// <param name="t2">The Second Object To compare</param>
        /// <returns>true if success</returns>
        public static bool operator !=(bActivity t1, bActivity t2)
        {
            return !(t1 == t2);
        }
        #endregion

        #region Override Functions

        //	Object methods

        /// <summary>
        /// Overrides the ToString Function.
        /// </summary>
        /// <returns>The string representation of the Object</returns>
        public override string ToString()
        {
            System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");
            retValue.Append(" ActivityID = \"");
            retValue.Append(m_intActivityID);
            retValue.Append("\"\n");

            retValue.Append("Columns:\n");
            retValue.Append("    ActivityTitle = \"");
            retValue.Append(m_strActivityTitle);
            retValue.Append("\"\n");
            retValue.Append("    Description = \"");
            retValue.Append(m_strDescription);
            retValue.Append("\"\n");
            retValue.Append("    ActivityContent = \"");
            retValue.Append(m_strActivityContent);
            retValue.Append("\"\n");
            retValue.Append("    PhotoPath = \"");
            retValue.Append(m_strPhotoPath);
            retValue.Append("\"\n");
            retValue.Append("    StartDate = \"");
            retValue.Append(m_dtStartDate);
            retValue.Append("\"\n");
            retValue.Append("    EndDate = \"");
            retValue.Append(m_dtEndDate);
            retValue.Append("\"\n");
            retValue.Append("    ActivityType = \"");
            retValue.Append(m_intActivityType);
            retValue.Append("\"\n");
            retValue.Append("    ModifyDate = \"");
            retValue.Append(m_dtModifyDate);
            retValue.Append("\"\n");
            retValue.Append("    CreatedBy = \"");
            retValue.Append(m_intCreatedBy);
            retValue.Append("\"\n");
            retValue.Append("    CreateDate = \"");
            retValue.Append(m_dtCreateDate);
            retValue.Append("\"\n");
            retValue.Append("    ModifiedBy = \"");
            retValue.Append(m_intModifiedBy);
            retValue.Append("\"\n");
            retValue.Append("    isActive = \"");
            retValue.Append(m_bolisActive);
            retValue.Append("\"\n");
            retValue.Append("    isMain = \"");
            retValue.Append(m_bolisMain);
            retValue.Append("\"\n");
            return retValue.ToString();
        }

        /// <summary>
        /// Overrides the Equals Function.
        /// </summary>
        /// <param name="o">The Object To compare With</param>
        /// <returns>Bool if the two objects are identical.</returns>
        public override bool Equals(System.Object o)
        {
            //	check the type of o
            if (!(o is Activity))
            {
                //	types Not the same, return false
                return false;
            }

            //	compare objects And return retValue
            return this == (Activity)o;
        }

        /// <summary>
        /// Overrides the GetHashCode Function.
        /// </summary>
        /// <returns>Bool if the two objects are identical.</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        #endregion

    }
}

