using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities {

	public class bForumArticle {
		//transactions
		//	enum types
		protected enum Action { Insert, Update, Delete };
			//	Sub-types
		public struct PK {
				public SqlInt32 ArticleID;
		}	
		
		
		protected Action m_aAction;
		protected bool m_bIsDirty;

		#region Table Members
		protected SqlInt32 m_intArticleID;
		protected SqlString m_strArticleName;
		protected SqlString m_strArticleDesc;
		protected SqlInt32 m_intArticleStatus;
		protected SqlInt32 m_intCategoryID;
		protected SqlInt32 m_intCreatedBy;
		protected SqlDateTime m_dtCreateDate;
protected SqlDateTime m_FindBefore_dtCreateDate;
protected SqlDateTime m_FindAfter_dtCreateDate;
		protected SqlDateTime m_dtEndDate;
protected SqlDateTime m_FindBefore_dtEndDate;
protected SqlDateTime m_FindAfter_dtEndDate;
		protected SqlInt32 m_intOrder;
		#endregion
		
		#region Properties
	
		public PK PrimaryKey {
			get {
				PK pk;
				pk.ArticleID = m_intArticleID;
				return pk;
			}
		}
			
		
		public int ArticleID {
			get {
				return (int)m_intArticleID;
			}
			set {
				m_intArticleID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string ArticleName {
			get {
				return (string)m_strArticleName;
			}
			set {
				m_strArticleName = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string ArticleDesc {
			get {
				return (string)m_strArticleDesc;
			}
			set {
				m_strArticleDesc = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int ArticleStatus {
			get {
				return (int)m_intArticleStatus;
			}
			set {
				m_intArticleStatus = value;
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
		
			
		
		public int CreatedBy {
			get {
				return (int)m_intCreatedBy;
			}
			set {
				m_intCreatedBy = value;
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
		
					public DateTime FindBefore_EndDate {
			get {
				return (DateTime)m_FindBefore_dtEndDate;
			}
			set {
				m_FindBefore_dtEndDate = value;
				m_bIsDirty = true;
			}
		}
		
		public DateTime FindAfter_EndDate {
			get {
				return (DateTime)m_FindAfter_dtEndDate;
			}
			set {
				m_FindAfter_dtEndDate = value;
				m_bIsDirty = true;
			}
		}
		
		
		
		public DateTime EndDate {
			get {
				return (DateTime)m_dtEndDate;
			}
			set {
				m_dtEndDate = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int Order {
			get {
				return (int)m_intOrder;
			}
			set {
				m_intOrder = value;
				m_bIsDirty = true;
			}
		}
		
	#endregion
	
		#region Constructers

		public bForumArticle() {
			Init();	//	init Object
		}
		#endregion

		#region Static Functions

		/// <summary>
		/// Gets all ForumArticle from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the ForumArticle</returns>
		
		public static SqlDataReader LoadAllReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleSelectAll", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet LoadAll() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all ForumArticle from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable LoadAllHashTable() {
			SqlDataReader dr = LoadAllReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates ForumArticle for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the ForumArticle records</param>
		/// <returns>The Hashtable containing ForumArticle objects And their ID As key.</returns>
		protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            ForumArticle myForumArticle = new ForumArticle();
            
            myForumArticle.m_intArticleID = dr.GetSqlInt32(0);
            myForumArticle.m_strArticleName = dr.GetSqlString(1);
            myForumArticle.m_strArticleDesc = dr.GetSqlString(2);
            myForumArticle.m_intArticleStatus = dr.GetSqlInt32(3);
            myForumArticle.m_intCategoryID = dr.GetSqlInt32(4);
            myForumArticle.m_intCreatedBy = dr.GetSqlInt32(5);
            myForumArticle.m_dtCreateDate = dr.GetSqlDateTime(6);
            myForumArticle.m_dtEndDate = dr.GetSqlDateTime(7);
            myForumArticle.m_intOrder = dr.GetSqlInt32(8);
            
            result.Add(myForumArticle.ArticleID, myForumArticle);
		}
	
			return result;
		}
		
		public static DataSet LoadByParams(object intArticleID , object strArticleName , object strArticleDesc , object intArticleStatus , object intCategoryID , object intCreatedBy , object dtFindBefore_CreateDate,object dtFindAfter_CreateDate , object dtFindBefore_EndDate,object dtFindAfter_EndDate , object intOrder) 
		{
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleSelectByParams", conn);
			SqlParameter param;
			
			
			
		        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intArticleID==null ? intArticleID : (int)intArticleID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strArticleName==null ? strArticleName : (string)strArticleName);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleDesc", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strArticleDesc==null ? strArticleDesc : (string)strArticleDesc);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleStatus", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intArticleStatus==null ? intArticleStatus : (int)intArticleStatus);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intCategoryID==null ? intCategoryID : (int)intCategoryID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intCreatedBy==null ? intCreatedBy : (int)intCreatedBy);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_CreateDate==null ? dtFindBefore_CreateDate : (DateTime)dtFindBefore_CreateDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_CreateDate==null ? dtFindAfter_CreateDate : (DateTime)dtFindAfter_CreateDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_EndDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_EndDate==null ? dtFindBefore_EndDate : (DateTime)dtFindBefore_EndDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_EndDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_EndDate==null ? dtFindAfter_EndDate : (DateTime)dtFindAfter_EndDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Order", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intOrder==null ? intOrder : (int)intOrder);
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static DataSet LoadByParams(object intArticleID , object strArticleName , object strArticleDesc , object intArticleStatus , object intCategoryID , object intCreatedBy , object dtFindBefore_CreateDate,object dtFindAfter_CreateDate , object dtFindBefore_EndDate,object dtFindAfter_EndDate , object intOrder,SqlConnection sqlConn,SqlTransaction sqlTran) 
		{
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleSelectByParams", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
			
		        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intArticleID==null ? intArticleID : (int)intArticleID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strArticleName==null ? strArticleName : (string)strArticleName);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleDesc", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strArticleDesc==null ? strArticleDesc : (string)strArticleDesc);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleStatus", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intArticleStatus==null ? intArticleStatus : (int)intArticleStatus);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intCategoryID==null ? intCategoryID : (int)intCategoryID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intCreatedBy==null ? intCreatedBy : (int)intCreatedBy);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_CreateDate==null ? dtFindBefore_CreateDate : (DateTime)dtFindBefore_CreateDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_CreateDate==null ? dtFindAfter_CreateDate : (DateTime)dtFindAfter_CreateDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_EndDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_EndDate==null ? dtFindBefore_EndDate : (DateTime)dtFindBefore_EndDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_EndDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_EndDate==null ? dtFindAfter_EndDate : (DateTime)dtFindAfter_EndDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Order", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intOrder==null ? intOrder : (int)intOrder);
        cmd.Parameters.Add(param);
        
		//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static int Insert(bForumArticle objForumArticle) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleDesc", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleDesc;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleStatus", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleStatus;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.CategoryID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.CreatedBy;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.CreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EndDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.EndDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Order", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.Order;
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
				objForumArticle.ArticleID = retValue;
			return retValue;
		}
		
		public static int Insert(bForumArticle objForumArticle,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleInsert", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleDesc", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleDesc;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleStatus", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleStatus;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.CategoryID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.CreatedBy;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.CreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EndDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.EndDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Order", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.Order;
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
				objForumArticle.ArticleID = retValue;
			return retValue;
		}

		public static int Update(bForumArticle objForumArticle) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleDesc", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleDesc;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleStatus", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleStatus;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.CategoryID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.CreatedBy;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.CreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EndDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.EndDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Order", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.Order;
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
		
		public static int Update(bForumArticle objForumArticle,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleUpdate", conn);
			cmd.Transaction=sqlTran;
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleDesc", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleDesc;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleStatus", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleStatus;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.CategoryID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.CreatedBy;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.CreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EndDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.EndDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Order", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.Order;
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
		
		public static int Delete(bForumArticle objForumArticle) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleID;
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
		
		public static int Delete(bForumArticle objForumArticle,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleUpdate", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticle.ArticleID;
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
			return Load(pk.ArticleID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intArticleID"> ArticleID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intArticleID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleSelect", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for ArticleID column
        param = new SqlParameter("@ArticleID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intArticleID;
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
		            m_intArticleID = reader.GetSqlInt32(0);
            m_strArticleName = reader.GetSqlString(1);
            m_strArticleDesc = reader.GetSqlString(2);
            m_intArticleStatus = reader.GetSqlInt32(3);
            m_intCategoryID = reader.GetSqlInt32(4);
            m_intCreatedBy = reader.GetSqlInt32(5);
            m_dtCreateDate = reader.GetSqlDateTime(6);
            m_dtEndDate = reader.GetSqlDateTime(7);
            m_intOrder = reader.GetSqlInt32(8);
		
			} else {
			//	set key values
		            m_intArticleID = intArticleID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleSelectByParams", conn);

			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intArticleID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strArticleName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleDesc", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strArticleDesc;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleStatus", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intArticleStatus;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CategoryID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intCategoryID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intCreatedBy;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindBefore_dtCreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindAfter_dtCreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_EndDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindBefore_dtEndDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_EndDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindAfter_dtEndDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Order", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intOrder;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for ArticleID column
        param = new SqlParameter("@ArticleID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intArticleID;
        cmd.Parameters.Add(param);
        
        // parameter for ArticleName column
        param = new SqlParameter("@ArticleName", SqlDbType.NVarChar, 1000);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strArticleName;
        cmd.Parameters.Add(param);
        
        // parameter for ArticleDesc column
        param = new SqlParameter("@ArticleDesc", SqlDbType.NVarChar, 4000);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strArticleDesc;
        cmd.Parameters.Add(param);
        
        // parameter for ArticleStatus column
        param = new SqlParameter("@ArticleStatus", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intArticleStatus;
        cmd.Parameters.Add(param);
        
        // parameter for CategoryID column
        param = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCategoryID;
        cmd.Parameters.Add(param);
        
        // parameter for CreatedBy column
        param = new SqlParameter("@CreatedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCreatedBy;
        cmd.Parameters.Add(param);
        
        // parameter for CreateDate column
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtCreateDate;
        cmd.Parameters.Add(param);
        
        // parameter for EndDate column
        param = new SqlParameter("@EndDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtEndDate;
        cmd.Parameters.Add(param);
        
        // parameter for Order column
        param = new SqlParameter("@Order", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intOrder;
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
				ArticleID = retValue;
			return retValue;
		}
	
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		protected int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for ArticleID column
        param = new SqlParameter("@ArticleID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intArticleID;
        cmd.Parameters.Add(param);
        
        // parameter for ArticleName column
        param = new SqlParameter("@ArticleName", SqlDbType.NVarChar, 1000);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strArticleName;
        cmd.Parameters.Add(param);
        
        // parameter for ArticleDesc column
        param = new SqlParameter("@ArticleDesc", SqlDbType.NVarChar, 4000);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strArticleDesc;
        cmd.Parameters.Add(param);
        
        // parameter for ArticleStatus column
        param = new SqlParameter("@ArticleStatus", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intArticleStatus;
        cmd.Parameters.Add(param);
        
        // parameter for CategoryID column
        param = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCategoryID;
        cmd.Parameters.Add(param);
        
        // parameter for CreatedBy column
        param = new SqlParameter("@CreatedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCreatedBy;
        cmd.Parameters.Add(param);
        
        // parameter for CreateDate column
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtCreateDate;
        cmd.Parameters.Add(param);
        
        // parameter for EndDate column
        param = new SqlParameter("@EndDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtEndDate;
        cmd.Parameters.Add(param);
        
        // parameter for Order column
        param = new SqlParameter("@Order", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intOrder;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for ArticleID column
        param = new SqlParameter("@ArticleID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intArticleID;
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
		public static bool operator ==(bForumArticle t1, bForumArticle t2) {
			//	compare values
			if(t1.m_intArticleID != t2.m_intArticleID) {
				return false;	//	because "ArticleID" values are Not equal
			}
	
			if(t1.m_strArticleName != t2.m_strArticleName) {
				return false;	//	because "ArticleName" values are Not equal
			}
	
			if(t1.m_strArticleDesc != t2.m_strArticleDesc) {
				return false;	//	because "ArticleDesc" values are Not equal
			}
	
			if(t1.m_intArticleStatus != t2.m_intArticleStatus) {
				return false;	//	because "ArticleStatus" values are Not equal
			}
	
			if(t1.m_intCategoryID != t2.m_intCategoryID) {
				return false;	//	because "CategoryID" values are Not equal
			}
	
			if(t1.m_intCreatedBy != t2.m_intCreatedBy) {
				return false;	//	because "CreatedBy" values are Not equal
			}
	
			if(t1.m_dtCreateDate != t2.m_dtCreateDate) {
				return false;	//	because "CreateDate" values are Not equal
			}
	
			if(t1.m_dtEndDate != t2.m_dtEndDate) {
				return false;	//	because "EndDate" values are Not equal
			}
	
			if(t1.m_intOrder != t2.m_intOrder) {
				return false;	//	because "Order" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(bForumArticle t1, bForumArticle t2) {
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
				retValue.Append(" ArticleID = \"");
			retValue.Append(m_intArticleID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    ArticleName = \"");
			retValue.Append(m_strArticleName);
			retValue.Append("\"\n");
				retValue.Append("    ArticleDesc = \"");
			retValue.Append(m_strArticleDesc);
			retValue.Append("\"\n");
				retValue.Append("    ArticleStatus = \"");
			retValue.Append(m_intArticleStatus);
			retValue.Append("\"\n");
				retValue.Append("    CategoryID = \"");
			retValue.Append(m_intCategoryID);
			retValue.Append("\"\n");
				retValue.Append("    CreatedBy = \"");
			retValue.Append(m_intCreatedBy);
			retValue.Append("\"\n");
				retValue.Append("    CreateDate = \"");
			retValue.Append(m_dtCreateDate);
			retValue.Append("\"\n");
				retValue.Append("    EndDate = \"");
			retValue.Append(m_dtEndDate);
			retValue.Append("\"\n");
				retValue.Append("    Order = \"");
			retValue.Append(m_intOrder);
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
			if (!(o is ForumArticle)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (ForumArticle)o;
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

