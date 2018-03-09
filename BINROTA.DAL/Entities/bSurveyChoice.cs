using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities {

	public class bSurveyChoice {
		//transactions
		//	enum types
		protected enum Action { Insert, Update, Delete };
			//	Sub-types
		public struct PK {
				public SqlInt32 SurveyChoiceID;
		}	
		
		
		protected Action m_aAction;
		protected bool m_bIsDirty;

		#region Table Members
		protected SqlInt32 m_intSurveyChoiceID;
		protected SqlInt32 m_intSurveyQuestionID;
		protected SqlString m_strSurveyChoice;
		protected SqlInt32 m_intSurveyVoteNumber;
		#endregion
		
		#region Properties
	
		public PK PrimaryKey {
			get {
				PK pk;
				pk.SurveyChoiceID = m_intSurveyChoiceID;
				return pk;
			}
		}
			
		
		public int SurveyChoiceID {
			get {
				return (int)m_intSurveyChoiceID;
			}
			set {
				m_intSurveyChoiceID = value;
				m_bIsDirty = true;
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
		
			
		
		public string SurveyChoice {
			get {
				return (string)m_strSurveyChoice;
			}
			set {
				m_strSurveyChoice = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int SurveyVoteNumber {
			get {
				return (int)m_intSurveyVoteNumber;
			}
			set {
				m_intSurveyVoteNumber = value;
				m_bIsDirty = true;
			}
		}
		
	#endregion
	
		#region Constructers

		public bSurveyChoice() {
			Init();	//	init Object
		}
		#endregion

		#region Static Functions

		/// <summary>
		/// Gets all SurveyChoice from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the SurveyChoice</returns>
		
		public static SqlDataReader LoadAllReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyChoiceSelectAll", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet LoadAll() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyChoiceSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all SurveyChoice from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable LoadAllHashTable() {
			SqlDataReader dr = LoadAllReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates SurveyChoice for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the SurveyChoice records</param>
		/// <returns>The Hashtable containing SurveyChoice objects And their ID As key.</returns>
		protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            SurveyChoice mySurveyChoice = new SurveyChoice();
            
            mySurveyChoice.m_intSurveyChoiceID = dr.GetSqlInt32(0);
            mySurveyChoice.m_intSurveyQuestionID = dr.GetSqlInt32(1);
            mySurveyChoice.m_strSurveyChoice = dr.GetSqlString(2);
            mySurveyChoice.m_intSurveyVoteNumber = dr.GetSqlInt32(3);
            
            result.Add(mySurveyChoice.SurveyChoiceID, mySurveyChoice);
		}
	
			return result;
		}
		
		public static DataSet LoadByParams(object intSurveyChoiceID , object intSurveyQuestionID , object strSurveyChoice , object intSurveyVoteNumber) 
		{
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyChoiceSelectByParams", conn);
			SqlParameter param;
			
			
			
		        param = new SqlParameter("@SurveyChoiceID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSurveyChoiceID==null ? intSurveyChoiceID : (int)intSurveyChoiceID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSurveyQuestionID==null ? intSurveyQuestionID : (int)intSurveyQuestionID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyChoice", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strSurveyChoice==null ? strSurveyChoice : (string)strSurveyChoice);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyVoteNumber", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSurveyVoteNumber==null ? intSurveyVoteNumber : (int)intSurveyVoteNumber);
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static DataSet LoadByParams(object intSurveyChoiceID , object intSurveyQuestionID , object strSurveyChoice , object intSurveyVoteNumber,SqlConnection sqlConn,SqlTransaction sqlTran) 
		{
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyChoiceSelectByParams", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
			
		        param = new SqlParameter("@SurveyChoiceID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSurveyChoiceID==null ? intSurveyChoiceID : (int)intSurveyChoiceID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSurveyQuestionID==null ? intSurveyQuestionID : (int)intSurveyQuestionID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyChoice", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strSurveyChoice==null ? strSurveyChoice : (string)strSurveyChoice);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyVoteNumber", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSurveyVoteNumber==null ? intSurveyVoteNumber : (int)intSurveyVoteNumber);
        cmd.Parameters.Add(param);
        
		//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static int Insert(bSurveyChoice objSurveyChoice) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyChoiceInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SurveyChoiceID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyChoiceID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyQuestionID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyChoice", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyChoice;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyVoteNumber", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyVoteNumber;
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
				objSurveyChoice.SurveyChoiceID = retValue;
			return retValue;
		}
		
		public static int Insert(bSurveyChoice objSurveyChoice,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyChoiceInsert", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SurveyChoiceID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyChoiceID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyQuestionID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyChoice", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyChoice;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyVoteNumber", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyVoteNumber;
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
				objSurveyChoice.SurveyChoiceID = retValue;
			return retValue;
		}

		public static int Update(bSurveyChoice objSurveyChoice) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyChoiceUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@SurveyChoiceID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyChoiceID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyQuestionID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyChoice", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyChoice;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyVoteNumber", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyVoteNumber;
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
		
		public static int Update(bSurveyChoice objSurveyChoice,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyChoiceUpdate", conn);
			cmd.Transaction=sqlTran;
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@SurveyChoiceID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyChoiceID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyQuestionID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyChoice", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyChoice;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyVoteNumber", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyVoteNumber;
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
		
		public static int Delete(bSurveyChoice objSurveyChoice) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyChoiceDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SurveyChoiceID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyChoiceID;
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
		
		public static int Delete(bSurveyChoice objSurveyChoice,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyChoiceUpdate", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SurveyChoiceID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSurveyChoice.SurveyChoiceID;
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
			return Load(pk.SurveyChoiceID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intSurveyChoiceID"> SurveyChoiceID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intSurveyChoiceID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyChoiceSelect", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for SurveyChoiceID column
        param = new SqlParameter("@SurveyChoiceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intSurveyChoiceID;
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
		            m_intSurveyChoiceID = reader.GetSqlInt32(0);
            m_intSurveyQuestionID = reader.GetSqlInt32(1);
            m_strSurveyChoice = reader.GetSqlString(2);
            m_intSurveyVoteNumber = reader.GetSqlInt32(3);
		
			} else {
			//	set key values
		            m_intSurveyChoiceID = intSurveyChoiceID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyChoiceSelectByParams", conn);

			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SurveyChoiceID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intSurveyChoiceID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intSurveyQuestionID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyChoice", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strSurveyChoice;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SurveyVoteNumber", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intSurveyVoteNumber;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyChoiceInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for SurveyChoiceID column
        param = new SqlParameter("@SurveyChoiceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSurveyChoiceID;
        cmd.Parameters.Add(param);
        
        // parameter for SurveyQuestionID column
        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSurveyQuestionID;
        cmd.Parameters.Add(param);
        
        // parameter for SurveyChoice column
        param = new SqlParameter("@SurveyChoice", SqlDbType.NVarChar, 100);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strSurveyChoice;
        cmd.Parameters.Add(param);
        
        // parameter for SurveyVoteNumber column
        param = new SqlParameter("@SurveyVoteNumber", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSurveyVoteNumber;
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
				SurveyChoiceID = retValue;
			return retValue;
		}
	
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		protected int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyChoiceUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for SurveyChoiceID column
        param = new SqlParameter("@SurveyChoiceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSurveyChoiceID;
        cmd.Parameters.Add(param);
        
        // parameter for SurveyQuestionID column
        param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSurveyQuestionID;
        cmd.Parameters.Add(param);
        
        // parameter for SurveyChoice column
        param = new SqlParameter("@SurveyChoice", SqlDbType.NVarChar, 100);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strSurveyChoice;
        cmd.Parameters.Add(param);
        
        // parameter for SurveyVoteNumber column
        param = new SqlParameter("@SurveyVoteNumber", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSurveyVoteNumber;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSurveyChoiceDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for SurveyChoiceID column
        param = new SqlParameter("@SurveyChoiceID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSurveyChoiceID;
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
		public static bool operator ==(bSurveyChoice t1, bSurveyChoice t2) {
			//	compare values
			if(t1.m_intSurveyChoiceID != t2.m_intSurveyChoiceID) {
				return false;	//	because "SurveyChoiceID" values are Not equal
			}
	
			if(t1.m_intSurveyQuestionID != t2.m_intSurveyQuestionID) {
				return false;	//	because "SurveyQuestionID" values are Not equal
			}
	
			if(t1.m_strSurveyChoice != t2.m_strSurveyChoice) {
				return false;	//	because "SurveyChoice" values are Not equal
			}
	
			if(t1.m_intSurveyVoteNumber != t2.m_intSurveyVoteNumber) {
				return false;	//	because "SurveyVoteNumber" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(bSurveyChoice t1, bSurveyChoice t2) {
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
				retValue.Append(" SurveyChoiceID = \"");
			retValue.Append(m_intSurveyChoiceID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    SurveyQuestionID = \"");
			retValue.Append(m_intSurveyQuestionID);
			retValue.Append("\"\n");
				retValue.Append("    SurveyChoice = \"");
			retValue.Append(m_strSurveyChoice);
			retValue.Append("\"\n");
				retValue.Append("    SurveyVoteNumber = \"");
			retValue.Append(m_intSurveyVoteNumber);
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
			if (!(o is SurveyChoice)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (SurveyChoice)o;
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

