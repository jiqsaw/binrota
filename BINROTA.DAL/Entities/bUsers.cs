using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities {

	public class bUsers {
		//transactions
		//	enum types
		protected enum Action { Insert, Update, Delete };
			//	Sub-types
		public struct PK {
				public SqlInt32 UserID;
		}	
		
		
		protected Action m_aAction;
		protected bool m_bIsDirty;

		#region Table Members
		protected SqlInt32 m_intUserID;
		protected SqlString m_strFirstName;
		protected SqlString m_strLastName;
		protected SqlString m_strEMail;
		protected SqlString m_strPassword;
		protected SqlBoolean m_bolGender;
		protected SqlDateTime m_dtBirthDate;
protected SqlDateTime m_FindBefore_dtBirthDate;
protected SqlDateTime m_FindAfter_dtBirthDate;
		protected SqlString m_strActivationKey;
		protected SqlInt32 m_intStatusID;
		protected SqlDateTime m_dtModifyDate;
protected SqlDateTime m_FindBefore_dtModifyDate;
protected SqlDateTime m_FindAfter_dtModifyDate;
		protected SqlInt32 m_intModifiedBy;
		#endregion
		
		#region Properties
	
		public PK PrimaryKey {
			get {
				PK pk;
				pk.UserID = m_intUserID;
				return pk;
			}
		}
			
		
		public int UserID {
			get {
				return (int)m_intUserID;
			}
			set {
				m_intUserID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string FirstName {
			get {
				return (string)m_strFirstName;
			}
			set {
				m_strFirstName = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string LastName {
			get {
				return (string)m_strLastName;
			}
			set {
				m_strLastName = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string EMail {
			get {
				return (string)m_strEMail;
			}
			set {
				m_strEMail = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Password {
			get {
				return (string)m_strPassword;
			}
			set {
				m_strPassword = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public bool Gender {
			get {
				return (bool)m_bolGender;
			}
			set {
				m_bolGender = value;
				m_bIsDirty = true;
			}
		}
		
					public DateTime FindBefore_BirthDate {
			get {
				return (DateTime)m_FindBefore_dtBirthDate;
			}
			set {
				m_FindBefore_dtBirthDate = value;
				m_bIsDirty = true;
			}
		}
		
		public DateTime FindAfter_BirthDate {
			get {
				return (DateTime)m_FindAfter_dtBirthDate;
			}
			set {
				m_FindAfter_dtBirthDate = value;
				m_bIsDirty = true;
			}
		}
		
		
		
		public DateTime BirthDate {
			get {
				return (DateTime)m_dtBirthDate;
			}
			set {
				m_dtBirthDate = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string ActivationKey {
			get {
				return (string)m_strActivationKey;
			}
			set {
				m_strActivationKey = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int StatusID {
			get {
				return (int)m_intStatusID;
			}
			set {
				m_intStatusID = value;
				m_bIsDirty = true;
			}
		}
		
					public DateTime FindBefore_ModifyDate {
			get {
				return (DateTime)m_FindBefore_dtModifyDate;
			}
			set {
				m_FindBefore_dtModifyDate = value;
				m_bIsDirty = true;
			}
		}
		
		public DateTime FindAfter_ModifyDate {
			get {
				return (DateTime)m_FindAfter_dtModifyDate;
			}
			set {
				m_FindAfter_dtModifyDate = value;
				m_bIsDirty = true;
			}
		}
		
		
		
		public DateTime ModifyDate {
			get {
				return (DateTime)m_dtModifyDate;
			}
			set {
				m_dtModifyDate = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int ModifiedBy {
			get {
				return (int)m_intModifiedBy;
			}
			set {
				m_intModifiedBy = value;
				m_bIsDirty = true;
			}
		}
		
	#endregion
	
		#region Constructers

		public bUsers() {
			Init();	//	init Object
		}
		#endregion

		#region Static Functions

		/// <summary>
		/// Gets all Users from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Users</returns>
		
		public static SqlDataReader LoadAllReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersSelectAll", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet LoadAll() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all Users from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable LoadAllHashTable() {
			SqlDataReader dr = LoadAllReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates Users for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Users records</param>
		/// <returns>The Hashtable containing Users objects And their ID As key.</returns>
		protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Users myUsers = new Users();
            
            myUsers.m_intUserID = dr.GetSqlInt32(0);
            myUsers.m_strFirstName = dr.GetSqlString(1);
            myUsers.m_strLastName = dr.GetSqlString(2);
            myUsers.m_strEMail = dr.GetSqlString(3);
            myUsers.m_strPassword = dr.GetSqlString(4);
            myUsers.m_bolGender = dr.GetSqlBoolean(5);
            myUsers.m_dtBirthDate = dr.GetSqlDateTime(6);
            myUsers.m_strActivationKey = dr.GetSqlString(7);
            myUsers.m_intStatusID = dr.GetSqlInt32(8);
            myUsers.m_dtModifyDate = dr.GetSqlDateTime(9);
            myUsers.m_intModifiedBy = dr.GetSqlInt32(10);
            
            result.Add(myUsers.UserID, myUsers);
		}
	
			return result;
		}
		
		public static DataSet LoadByParams(object intUserID , object strFirstName , object strLastName , object strEMail , object strPassword , object bolGender , object dtFindBefore_BirthDate,object dtFindAfter_BirthDate , object strActivationKey , object intStatusID , object dtFindBefore_ModifyDate,object dtFindAfter_ModifyDate , object intModifiedBy) 
		{
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersSelectByParams", conn);
			SqlParameter param;
			
			
			
		        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intUserID==null ? intUserID : (int)intUserID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strFirstName==null ? strFirstName : (string)strFirstName);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LastName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strLastName==null ? strLastName : (string)strLastName);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EMail", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strEMail==null ? strEMail : (string)strEMail);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Password", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPassword==null ? strPassword : (string)strPassword);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Gender", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=(bolGender==null ? bolGender : (bool)bolGender);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_BirthDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_BirthDate==null ? dtFindBefore_BirthDate : (DateTime)dtFindBefore_BirthDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_BirthDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_BirthDate==null ? dtFindAfter_BirthDate : (DateTime)dtFindAfter_BirthDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strActivationKey==null ? strActivationKey : (string)strActivationKey);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@StatusID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intStatusID==null ? intStatusID : (int)intStatusID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_ModifyDate==null ? dtFindBefore_ModifyDate : (DateTime)dtFindBefore_ModifyDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_ModifyDate==null ? dtFindAfter_ModifyDate : (DateTime)dtFindAfter_ModifyDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intModifiedBy==null ? intModifiedBy : (int)intModifiedBy);
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static DataSet LoadByParams(object intUserID , object strFirstName , object strLastName , object strEMail , object strPassword , object bolGender , object dtFindBefore_BirthDate,object dtFindAfter_BirthDate , object strActivationKey , object intStatusID , object dtFindBefore_ModifyDate,object dtFindAfter_ModifyDate , object intModifiedBy,SqlConnection sqlConn,SqlTransaction sqlTran) 
		{
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersSelectByParams", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
			
		        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intUserID==null ? intUserID : (int)intUserID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strFirstName==null ? strFirstName : (string)strFirstName);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LastName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strLastName==null ? strLastName : (string)strLastName);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EMail", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strEMail==null ? strEMail : (string)strEMail);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Password", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPassword==null ? strPassword : (string)strPassword);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Gender", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=(bolGender==null ? bolGender : (bool)bolGender);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_BirthDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_BirthDate==null ? dtFindBefore_BirthDate : (DateTime)dtFindBefore_BirthDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_BirthDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_BirthDate==null ? dtFindAfter_BirthDate : (DateTime)dtFindAfter_BirthDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strActivationKey==null ? strActivationKey : (string)strActivationKey);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@StatusID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intStatusID==null ? intStatusID : (int)intStatusID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_ModifyDate==null ? dtFindBefore_ModifyDate : (DateTime)dtFindBefore_ModifyDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_ModifyDate==null ? dtFindAfter_ModifyDate : (DateTime)dtFindAfter_ModifyDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intModifiedBy==null ? intModifiedBy : (int)intModifiedBy);
        cmd.Parameters.Add(param);
        
		//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static int Insert(bUsers objUsers) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.UserID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.FirstName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LastName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.LastName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EMail", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.EMail;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Password", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.Password;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Gender", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.Gender;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@BirthDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.BirthDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.ActivationKey;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@StatusID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.StatusID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.ModifiedBy;
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
				objUsers.UserID = retValue;
			return retValue;
		}
		
		public static int Insert(bUsers objUsers,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersInsert", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.UserID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.FirstName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LastName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.LastName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EMail", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.EMail;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Password", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.Password;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Gender", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.Gender;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@BirthDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.BirthDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.ActivationKey;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@StatusID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.StatusID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.ModifiedBy;
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
				objUsers.UserID = retValue;
			return retValue;
		}

		public static int Update(bUsers objUsers) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.UserID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.FirstName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LastName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.LastName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EMail", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.EMail;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Password", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.Password;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Gender", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.Gender;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@BirthDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.BirthDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.ActivationKey;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@StatusID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.StatusID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.ModifiedBy;
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
		
		public static int Update(bUsers objUsers,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersUpdate", conn);
			cmd.Transaction=sqlTran;
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.UserID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.FirstName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LastName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.LastName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EMail", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.EMail;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Password", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.Password;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Gender", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.Gender;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@BirthDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.BirthDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.ActivationKey;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@StatusID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.StatusID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.ModifiedBy;
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
		
		public static int Delete(bUsers objUsers) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.UserID;
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
		
		public static int Delete(bUsers objUsers,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersUpdate", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objUsers.UserID;
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
			return Load(pk.UserID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intUserID"> UserID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intUserID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersSelect", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for UserID column
        param = new SqlParameter("@UserID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intUserID;
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
		            m_intUserID = reader.GetSqlInt32(0);
            m_strFirstName = reader.GetSqlString(1);
            m_strLastName = reader.GetSqlString(2);
            m_strEMail = reader.GetSqlString(3);
            m_strPassword = reader.GetSqlString(4);
            m_bolGender = reader.GetSqlBoolean(5);
            m_dtBirthDate = reader.GetSqlDateTime(6);
            m_strActivationKey = reader.GetSqlString(7);
            m_intStatusID = reader.GetSqlInt32(8);
            m_dtModifyDate = reader.GetSqlDateTime(9);
            m_intModifiedBy = reader.GetSqlInt32(10);
		
			} else {
			//	set key values
		            m_intUserID = intUserID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersSelectByParams", conn);

			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intUserID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strFirstName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LastName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strLastName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EMail", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strEMail;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Password", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strPassword;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Gender", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=m_bolGender;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_BirthDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindBefore_dtBirthDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_BirthDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindAfter_dtBirthDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strActivationKey;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@StatusID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intStatusID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindBefore_dtModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindAfter_dtModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intModifiedBy;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for UserID column
        param = new SqlParameter("@UserID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserID;
        cmd.Parameters.Add(param);
        
        // parameter for FirstName column
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strFirstName;
        cmd.Parameters.Add(param);
        
        // parameter for LastName column
        param = new SqlParameter("@LastName", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strLastName;
        cmd.Parameters.Add(param);
        
        // parameter for EMail column
        param = new SqlParameter("@EMail", SqlDbType.VarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strEMail;
        cmd.Parameters.Add(param);
        
        // parameter for Password column
        param = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPassword;
        cmd.Parameters.Add(param);
        
        // parameter for Gender column
        param = new SqlParameter("@Gender", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolGender;
        cmd.Parameters.Add(param);
        
        // parameter for BirthDate column
        param = new SqlParameter("@BirthDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBirthDate;
        cmd.Parameters.Add(param);
        
        // parameter for ActivationKey column
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strActivationKey;
        cmd.Parameters.Add(param);
        
        // parameter for StatusID column
        param = new SqlParameter("@StatusID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intStatusID;
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
				UserID = retValue;
			return retValue;
		}
	
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		protected int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for UserID column
        param = new SqlParameter("@UserID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserID;
        cmd.Parameters.Add(param);
        
        // parameter for FirstName column
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strFirstName;
        cmd.Parameters.Add(param);
        
        // parameter for LastName column
        param = new SqlParameter("@LastName", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strLastName;
        cmd.Parameters.Add(param);
        
        // parameter for EMail column
        param = new SqlParameter("@EMail", SqlDbType.VarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strEMail;
        cmd.Parameters.Add(param);
        
        // parameter for Password column
        param = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPassword;
        cmd.Parameters.Add(param);
        
        // parameter for Gender column
        param = new SqlParameter("@Gender", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolGender;
        cmd.Parameters.Add(param);
        
        // parameter for BirthDate column
        param = new SqlParameter("@BirthDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBirthDate;
        cmd.Parameters.Add(param);
        
        // parameter for ActivationKey column
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strActivationKey;
        cmd.Parameters.Add(param);
        
        // parameter for StatusID column
        param = new SqlParameter("@StatusID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intStatusID;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for UserID column
        param = new SqlParameter("@UserID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intUserID;
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
		public static bool operator ==(bUsers t1, bUsers t2) {
			//	compare values
			if(t1.m_intUserID != t2.m_intUserID) {
				return false;	//	because "UserID" values are Not equal
			}
	
			if(t1.m_strFirstName != t2.m_strFirstName) {
				return false;	//	because "FirstName" values are Not equal
			}
	
			if(t1.m_strLastName != t2.m_strLastName) {
				return false;	//	because "LastName" values are Not equal
			}
	
			if(t1.m_strEMail != t2.m_strEMail) {
				return false;	//	because "EMail" values are Not equal
			}
	
			if(t1.m_strPassword != t2.m_strPassword) {
				return false;	//	because "Password" values are Not equal
			}
	
			if(t1.m_bolGender != t2.m_bolGender) {
				return false;	//	because "Gender" values are Not equal
			}
	
			if(t1.m_dtBirthDate != t2.m_dtBirthDate) {
				return false;	//	because "BirthDate" values are Not equal
			}
	
			if(t1.m_strActivationKey != t2.m_strActivationKey) {
				return false;	//	because "ActivationKey" values are Not equal
			}
	
			if(t1.m_intStatusID != t2.m_intStatusID) {
				return false;	//	because "StatusID" values are Not equal
			}
	
			if(t1.m_dtModifyDate != t2.m_dtModifyDate) {
				return false;	//	because "ModifyDate" values are Not equal
			}
	
			if(t1.m_intModifiedBy != t2.m_intModifiedBy) {
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
		public static bool operator !=(bUsers t1, bUsers t2) {
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
				retValue.Append(" UserID = \"");
			retValue.Append(m_intUserID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    FirstName = \"");
			retValue.Append(m_strFirstName);
			retValue.Append("\"\n");
				retValue.Append("    LastName = \"");
			retValue.Append(m_strLastName);
			retValue.Append("\"\n");
				retValue.Append("    EMail = \"");
			retValue.Append(m_strEMail);
			retValue.Append("\"\n");
				retValue.Append("    Password = \"");
			retValue.Append(m_strPassword);
			retValue.Append("\"\n");
				retValue.Append("    Gender = \"");
			retValue.Append(m_bolGender);
			retValue.Append("\"\n");
				retValue.Append("    BirthDate = \"");
			retValue.Append(m_dtBirthDate);
			retValue.Append("\"\n");
				retValue.Append("    ActivationKey = \"");
			retValue.Append(m_strActivationKey);
			retValue.Append("\"\n");
				retValue.Append("    StatusID = \"");
			retValue.Append(m_intStatusID);
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
		public override bool Equals(System.Object o) {
			//	check the type of o
			if (!(o is Users)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Users)o;
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

