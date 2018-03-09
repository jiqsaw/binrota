using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities
{

    public class bMemberPhotos
    {
        //transactions
        //	enum types
        protected enum Action { Insert, Update, Delete };
        //	Sub-types
        public struct PK
        {
            public SqlInt32 MemberPhotoID;
        }


        protected Action m_aAction;
        protected bool m_bIsDirty;

        #region Table Members
        protected SqlInt32 m_intMemberPhotoID;
        protected SqlString m_strPhotoName;
        protected SqlString m_strPhotoDesc;
        protected SqlString m_strPhotoUrl;
        protected SqlInt32 m_intPhotoType;
        protected SqlInt32 m_intAlbumID;
        protected SqlInt32 m_intMemberID;
        #endregion

        #region Properties

        public PK PrimaryKey
        {
            get
            {
                PK pk;
                pk.MemberPhotoID = m_intMemberPhotoID;
                return pk;
            }
        }


        public int MemberPhotoID
        {
            get
            {
                return (int)m_intMemberPhotoID;
            }
            set
            {
                m_intMemberPhotoID = value;
                m_bIsDirty = true;
            }
        }



        public string PhotoName
        {
            get
            {
                return (string)m_strPhotoName;
            }
            set
            {
                m_strPhotoName = value;
                m_bIsDirty = true;
            }
        }



        public string PhotoDesc
        {
            get
            {
                return (string)m_strPhotoDesc;
            }
            set
            {
                m_strPhotoDesc = value;
                m_bIsDirty = true;
            }
        }



        public string PhotoUrl
        {
            get
            {
                return (string)m_strPhotoUrl;
            }
            set
            {
                m_strPhotoUrl = value;
                m_bIsDirty = true;
            }
        }



        public int PhotoType
        {
            get
            {
                return (int)m_intPhotoType;
            }
            set
            {
                m_intPhotoType = value;
                m_bIsDirty = true;
            }
        }



        public int AlbumID
        {
            get
            {
                return (int)m_intAlbumID;
            }
            set
            {
                m_intAlbumID = value;
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

        #endregion

        #region Constructers

        public bMemberPhotos()
        {
            Init();	//	init Object
        }
        #endregion

        #region Static Functions

        /// <summary>
        /// Gets all MemberPhotos from the database, using the default connection string, into a SQLDataReader
        /// </summary>
        /// <returns>The SQLDataReader With the MemberPhotos</returns>

        public static SqlDataReader LoadAllReader()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMemberPhotosSelectAll", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        public static DataSet LoadAll()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMemberPhotosSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        /// <summary>
        /// Gets all MemberPhotos from the database, using the default connection string, into a hashtable SQLReader
        /// </summary>
        /// <returns></returns>
        public static Hashtable LoadAllHashTable()
        {
            SqlDataReader dr = LoadAllReader();
            return ConvertReaderToHashTable(dr);
        }

        /// <summary>
        /// Creates MemberPhotos for records In the prefilled DataReader, And puts them into a HashTable
        /// </summary>
        /// <param name="dr">The DataReader prefilled With the MemberPhotos records</param>
        /// <returns>The Hashtable containing MemberPhotos objects And their ID As key.</returns>
        protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr)
        {
            Hashtable result = new Hashtable();
            while (dr.Read())
            {
                MemberPhotos myMemberPhotos = new MemberPhotos();

                myMemberPhotos.m_intMemberPhotoID = dr.GetSqlInt32(0);
                myMemberPhotos.m_strPhotoName = dr.GetSqlString(1);
                myMemberPhotos.m_strPhotoDesc = dr.GetSqlString(2);
                myMemberPhotos.m_strPhotoUrl = dr.GetSqlString(3);
                myMemberPhotos.m_intPhotoType = dr.GetSqlInt32(4);
                myMemberPhotos.m_intAlbumID = dr.GetSqlInt32(5);
                myMemberPhotos.m_intMemberID = dr.GetSqlInt32(6);

                result.Add(myMemberPhotos.MemberPhotoID, myMemberPhotos);
            }

            return result;
        }

        public static int Insert(bMemberPhotos objMemberPhotos)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMemberPhotosInsert", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@MemberPhotoID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoUrl", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoUrl;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intPhotoType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AlbumID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intAlbumID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intMemberID;
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
                objMemberPhotos.MemberPhotoID = retValue;
            return retValue;
        }

        public static int Insert(bMemberPhotos objMemberPhotos, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMemberPhotosInsert", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@MemberPhotoID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intMemberPhotoID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoUrl", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoUrl;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intPhotoType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AlbumID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intAlbumID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intMemberID;
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
                objMemberPhotos.MemberPhotoID = retValue;
            return retValue;
        }

        public static int Update(bMemberPhotos objMemberPhotos)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMemberPhotosUpdate", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            param = new SqlParameter("@MemberPhotoID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intMemberPhotoID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoUrl", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoUrl;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intPhotoType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AlbumID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intAlbumID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intMemberID;
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

        public static int Update(bMemberPhotos objMemberPhotos, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMemberPhotosUpdate", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            param = new SqlParameter("@MemberPhotoID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intMemberPhotoID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoUrl", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoUrl;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intPhotoType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AlbumID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intAlbumID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intMemberID;
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

        public static int Delete(bMemberPhotos objMemberPhotos)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMemberPhotosDeleteByParams", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@MemberPhotoID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intMemberPhotoID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoUrl", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoUrl;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intPhotoType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AlbumID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intAlbumID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intMemberID;
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

        public static int Delete(bMemberPhotos objMemberPhotos, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            //	construct new connection and command objects
            SqlConnection conn = sqlConn;
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMemberPhotosDeleteByParams", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@MemberPhotoID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intMemberPhotoID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoUrl", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_strPhotoUrl;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intPhotoType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AlbumID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intAlbumID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = objMemberPhotos.m_intMemberID;
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
            return Load(pk.MemberPhotoID.Value);
        }

        /// <summary>
        /// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
        /// </summary>
        /// <param name="intMemberPhotoID"> MemberPhotoID key value</param>
        /// <returns>true if success</returns>
        public bool Load(Int32 intMemberPhotoID)
        {
            //	construct new connection and command objects
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMemberPhotosSelect", conn);

            SqlParameter param;

            //	Add params
            // parameter for MemberPhotoID column
            param = new SqlParameter("@MemberPhotoID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = intMemberPhotoID;
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
                m_intMemberPhotoID = reader.GetSqlInt32(0);
                m_strPhotoName = reader.GetSqlString(1);
                m_strPhotoDesc = reader.GetSqlString(2);
                m_strPhotoUrl = reader.GetSqlString(3);
                m_intPhotoType = reader.GetSqlInt32(4);
                m_intAlbumID = reader.GetSqlInt32(5);
                m_intMemberID = reader.GetSqlInt32(6);

            }
            else
            {
                //	set key values
                m_intMemberPhotoID = intMemberPhotoID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMemberPhotosSelectByParams", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@MemberPhotoID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intMemberPhotoID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoUrl", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoUrl;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intPhotoType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AlbumID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intAlbumID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intMemberID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMemberPhotosSelectByParams", conn);
            cmd.Transaction = sqlTran;

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@MemberPhotoID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intMemberPhotoID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoName", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoDesc", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoDesc;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoUrl", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoUrl;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intPhotoType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AlbumID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intAlbumID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intMemberID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMemberPhotosInsert", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            // parameter for MemberPhotoID column
            param = new SqlParameter("@MemberPhotoID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intMemberPhotoID;
            cmd.Parameters.Add(param);

            // parameter for PhotoName column
            param = new SqlParameter("@PhotoName", SqlDbType.NVarChar, 100);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoName;
            cmd.Parameters.Add(param);

            // parameter for PhotoDesc column
            param = new SqlParameter("@PhotoDesc", SqlDbType.NVarChar, 500);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoDesc;
            cmd.Parameters.Add(param);

            // parameter for PhotoUrl column
            param = new SqlParameter("@PhotoUrl", SqlDbType.NVarChar, 300);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoUrl;
            cmd.Parameters.Add(param);

            // parameter for PhotoType column
            param = new SqlParameter("@PhotoType", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intPhotoType;
            cmd.Parameters.Add(param);

            // parameter for AlbumID column
            param = new SqlParameter("@AlbumID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intAlbumID;
            cmd.Parameters.Add(param);

            // parameter for MemberID column
            param = new SqlParameter("@MemberID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intMemberID;
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
                MemberPhotoID = retValue;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMemberPhotosUpdate", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	add params
            // parameter for MemberPhotoID column
            param = new SqlParameter("@MemberPhotoID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intMemberPhotoID;
            cmd.Parameters.Add(param);

            // parameter for PhotoName column
            param = new SqlParameter("@PhotoName", SqlDbType.NVarChar, 100);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoName;
            cmd.Parameters.Add(param);

            // parameter for PhotoDesc column
            param = new SqlParameter("@PhotoDesc", SqlDbType.NVarChar, 500);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoDesc;
            cmd.Parameters.Add(param);

            // parameter for PhotoUrl column
            param = new SqlParameter("@PhotoUrl", SqlDbType.NVarChar, 300);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strPhotoUrl;
            cmd.Parameters.Add(param);

            // parameter for PhotoType column
            param = new SqlParameter("@PhotoType", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intPhotoType;
            cmd.Parameters.Add(param);

            // parameter for AlbumID column
            param = new SqlParameter("@AlbumID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intAlbumID;
            cmd.Parameters.Add(param);

            // parameter for MemberID column
            param = new SqlParameter("@MemberID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intMemberID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMemberPhotosDelete", conn);

            SqlParameter param;

            //	add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            // parameter for MemberPhotoID column
            param = new SqlParameter("@MemberPhotoID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intMemberPhotoID;
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
        public static bool operator ==(bMemberPhotos t1, bMemberPhotos t2)
        {
            //	compare values
            if (t1.m_intMemberPhotoID != t2.m_intMemberPhotoID)
            {
                return false;	//	because "MemberPhotoID" values are Not equal
            }

            if (t1.m_strPhotoName != t2.m_strPhotoName)
            {
                return false;	//	because "PhotoName" values are Not equal
            }

            if (t1.m_strPhotoDesc != t2.m_strPhotoDesc)
            {
                return false;	//	because "PhotoDesc" values are Not equal
            }

            if (t1.m_strPhotoUrl != t2.m_strPhotoUrl)
            {
                return false;	//	because "PhotoUrl" values are Not equal
            }

            if (t1.m_intPhotoType != t2.m_intPhotoType)
            {
                return false;	//	because "PhotoType" values are Not equal
            }

            if (t1.m_intAlbumID != t2.m_intAlbumID)
            {
                return false;	//	because "AlbumID" values are Not equal
            }

            if (t1.m_intMemberID != t2.m_intMemberID)
            {
                return false;	//	because "MemberID" values are Not equal
            }

            return true;	//	because every Valuestringequal
        }

        /// <summary>
        /// Compares two objects
        /// </summary>
        /// <param name="t1">The first Object To compare</param>
        /// <param name="t2">The Second Object To compare</param>
        /// <returns>true if success</returns>
        public static bool operator !=(bMemberPhotos t1, bMemberPhotos t2)
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
            retValue.Append(" MemberPhotoID = \"");
            retValue.Append(m_intMemberPhotoID);
            retValue.Append("\"\n");

            retValue.Append("Columns:\n");
            retValue.Append("    PhotoName = \"");
            retValue.Append(m_strPhotoName);
            retValue.Append("\"\n");
            retValue.Append("    PhotoDesc = \"");
            retValue.Append(m_strPhotoDesc);
            retValue.Append("\"\n");
            retValue.Append("    PhotoUrl = \"");
            retValue.Append(m_strPhotoUrl);
            retValue.Append("\"\n");
            retValue.Append("    PhotoType = \"");
            retValue.Append(m_intPhotoType);
            retValue.Append("\"\n");
            retValue.Append("    AlbumID = \"");
            retValue.Append(m_intAlbumID);
            retValue.Append("\"\n");
            retValue.Append("    MemberID = \"");
            retValue.Append(m_intMemberID);
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
            if (!(o is MemberPhotos))
            {
                //	types Not the same, return false
                return false;
            }

            //	compare objects And return retValue
            return this == (MemberPhotos)o;
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

