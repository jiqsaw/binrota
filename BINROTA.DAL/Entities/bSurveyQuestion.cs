using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities {

	public class bSurveyQuestion {
		//transactions
		//	enum types
		protected enum Action { Insert, Update, Delete };
			//	Sub-types
		public struct PK {
				public SqlInt32 SurveyQuestionID;
		}	
		
		
		protected Action m_aAction;
		protected bool m_bIsDirty;

		#region Table Members
		protected SqlInt32 m_intSurveyQuestionID;
		protected SqlString m_strSurveyQuestion;
		protected SqlBoolean m_bolisMain;
		protected SqlBoolean m_bolisActive;
		#endregion
		
		#region Properties
	
		public PK PrimaryKey {
			get {
				PK pk;
				pk.SurveyQuestionID = m_intSurveyQuestionID;
				return pk;
			}
		}
			
		
		public int SurveyQuestionID {
			get {
				return (int)m_intSurveyQuestionID;
			}
			set {
				m_intSurveyQuestionID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string SurveyQuestion {
			get {
				return (string)m_strSurveyQuestion;
			}
			set {
				m_strSurveyQuestion = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public bool isMain {
			get {
				return (bool)m_bolisMain;
			}
			set {
				m_bolisMain = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public bool isActive {
			get {
				return (bool)m_bolisActive;
			}
			set {
				m_bolisActive = value;
				m_bIsDirty = true;
			}
		}
		
	#endregion
	
		#region Constructers

		public bSurveyQuestion() {
			Init();	//	init Object
		}
		#endregion

		#region Static Functions

		/// <summary>
		/// Gets all SurveyQuestion from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the SurveyQuestion</returns>
		
		public static SqlDataReader LoadAllReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyQuestionSelectAll", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet LoadAll() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyQuestionSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all SurveyQuestion from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable LoadAllHashTable() {
			SqlDataReader dr = LoadAllReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates SurveyQuestion for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the SurveyQuestion records</param>
		/// <returns>The Hashtable containing SurveyQuestion objects And their ID As key.</returns>
		protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            SurveyQuestion mySurveyQuestion = new SurveyQuestion();
            
            mySurveyQuestion.m_intSurveyQuestionID = dr.GetSqlInt32(0);
            mySurveyQuestion.m_strSurveyQuestion = dr.GetSqlString(1);
            mySurveyQuestion.m_bolisMain = dr.GetSqlBoolean(2);
            mySurveyQuestion.m_bolisActive = dr.GetSqlBoolean(3);
            
            result.Add(mySurveyQuestion.SurveyQuestionID, mySurveyQuestion);
		}
	
			return result;
		}
		
		public static DataSet LoadByParams(object intSurveyQuestionID , object strSurveyQuestion , object bolisMain , object bolisActive) 
		{
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyQuestionSelectByParams", conn);
			SqlParameter param;
			
			
			
		        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSurveyQuestionID==null ? intSurveyQuestionID : (int)intSurveyQuestionID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyQuestion", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strSurveyQuestion==null ? strSurveyQuestion : (string)strSurveyQuestion);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isMain", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=(bolisMain==null ? bolisMain : (bool)bolisMain);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isActive", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=(bolisActive==null ? bolisActive : (bool)bolisActive);
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static DataSet LoadByParams(object intSurveyQuestionID , object strSurveyQuestion , object bolisMain , object bolisActive,SqlConnection sqlConn,SqlTransaction sqlTran) 
		{
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyQuestionSelectByParams", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
			
		        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSurveyQuestionID==null ? intSurveyQuestionID : (int)intSurveyQuestionID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyQuestion", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strSurveyQuestion==null ? strSurveyQuestion : (string)strSurveyQuestion);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isMain", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=(bolisMain==null ? bolisMain : (bool)bolisMain);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isActive", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=(bolisActive==null ? bolisActive : (bool)bolisActive);
        cmd.Parameters.Add(param);
        
		//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static int Insert(bSurveyQuestion objSurveyQuestion) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyQuestionInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.SurveyQuestionID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyQuestion", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.SurveyQuestion;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isMain", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.isMain;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isActive", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.isActive;
        cmd.Parameters.Add(param);
        
		
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			//	close connection
			conn.Close();
		
			//	set dirty flag To false
			if (retValue != 0)
				objSurveyQuestion.SurveyQuestionID = retValue;
			return retValue;
		}
		
		public static int Insert(bSurveyQuestion objSurveyQuestion,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyQuestionInsert", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.SurveyQuestionID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyQuestion", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.SurveyQuestion;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isMain", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.isMain;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isActive", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.isActive;
        cmd.Parameters.Add(param);
        
		
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			//	close connection
			conn.Close();
		
			//	set dirty flag To false
			if (retValue != 0)
				objSurveyQuestion.SurveyQuestionID = retValue;
			return retValue;
		}

		public static int Update(bSurveyQuestion objSurveyQuestion) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyQuestionUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.SurveyQuestionID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyQuestion", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.SurveyQuestion;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isMain", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.isMain;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isActive", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.isActive;
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			
			//	close connection
			conn.Close();
		
		
			return retValue;
		}
		
		public static int Update(bSurveyQuestion objSurveyQuestion,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyQuestionUpdate", conn);
			cmd.Transaction=sqlTran;
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.SurveyQuestionID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyQuestion", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.SurveyQuestion;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isMain", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.isMain;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isActive", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.isActive;
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			
			//	close connection
			conn.Close();
		
			return retValue;
		}
		
		public static int Delete(bSurveyQuestion objSurveyQuestion) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyQuestionDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.SurveyQuestionID;
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			//	close connection
			conn.Close();
			
			return retValue;
		}
		
		public static int Delete(bSurveyQuestion objSurveyQuestion,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyQuestionUpdate", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyQuestion.SurveyQuestionID;
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
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
		public bool Load(PK pk) {
			return Load(pk.SurveyQuestionID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intSurveyQuestionID"> SurveyQuestionID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intSurveyQuestionID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyQuestionSelect", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for SurveyQuestionID column
        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intSurveyQuestionID;
        cmd.Parameters.Add(param);
        
		//	open connection
				conn.Open();
				//	Execute command And get reader
				SqlDataReader reader = cmd.ExecuteReader();
		
				bool found = false;	//	false solution
		
				//	check if  anything was found
				if(reader.Read()) {
					found = true;	//	corresponding row found
					m_aAction = Action.Update;	//	future action
		
					//	set member values
		            m_intSurveyQuestionID = reader.GetSqlInt32(0);
            m_strSurveyQuestion = reader.GetSqlString(1);
            m_bolisMain = reader.GetSqlBoolean(2);
            m_bolisActive = reader.GetSqlBoolean(3);
		
			} else {
			//	set key values
		            m_intSurveyQuestionID = intSurveyQuestionID;
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
		public int Save() {
			int retValue;
			switch(m_aAction) {
				case Action.Insert:
					//	insert row
					retValue = ins();
					//	future action To be update
					m_aAction = Action.Update;
					//	return retValue from insert
					return retValue;
				case Action.Update:
					//	check if  Objectstringdirty
					if (m_bIsDirty)	{
						//	update row And return retValue
						return upd();
					} else {
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
		public int Delete() {
			m_aAction = Action.Delete;	//	actionstringdelete
			return Save();
		}
	
		public DataSet LoadByParams() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyQuestionSelectByParams", conn);

			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intSurveyQuestionID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyQuestion", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strSurveyQuestion;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isMain", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=m_bolisMain;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isActive", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=m_bolisActive;
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
		protected void Init() {
			m_aAction = Action.Insert;	//	initial action
			m_bIsDirty = false;	//	Objectstring"clean" upon init
		}
		
		protected int ins() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyQuestionInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for SurveyQuestionID column
        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSurveyQuestionID;
        cmd.Parameters.Add(param);
        
        // parameter for SurveyQuestion column
        param = new SqlParameter("@SurveyQuestion", SqlDbType.NVarChar, 400);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strSurveyQuestion;
        cmd.Parameters.Add(param);
        
        // parameter for isMain column
        param = new SqlParameter("@isMain", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisMain;
        cmd.Parameters.Add(param);
        
        // parameter for isActive column
        param = new SqlParameter("@isActive", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisActive;
        cmd.Parameters.Add(param);
        
		
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			//	close connection
			conn.Close();
		
			//	set dirty flag To false
			m_bIsDirty = false;
			if (retValue != 0)
				SurveyQuestionID = retValue;
			return retValue;
		}
	
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		protected int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyQuestionUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for SurveyQuestionID column
        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSurveyQuestionID;
        cmd.Parameters.Add(param);
        
        // parameter for SurveyQuestion column
        param = new SqlParameter("@SurveyQuestion", SqlDbType.NVarChar, 400);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strSurveyQuestion;
        cmd.Parameters.Add(param);
        
        // parameter for isMain column
        param = new SqlParameter("@isMain", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisMain;
        cmd.Parameters.Add(param);
        
        // parameter for isActive column
        param = new SqlParameter("@isActive", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisActive;
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
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
		protected int del() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyQuestionDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for SurveyQuestionID column
        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSurveyQuestionID;
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
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
		public static bool operator ==(bSurveyQuestion t1, bSurveyQuestion t2) {
			//	compare values
			if(t1.m_intSurveyQuestionID != t2.m_intSurveyQuestionID) {
				return false;	//	because "SurveyQuestionID" values are Not equal
			}
	
			if(t1.m_strSurveyQuestion != t2.m_strSurveyQuestion) {
				return false;	//	because "SurveyQuestion" values are Not equal
			}
	
			if(t1.m_bolisMain != t2.m_bolisMain) {
				return false;	//	because "isMain" values are Not equal
			}
	
			if(t1.m_bolisActive != t2.m_bolisActive) {
				return false;	//	because "isActive" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(bSurveyQuestion t1, bSurveyQuestion t2) {
			return !(t1 == t2);
		}
		#endregion
	
		#region Override Functions

		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" SurveyQuestionID = \"");
			retValue.Append(m_intSurveyQuestionID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    SurveyQuestion = \"");
			retValue.Append(m_strSurveyQuestion);
			retValue.Append("\"\n");
				retValue.Append("    isMain = \"");
			retValue.Append(m_bolisMain);
			retValue.Append("\"\n");
				retValue.Append("    isActive = \"");
			retValue.Append(m_bolisActive);
			retValue.Append("\"\n");
				return retValue.ToString();
		}
	
		/// <summary>
		/// Overrides the Equals Function.
		/// </summary>
		/// <param name="o">The Object To compare With</param>
		/// <returns>Bool if the two objects are identical.</returns>
		public override bool Equals(System.Object o) {
			//	check the type of o
			if (!(o is SurveyQuestion)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (SurveyQuestion)o;
		}
	
		/// <summary>
		/// Overrides the GetHashCode Function.
		/// </summary>
		/// <returns>Bool if the two objects are identical.</returns>
		public override int GetHashCode() {
			return this.ToString().GetHashCode();
		}
		#endregion
	
	}
}

