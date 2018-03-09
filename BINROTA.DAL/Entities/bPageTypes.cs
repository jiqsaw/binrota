using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities {

	public class bPageTypes {
		//transactions
		//	enum types
		protected enum Action { Insert, Update, Delete };
			//	Sub-types
		public struct PK {
				public SqlInt32 PageTypeID;
		}	
		
		
		protected Action m_aAction;
		protected bool m_bIsDirty;

		#region Table Members
		protected SqlInt32 m_intPageTypeID;
		protected SqlString m_strDescription;
		protected SqlString m_strCode;
		#endregion
		
		#region Properties
	
		public PK PrimaryKey {
			get {
				PK pk;
				pk.PageTypeID = m_intPageTypeID;
				return pk;
			}
		}
			
		
		public int PageTypeID {
			get {
				return (int)m_intPageTypeID;
			}
			set {
				m_intPageTypeID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Description {
			get {
				return (string)m_strDescription;
			}
			set {
				m_strDescription = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Code {
			get {
				return (string)m_strCode;
			}
			set {
				m_strCode = value;
				m_bIsDirty = true;
			}
		}
		
	#endregion
	
		#region Constructers

		public bPageTypes() {
			Init();	//	init Object
		}
		#endregion

		#region Static Functions

		/// <summary>
		/// Gets all PageTypes from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the PageTypes</returns>
		
		public static SqlDataReader LoadAllReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageTypesSelectAll", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet LoadAll() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPageTypesSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all PageTypes from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable LoadAllHashTable() {
			SqlDataReader dr = LoadAllReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates PageTypes for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the PageTypes records</param>
		/// <returns>The Hashtable containing PageTypes objects And their ID As key.</returns>
		protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            PageTypes myPageTypes = new PageTypes();
            
            myPageTypes.m_intPageTypeID = dr.GetSqlInt32(0);
            myPageTypes.m_strDescription = dr.GetSqlString(1);
            myPageTypes.m_strCode = dr.GetSqlString(2);
            
            result.Add(myPageTypes.PageTypeID, myPageTypes);
		}
	
			return result;
		}
		
		public static DataSet LoadByParams(object intPageTypeID , object strDescription , object strCode) 
		{
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageTypesSelectByParams", conn);
			SqlParameter param;
			
			
			
		        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPageTypeID==null ? intPageTypeID : (int)intPageTypeID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strDescription==null ? strDescription : (string)strDescription);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Code", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strCode==null ? strCode : (string)strCode);
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static DataSet LoadByParams(object intPageTypeID , object strDescription , object strCode,SqlConnection sqlConn,SqlTransaction sqlTran) 
		{
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageTypesSelectByParams", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
			
		        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPageTypeID==null ? intPageTypeID : (int)intPageTypeID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strDescription==null ? strDescription : (string)strDescription);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Code", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strCode==null ? strCode : (string)strCode);
        cmd.Parameters.Add(param);
        
		//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static int Insert(bPageTypes objPageTypes) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageTypesInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageTypes.PageTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageTypes.Description;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Code", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageTypes.Code;
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
				objPageTypes.PageTypeID = retValue;
			return retValue;
		}
		
		public static int Insert(bPageTypes objPageTypes,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageTypesInsert", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageTypes.PageTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageTypes.Description;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Code", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageTypes.Code;
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
				objPageTypes.PageTypeID = retValue;
			return retValue;
		}

		public static int Update(bPageTypes objPageTypes) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageTypesUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageTypes.PageTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageTypes.Description;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Code", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageTypes.Code;
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
		
		public static int Update(bPageTypes objPageTypes,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageTypesUpdate", conn);
			cmd.Transaction=sqlTran;
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageTypes.PageTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageTypes.Description;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Code", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageTypes.Code;
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
		
		public static int Delete(bPageTypes objPageTypes) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageTypesDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageTypes.PageTypeID;
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
		
		public static int Delete(bPageTypes objPageTypes,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageTypesUpdate", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPageTypes.PageTypeID;
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
			return Load(pk.PageTypeID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intPageTypeID"> PageTypeID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intPageTypeID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageTypesSelect", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for PageTypeID column
        param = new SqlParameter("@PageTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intPageTypeID;
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
		            m_intPageTypeID = reader.GetSqlInt32(0);
            m_strDescription = reader.GetSqlString(1);
            m_strCode = reader.GetSqlString(2);
		
			} else {
			//	set key values
		            m_intPageTypeID = intPageTypeID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPageTypesSelectByParams", conn);

			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intPageTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strDescription;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Code", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strCode;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageTypesInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for PageTypeID column
        param = new SqlParameter("@PageTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPageTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for Description column
        param = new SqlParameter("@Description", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDescription;
        cmd.Parameters.Add(param);
        
        // parameter for Code column
        param = new SqlParameter("@Code", SqlDbType.VarChar, 15);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCode;
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
				PageTypeID = retValue;
			return retValue;
		}
	
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		protected int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageTypesUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for PageTypeID column
        param = new SqlParameter("@PageTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPageTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for Description column
        param = new SqlParameter("@Description", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDescription;
        cmd.Parameters.Add(param);
        
        // parameter for Code column
        param = new SqlParameter("@Code", SqlDbType.VarChar, 15);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCode;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPageTypesDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for PageTypeID column
        param = new SqlParameter("@PageTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPageTypeID;
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
		public static bool operator ==(bPageTypes t1, bPageTypes t2) {
			//	compare values
			if(t1.m_intPageTypeID != t2.m_intPageTypeID) {
				return false;	//	because "PageTypeID" values are Not equal
			}
	
			if(t1.m_strDescription != t2.m_strDescription) {
				return false;	//	because "Description" values are Not equal
			}
	
			if(t1.m_strCode != t2.m_strCode) {
				return false;	//	because "Code" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(bPageTypes t1, bPageTypes t2) {
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
				retValue.Append(" PageTypeID = \"");
			retValue.Append(m_intPageTypeID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    Description = \"");
			retValue.Append(m_strDescription);
			retValue.Append("\"\n");
				retValue.Append("    Code = \"");
			retValue.Append(m_strCode);
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
			if (!(o is PageTypes)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (PageTypes)o;
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

