using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities {

	public class bPages {
		//transactions
		//	enum types
		protected enum Action { Insert, Update, Delete };
			//	Sub-types
		public struct PK {
				public SqlInt32 PageID;
		}	
		
		
		protected Action m_aAction;
		protected bool m_bIsDirty;

		#region Table Members
		protected SqlInt32 m_intPageID;
		protected SqlInt32 m_intMemberID;
		protected SqlInt32 m_intSubjectID;
		protected SqlInt32 m_intCategoryID;
		protected SqlInt32 m_intPageTypeID;
		protected SqlInt32 m_intPageCategoryID;
		protected SqlString m_strTitle;
		protected SqlString m_strPageContent;
		protected SqlDateTime m_dtTravelDate;
protected SqlDateTime m_FindBefore_dtTravelDate;
protected SqlDateTime m_FindAfter_dtTravelDate;
		protected SqlString m_strPhotoPath;
		protected SqlString m_strPhotoCaption;
		protected SqlInt32 m_intParentPageID;
		protected SqlInt32 m_intLeftBound;
		protected SqlInt32 m_intRightBound;
		protected SqlDateTime m_dtCreateDate;
protected SqlDateTime m_FindBefore_dtCreateDate;
protected SqlDateTime m_FindAfter_dtCreateDate;
		protected SqlDateTime m_dtModifyDate;
protected SqlDateTime m_FindBefore_dtModifyDate;
protected SqlDateTime m_FindAfter_dtModifyDate;
		protected SqlInt32 m_intModifiedBy;
		protected SqlBoolean m_bolisDeleted;
		#endregion
		
		#region Properties
	
		public PK PrimaryKey {
			get {
				PK pk;
				pk.PageID = m_intPageID;
				return pk;
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
		
			
		
		public int MemberID {
			get {
				return (int)m_intMemberID;
			}
			set {
				m_intMemberID = value;
				m_bIsDirty = true;
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
		
			
		
		public int CategoryID {
			get {
				return (int)m_intCategoryID;
			}
			set {
				m_intCategoryID = value;
				m_bIsDirty = true;
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
		
			
		
		public int PageCategoryID {
			get {
				return (int)m_intPageCategoryID;
			}
			set {
				m_intPageCategoryID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Title {
			get {
				return (string)m_strTitle;
			}
			set {
				m_strTitle = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string PageContent {
			get {
				return (string)m_strPageContent;
			}
			set {
				m_strPageContent = value;
				m_bIsDirty = true;
			}
		}
		
					public DateTime FindBefore_TravelDate {
			get {
				return (DateTime)m_FindBefore_dtTravelDate;
			}
			set {
				m_FindBefore_dtTravelDate = value;
				m_bIsDirty = true;
			}
		}
		
		public DateTime FindAfter_TravelDate {
			get {
				return (DateTime)m_FindAfter_dtTravelDate;
			}
			set {
				m_FindAfter_dtTravelDate = value;
				m_bIsDirty = true;
			}
		}
		
		
		
		public DateTime TravelDate {
			get {
				return (DateTime)m_dtTravelDate;
			}
			set {
				m_dtTravelDate = value;
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
		
			
		
		public int ParentPageID {
			get {
				return (int)m_intParentPageID;
			}
			set {
				m_intParentPageID = value;
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
		
					public DateTime FindBefore_CreateDate {
			get {
				return (DateTime)m_FindBefore_dtCreateDate;
			}
			set {
				m_FindBefore_dtCreateDate = value;
				m_bIsDirty = true;
			}
		}
		
		public DateTime FindAfter_CreateDate {
			get {
				return (DateTime)m_FindAfter_dtCreateDate;
			}
			set {
				m_FindAfter_dtCreateDate = value;
				m_bIsDirty = true;
			}
		}
		
		
		
		public DateTime CreateDate {
			get {
				return (DateTime)m_dtCreateDate;
			}
			set {
				m_dtCreateDate = value;
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
		
			
		
		public bool isDeleted {
			get {
				return (bool)m_bolisDeleted;
			}
			set {
				m_bolisDeleted = value;
				m_bIsDirty = true;
			}
		}
		
	#endregion
	
		#region Constructers

		public bPages() {
			Init();	//	init Object
		}
		#endregion

		#region Static Functions

		/// <summary>
		/// Gets all Pages from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Pages</returns>
		
		public static SqlDataReader LoadAllReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagesSelectAll", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet LoadAll() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagesSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all Pages from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable LoadAllHashTable() {
			SqlDataReader dr = LoadAllReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates Pages for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Pages records</param>
		/// <returns>The Hashtable containing Pages objects And their ID As key.</returns>
		protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Pages myPages = new Pages();
            
            myPages.m_intPageID = dr.GetSqlInt32(0);
            myPages.m_intMemberID = dr.GetSqlInt32(1);
            myPages.m_intSubjectID = dr.GetSqlInt32(2);
            myPages.m_intCategoryID = dr.GetSqlInt32(3);
            myPages.m_intPageTypeID = dr.GetSqlInt32(4);
            myPages.m_intPageCategoryID = dr.GetSqlInt32(5);
            myPages.m_strTitle = dr.GetSqlString(6);
            myPages.m_strPageContent = dr.GetSqlString(7);
            myPages.m_dtTravelDate = dr.GetSqlDateTime(8);
            myPages.m_strPhotoPath = dr.GetSqlString(9);
            myPages.m_strPhotoCaption = dr.GetSqlString(10);
            myPages.m_intParentPageID = dr.GetSqlInt32(11);
            myPages.m_intLeftBound = dr.GetSqlInt32(12);
            myPages.m_intRightBound = dr.GetSqlInt32(13);
            myPages.m_dtCreateDate = dr.GetSqlDateTime(14);
            myPages.m_dtModifyDate = dr.GetSqlDateTime(15);
            myPages.m_intModifiedBy = dr.GetSqlInt32(16);
            myPages.m_bolisDeleted = dr.GetSqlBoolean(17);
            
            result.Add(myPages.PageID, myPages);
		}
	
			return result;
		}
		
		public static DataSet LoadByParams(object intPageID , object intMemberID , object intSubjectID , object intCategoryID , object intPageTypeID , object intPageCategoryID , object strTitle , object strPageContent , object dtFindBefore_TravelDate,object dtFindAfter_TravelDate , object strPhotoPath , object strPhotoCaption , object intParentPageID , object intLeftBound , object intRightBound , object dtFindBefore_CreateDate,object dtFindAfter_CreateDate , object dtFindBefore_ModifyDate,object dtFindAfter_ModifyDate , object intModifiedBy , object bolisDeleted) 
		{
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagesSelectByParams", conn);
			SqlParameter param;
			
			
			
		        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPageID==null ? intPageID : (int)intPageID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intMemberID==null ? intMemberID : (int)intMemberID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSubjectID==null ? intSubjectID : (int)intSubjectID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intCategoryID==null ? intCategoryID : (int)intCategoryID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPageTypeID==null ? intPageTypeID : (int)intPageTypeID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageCategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPageCategoryID==null ? intPageCategoryID : (int)intPageCategoryID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Title", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strTitle==null ? strTitle : (string)strTitle);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageContent", SqlDbType.NText);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPageContent==null ? strPageContent : (string)strPageContent);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_TravelDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_TravelDate==null ? dtFindBefore_TravelDate : (DateTime)dtFindBefore_TravelDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_TravelDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_TravelDate==null ? dtFindAfter_TravelDate : (DateTime)dtFindAfter_TravelDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoPath==null ? strPhotoPath : (string)strPhotoPath);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoCaption==null ? strPhotoCaption : (string)strPhotoCaption);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentPageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intParentPageID==null ? intParentPageID : (int)intParentPageID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LeftBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intLeftBound==null ? intLeftBound : (int)intLeftBound);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@RightBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intRightBound==null ? intRightBound : (int)intRightBound);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_CreateDate==null ? dtFindBefore_CreateDate : (DateTime)dtFindBefore_CreateDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_CreateDate==null ? dtFindAfter_CreateDate : (DateTime)dtFindAfter_CreateDate);
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
        
        param = new SqlParameter("@isDeleted", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=(bolisDeleted==null ? bolisDeleted : (bool)bolisDeleted);
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static DataSet LoadByParams(object intPageID , object intMemberID , object intSubjectID , object intCategoryID , object intPageTypeID , object intPageCategoryID , object strTitle , object strPageContent , object dtFindBefore_TravelDate,object dtFindAfter_TravelDate , object strPhotoPath , object strPhotoCaption , object intParentPageID , object intLeftBound , object intRightBound , object dtFindBefore_CreateDate,object dtFindAfter_CreateDate , object dtFindBefore_ModifyDate,object dtFindAfter_ModifyDate , object intModifiedBy , object bolisDeleted,SqlConnection sqlConn,SqlTransaction sqlTran) 
		{
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagesSelectByParams", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
			
		        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPageID==null ? intPageID : (int)intPageID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intMemberID==null ? intMemberID : (int)intMemberID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSubjectID==null ? intSubjectID : (int)intSubjectID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intCategoryID==null ? intCategoryID : (int)intCategoryID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPageTypeID==null ? intPageTypeID : (int)intPageTypeID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageCategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intPageCategoryID==null ? intPageCategoryID : (int)intPageCategoryID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Title", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strTitle==null ? strTitle : (string)strTitle);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageContent", SqlDbType.NText);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPageContent==null ? strPageContent : (string)strPageContent);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_TravelDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_TravelDate==null ? dtFindBefore_TravelDate : (DateTime)dtFindBefore_TravelDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_TravelDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_TravelDate==null ? dtFindAfter_TravelDate : (DateTime)dtFindAfter_TravelDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoPath==null ? strPhotoPath : (string)strPhotoPath);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoCaption==null ? strPhotoCaption : (string)strPhotoCaption);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentPageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intParentPageID==null ? intParentPageID : (int)intParentPageID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LeftBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intLeftBound==null ? intLeftBound : (int)intLeftBound);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@RightBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intRightBound==null ? intRightBound : (int)intRightBound);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_CreateDate==null ? dtFindBefore_CreateDate : (DateTime)dtFindBefore_CreateDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_CreateDate==null ? dtFindAfter_CreateDate : (DateTime)dtFindAfter_CreateDate);
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
        
        param = new SqlParameter("@isDeleted", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=(bolisDeleted==null ? bolisDeleted : (bool)bolisDeleted);
        cmd.Parameters.Add(param);
        
		//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static int Insert(bPages objPages) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagesInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.MemberID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.CategoryID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageCategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageCategoryID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Title", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.Title;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageContent", SqlDbType.NText);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageContent;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@TravelDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.TravelDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentPageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.ParentPageID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LeftBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.LeftBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@RightBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.RightBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.CreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.ModifiedBy;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isDeleted", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.isDeleted;
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
				objPages.PageID = retValue;
			return retValue;
		}
		
		public static int Insert(bPages objPages,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagesInsert", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.MemberID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.CategoryID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageCategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageCategoryID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Title", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.Title;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageContent", SqlDbType.NText);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageContent;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@TravelDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.TravelDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentPageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.ParentPageID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LeftBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.LeftBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@RightBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.RightBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.CreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.ModifiedBy;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isDeleted", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.isDeleted;
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
				objPages.PageID = retValue;
			return retValue;
		}

		public static int Update(bPages objPages) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagesUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.MemberID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.CategoryID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageCategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageCategoryID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Title", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.Title;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageContent", SqlDbType.NText);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageContent;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@TravelDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.TravelDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentPageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.ParentPageID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LeftBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.LeftBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@RightBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.RightBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.CreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.ModifiedBy;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isDeleted", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.isDeleted;
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
		
		public static int Update(bPages objPages,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagesUpdate", conn);
			cmd.Transaction=sqlTran;
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.MemberID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.CategoryID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageCategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageCategoryID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Title", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.Title;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageContent", SqlDbType.NText);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageContent;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@TravelDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.TravelDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentPageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.ParentPageID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LeftBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.LeftBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@RightBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.RightBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.CreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.ModifiedBy;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isDeleted", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.isDeleted;
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
		
		public static int Delete(bPages objPages) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagesDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageID;
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
		
		public static int Delete(bPages objPages,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagesUpdate", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objPages.PageID;
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
			return Load(pk.PageID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intPageID"> PageID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intPageID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagesSelect", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for PageID column
        param = new SqlParameter("@PageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intPageID;
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
		            m_intPageID = reader.GetSqlInt32(0);
            m_intMemberID = reader.GetSqlInt32(1);
            m_intSubjectID = reader.GetSqlInt32(2);
            m_intCategoryID = reader.GetSqlInt32(3);
            m_intPageTypeID = reader.GetSqlInt32(4);
            m_intPageCategoryID = reader.GetSqlInt32(5);
            m_strTitle = reader.GetSqlString(6);
            m_strPageContent = reader.GetSqlString(7);
            m_dtTravelDate = reader.GetSqlDateTime(8);
            m_strPhotoPath = reader.GetSqlString(9);
            m_strPhotoCaption = reader.GetSqlString(10);
            m_intParentPageID = reader.GetSqlInt32(11);
            m_intLeftBound = reader.GetSqlInt32(12);
            m_intRightBound = reader.GetSqlInt32(13);
            m_dtCreateDate = reader.GetSqlDateTime(14);
            m_dtModifyDate = reader.GetSqlDateTime(15);
            m_intModifiedBy = reader.GetSqlInt32(16);
            m_bolisDeleted = reader.GetSqlBoolean(17);
		
			} else {
			//	set key values
		            m_intPageID = intPageID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocPagesSelectByParams", conn);

			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@PageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intPageID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intMemberID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intSubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intCategoryID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intPageTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageCategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intPageCategoryID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Title", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strTitle;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PageContent", SqlDbType.NText);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strPageContent;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_TravelDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindBefore_dtTravelDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_TravelDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindAfter_dtTravelDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strPhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strPhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentPageID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intParentPageID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LeftBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intLeftBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@RightBound", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intRightBound;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindBefore_dtCreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindAfter_dtCreateDate;
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
        
        param = new SqlParameter("@isDeleted", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=m_bolisDeleted;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagesInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
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
        
        // parameter for SubjectID column
        param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectID;
        cmd.Parameters.Add(param);
        
        // parameter for CategoryID column
        param = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCategoryID;
        cmd.Parameters.Add(param);
        
        // parameter for PageTypeID column
        param = new SqlParameter("@PageTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPageTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for PageCategoryID column
        param = new SqlParameter("@PageCategoryID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPageCategoryID;
        cmd.Parameters.Add(param);
        
        // parameter for Title column
        param = new SqlParameter("@Title", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strTitle;
        cmd.Parameters.Add(param);
        
        // parameter for PageContent column
        param = new SqlParameter("@PageContent", SqlDbType.NText);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPageContent;
        cmd.Parameters.Add(param);
        
        // parameter for TravelDate column
        param = new SqlParameter("@TravelDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtTravelDate;
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
        
        // parameter for ParentPageID column
        param = new SqlParameter("@ParentPageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intParentPageID;
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
        
        // parameter for isDeleted column
        param = new SqlParameter("@isDeleted", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisDeleted;
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
				PageID = retValue;
			return retValue;
		}
	
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		protected int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagesUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
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
        
        // parameter for SubjectID column
        param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectID;
        cmd.Parameters.Add(param);
        
        // parameter for CategoryID column
        param = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCategoryID;
        cmd.Parameters.Add(param);
        
        // parameter for PageTypeID column
        param = new SqlParameter("@PageTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPageTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for PageCategoryID column
        param = new SqlParameter("@PageCategoryID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPageCategoryID;
        cmd.Parameters.Add(param);
        
        // parameter for Title column
        param = new SqlParameter("@Title", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strTitle;
        cmd.Parameters.Add(param);
        
        // parameter for PageContent column
        param = new SqlParameter("@PageContent", SqlDbType.NText);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPageContent;
        cmd.Parameters.Add(param);
        
        // parameter for TravelDate column
        param = new SqlParameter("@TravelDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtTravelDate;
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
        
        // parameter for ParentPageID column
        param = new SqlParameter("@ParentPageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intParentPageID;
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
        
        // parameter for isDeleted column
        param = new SqlParameter("@isDeleted", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisDeleted;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocPagesDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for PageID column
        param = new SqlParameter("@PageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intPageID;
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
		public static bool operator ==(bPages t1, bPages t2) {
			//	compare values
			if(t1.m_intPageID != t2.m_intPageID) {
				return false;	//	because "PageID" values are Not equal
			}
	
			if(t1.m_intMemberID != t2.m_intMemberID) {
				return false;	//	because "MemberID" values are Not equal
			}
	
			if(t1.m_intSubjectID != t2.m_intSubjectID) {
				return false;	//	because "SubjectID" values are Not equal
			}
	
			if(t1.m_intCategoryID != t2.m_intCategoryID) {
				return false;	//	because "CategoryID" values are Not equal
			}
	
			if(t1.m_intPageTypeID != t2.m_intPageTypeID) {
				return false;	//	because "PageTypeID" values are Not equal
			}
	
			if(t1.m_intPageCategoryID != t2.m_intPageCategoryID) {
				return false;	//	because "PageCategoryID" values are Not equal
			}
	
			if(t1.m_strTitle != t2.m_strTitle) {
				return false;	//	because "Title" values are Not equal
			}
	
			if(t1.m_strPageContent != t2.m_strPageContent) {
				return false;	//	because "PageContent" values are Not equal
			}
	
			if(t1.m_dtTravelDate != t2.m_dtTravelDate) {
				return false;	//	because "TravelDate" values are Not equal
			}
	
			if(t1.m_strPhotoPath != t2.m_strPhotoPath) {
				return false;	//	because "PhotoPath" values are Not equal
			}
	
			if(t1.m_strPhotoCaption != t2.m_strPhotoCaption) {
				return false;	//	because "PhotoCaption" values are Not equal
			}
	
			if(t1.m_intParentPageID != t2.m_intParentPageID) {
				return false;	//	because "ParentPageID" values are Not equal
			}
	
			if(t1.m_intLeftBound != t2.m_intLeftBound) {
				return false;	//	because "LeftBound" values are Not equal
			}
	
			if(t1.m_intRightBound != t2.m_intRightBound) {
				return false;	//	because "RightBound" values are Not equal
			}
	
			if(t1.m_dtCreateDate != t2.m_dtCreateDate) {
				return false;	//	because "CreateDate" values are Not equal
			}
	
			if(t1.m_dtModifyDate != t2.m_dtModifyDate) {
				return false;	//	because "ModifyDate" values are Not equal
			}
	
			if(t1.m_intModifiedBy != t2.m_intModifiedBy) {
				return false;	//	because "ModifiedBy" values are Not equal
			}
	
			if(t1.m_bolisDeleted != t2.m_bolisDeleted) {
				return false;	//	because "isDeleted" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(bPages t1, bPages t2) {
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
				retValue.Append(" PageID = \"");
			retValue.Append(m_intPageID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    MemberID = \"");
			retValue.Append(m_intMemberID);
			retValue.Append("\"\n");
				retValue.Append("    SubjectID = \"");
			retValue.Append(m_intSubjectID);
			retValue.Append("\"\n");
				retValue.Append("    CategoryID = \"");
			retValue.Append(m_intCategoryID);
			retValue.Append("\"\n");
				retValue.Append("    PageTypeID = \"");
			retValue.Append(m_intPageTypeID);
			retValue.Append("\"\n");
				retValue.Append("    PageCategoryID = \"");
			retValue.Append(m_intPageCategoryID);
			retValue.Append("\"\n");
				retValue.Append("    Title = \"");
			retValue.Append(m_strTitle);
			retValue.Append("\"\n");
				retValue.Append("    PageContent = \"");
			retValue.Append(m_strPageContent);
			retValue.Append("\"\n");
				retValue.Append("    TravelDate = \"");
			retValue.Append(m_dtTravelDate);
			retValue.Append("\"\n");
				retValue.Append("    PhotoPath = \"");
			retValue.Append(m_strPhotoPath);
			retValue.Append("\"\n");
				retValue.Append("    PhotoCaption = \"");
			retValue.Append(m_strPhotoCaption);
			retValue.Append("\"\n");
				retValue.Append("    ParentPageID = \"");
			retValue.Append(m_intParentPageID);
			retValue.Append("\"\n");
				retValue.Append("    LeftBound = \"");
			retValue.Append(m_intLeftBound);
			retValue.Append("\"\n");
				retValue.Append("    RightBound = \"");
			retValue.Append(m_intRightBound);
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
				retValue.Append("    isDeleted = \"");
			retValue.Append(m_bolisDeleted);
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
			if (!(o is Pages)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Pages)o;
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

