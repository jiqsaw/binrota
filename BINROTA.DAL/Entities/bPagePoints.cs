using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities
{

    public class bPagePoints
    {
        //transactions
        //	enum types
        protected enum Action { Insert, Update, Delete };
        //	Sub-types
        public struct PK
        {
            public SqlInt32 PagePointID;
        }


        protected Action m_aAction;
        protected bool m_bIsDirty;

        #region Table Members
        protected SqlInt32 m_intPagePointID;
        protected SqlInt32 m_intPageID;
        protected SqlInt32 m_intMemberID;
        protected SqlInt32 m_intPoints;
        #endregion

        #region Properties

        public PK PrimaryKey
        {
            get
            {
                PK pk;
                pk.PagePointID = m_intPagePointID;
                return pk;
            }
        }


        public int PagePointID
        {
            get
            {
                return (int)m_intPagePointID;
            }
            set
            {
                m_intPagePointID = value;
                m_bIsDirty = true;
            }
        }



        public int PageID
        {
            get
            {
                return (int)m_intPageID;
            }
            set
            {
                m_intPageID = value;
                m_bIsDirty = true;
            }
        }



        public int MemberID
        {
            get
            {
                return (int)m_intMemberID;
            }
            set
            {
                m_intMemberID = value;
                m_bIsDirty = true;
            }
        }



        public int Points
        {
            get
            {
                return (int)m_intPoints;
            }
            set
            {
                m_intPoints = value;
                m_bIsDirty = true;
            }
        }

        #endregion

        #region Constructers

        public bPagePoints()
        {
            Init();	//	init Object
        }
        #endregion

        #region Static Functions

        /// <summary>
        /// Gets all PagePoints from the database, using the default connection string, into a SQLDataReader
        /// </summary>
        /// <returns>The SQLDataReader With the PagePoints</returns>

        public static SqlDataReader LoadAllReader()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePointsSelectAll", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        public static DataSet LoadAll()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePointsSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        /// <summary>
        /// Gets all PagePoints from the database, using the default connection string, into a hashtable SQLReader
        /// </summary>
        /// <returns></returns>
        public static Hashtable LoadAllHashTable()
        {
            SqlDataReader dr = LoadAllReader();
            return ConvertReaderToHashTable(dr);
        }

        /// <summary>
        /// Creates PagePoints for records In the prefilled DataReader, And puts them into a HashTable
        /// </summary>
        /// <param name="dr">The DataReader prefilled With the PagePoints records</param>
        /// <returns>The Hashtable containing PagePoints objects And their ID As key.</returns>
        protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr)
        {
            Hashtable result = new Hashtable();
            while (dr.Read())
            {
                PagePoints myPagePoints = new PagePoints();

                myPagePoints.m_intPagePointID = dr.GetSqlInt32(0);
                myPagePoints.m_intPageID = dr.GetSqlInt32(1);
                myPagePoints.m_intMemberID = dr.GetSqlInt32(2);
                myPagePoints.m_intPoints = dr.GetSqlInt32(3);

                result.Add(myPagePoints.PagePointID, myPagePoints);
            }

            return result;
        }

        public static DataSet LoadByParams(object intPagePointID, object intPageID, object intMemberID, object intPoints)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePointsSelectByParams", conn);
            SqlParameter param;



            param = new SqlParameter("@PagePointID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = (intPagePointID == null ? intPagePointID : (int)intPagePointID);
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = (intPageID == null ? intPageID : (int)intPageID);
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = (intMemberID == null ? intMemberID : (int)intMemberID);
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Points", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = (intPoints == null ? intPoints : (int)intPoints);
            cmd.Parameters.Add(param);

            //	open connection
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        public static DataSet LoadByParams(object intPagePointID, object intPageID, object intMemberID, object intPoints, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePointsSelectByParams", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            param = new SqlParameter("@PagePointID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = (intPagePointID == null ? intPagePointID : (int)intPagePointID);
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = (intPageID == null ? intPageID : (int)intPageID);
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = (intMemberID == null ? intMemberID : (int)intMemberID);
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Points", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = (intPoints == null ? intPoints : (int)intPoints);
            cmd.Parameters.Add(param);

            //	open connection
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        public static int Insert(bPagePoints objPagePoints)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePointsInsert", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@PagePointID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.PagePointID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.PageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.MemberID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Points", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.Points;
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
                objPagePoints.PagePointID = retValue;
            return retValue;
        }

        public static int Insert(bPagePoints objPagePoints, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePointsInsert", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@PagePointID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.PagePointID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.PageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.MemberID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Points", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.Points;
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
                objPagePoints.PagePointID = retValue;
            return retValue;
        }

        public static int Update(bPagePoints objPagePoints)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePointsUpdate", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            param = new SqlParameter("@PagePointID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.PagePointID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.PageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.MemberID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Points", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.Points;
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

        public static int Update(bPagePoints objPagePoints, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePointsUpdate", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            param = new SqlParameter("@PagePointID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.PagePointID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.PageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.MemberID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Points", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.Points;
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

        public static int Delete(bPagePoints objPagePoints)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePointsDelete", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@PagePointID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.PagePointID;
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

        public static int Delete(bPagePoints objPagePoints, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePointsUpdate", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@PagePointID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objPagePoints.PagePointID;
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

        #endregion

        #region Public Functions

        /// <summary>
        /// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
        /// </summary>
        /// <param name="pk">PK struct</param>
        /// <returns>true member variables filled.</returns>
        public bool Load(PK pk)
        {
            return Load(pk.PagePointID.Value);
        }

        /// <summary>
        /// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
        /// </summary>
        /// <param name="intPagePointID"> PagePointID key value</param>
        /// <returns>true if success</returns>
        public bool Load(Int32 intPagePointID)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePointsSelect", conn);

            SqlParameter param;

            //	Add params
            // parameter for PagePointID column
            param = new SqlParameter("@PagePointID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = intPagePointID;
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
                m_intPagePointID = reader.GetSqlInt32(0);
                m_intPageID = reader.GetSqlInt32(1);
                m_intMemberID = reader.GetSqlInt32(2);
                m_intPoints = reader.GetSqlInt32(3);

            }
            else
            {
                //	set key values
                m_intPagePointID = intPagePointID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePointsSelectByParams", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@PagePointID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intPagePointID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intPageID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intMemberID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Points", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intPoints;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePointsInsert", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            // parameter for PagePointID column
            param = new SqlParameter("@PagePointID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intPagePointID;
            cmd.Parameters.Add(param);

            // parameter for PageID column
            param = new SqlParameter("@PageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intPageID;
            cmd.Parameters.Add(param);

            // parameter for MemberID column
            param = new SqlParameter("@MemberID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intMemberID;
            cmd.Parameters.Add(param);

            // parameter for Points column
            param = new SqlParameter("@Points", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intPoints;
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
                PagePointID = retValue;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePointsUpdate", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            // parameter for PagePointID column
            param = new SqlParameter("@PagePointID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intPagePointID;
            cmd.Parameters.Add(param);

            // parameter for PageID column
            param = new SqlParameter("@PageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intPageID;
            cmd.Parameters.Add(param);

            // parameter for MemberID column
            param = new SqlParameter("@MemberID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intMemberID;
            cmd.Parameters.Add(param);

            // parameter for Points column
            param = new SqlParameter("@Points", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intPoints;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePointsDelete", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            // parameter for PagePointID column
            param = new SqlParameter("@PagePointID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intPagePointID;
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
        public static bool operator ==(bPagePoints t1, bPagePoints t2)
        {
            //	compare values
            if (t1.m_intPagePointID != t2.m_intPagePointID)
            {
                return false;	//	because "PagePointID" values are Not equal
            }

            if (t1.m_intPageID != t2.m_intPageID)
            {
                return false;	//	because "PageID" values are Not equal
            }

            if (t1.m_intMemberID != t2.m_intMemberID)
            {
                return false;	//	because "MemberID" values are Not equal
            }

            if (t1.m_intPoints != t2.m_intPoints)
            {
                return false;	//	because "Points" values are Not equal
            }

            return true;	//	because every Valuestringequal
        }

        /// <summary>
        /// Compares two objects
        /// </summary>
        /// <param name="t1">The first Object To compare</param>
        /// <param name="t2">The Second Object To compare</param>
        /// <returns>true if success</returns>
        public static bool operator !=(bPagePoints t1, bPagePoints t2)
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
            retValue.Append(" PagePointID = \"");
            retValue.Append(m_intPagePointID);
            retValue.Append("\"\n");

            retValue.Append("Columns:\n");
            retValue.Append("    PageID = \"");
            retValue.Append(m_intPageID);
            retValue.Append("\"\n");
            retValue.Append("    MemberID = \"");
            retValue.Append(m_intMemberID);
            retValue.Append("\"\n");
            retValue.Append("    Points = \"");
            retValue.Append(m_intPoints);
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
            if (!(o is PagePoints))
            {
                //	types Not the same, return false
                return false;
            }

            //	compare objects And return retValue
            return this == (PagePoints)o;
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

