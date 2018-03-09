using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities {

	public class bPageComments {
		//transactions
		//	enum types
		protected enum Action { Insert, Update, Delete };
			//	Sub-types
		public struct PK {
				public SqlInt32 PageCommentID;
		}	
		
		
		protected Action m_aAction;
		protected bool m_bIsDirty;

		#region Table Members
		protected SqlInt32 m_intPageCommentID;
		protected SqlInt32 m_intMemberID;
		protected SqlInt32 m_intPageID;
		protected SqlString m_strComment;
		protected SqlInt32 m_intPoint;
		protected SqlInt32 m_intStatus;
		#endregion
		
		#region Properties
	
		public PK PrimaryKey {
			get {
				PK pk;
				pk.PageCommentID = m_intPageCommentID;
				return pk;
			}
		}
			
		
		public int PageCommentID {
			get {
				return (int)m_intPageCommentID;
			}
			set {
				m_intPageCommentID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int MemberID {
			get {
				return (int)m_intMemberID;
			}
			set {
				m_intMemberID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int PageID {
			get {
				return (int)m_intPageID;
			}
			set {
				m_intPageID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Comment {
			get {
				return (string)m_strComment;
			}
			set {
				m_strComment = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int Point {
			get {
				return (int)m_intPoint;
			}
			set {
				m_intPoint = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int Status {
			get {
				return (int)m_intStatus;
			}
			set {
				m_intStatus = value;
				m_bIsDirty = true;
			}
		}
		
	#endregion
	
		#region Constructers

		public bPageComments() {
			Init();	//	init Object
		}
		#endregion

		#region Static Functions

		/// <summary>
		/// Gets all PageComments from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the PageComments</returns>
		
		public static SqlDataReader LoadAllReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageCommentsSelectAll", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet LoadAll() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPageCommentsSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all PageComments from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable LoadAllHashTable() {
			SqlDataReader dr = LoadAllReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates PageComments for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the PageComments records</param>
		/// <returns>The Hashtable containing PageComments objects And their ID As key.</returns>
		protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            PageComments myPageComments = new PageComments();
            
            myPageComments.m_intPageCommentID = dr.GetSqlInt32(0);
            myPageComments.m_intMemberID = dr.GetSqlInt32(1);
            myPageComments.m_intPageID = dr.GetSqlInt32(2);
            myPageComments.m_strComment = dr.GetSqlString(3);
            myPageComments.m_intPoint = dr.GetSqlInt32(4);
            myPageComments.m_intStatus = dr.GetSqlInt32(5);
            
            result.Add(myPageComments.PageCommentID, myPageComments);
		}
	
			return result;
		}
		
		public static DataSet LoadByParams(object intPageCommentID , object intMemberID , object intPageID , object strComment , object intPoint , object intStatus) 
		{
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageCommentsSelectByParams", conn);
			SqlParameter param;
			
			
			
		        param = new SqlParameter("@PageCommentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPageCommentID==null ? intPageCommentID : (int)intPageCommentID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intMemberID==null ? intMemberID : (int)intMemberID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPageID==null ? intPageID : (int)intPageID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Comment", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strComment==null ? strComment : (string)strComment);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Point", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPoint==null ? intPoint : (int)intPoint);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Status", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intStatus==null ? intStatus : (int)intStatus);
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static DataSet LoadByParams(object intPageCommentID , object intMemberID , object intPageID , object strComment , object intPoint , object intStatus,SqlConnection sqlConn,SqlTransaction sqlTran) 
		{
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageCommentsSelectByParams", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
			
		        param = new SqlParameter("@PageCommentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPageCommentID==null ? intPageCommentID : (int)intPageCommentID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intMemberID==null ? intMemberID : (int)intMemberID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPageID==null ? intPageID : (int)intPageID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Comment", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strComment==null ? strComment : (string)strComment);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Point", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPoint==null ? intPoint : (int)intPoint);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Status", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intStatus==null ? intStatus : (int)intStatus);
        cmd.Parameters.Add(param);
        
		//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static int Insert(bPageComments objPageComments) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageCommentsInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PageCommentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.PageCommentID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.MemberID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.PageID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Comment", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.Comment;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Point", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.Point;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Status", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.Status;
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
				objPageComments.PageCommentID = retValue;
			return retValue;
		}
		
		public static int Insert(bPageComments objPageComments,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageCommentsInsert", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PageCommentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.PageCommentID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.MemberID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.PageID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Comment", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.Comment;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Point", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.Point;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Status", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.Status;
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
				objPageComments.PageCommentID = retValue;
			return retValue;
		}

		public static int Update(bPageComments objPageComments) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageCommentsUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@PageCommentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.PageCommentID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.MemberID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.PageID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Comment", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.Comment;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Point", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.Point;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Status", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.Status;
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
		
		public static int Update(bPageComments objPageComments,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageCommentsUpdate", conn);
			cmd.Transaction=sqlTran;
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@PageCommentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.PageCommentID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.MemberID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.PageID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Comment", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.Comment;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Point", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.Point;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Status", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.Status;
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
		
		public static int Delete(bPageComments objPageComments) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageCommentsDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PageCommentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.PageCommentID;
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
		
		public static int Delete(bPageComments objPageComments,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageCommentsUpdate", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PageCommentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageComments.PageCommentID;
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
			return Load(pk.PageCommentID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intPageCommentID"> PageCommentID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intPageCommentID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageCommentsSelect", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for PageCommentID column
        param = new SqlParameter("@PageCommentID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intPageCommentID;
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
		            m_intPageCommentID = reader.GetSqlInt32(0);
            m_intMemberID = reader.GetSqlInt32(1);
            m_intPageID = reader.GetSqlInt32(2);
            m_strComment = reader.GetSqlString(3);
            m_intPoint = reader.GetSqlInt32(4);
            m_intStatus = reader.GetSqlInt32(5);
		
			} else {
			//	set key values
		            m_intPageCommentID = intPageCommentID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPageCommentsSelectByParams", conn);

			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PageCommentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intPageCommentID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intMemberID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intPageID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Comment", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strComment;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Point", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intPoint;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Status", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intStatus;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageCommentsInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for PageCommentID column
        param = new SqlParameter("@PageCommentID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPageCommentID;
        cmd.Parameters.Add(param);
        
        // parameter for MemberID column
        param = new SqlParameter("@MemberID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intMemberID;
        cmd.Parameters.Add(param);
        
        // parameter for PageID column
        param = new SqlParameter("@PageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPageID;
        cmd.Parameters.Add(param);
        
        // parameter for Comment column
        param = new SqlParameter("@Comment", SqlDbType.NVarChar, 500);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strComment;
        cmd.Parameters.Add(param);
        
        // parameter for Point column
        param = new SqlParameter("@Point", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPoint;
        cmd.Parameters.Add(param);
        
        // parameter for Status column
        param = new SqlParameter("@Status", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intStatus;
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
				PageCommentID = retValue;
			return retValue;
		}
	
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		protected int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageCommentsUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for PageCommentID column
        param = new SqlParameter("@PageCommentID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPageCommentID;
        cmd.Parameters.Add(param);
        
        // parameter for MemberID column
        param = new SqlParameter("@MemberID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intMemberID;
        cmd.Parameters.Add(param);
        
        // parameter for PageID column
        param = new SqlParameter("@PageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPageID;
        cmd.Parameters.Add(param);
        
        // parameter for Comment column
        param = new SqlParameter("@Comment", SqlDbType.NVarChar, 500);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strComment;
        cmd.Parameters.Add(param);
        
        // parameter for Point column
        param = new SqlParameter("@Point", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPoint;
        cmd.Parameters.Add(param);
        
        // parameter for Status column
        param = new SqlParameter("@Status", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intStatus;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageCommentsDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for PageCommentID column
        param = new SqlParameter("@PageCommentID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPageCommentID;
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
		public static bool operator ==(bPageComments t1, bPageComments t2) {
			//	compare values
			if(t1.m_intPageCommentID != t2.m_intPageCommentID) {
				return false;	//	because "PageCommentID" values are Not equal
			}
	
			if(t1.m_intMemberID != t2.m_intMemberID) {
				return false;	//	because "MemberID" values are Not equal
			}
	
			if(t1.m_intPageID != t2.m_intPageID) {
				return false;	//	because "PageID" values are Not equal
			}
	
			if(t1.m_strComment != t2.m_strComment) {
				return false;	//	because "Comment" values are Not equal
			}
	
			if(t1.m_intPoint != t2.m_intPoint) {
				return false;	//	because "Point" values are Not equal
			}
	
			if(t1.m_intStatus != t2.m_intStatus) {
				return false;	//	because "Status" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(bPageComments t1, bPageComments t2) {
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
				retValue.Append(" PageCommentID = \"");
			retValue.Append(m_intPageCommentID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    MemberID = \"");
			retValue.Append(m_intMemberID);
			retValue.Append("\"\n");
				retValue.Append("    PageID = \"");
			retValue.Append(m_intPageID);
			retValue.Append("\"\n");
				retValue.Append("    Comment = \"");
			retValue.Append(m_strComment);
			retValue.Append("\"\n");
				retValue.Append("    Point = \"");
			retValue.Append(m_intPoint);
			retValue.Append("\"\n");
				retValue.Append("    Status = \"");
			retValue.Append(m_intStatus);
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
			if (!(o is PageComments)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (PageComments)o;
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

