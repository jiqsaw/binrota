using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities
{

    public class bForumArticleItems
    {
        //transactions
        //	enum types
        protected enum Action { Insert, Update, Delete };
        //	Sub-types
        public struct PK
        {
            public SqlInt32 ArticleItemID;
        }


        protected Action m_aAction;
        protected bool m_bIsDirty;

        #region Table Members
        protected SqlInt32 m_intArticleItemID;
        protected SqlInt32 m_intArticleID;
        protected SqlString m_strSubject;
        protected SqlString m_strReply;
        protected SqlInt32 m_intCommentType;
        protected SqlInt32 m_intScore;
        protected SqlInt32 m_intScoreCount;
        protected SqlInt32 m_intStatus;
        protected SqlInt32 m_intCreatedBy;
        protected SqlDateTime m_dtCreateDate;
        protected SqlDateTime m_FindBefore_dtCreateDate;
        protected SqlDateTime m_FindAfter_dtCreateDate;
        #endregion

        #region Properties

        public PK PrimaryKey
        {
            get
            {
                PK pk;
                pk.ArticleItemID = m_intArticleItemID;
                return pk;
            }
        }


        public int ArticleItemID
        {
            get
            {
                return (int)m_intArticleItemID;
            }
            set
            {
                m_intArticleItemID = value;
                m_bIsDirty = true;
            }
        }



        public int ArticleID
        {
            get
            {
                return (int)m_intArticleID;
            }
            set
            {
                m_intArticleID = value;
                m_bIsDirty = true;
            }
        }



        public string Subject
        {
            get
            {
                return (string)m_strSubject;
            }
            set
            {
                m_strSubject = value;
                m_bIsDirty = true;
            }
        }



        public string Reply
        {
            get
            {
                return (string)m_strReply;
            }
            set
            {
                m_strReply = value;
                m_bIsDirty = true;
            }
        }



        public int CommentType
        {
            get
            {
                return (int)m_intCommentType;
            }
            set
            {
                m_intCommentType = value;
                m_bIsDirty = true;
            }
        }



        public int Score
        {
            get
            {
                return (int)m_intScore;
            }
            set
            {
                m_intScore = value;
                m_bIsDirty = true;
            }
        }



        public int ScoreCount
        {
            get
            {
                return (int)m_intScoreCount;
            }
            set
            {
                m_intScoreCount = value;
                m_bIsDirty = true;
            }
        }



        public int Status
        {
            get
            {
                return (int)m_intStatus;
            }
            set
            {
                m_intStatus = value;
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

        #endregion

        #region Constructers

        public bForumArticleItems()
        {
            Init();	//	init Object
        }
        #endregion

        #region Static Functions

        /// <summary>
        /// Gets all ForumArticleItems from the database, using the default connection string, into a SQLDataReader
        /// </summary>
        /// <returns>The SQLDataReader With the ForumArticleItems</returns>

        public static SqlDataReader LoadAllReader()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsSelectAll", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        public static DataSet LoadAll()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        /// <summary>
        /// Gets all ForumArticleItems from the database, using the default connection string, into a hashtable SQLReader
        /// </summary>
        /// <returns></returns>
        public static Hashtable LoadAllHashTable()
        {
            SqlDataReader dr = LoadAllReader();
            return ConvertReaderToHashTable(dr);
        }

        /// <summary>
        /// Creates ForumArticleItems for records In the prefilled DataReader, And puts them into a HashTable
        /// </summary>
        /// <param name="dr">The DataReader prefilled With the ForumArticleItems records</param>
        /// <returns>The Hashtable containing ForumArticleItems objects And their ID As key.</returns>
        protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr)
        {
            Hashtable result = new Hashtable();
            while (dr.Read())
            {
                ForumArticleItems myForumArticleItems = new ForumArticleItems();

                myForumArticleItems.m_intArticleItemID = dr.GetSqlInt32(0);
                myForumArticleItems.m_intArticleID = dr.GetSqlInt32(1);
                myForumArticleItems.m_strSubject = dr.GetSqlString(2);
                myForumArticleItems.m_strReply = dr.GetSqlString(3);
                myForumArticleItems.m_intCommentType = dr.GetSqlInt32(4);
                myForumArticleItems.m_intScore = dr.GetSqlInt32(5);
                myForumArticleItems.m_intScoreCount = dr.GetSqlInt32(6);
                myForumArticleItems.m_intStatus = dr.GetSqlInt32(7);
                myForumArticleItems.m_intCreatedBy = dr.GetSqlInt32(8);
                myForumArticleItems.m_dtCreateDate = dr.GetSqlDateTime(9);

                result.Add(myForumArticleItems.ArticleItemID, myForumArticleItems);
            }

            return result;
        }

        public static int Insert(bForumArticleItems objForumArticleItems)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsInsert", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticleID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intArticleID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Subject", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_strSubject;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Reply", SqlDbType.Text);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_strReply;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CommentType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intCommentType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Score", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intScore;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ScoreCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intScoreCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_dtCreateDate;
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
                objForumArticleItems.ArticleItemID = retValue;
            return retValue;
        }

        public static int Insert(bForumArticleItems objForumArticleItems, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsInsert", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intArticleItemID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticleID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intArticleID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Subject", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_strSubject;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Reply", SqlDbType.Text);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_strReply;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CommentType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intCommentType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Score", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intScore;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ScoreCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intScoreCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_dtCreateDate;
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
                objForumArticleItems.ArticleItemID = retValue;
            return retValue;
        }

        public static int Update(bForumArticleItems objForumArticleItems)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsUpdate", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intArticleItemID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticleID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intArticleID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Subject", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_strSubject;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Reply", SqlDbType.Text);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_strReply;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CommentType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intCommentType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Score", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intScore;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ScoreCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intScoreCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_dtCreateDate;
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

        public static int Update(bForumArticleItems objForumArticleItems, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsUpdate", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intArticleItemID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticleID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intArticleID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Subject", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_strSubject;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Reply", SqlDbType.Text);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_strReply;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CommentType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intCommentType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Score", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intScore;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ScoreCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intScoreCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_dtCreateDate;
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

        public static int Delete(bForumArticleItems objForumArticleItems)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsDeleteByParams", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intArticleItemID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticleID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intArticleID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Subject", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_strSubject;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Reply", SqlDbType.Text);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_strReply;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CommentType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intCommentType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Score", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intScore;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ScoreCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intScoreCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_dtCreateDate;
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

        public static int Delete(bForumArticleItems objForumArticleItems, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsDeleteByParams", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intArticleItemID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticleID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intArticleID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Subject", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_strSubject;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Reply", SqlDbType.Text);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_strReply;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CommentType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intCommentType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Score", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intScore;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ScoreCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intScoreCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objForumArticleItems.m_dtCreateDate;
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
            return Load(pk.ArticleItemID.Value);
        }

        /// <summary>
        /// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
        /// </summary>
        /// <param name="intArticleItemID"> ArticleItemID key value</param>
        /// <returns>true if success</returns>
        public bool Load(Int32 intArticleItemID)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsSelect", conn);

            SqlParameter param;

            //	Add params
            // parameter for ArticleItemID column
            param = new SqlParameter("@ArticleItemID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = intArticleItemID;
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
                m_intArticleItemID = reader.GetSqlInt32(0);
                m_intArticleID = reader.GetSqlInt32(1);
                m_strSubject = reader.GetSqlString(2);
                m_strReply = reader.GetSqlString(3);
                m_intCommentType = reader.GetSqlInt32(4);
                m_intScore = reader.GetSqlInt32(5);
                m_intScoreCount = reader.GetSqlInt32(6);
                m_intStatus = reader.GetSqlInt32(7);
                m_intCreatedBy = reader.GetSqlInt32(8);
                m_dtCreateDate = reader.GetSqlDateTime(9);

            }
            else
            {
                //	set key values
                m_intArticleItemID = intArticleItemID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsSelectByParams", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticleItemID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticleID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticleID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Subject", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strSubject;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CommentType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCommentType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Score", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intScore;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ScoreCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intScoreCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intStatus;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsSelectByParams", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticleItemID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticleID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticleID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Subject", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strSubject;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Reply", SqlDbType.Text);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strReply;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CommentType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCommentType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Score", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intScore;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ScoreCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intScoreCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intStatus;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsInsert", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            // parameter for ArticleItemID column
            param = new SqlParameter("@ArticleItemID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticleItemID;
            cmd.Parameters.Add(param);

            // parameter for ArticleID column
            param = new SqlParameter("@ArticleID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticleID;
            cmd.Parameters.Add(param);

            // parameter for Subject column
            param = new SqlParameter("@Subject", SqlDbType.NVarChar, 300);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strSubject;
            cmd.Parameters.Add(param);

            // parameter for Reply column
            param = new SqlParameter("@Reply", SqlDbType.Text);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strReply;
            cmd.Parameters.Add(param);

            // parameter for CommentType column
            param = new SqlParameter("@CommentType", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCommentType;
            cmd.Parameters.Add(param);

            // parameter for Score column
            param = new SqlParameter("@Score", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intScore;
            cmd.Parameters.Add(param);

            // parameter for ScoreCount column
            param = new SqlParameter("@ScoreCount", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intScoreCount;
            cmd.Parameters.Add(param);

            // parameter for Status column
            param = new SqlParameter("@Status", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intStatus;
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
                ArticleItemID = retValue;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsUpdate", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            // parameter for ArticleItemID column
            param = new SqlParameter("@ArticleItemID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticleItemID;
            cmd.Parameters.Add(param);

            // parameter for ArticleID column
            param = new SqlParameter("@ArticleID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticleID;
            cmd.Parameters.Add(param);

            // parameter for Subject column
            param = new SqlParameter("@Subject", SqlDbType.NVarChar, 300);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strSubject;
            cmd.Parameters.Add(param);

            // parameter for Reply column
            param = new SqlParameter("@Reply", SqlDbType.Text);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strReply;
            cmd.Parameters.Add(param);

            // parameter for CommentType column
            param = new SqlParameter("@CommentType", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCommentType;
            cmd.Parameters.Add(param);

            // parameter for Score column
            param = new SqlParameter("@Score", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intScore;
            cmd.Parameters.Add(param);

            // parameter for ScoreCount column
            param = new SqlParameter("@ScoreCount", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intScoreCount;
            cmd.Parameters.Add(param);

            // parameter for Status column
            param = new SqlParameter("@Status", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intStatus;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsDelete", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            // parameter for ArticleItemID column
            param = new SqlParameter("@ArticleItemID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticleItemID;
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
        public static bool operator ==(bForumArticleItems t1, bForumArticleItems t2)
        {
            //	compare values
            if (t1.m_intArticleItemID != t2.m_intArticleItemID)
            {
                return false;	//	because "ArticleItemID" values are Not equal
            }

            if (t1.m_intArticleID != t2.m_intArticleID)
            {
                return false;	//	because "ArticleID" values are Not equal
            }

            if (t1.m_strSubject != t2.m_strSubject)
            {
                return false;	//	because "Subject" values are Not equal
            }

            if (t1.m_strReply != t2.m_strReply)
            {
                return false;	//	because "Reply" values are Not equal
            }

            if (t1.m_intCommentType != t2.m_intCommentType)
            {
                return false;	//	because "CommentType" values are Not equal
            }

            if (t1.m_intScore != t2.m_intScore)
            {
                return false;	//	because "Score" values are Not equal
            }

            if (t1.m_intScoreCount != t2.m_intScoreCount)
            {
                return false;	//	because "ScoreCount" values are Not equal
            }

            if (t1.m_intStatus != t2.m_intStatus)
            {
                return false;	//	because "Status" values are Not equal
            }

            if (t1.m_intCreatedBy != t2.m_intCreatedBy)
            {
                return false;	//	because "CreatedBy" values are Not equal
            }

            if (t1.m_dtCreateDate != t2.m_dtCreateDate)
            {
                return false;	//	because "CreateDate" values are Not equal
            }

            return true;	//	because every Valuestringequal
        }

        /// <summary>
        /// Compares two objects
        /// </summary>
        /// <param name="t1">The first Object To compare</param>
        /// <param name="t2">The Second Object To compare</param>
        /// <returns>true if success</returns>
        public static bool operator !=(bForumArticleItems t1, bForumArticleItems t2)
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
            retValue.Append(" ArticleItemID = \"");
            retValue.Append(m_intArticleItemID);
            retValue.Append("\"\n");

            retValue.Append("Columns:\n");
            retValue.Append("    ArticleID = \"");
            retValue.Append(m_intArticleID);
            retValue.Append("\"\n");
            retValue.Append("    Subject = \"");
            retValue.Append(m_strSubject);
            retValue.Append("\"\n");
            retValue.Append("    Reply = \"");
            retValue.Append(m_strReply);
            retValue.Append("\"\n");
            retValue.Append("    CommentType = \"");
            retValue.Append(m_intCommentType);
            retValue.Append("\"\n");
            retValue.Append("    Score = \"");
            retValue.Append(m_intScore);
            retValue.Append("\"\n");
            retValue.Append("    ScoreCount = \"");
            retValue.Append(m_intScoreCount);
            retValue.Append("\"\n");
            retValue.Append("    Status = \"");
            retValue.Append(m_intStatus);
            retValue.Append("\"\n");
            retValue.Append("    CreatedBy = \"");
            retValue.Append(m_intCreatedBy);
            retValue.Append("\"\n");
            retValue.Append("    CreateDate = \"");
            retValue.Append(m_dtCreateDate);
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
            if (!(o is ForumArticleItems))
            {
                //	types Not the same, return false
                return false;
            }

            //	compare objects And return retValue
            return this == (ForumArticleItems)o;
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

