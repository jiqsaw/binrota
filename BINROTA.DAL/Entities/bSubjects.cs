using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities {

	public class bSubjects {
		//transactions
		//	enum types
		protected enum Action { Insert, Update, Delete };
			//	Sub-types
		public struct PK {
				public SqlInt32 SubjectID;
		}	
		
		
		protected Action m_aAction;
		protected bool m_bIsDirty;

		#region Table Members
		protected SqlInt32 m_intSubjectID;
		protected SqlString m_strName;
		protected SqlString m_strDescription;
		protected SqlString m_strPhotoPath;
		protected SqlString m_strPhotoCaption;
		protected SqlInt32 m_intParentSubjectID;
		protected SqlInt32 m_intLeftBound;
		protected SqlInt32 m_intRightBound;
		protected SqlInt32 m_intSubjectTypeID;
		protected SqlDateTime m_dtModifyDate;
protected SqlDateTime m_FindBefore_dtModifyDate;
protected SqlDateTime m_FindAfter_dtModifyDate;
		protected SqlInt32 m_intModifiedBy;
		#endregion
		
		#region Properties
	
		public PK PrimaryKey {
			get {
				PK pk;
				pk.SubjectID = m_intSubjectID;
				return pk;
			}
		}
			
		
		public int SubjectID {
			get {
				return (int)m_intSubjectID;
			}
			set {
				m_intSubjectID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Name {
			get {
				return (string)m_strName;
			}
			set {
				m_strName = value;
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
		
			
		
		public int ParentSubjectID {
			get {
				return (int)m_intParentSubjectID;
			}
			set {
				m_intParentSubjectID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int LeftBound {
			get {
				return (int)m_intLeftBound;
			}
			set {
				m_intLeftBound = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int RightBound {
			get {
				return (int)m_intRightBound;
			}
			set {
				m_intRightBound = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int SubjectTypeID {
			get {
				return (int)m_intSubjectTypeID;
			}
			set {
				m_intSubjectTypeID = value;
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

		public bSubjects() {
			Init();	//	init Object
		}
		#endregion

		#region Static Functions

		/// <summary>
		/// Gets all Subjects from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Subjects</returns>
		
		public static SqlDataReader LoadAllReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsSelectAll", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet LoadAll() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all Subjects from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable LoadAllHashTable() {
			SqlDataReader dr = LoadAllReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates Subjects for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Subjects records</param>
		/// <returns>The Hashtable containing Subjects objects And their ID As key.</returns>
		protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Subjects mySubjects = new Subjects();
            
            mySubjects.m_intSubjectID = dr.GetSqlInt32(0);
            mySubjects.m_strName = dr.GetSqlString(1);
            mySubjects.m_strDescription = dr.GetSqlString(2);
            mySubjects.m_strPhotoPath = dr.GetSqlString(3);
            mySubjects.m_strPhotoCaption = dr.GetSqlString(4);
            mySubjects.m_intParentSubjectID = dr.GetSqlInt32(5);
            mySubjects.m_intLeftBound = dr.GetSqlInt32(6);
            mySubjects.m_intRightBound = dr.GetSqlInt32(7);
            mySubjects.m_intSubjectTypeID = dr.GetSqlInt32(8);
            mySubjects.m_dtModifyDate = dr.GetSqlDateTime(9);
            mySubjects.m_intModifiedBy = dr.GetSqlInt32(10);
            
            result.Add(mySubjects.SubjectID, mySubjects);
		}
	
			return result;
		}
		
		public static DataSet LoadByParams(object intSubjectID , object strName , object strDescription , object strPhotoPath , object strPhotoCaption , object intParentSubjectID , object intLeftBound , object intRightBound , object intSubjectTypeID , object dtFindBefore_ModifyDate,object dtFindAfter_ModifyDate , object intModifiedBy) 
		{
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsSelectByParams", conn);
			SqlParameter param;
			
			
			
		        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSubjectID==null ? intSubjectID : (int)intSubjectID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Name", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strName==null ? strName : (string)strName);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strDescription==null ? strDescription : (string)strDescription);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoPath==null ? strPhotoPath : (string)strPhotoPath);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoCaption==null ? strPhotoCaption : (string)strPhotoCaption);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentSubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intParentSubjectID==null ? intParentSubjectID : (int)intParentSubjectID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LeftBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intLeftBound==null ? intLeftBound : (int)intLeftBound);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@RightBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intRightBound==null ? intRightBound : (int)intRightBound);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSubjectTypeID==null ? intSubjectTypeID : (int)intSubjectTypeID);
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
		
		public static DataSet LoadByParams(object intSubjectID , object strName , object strDescription , object strPhotoPath , object strPhotoCaption , object intParentSubjectID , object intLeftBound , object intRightBound , object intSubjectTypeID , object dtFindBefore_ModifyDate,object dtFindAfter_ModifyDate , object intModifiedBy,SqlConnection sqlConn,SqlTransaction sqlTran) 
		{
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsSelectByParams", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
			
		        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSubjectID==null ? intSubjectID : (int)intSubjectID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Name", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strName==null ? strName : (string)strName);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strDescription==null ? strDescription : (string)strDescription);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoPath==null ? strPhotoPath : (string)strPhotoPath);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoCaption==null ? strPhotoCaption : (string)strPhotoCaption);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentSubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intParentSubjectID==null ? intParentSubjectID : (int)intParentSubjectID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LeftBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intLeftBound==null ? intLeftBound : (int)intLeftBound);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@RightBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intRightBound==null ? intRightBound : (int)intRightBound);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSubjectTypeID==null ? intSubjectTypeID : (int)intSubjectTypeID);
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
		
		public static int Insert(bSubjects objSubjects) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Name", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.Name;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.Description;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentSubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.ParentSubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LeftBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.LeftBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@RightBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.RightBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.SubjectTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.ModifiedBy;
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
				objSubjects.SubjectID = retValue;
			return retValue;
		}
		
		public static int Insert(bSubjects objSubjects,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsInsert", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Name", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.Name;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.Description;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentSubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.ParentSubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LeftBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.LeftBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@RightBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.RightBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.SubjectTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.ModifiedBy;
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
				objSubjects.SubjectID = retValue;
			return retValue;
		}

		public static int Update(bSubjects objSubjects) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Name", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.Name;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.Description;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentSubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.ParentSubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LeftBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.LeftBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@RightBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.RightBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.SubjectTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.ModifiedBy;
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
		
		public static int Update(bSubjects objSubjects,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsUpdate", conn);
			cmd.Transaction=sqlTran;
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Name", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.Name;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.Description;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentSubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.ParentSubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LeftBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.LeftBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@RightBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.RightBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.SubjectTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.ModifiedBy;
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
		
		public static int Delete(bSubjects objSubjects) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.SubjectID;
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
		
		public static int Delete(bSubjects objSubjects,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsUpdate", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjects.SubjectID;
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
			return Load(pk.SubjectID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intSubjectID"> SubjectID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intSubjectID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsSelect", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for SubjectID column
        param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intSubjectID;
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
		            m_intSubjectID = reader.GetSqlInt32(0);
            m_strName = reader.GetSqlString(1);
            m_strDescription = reader.GetSqlString(2);
            m_strPhotoPath = reader.GetSqlString(3);
            m_strPhotoCaption = reader.GetSqlString(4);
            m_intParentSubjectID = reader.GetSqlInt32(5);
            m_intLeftBound = reader.GetSqlInt32(6);
            m_intRightBound = reader.GetSqlInt32(7);
            m_intSubjectTypeID = reader.GetSqlInt32(8);
            m_dtModifyDate = reader.GetSqlDateTime(9);
            m_intModifiedBy = reader.GetSqlInt32(10);
		
			} else {
			//	set key values
		            m_intSubjectID = intSubjectID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsSelectByParams", conn);

			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intSubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Name", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strDescription;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strPhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strPhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentSubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intParentSubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LeftBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intLeftBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@RightBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intRightBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intSubjectTypeID;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for SubjectID column
        param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectID;
        cmd.Parameters.Add(param);
        
        // parameter for Name column
        param = new SqlParameter("@Name", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strName;
        cmd.Parameters.Add(param);
        
        // parameter for Description column
        param = new SqlParameter("@Description", SqlDbType.NVarChar, 4000);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDescription;
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
        
        // parameter for ParentSubjectID column
        param = new SqlParameter("@ParentSubjectID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intParentSubjectID;
        cmd.Parameters.Add(param);
        
        // parameter for LeftBound column
        param = new SqlParameter("@LeftBound", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intLeftBound;
        cmd.Parameters.Add(param);
        
        // parameter for RightBound column
        param = new SqlParameter("@RightBound", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRightBound;
        cmd.Parameters.Add(param);
        
        // parameter for SubjectTypeID column
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectTypeID;
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
				SubjectID = retValue;
			return retValue;
		}
	
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		protected int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for SubjectID column
        param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectID;
        cmd.Parameters.Add(param);
        
        // parameter for Name column
        param = new SqlParameter("@Name", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strName;
        cmd.Parameters.Add(param);
        
        // parameter for Description column
        param = new SqlParameter("@Description", SqlDbType.NVarChar, 4000);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDescription;
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
        
        // parameter for ParentSubjectID column
        param = new SqlParameter("@ParentSubjectID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intParentSubjectID;
        cmd.Parameters.Add(param);
        
        // parameter for LeftBound column
        param = new SqlParameter("@LeftBound", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intLeftBound;
        cmd.Parameters.Add(param);
        
        // parameter for RightBound column
        param = new SqlParameter("@RightBound", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRightBound;
        cmd.Parameters.Add(param);
        
        // parameter for SubjectTypeID column
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectTypeID;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectsDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for SubjectID column
        param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectID;
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
		public static bool operator ==(bSubjects t1, bSubjects t2) {
			//	compare values
			if(t1.m_intSubjectID != t2.m_intSubjectID) {
				return false;	//	because "SubjectID" values are Not equal
			}
	
			if(t1.m_strName != t2.m_strName) {
				return false;	//	because "Name" values are Not equal
			}
	
			if(t1.m_strDescription != t2.m_strDescription) {
				return false;	//	because "Description" values are Not equal
			}
	
			if(t1.m_strPhotoPath != t2.m_strPhotoPath) {
				return false;	//	because "PhotoPath" values are Not equal
			}
	
			if(t1.m_strPhotoCaption != t2.m_strPhotoCaption) {
				return false;	//	because "PhotoCaption" values are Not equal
			}
	
			if(t1.m_intParentSubjectID != t2.m_intParentSubjectID) {
				return false;	//	because "ParentSubjectID" values are Not equal
			}
	
			if(t1.m_intLeftBound != t2.m_intLeftBound) {
				return false;	//	because "LeftBound" values are Not equal
			}
	
			if(t1.m_intRightBound != t2.m_intRightBound) {
				return false;	//	because "RightBound" values are Not equal
			}
	
			if(t1.m_intSubjectTypeID != t2.m_intSubjectTypeID) {
				return false;	//	because "SubjectTypeID" values are Not equal
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
		public static bool operator !=(bSubjects t1, bSubjects t2) {
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
				retValue.Append(" SubjectID = \"");
			retValue.Append(m_intSubjectID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    Name = \"");
			retValue.Append(m_strName);
			retValue.Append("\"\n");
				retValue.Append("    Description = \"");
			retValue.Append(m_strDescription);
			retValue.Append("\"\n");
				retValue.Append("    PhotoPath = \"");
			retValue.Append(m_strPhotoPath);
			retValue.Append("\"\n");
				retValue.Append("    PhotoCaption = \"");
			retValue.Append(m_strPhotoCaption);
			retValue.Append("\"\n");
				retValue.Append("    ParentSubjectID = \"");
			retValue.Append(m_intParentSubjectID);
			retValue.Append("\"\n");
				retValue.Append("    LeftBound = \"");
			retValue.Append(m_intLeftBound);
			retValue.Append("\"\n");
				retValue.Append("    RightBound = \"");
			retValue.Append(m_intRightBound);
			retValue.Append("\"\n");
				retValue.Append("    SubjectTypeID = \"");
			retValue.Append(m_intSubjectTypeID);
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
			if (!(o is Subjects)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Subjects)o;
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

