using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities {

	public class bPagePhotos {
		//transactions
		//	enum types
		protected enum Action { Insert, Update, Delete };
			//	Sub-types
		public struct PK {
				public SqlInt32 PagePhotoID;
		}	
		
		
		protected Action m_aAction;
		protected bool m_bIsDirty;

		#region Table Members
		protected SqlInt32 m_intPagePhotoID;
		protected SqlString m_strPhotoPath;
		protected SqlString m_strPhotoCaption;
		protected SqlDateTime m_dtModifyDate;
protected SqlDateTime m_FindBefore_dtModifyDate;
protected SqlDateTime m_FindAfter_dtModifyDate;
		protected SqlInt32 m_intModifiedBy;
		#endregion
		
		#region Properties
	
		public PK PrimaryKey {
			get {
				PK pk;
				pk.PagePhotoID = m_intPagePhotoID;
				return pk;
			}
		}
			
		
		public int PagePhotoID {
			get {
				return (int)m_intPagePhotoID;
			}
			set {
				m_intPagePhotoID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string PhotoPath {
			get {
				return (string)m_strPhotoPath;
			}
			set {
				m_strPhotoPath = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string PhotoCaption {
			get {
				return (string)m_strPhotoCaption;
			}
			set {
				m_strPhotoCaption = value;
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

		public bPagePhotos() {
			Init();	//	init Object
		}
		#endregion

		#region Static Functions

		/// <summary>
		/// Gets all PagePhotos from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the PagePhotos</returns>
		
		public static SqlDataReader LoadAllReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePhotosSelectAll", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet LoadAll() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePhotosSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all PagePhotos from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable LoadAllHashTable() {
			SqlDataReader dr = LoadAllReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates PagePhotos for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the PagePhotos records</param>
		/// <returns>The Hashtable containing PagePhotos objects And their ID As key.</returns>
		protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            PagePhotos myPagePhotos = new PagePhotos();
            
            myPagePhotos.m_intPagePhotoID = dr.GetSqlInt32(0);
            myPagePhotos.m_strPhotoPath = dr.GetSqlString(1);
            myPagePhotos.m_strPhotoCaption = dr.GetSqlString(2);
            myPagePhotos.m_dtModifyDate = dr.GetSqlDateTime(3);
            myPagePhotos.m_intModifiedBy = dr.GetSqlInt32(4);
            
            result.Add(myPagePhotos.PagePhotoID, myPagePhotos);
		}
	
			return result;
		}
		
		public static DataSet LoadByParams(object intPagePhotoID , object strPhotoPath , object strPhotoCaption , object dtFindBefore_ModifyDate,object dtFindAfter_ModifyDate , object intModifiedBy) 
		{
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePhotosSelectByParams", conn);
			SqlParameter param;
			
			
			
		        param = new SqlParameter("@PagePhotoID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPagePhotoID==null ? intPagePhotoID : (int)intPagePhotoID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoPath==null ? strPhotoPath : (string)strPhotoPath);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoCaption==null ? strPhotoCaption : (string)strPhotoCaption);
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
		
		public static DataSet LoadByParams(object intPagePhotoID , object strPhotoPath , object strPhotoCaption , object dtFindBefore_ModifyDate,object dtFindAfter_ModifyDate , object intModifiedBy,SqlConnection sqlConn,SqlTransaction sqlTran) 
		{
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePhotosSelectByParams", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
			
		        param = new SqlParameter("@PagePhotoID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPagePhotoID==null ? intPagePhotoID : (int)intPagePhotoID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoPath==null ? strPhotoPath : (string)strPhotoPath);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoCaption==null ? strPhotoCaption : (string)strPhotoCaption);
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
		
		public static int Insert(bPagePhotos objPagePhotos) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePhotosInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PagePhotoID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.PagePhotoID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.ModifiedBy;
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
						return retValue;
		}
		
		public static int Insert(bPagePhotos objPagePhotos,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePhotosInsert", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PagePhotoID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.PagePhotoID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.ModifiedBy;
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
						return retValue;
		}

		public static int Update(bPagePhotos objPagePhotos) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePhotosUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@PagePhotoID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.PagePhotoID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.ModifiedBy;
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
		
		public static int Update(bPagePhotos objPagePhotos,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePhotosUpdate", conn);
			cmd.Transaction=sqlTran;
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@PagePhotoID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.PagePhotoID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.ModifiedBy;
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
		
		public static int Delete(bPagePhotos objPagePhotos) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePhotosDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PagePhotoID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.PagePhotoID;
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
		
		public static int Delete(bPagePhotos objPagePhotos,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePhotosUpdate", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PagePhotoID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPagePhotos.PagePhotoID;
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
			return Load(pk.PagePhotoID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intPagePhotoID"> PagePhotoID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intPagePhotoID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePhotosSelect", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for PagePhotoID column
        param = new SqlParameter("@PagePhotoID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intPagePhotoID;
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
		            m_intPagePhotoID = reader.GetSqlInt32(0);
            m_strPhotoPath = reader.GetSqlString(1);
            m_strPhotoCaption = reader.GetSqlString(2);
            m_dtModifyDate = reader.GetSqlDateTime(3);
            m_intModifiedBy = reader.GetSqlInt32(4);
		
			} else {
			//	set key values
		            m_intPagePhotoID = intPagePhotoID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePhotosSelectByParams", conn);

			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PagePhotoID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intPagePhotoID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strPhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strPhotoCaption;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePhotosInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for PagePhotoID column
        param = new SqlParameter("@PagePhotoID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPagePhotoID;
        cmd.Parameters.Add(param);
        
        // parameter for PhotoPath column
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPhotoPath;
        cmd.Parameters.Add(param);
        
        // parameter for PhotoCaption column
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPhotoCaption;
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
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		protected int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePhotosUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for PagePhotoID column
        param = new SqlParameter("@PagePhotoID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPagePhotoID;
        cmd.Parameters.Add(param);
        
        // parameter for PhotoPath column
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPhotoPath;
        cmd.Parameters.Add(param);
        
        // parameter for PhotoCaption column
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPhotoCaption;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagePhotosDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for PagePhotoID column
        param = new SqlParameter("@PagePhotoID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPagePhotoID;
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
		public static bool operator ==(bPagePhotos t1, bPagePhotos t2) {
			//	compare values
			if(t1.m_intPagePhotoID != t2.m_intPagePhotoID) {
				return false;	//	because "PagePhotoID" values are Not equal
			}
	
			if(t1.m_strPhotoPath != t2.m_strPhotoPath) {
				return false;	//	because "PhotoPath" values are Not equal
			}
	
			if(t1.m_strPhotoCaption != t2.m_strPhotoCaption) {
				return false;	//	because "PhotoCaption" values are Not equal
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
		public static bool operator !=(bPagePhotos t1, bPagePhotos t2) {
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
				retValue.Append(" PagePhotoID = \"");
			retValue.Append(m_intPagePhotoID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    PhotoPath = \"");
			retValue.Append(m_strPhotoPath);
			retValue.Append("\"\n");
				retValue.Append("    PhotoCaption = \"");
			retValue.Append(m_strPhotoCaption);
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
			if (!(o is PagePhotos)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (PagePhotos)o;
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

