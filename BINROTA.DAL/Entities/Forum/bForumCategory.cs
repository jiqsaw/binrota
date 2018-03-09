using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities
{

    public class bForumCategory
    {
        //transactions
        //	enum types
        protected enum Action { Insert, Update, Delete };
        //	Sub-types
        public struct PK
        {
            public SqlInt32 CategoryID;
        }


        protected Action m_aAction;
        protected bool m_bIsDirty;

        #region Table Members
        protected SqlInt32 m_intCategoryID;
        protected SqlString m_strCategoryName;
        protected SqlString m_strCategoryDesc;
        protected SqlInt32 m_intCategoryStatus;
        protected SqlInt32 m_intArticlesCount;
        protected SqlString m_strLastPost;
        protected SqlDateTime m_dtCreateDate;
        protected SqlDateTime m_FindBefore_dtCreateDate;
        protected SqlDateTime m_FindAfter_dtCreateDate;
        protected SqlDateTime m_dtEndDate;
        protected SqlDateTime m_FindBefore_dtEndDate;
        protected SqlDateTime m_FindAfter_dtEndDate;
        protected SqlDateTime m_dtLastPostDate;
        protected SqlDateTime m_FindBefore_dtLastPostDate;
        protected SqlDateTime m_FindAfter_dtLastPostDate;
        protected SqlInt32 m_intCreatedBy;
        protected SqlInt32 m_intOrder;
        #endregion

        #region Properties

        public PK PrimaryKey
        {
            get
            {
                PK pk;
                pk.CategoryID = m_intCategoryID;
                return pk;
            }
        }


        public int CategoryID
        {
            get
            {
                return (int)m_intCategoryID;
            }
            set
            {
                m_intCategoryID = value;
                m_bIsDirty = true;
            }
        }



        public string CategoryName
        {
            get
            {
                return (string)m_strCategoryName;
            }
            set
            {
                m_strCategoryName = value;
                m_bIsDirty = true;
            }
        }



        public string CategoryDesc
        {
            get
            {
                return (string)m_strCategoryDesc;
            }
            set
            {
                m_strCategoryDesc = value;
                m_bIsDirty = true;
            }
        }



        public int CategoryStatus
        {
            get
            {
                return (int)m_intCategoryStatus;
            }
            set
            {
                m_intCategoryStatus = value;
                m_bIsDirty = true;
            }
        }



        public int ArticlesCount
        {
            get
            {
                return (int)m_intArticlesCount;
            }
            set
            {
                m_intArticlesCount = value;
                m_bIsDirty = true;
            }
        }



        public string LastPost
        {
            get
            {
                return (string)m_strLastPost;
            }
            set
            {
                m_strLastPost = value;
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

        public DateTime FindBefore_EndDate
        {
            get
            {
                return (DateTime)m_FindBefore_dtEndDate;
            }
            set
            {
                m_FindBefore_dtEndDate = value;
                m_bIsDirty = true;
            }
        }

        public DateTime FindAfter_EndDate
        {
            get
            {
                return (DateTime)m_FindAfter_dtEndDate;
            }
            set
            {
                m_FindAfter_dtEndDate = value;
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

        public DateTime FindBefore_LastPostDate
        {
            get
            {
                return (DateTime)m_FindBefore_dtLastPostDate;
            }
            set
            {
                m_FindBefore_dtLastPostDate = value;
                m_bIsDirty = true;
            }
        }

        public DateTime FindAfter_LastPostDate
        {
            get
            {
                return (DateTime)m_FindAfter_dtLastPostDate;
            }
            set
            {
                m_FindAfter_dtLastPostDate = value;
                m_bIsDirty = true;
            }
        }



        public DateTime LastPostDate
        {
            get
            {
                return (DateTime)m_dtLastPostDate;
            }
            set
            {
                m_dtLastPostDate = value;
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



        public int Order
        {
            get
            {
                return (int)m_intOrder;
            }
            set
            {
                m_intOrder = value;
                m_bIsDirty = true;
            }
        }

        #endregion

        #region Constructers

        public bForumCategory()
        {
            Init();	//	init Object
        }
        #endregion

        #region Static Functions

        /// <summary>
        /// Gets all ForumCategory from the database, using the default connection string, into a SQLDataReader
        /// </summary>
        /// <returns>The SQLDataReader With the ForumCategory</returns>

        public static SqlDataReader LoadAllReader()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumCategorySelectAll", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        public static DataSet LoadAll()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumCategorySelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        /// <summary>
        /// Gets all ForumCategory from the database, using the default connection string, into a hashtable SQLReader
        /// </summary>
        /// <returns></returns>
        public static Hashtable LoadAllHashTable()
        {
            SqlDataReader dr = LoadAllReader();
            return ConvertReaderToHashTable(dr);
        }

        /// <summary>
        /// Creates ForumCategory for records In the prefilled DataReader, And puts them into a HashTable
        /// </summary>
        /// <param name="dr">The DataReader prefilled With the ForumCategory records</param>
        /// <returns>The Hashtable containing ForumCategory objects And their ID As key.</returns>
        protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr)
        {
            Hashtable result = new Hashtable();
            while (dr.Read())
            {
                ForumCategory myForumCategory = new ForumCategory();

                myForumCategory.m_intCategoryID = dr.GetSqlInt32(0);
                myForumCategory.m_strCategoryName = dr.GetSqlString(1);
                myForumCategory.m_strCategoryDesc = dr.GetSqlString(2);
                myForumCategory.m_intCategoryStatus = dr.GetSqlInt32(3);
                myForumCategory.m_intArticlesCount = dr.GetSqlInt32(4);
                myForumCategory.m_strLastPost = dr.GetSqlString(5);
                myForumCategory.m_dtCreateDate = dr.GetSqlDateTime(6);
                myForumCategory.m_dtEndDate = dr.GetSqlDateTime(7);
                myForumCategory.m_dtLastPostDate = dr.GetSqlDateTime(8);
                myForumCategory.m_intCreatedBy = dr.GetSqlInt32(9);
                myForumCategory.m_intOrder = dr.GetSqlInt32(10);

                result.Add(myForumCategory.CategoryID, myForumCategory);
            }

            return result;
        }

        public static int Insert(bForumCategory objForumCategory)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumCategoryInsert", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@CategoryID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strCategoryName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strCategoryDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryStatus", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCategoryStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticlesCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intArticlesCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPost", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strLastPost;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPostDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtLastPostDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Order", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intOrder;
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
                objForumCategory.CategoryID = retValue;
            return retValue;
        }

        public static int Insert(bForumCategory objForumCategory, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumCategoryInsert", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@CategoryID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCategoryID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strCategoryName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strCategoryDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryStatus", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCategoryStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticlesCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intArticlesCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPost", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strLastPost;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPostDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtLastPostDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Order", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intOrder;
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
                objForumCategory.CategoryID = retValue;
            return retValue;
        }

        public static int Update(bForumCategory objForumCategory)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumCategoryUpdate", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            param = new SqlParameter("@CategoryID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCategoryID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strCategoryName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strCategoryDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryStatus", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCategoryStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticlesCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intArticlesCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPost", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strLastPost;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPostDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtLastPostDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Order", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intOrder;
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

        public static int Update(bForumCategory objForumCategory, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumCategoryUpdate", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            param = new SqlParameter("@CategoryID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCategoryID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strCategoryName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strCategoryDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryStatus", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCategoryStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticlesCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intArticlesCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPost", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strLastPost;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPostDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtLastPostDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Order", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intOrder;
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

        public static int Delete(bForumCategory objForumCategory)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumCategoryDeleteByParams", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@CategoryID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCategoryID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strCategoryName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strCategoryDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryStatus", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCategoryStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticlesCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intArticlesCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPost", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strLastPost;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPostDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtLastPostDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Order", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intOrder;
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

        public static int Delete(bForumCategory objForumCategory, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumCategoryDeleteByParams", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@CategoryID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCategoryID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strCategoryName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strCategoryDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryStatus", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCategoryStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticlesCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intArticlesCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPost", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_strLastPost;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPostDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_dtLastPostDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Order", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumCategory.m_intOrder;
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
            return Load(pk.CategoryID.Value);
        }

        /// <summary>
        /// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
        /// </summary>
        /// <param name="intCategoryID"> CategoryID key value</param>
        /// <returns>true if success</returns>
        public bool Load(Int32 intCategoryID)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumCategorySelect", conn);

            SqlParameter param;

            //	Add params
            // parameter for CategoryID column
            param = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = intCategoryID;
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
                m_intCategoryID = reader.GetSqlInt32(0);
                m_strCategoryName = reader.GetSqlString(1);
                m_strCategoryDesc = reader.GetSqlString(2);
                m_intCategoryStatus = reader.GetSqlInt32(3);
                m_intArticlesCount = reader.GetSqlInt32(4);
                m_strLastPost = reader.GetSqlString(5);
                m_dtCreateDate = reader.GetSqlDateTime(6);
                m_dtEndDate = reader.GetSqlDateTime(7);
                m_dtLastPostDate = reader.GetSqlDateTime(8);
                m_intCreatedBy = reader.GetSqlInt32(9);
                m_intOrder = reader.GetSqlInt32(10);

            }
            else
            {
                //	set key values
                m_intCategoryID = intCategoryID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumCategorySelectByParams", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@CategoryID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCategoryID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strCategoryName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strCategoryDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryStatus", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCategoryStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticlesCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticlesCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPost", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strLastPost;
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

            param = new SqlParameter("@EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Before_EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindBefore_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@After_EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindAfter_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPostDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtLastPostDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Before_LastPostDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindBefore_dtLastPostDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@After_LastPostDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindAfter_dtLastPostDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Order", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intOrder;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumCategorySelectByParams", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@CategoryID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCategoryID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strCategoryName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strCategoryDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryStatus", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCategoryStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticlesCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticlesCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPost", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strLastPost;
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

            param = new SqlParameter("@EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Before_EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindBefore_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@After_EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindAfter_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPostDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtLastPostDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Before_LastPostDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindBefore_dtLastPostDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@After_LastPostDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindAfter_dtLastPostDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Order", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intOrder;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumCategoryInsert", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            // parameter for CategoryID column
            param = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCategoryID;
            cmd.Parameters.Add(param);

            // parameter for CategoryName column
            param = new SqlParameter("@CategoryName", SqlDbType.NVarChar, 200);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strCategoryName;
            cmd.Parameters.Add(param);

            // parameter for CategoryDesc column
            param = new SqlParameter("@CategoryDesc", SqlDbType.NVarChar, 2000);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strCategoryDesc;
            cmd.Parameters.Add(param);

            // parameter for CategoryStatus column
            param = new SqlParameter("@CategoryStatus", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCategoryStatus;
            cmd.Parameters.Add(param);

            // parameter for ArticlesCount column
            param = new SqlParameter("@ArticlesCount", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticlesCount;
            cmd.Parameters.Add(param);

            // parameter for LastPost column
            param = new SqlParameter("@LastPost", SqlDbType.NVarChar, 300);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strLastPost;
            cmd.Parameters.Add(param);

            // parameter for CreateDate column
            param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtCreateDate;
            cmd.Parameters.Add(param);

            // parameter for EndDate column
            param = new SqlParameter("@EndDate", SqlDbType.DateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtEndDate;
            cmd.Parameters.Add(param);

            // parameter for LastPostDate column
            param = new SqlParameter("@LastPostDate", SqlDbType.DateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtLastPostDate;
            cmd.Parameters.Add(param);

            // parameter for CreatedBy column
            param = new SqlParameter("@CreatedBy", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCreatedBy;
            cmd.Parameters.Add(param);

            // parameter for Order column
            param = new SqlParameter("@Order", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intOrder;
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
                CategoryID = retValue;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumCategoryUpdate", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            // parameter for CategoryID column
            param = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCategoryID;
            cmd.Parameters.Add(param);

            // parameter for CategoryName column
            param = new SqlParameter("@CategoryName", SqlDbType.NVarChar, 200);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strCategoryName;
            cmd.Parameters.Add(param);

            // parameter for CategoryDesc column
            param = new SqlParameter("@CategoryDesc", SqlDbType.NVarChar, 2000);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strCategoryDesc;
            cmd.Parameters.Add(param);

            // parameter for CategoryStatus column
            param = new SqlParameter("@CategoryStatus", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCategoryStatus;
            cmd.Parameters.Add(param);

            // parameter for ArticlesCount column
            param = new SqlParameter("@ArticlesCount", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticlesCount;
            cmd.Parameters.Add(param);

            // parameter for LastPost column
            param = new SqlParameter("@LastPost", SqlDbType.NVarChar, 300);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strLastPost;
            cmd.Parameters.Add(param);

            // parameter for CreateDate column
            param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtCreateDate;
            cmd.Parameters.Add(param);

            // parameter for EndDate column
            param = new SqlParameter("@EndDate", SqlDbType.DateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtEndDate;
            cmd.Parameters.Add(param);

            // parameter for LastPostDate column
            param = new SqlParameter("@LastPostDate", SqlDbType.DateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtLastPostDate;
            cmd.Parameters.Add(param);

            // parameter for CreatedBy column
            param = new SqlParameter("@CreatedBy", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCreatedBy;
            cmd.Parameters.Add(param);

            // parameter for Order column
            param = new SqlParameter("@Order", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intOrder;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumCategoryDelete", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            // parameter for CategoryID column
            param = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCategoryID;
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
        public static bool operator ==(bForumCategory t1, bForumCategory t2)
        {
            //	compare values
            if (t1.m_intCategoryID != t2.m_intCategoryID)
            {
                return false;	//	because "CategoryID" values are Not equal
            }

            if (t1.m_strCategoryName != t2.m_strCategoryName)
            {
                return false;	//	because "CategoryName" values are Not equal
            }

            if (t1.m_strCategoryDesc != t2.m_strCategoryDesc)
            {
                return false;	//	because "CategoryDesc" values are Not equal
            }

            if (t1.m_intCategoryStatus != t2.m_intCategoryStatus)
            {
                return false;	//	because "CategoryStatus" values are Not equal
            }

            if (t1.m_intArticlesCount != t2.m_intArticlesCount)
            {
                return false;	//	because "ArticlesCount" values are Not equal
            }

            if (t1.m_strLastPost != t2.m_strLastPost)
            {
                return false;	//	because "LastPost" values are Not equal
            }

            if (t1.m_dtCreateDate != t2.m_dtCreateDate)
            {
                return false;	//	because "CreateDate" values are Not equal
            }

            if (t1.m_dtEndDate != t2.m_dtEndDate)
            {
                return false;	//	because "EndDate" values are Not equal
            }

            if (t1.m_dtLastPostDate != t2.m_dtLastPostDate)
            {
                return false;	//	because "LastPostDate" values are Not equal
            }

            if (t1.m_intCreatedBy != t2.m_intCreatedBy)
            {
                return false;	//	because "CreatedBy" values are Not equal
            }

            if (t1.m_intOrder != t2.m_intOrder)
            {
                return false;	//	because "Order" values are Not equal
            }

            return true;	//	because every Valuestringequal
        }

        /// <summary>
        /// Compares two objects
        /// </summary>
        /// <param name="t1">The first Object To compare</param>
        /// <param name="t2">The Second Object To compare</param>
        /// <returns>true if success</returns>
        public static bool operator !=(bForumCategory t1, bForumCategory t2)
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
            retValue.Append(" CategoryID = \"");
            retValue.Append(m_intCategoryID);
            retValue.Append("\"\n");

            retValue.Append("Columns:\n");
            retValue.Append("    CategoryName = \"");
            retValue.Append(m_strCategoryName);
            retValue.Append("\"\n");
            retValue.Append("    CategoryDesc = \"");
            retValue.Append(m_strCategoryDesc);
            retValue.Append("\"\n");
            retValue.Append("    CategoryStatus = \"");
            retValue.Append(m_intCategoryStatus);
            retValue.Append("\"\n");
            retValue.Append("    ArticlesCount = \"");
            retValue.Append(m_intArticlesCount);
            retValue.Append("\"\n");
            retValue.Append("    LastPost = \"");
            retValue.Append(m_strLastPost);
            retValue.Append("\"\n");
            retValue.Append("    CreateDate = \"");
            retValue.Append(m_dtCreateDate);
            retValue.Append("\"\n");
            retValue.Append("    EndDate = \"");
            retValue.Append(m_dtEndDate);
            retValue.Append("\"\n");
            retValue.Append("    LastPostDate = \"");
            retValue.Append(m_dtLastPostDate);
            retValue.Append("\"\n");
            retValue.Append("    CreatedBy = \"");
            retValue.Append(m_intCreatedBy);
            retValue.Append("\"\n");
            retValue.Append("    Order = \"");
            retValue.Append(m_intOrder);
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
            if (!(o is ForumCategory))
            {
                //	types Not the same, return false
                return false;
            }

            //	compare objects And return retValue
            return this == (ForumCategory)o;
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

