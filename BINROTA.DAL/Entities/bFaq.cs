using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities
{

    public class bFaq
    {
        //transactions
        //	enum types
        protected enum Action { Insert, Update, Delete };
        //	Sub-types
        public struct PK
        {
            public SqlInt32 FaqID;
        }


        protected Action m_aAction;
        protected bool m_bIsDirty;

        #region Table Members
        protected SqlInt32 m_intFaqID;
        protected SqlInt32 m_intUserID;
        protected SqlString m_strQuestion;
        protected SqlString m_strAnswer;
        protected SqlBoolean m_bolisActive;
        protected SqlDateTime m_dtCreateDate;
        protected SqlDateTime m_FindBefore_dtCreateDate;
        protected SqlDateTime m_FindAfter_dtCreateDate;
        protected SqlDateTime m_dtModifyDate;
        protected SqlDateTime m_FindBefore_dtModifyDate;
        protected SqlDateTime m_FindAfter_dtModifyDate;
        protected SqlInt32 m_intModifiedBy;
        #endregion

        #region Properties

        public PK PrimaryKey
        {
            get
            {
                PK pk;
                pk.FaqID = m_intFaqID;
                return pk;
            }
        }


        public int FaqID
        {
            get
            {
                return (int)m_intFaqID;
            }
            set
            {
                m_intFaqID = value;
                m_bIsDirty = true;
            }
        }



        public int UserID
        {
            get
            {
                return (int)m_intUserID;
            }
            set
            {
                m_intUserID = value;
                m_bIsDirty = true;
            }
        }



        public string Question
        {
            get
            {
                return (string)m_strQuestion;
            }
            set
            {
                m_strQuestion = value;
                m_bIsDirty = true;
            }
        }



        public string Answer
        {
            get
            {
                return (string)m_strAnswer;
            }
            set
            {
                m_strAnswer = value;
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

        public DateTime FindBefore_ModifyDate
        {
            get
            {
                return (DateTime)m_FindBefore_dtModifyDate;
            }
            set
            {
                m_FindBefore_dtModifyDate = value;
                m_bIsDirty = true;
            }
        }

        public DateTime FindAfter_ModifyDate
        {
            get
            {
                return (DateTime)m_FindAfter_dtModifyDate;
            }
            set
            {
                m_FindAfter_dtModifyDate = value;
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

        #endregion

        #region Constructers

        public bFaq()
        {
            Init();	//	init Object
        }
        #endregion

        #region Static Functions

        /// <summary>
        /// Gets all Faq from the database, using the default connection string, into a SQLDataReader
        /// </summary>
        /// <returns>The SQLDataReader With the Faq</returns>

        public static SqlDataReader LoadAllReader()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocFaqSelectAll", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        public static DataSet LoadAll()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocFaqSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        /// <summary>
        /// Gets all Faq from the database, using the default connection string, into a hashtable SQLReader
        /// </summary>
        /// <returns></returns>
        public static Hashtable LoadAllHashTable()
        {
            SqlDataReader dr = LoadAllReader();
            return ConvertReaderToHashTable(dr);
        }

        /// <summary>
        /// Creates Faq for records In the prefilled DataReader, And puts them into a HashTable
        /// </summary>
        /// <param name="dr">The DataReader prefilled With the Faq records</param>
        /// <returns>The Hashtable containing Faq objects And their ID As key.</returns>
        protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr)
        {
            Hashtable result = new Hashtable();
            while (dr.Read())
            {
                Faq myFaq = new Faq();

                myFaq.m_intFaqID = dr.GetSqlInt32(0);
                myFaq.m_intUserID = dr.GetSqlInt32(1);
                myFaq.m_strQuestion = dr.GetSqlString(2);
                myFaq.m_strAnswer = dr.GetSqlString(3);
                myFaq.m_bolisActive = dr.GetSqlBoolean(4);
                myFaq.m_dtCreateDate = dr.GetSqlDateTime(5);
                myFaq.m_dtModifyDate = dr.GetSqlDateTime(6);
                myFaq.m_intModifiedBy = dr.GetSqlInt32(7);

                result.Add(myFaq.FaqID, myFaq);
            }

            return result;
        }

        public static int Insert(bFaq objFaq)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocFaqInsert", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@FaqID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intUserID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Question", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_strQuestion;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Answer", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_strAnswer;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_bolisActive;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intModifiedBy;
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
                objFaq.FaqID = retValue;
            return retValue;
        }

        public static int Insert(bFaq objFaq, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocFaqInsert", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@FaqID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intFaqID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intUserID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Question", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_strQuestion;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Answer", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_strAnswer;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_bolisActive;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intModifiedBy;
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
                objFaq.FaqID = retValue;
            return retValue;
        }

        public static int Update(bFaq objFaq)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocFaqUpdate", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            param = new SqlParameter("@FaqID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intFaqID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intUserID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Question", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_strQuestion;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Answer", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_strAnswer;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_bolisActive;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intModifiedBy;
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

        public static int Update(bFaq objFaq, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocFaqUpdate", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            param = new SqlParameter("@FaqID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intFaqID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intUserID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Question", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_strQuestion;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Answer", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_strAnswer;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_bolisActive;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intModifiedBy;
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

        public static int Delete(bFaq objFaq)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocFaqDeleteByParams", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@FaqID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intFaqID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intUserID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Question", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_strQuestion;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Answer", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_strAnswer;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_bolisActive;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intModifiedBy;
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

        public static int Delete(bFaq objFaq, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocFaqDeleteByParams", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@FaqID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intFaqID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intUserID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Question", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_strQuestion;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Answer", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_strAnswer;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_bolisActive;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objFaq.m_intModifiedBy;
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
            return Load(pk.FaqID.Value);
        }

        /// <summary>
        /// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
        /// </summary>
        /// <param name="intFaqID"> FaqID key value</param>
        /// <returns>true if success</returns>
        public bool Load(Int32 intFaqID)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocFaqSelect", conn);

            SqlParameter param;

            //	Add params
            // parameter for FaqID column
            param = new SqlParameter("@FaqID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = intFaqID;
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
                m_intFaqID = reader.GetSqlInt32(0);
                m_intUserID = reader.GetSqlInt32(1);
                m_strQuestion = reader.GetSqlString(2);
                m_strAnswer = reader.GetSqlString(3);
                m_bolisActive = reader.GetSqlBoolean(4);
                m_dtCreateDate = reader.GetSqlDateTime(5);
                m_dtModifyDate = reader.GetSqlDateTime(6);
                m_intModifiedBy = reader.GetSqlInt32(7);

            }
            else
            {
                //	set key values
                m_intFaqID = intFaqID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocFaqSelectByParams", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@FaqID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intFaqID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intUserID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Question", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strQuestion;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Answer", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strAnswer;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = m_bolisActive;
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

            param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Before_ModifyDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindBefore_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@After_ModifyDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindAfter_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intModifiedBy;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocFaqSelectByParams", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@FaqID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intFaqID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@UserID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intUserID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Question", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strQuestion;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Answer", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strAnswer;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = m_bolisActive;
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

            param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Before_ModifyDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindBefore_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@After_ModifyDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindAfter_dtModifyDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intModifiedBy;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocFaqInsert", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            // parameter for FaqID column
            param = new SqlParameter("@FaqID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intFaqID;
            cmd.Parameters.Add(param);

            // parameter for UserID column
            param = new SqlParameter("@UserID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intUserID;
            cmd.Parameters.Add(param);

            // parameter for Question column
            param = new SqlParameter("@Question", SqlDbType.NVarChar, 1024);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strQuestion;
            cmd.Parameters.Add(param);

            // parameter for Answer column
            param = new SqlParameter("@Answer", SqlDbType.NVarChar, 2000);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strAnswer;
            cmd.Parameters.Add(param);

            // parameter for isActive column
            param = new SqlParameter("@isActive", SqlDbType.Bit, 1);
            param.Direction = ParameterDirection.Input;
            param.Value = m_bolisActive;
            cmd.Parameters.Add(param);

            // parameter for CreateDate column
            param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtCreateDate;
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
                FaqID = retValue;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocFaqUpdate", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            // parameter for FaqID column
            param = new SqlParameter("@FaqID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intFaqID;
            cmd.Parameters.Add(param);

            // parameter for UserID column
            param = new SqlParameter("@UserID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intUserID;
            cmd.Parameters.Add(param);

            // parameter for Question column
            param = new SqlParameter("@Question", SqlDbType.NVarChar, 1024);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strQuestion;
            cmd.Parameters.Add(param);

            // parameter for Answer column
            param = new SqlParameter("@Answer", SqlDbType.NVarChar, 2000);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strAnswer;
            cmd.Parameters.Add(param);

            // parameter for isActive column
            param = new SqlParameter("@isActive", SqlDbType.Bit, 1);
            param.Direction = ParameterDirection.Input;
            param.Value = m_bolisActive;
            cmd.Parameters.Add(param);

            // parameter for CreateDate column
            param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtCreateDate;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocFaqDelete", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            // parameter for FaqID column
            param = new SqlParameter("@FaqID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intFaqID;
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
        public static bool operator ==(bFaq t1, bFaq t2)
        {
            //	compare values
            if (t1.m_intFaqID != t2.m_intFaqID)
            {
                return false;	//	because "FaqID" values are Not equal
            }

            if (t1.m_intUserID != t2.m_intUserID)
            {
                return false;	//	because "UserID" values are Not equal
            }

            if (t1.m_strQuestion != t2.m_strQuestion)
            {
                return false;	//	because "Question" values are Not equal
            }

            if (t1.m_strAnswer != t2.m_strAnswer)
            {
                return false;	//	because "Answer" values are Not equal
            }

            if (t1.m_bolisActive != t2.m_bolisActive)
            {
                return false;	//	because "isActive" values are Not equal
            }

            if (t1.m_dtCreateDate != t2.m_dtCreateDate)
            {
                return false;	//	because "CreateDate" values are Not equal
            }

            if (t1.m_dtModifyDate != t2.m_dtModifyDate)
            {
                return false;	//	because "ModifyDate" values are Not equal
            }

            if (t1.m_intModifiedBy != t2.m_intModifiedBy)
            {
                return false;	//	because "ModifiedBy" values are Not equal
            }

            return true;	//	because every Valuestringequal
        }

        /// <summary>
        /// Compares two objects
        /// </summary>
        /// <param name="t1">The first Object To compare</param>
        /// <param name="t2">The Second Object To compare</param>
        /// <returns>true if success</returns>
        public static bool operator !=(bFaq t1, bFaq t2)
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
            retValue.Append(" FaqID = \"");
            retValue.Append(m_intFaqID);
            retValue.Append("\"\n");

            retValue.Append("Columns:\n");
            retValue.Append("    UserID = \"");
            retValue.Append(m_intUserID);
            retValue.Append("\"\n");
            retValue.Append("    Question = \"");
            retValue.Append(m_strQuestion);
            retValue.Append("\"\n");
            retValue.Append("    Answer = \"");
            retValue.Append(m_strAnswer);
            retValue.Append("\"\n");
            retValue.Append("    isActive = \"");
            retValue.Append(m_bolisActive);
            retValue.Append("\"\n");
            retValue.Append("    CreateDate = \"");
            retValue.Append(m_dtCreateDate);
            retValue.Append("\"\n");
            retValue.Append("    ModifyDate = \"");
            retValue.Append(m_dtModifyDate);
            retValue.Append("\"\n");
            retValue.Append("    ModifiedBy = \"");
            retValue.Append(m_intModifiedBy);
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
            if (!(o is Faq))
            {
                //	types Not the same, return false
                return false;
            }

            //	compare objects And return retValue
            return this == (Faq)o;
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

