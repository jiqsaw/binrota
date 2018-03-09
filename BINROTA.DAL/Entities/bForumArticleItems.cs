using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities {

	public class bForumArticleItems {
		//transactions
		//	enum types
		protected enum Action { Insert, Update, Delete };
			//	Sub-types
		public struct PK {
				public SqlInt32 ArticleItemID;
		}	
		
		
		protected Action m_aAction;
		protected bool m_bIsDirty;

		#region Table Members
		protected SqlInt32 m_intArticleItemID;
		protected SqlInt32 m_intParentID;
		protected SqlInt32 m_intArticleID;
		protected SqlString m_strTitle;
		protected SqlInt32 m_intCreatedBy;
		protected SqlString m_strDescription;
		protected SqlInt32 m_intIndent;
		protected SqlDateTime m_dtDateAdded;
protected SqlDateTime m_FindBefore_dtDateAdded;
protected SqlDateTime m_FindAfter_dtDateAdded;
		protected SqlByte m_bytCommentType;
		protected SqlInt32 m_intScore;
		#endregion
		
		#region Properties
	
		public PK PrimaryKey {
			get {
				PK pk;
				pk.ArticleItemID = m_intArticleItemID;
				return pk;
			}
		}
			
		
		public int ArticleItemID {
			get {
				return (int)m_intArticleItemID;
			}
			set {
				m_intArticleItemID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int ParentID {
			get {
				return (int)m_intParentID;
			}
			set {
				m_intParentID = value;
				m_bIsDirty = true;
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
		
			
		
		public string Title {
			get {
				return (string)m_strTitle;
			}
			set {
				m_strTitle = value;
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
		
			
		
		public string Description {
			get {
				return (string)m_strDescription;
			}
			set {
				m_strDescription = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int Indent {
			get {
				return (int)m_intIndent;
			}
			set {
				m_intIndent = value;
				m_bIsDirty = true;
			}
		}
		
					public DateTime FindBefore_DateAdded {
			get {
				return (DateTime)m_FindBefore_dtDateAdded;
			}
			set {
				m_FindBefore_dtDateAdded = value;
				m_bIsDirty = true;
			}
		}
		
		public DateTime FindAfter_DateAdded {
			get {
				return (DateTime)m_FindAfter_dtDateAdded;
			}
			set {
				m_FindAfter_dtDateAdded = value;
				m_bIsDirty = true;
			}
		}
		
		
		
		public DateTime DateAdded {
			get {
				return (DateTime)m_dtDateAdded;
			}
			set {
				m_dtDateAdded = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public byte CommentType {
			get {
				return (byte)m_bytCommentType;
			}
			set {
				m_bytCommentType = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int Score {
			get {
				return (int)m_intScore;
			}
			set {
				m_intScore = value;
				m_bIsDirty = true;
			}
		}
		
	#endregion
	
		#region Constructers

		public bForumArticleItems() {
			Init();	//	init Object
		}
		#endregion

		#region Static Functions

		/// <summary>
		/// Gets all ForumArticleItems from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the ForumArticleItems</returns>
		
		public static SqlDataReader LoadAllReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsSelectAll", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet LoadAll() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all ForumArticleItems from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable LoadAllHashTable() {
			SqlDataReader dr = LoadAllReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates ForumArticleItems for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the ForumArticleItems records</param>
		/// <returns>The Hashtable containing ForumArticleItems objects And their ID As key.</returns>
		protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            ForumArticleItems myForumArticleItems = new ForumArticleItems();
            
            myForumArticleItems.m_intArticleItemID = dr.GetSqlInt32(0);
            myForumArticleItems.m_intParentID = dr.GetSqlInt32(1);
            myForumArticleItems.m_intArticleID = dr.GetSqlInt32(2);
            myForumArticleItems.m_strTitle = dr.GetSqlString(3);
            myForumArticleItems.m_intCreatedBy = dr.GetSqlInt32(4);
            myForumArticleItems.m_strDescription = dr.GetSqlString(5);
            myForumArticleItems.m_intIndent = dr.GetSqlInt32(6);
            myForumArticleItems.m_dtDateAdded = dr.GetSqlDateTime(7);
            myForumArticleItems.m_bytCommentType = dr.GetSqlByte(8);
            myForumArticleItems.m_intScore = dr.GetSqlInt32(9);
            
            result.Add(myForumArticleItems.ArticleItemID, myForumArticleItems);
		}
	
			return result;
		}
		
		public static DataSet LoadByParams(object intArticleItemID , object intParentID , object intArticleID , object strTitle , object intCreatedBy , object strDescription , object intIndent , object dtFindBefore_DateAdded,object dtFindAfter_DateAdded , object bytCommentType , object intScore) 
		{
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsSelectByParams", conn);
			SqlParameter param;
			
			
			
		        param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intArticleItemID==null ? intArticleItemID : (int)intArticleItemID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intParentID==null ? intParentID : (int)intParentID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intArticleID==null ? intArticleID : (int)intArticleID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Title", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strTitle==null ? strTitle : (string)strTitle);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intCreatedBy==null ? intCreatedBy : (int)intCreatedBy);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strDescription==null ? strDescription : (string)strDescription);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Indent", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intIndent==null ? intIndent : (int)intIndent);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_DateAdded", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_DateAdded==null ? dtFindBefore_DateAdded : (DateTime)dtFindBefore_DateAdded);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_DateAdded", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_DateAdded==null ? dtFindAfter_DateAdded : (DateTime)dtFindAfter_DateAdded);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CommentType", SqlDbType.TinyInt);
        param.Direction = ParameterDirection.Input;
        param.Value=(bytCommentType==null ? bytCommentType : (byte)bytCommentType);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Score", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intScore==null ? intScore : (int)intScore);
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static DataSet LoadByParams(object intArticleItemID , object intParentID , object intArticleID , object strTitle , object intCreatedBy , object strDescription , object intIndent , object dtFindBefore_DateAdded,object dtFindAfter_DateAdded , object bytCommentType , object intScore,SqlConnection sqlConn,SqlTransaction sqlTran) 
		{
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsSelectByParams", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
			
		        param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intArticleItemID==null ? intArticleItemID : (int)intArticleItemID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intParentID==null ? intParentID : (int)intParentID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intArticleID==null ? intArticleID : (int)intArticleID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Title", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strTitle==null ? strTitle : (string)strTitle);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intCreatedBy==null ? intCreatedBy : (int)intCreatedBy);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strDescription==null ? strDescription : (string)strDescription);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Indent", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intIndent==null ? intIndent : (int)intIndent);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_DateAdded", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_DateAdded==null ? dtFindBefore_DateAdded : (DateTime)dtFindBefore_DateAdded);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_DateAdded", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_DateAdded==null ? dtFindAfter_DateAdded : (DateTime)dtFindAfter_DateAdded);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CommentType", SqlDbType.TinyInt);
        param.Direction = ParameterDirection.Input;
        param.Value=(bytCommentType==null ? bytCommentType : (byte)bytCommentType);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Score", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intScore==null ? intScore : (int)intScore);
        cmd.Parameters.Add(param);
        
		//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static int Insert(bForumArticleItems objForumArticleItems) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.ArticleItemID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.ParentID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.ArticleID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Title", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Title;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.CreatedBy;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Description;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Indent", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Indent;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@DateAdded", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.DateAdded;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CommentType", SqlDbType.TinyInt);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.CommentType;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Score", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Score;
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
				objForumArticleItems.ArticleItemID = retValue;
			return retValue;
		}
		
		public static int Insert(bForumArticleItems objForumArticleItems,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsInsert", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.ArticleItemID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.ParentID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.ArticleID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Title", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Title;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.CreatedBy;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Description;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Indent", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Indent;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@DateAdded", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.DateAdded;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CommentType", SqlDbType.TinyInt);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.CommentType;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Score", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Score;
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
				objForumArticleItems.ArticleItemID = retValue;
			return retValue;
		}

		public static int Update(bForumArticleItems objForumArticleItems) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.ArticleItemID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.ParentID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.ArticleID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Title", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Title;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.CreatedBy;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Description;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Indent", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Indent;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@DateAdded", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.DateAdded;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CommentType", SqlDbType.TinyInt);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.CommentType;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Score", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Score;
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
		
		public static int Update(bForumArticleItems objForumArticleItems,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsUpdate", conn);
			cmd.Transaction=sqlTran;
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.ArticleItemID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.ParentID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.ArticleID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Title", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Title;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.CreatedBy;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Description;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Indent", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Indent;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@DateAdded", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.DateAdded;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CommentType", SqlDbType.TinyInt);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.CommentType;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Score", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.Score;
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
		
		public static int Delete(bForumArticleItems objForumArticleItems) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.ArticleItemID;
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
		
		public static int Delete(bForumArticleItems objForumArticleItems,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsUpdate", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objForumArticleItems.ArticleItemID;
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
			return Load(pk.ArticleItemID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intArticleItemID"> ArticleItemID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intArticleItemID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsSelect", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for ArticleItemID column
        param = new SqlParameter("@ArticleItemID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intArticleItemID;
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
		            m_intArticleItemID = reader.GetSqlInt32(0);
            m_intParentID = reader.GetSqlInt32(1);
            m_intArticleID = reader.GetSqlInt32(2);
            m_strTitle = reader.GetSqlString(3);
            m_intCreatedBy = reader.GetSqlInt32(4);
            m_strDescription = reader.GetSqlString(5);
            m_intIndent = reader.GetSqlInt32(6);
            m_dtDateAdded = reader.GetSqlDateTime(7);
            m_bytCommentType = reader.GetSqlByte(8);
            m_intScore = reader.GetSqlInt32(9);
		
			} else {
			//	set key values
		            m_intArticleItemID = intArticleItemID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsSelectByParams", conn);

			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intArticleItemID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ParentID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intParentID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ArticleID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intArticleID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Title", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strTitle;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intCreatedBy;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Description", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strDescription;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Indent", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intIndent;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_DateAdded", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindBefore_dtDateAdded;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_DateAdded", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindAfter_dtDateAdded;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CommentType", SqlDbType.TinyInt);
        param.Direction = ParameterDirection.Input;
        param.Value=m_bytCommentType;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Score", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intScore;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for ArticleItemID column
        param = new SqlParameter("@ArticleItemID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intArticleItemID;
        cmd.Parameters.Add(param);
        
        // parameter for ParentID column
        param = new SqlParameter("@ParentID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intParentID;
        cmd.Parameters.Add(param);
        
        // parameter for ArticleID column
        param = new SqlParameter("@ArticleID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intArticleID;
        cmd.Parameters.Add(param);
        
        // parameter for Title column
        param = new SqlParameter("@Title", SqlDbType.NVarChar, 250);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strTitle;
        cmd.Parameters.Add(param);
        
        // parameter for CreatedBy column
        param = new SqlParameter("@CreatedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCreatedBy;
        cmd.Parameters.Add(param);
        
        // parameter for Description column
        param = new SqlParameter("@Description", SqlDbType.NVarChar, 2000);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDescription;
        cmd.Parameters.Add(param);
        
        // parameter for Indent column
        param = new SqlParameter("@Indent", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intIndent;
        cmd.Parameters.Add(param);
        
        // parameter for DateAdded column
        param = new SqlParameter("@DateAdded", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtDateAdded;
        cmd.Parameters.Add(param);
        
        // parameter for CommentType column
        param = new SqlParameter("@CommentType", SqlDbType.TinyInt, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bytCommentType;
        cmd.Parameters.Add(param);
        
        // parameter for Score column
        param = new SqlParameter("@Score", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intScore;
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
				ArticleItemID = retValue;
			return retValue;
		}
	
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		protected int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for ArticleItemID column
        param = new SqlParameter("@ArticleItemID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intArticleItemID;
        cmd.Parameters.Add(param);
        
        // parameter for ParentID column
        param = new SqlParameter("@ParentID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intParentID;
        cmd.Parameters.Add(param);
        
        // parameter for ArticleID column
        param = new SqlParameter("@ArticleID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intArticleID;
        cmd.Parameters.Add(param);
        
        // parameter for Title column
        param = new SqlParameter("@Title", SqlDbType.NVarChar, 250);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strTitle;
        cmd.Parameters.Add(param);
        
        // parameter for CreatedBy column
        param = new SqlParameter("@CreatedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCreatedBy;
        cmd.Parameters.Add(param);
        
        // parameter for Description column
        param = new SqlParameter("@Description", SqlDbType.NVarChar, 2000);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strDescription;
        cmd.Parameters.Add(param);
        
        // parameter for Indent column
        param = new SqlParameter("@Indent", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intIndent;
        cmd.Parameters.Add(param);
        
        // parameter for DateAdded column
        param = new SqlParameter("@DateAdded", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtDateAdded;
        cmd.Parameters.Add(param);
        
        // parameter for CommentType column
        param = new SqlParameter("@CommentType", SqlDbType.TinyInt, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bytCommentType;
        cmd.Parameters.Add(param);
        
        // parameter for Score column
        param = new SqlParameter("@Score", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intScore;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocForumArticleItemsDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for ArticleItemID column
        param = new SqlParameter("@ArticleItemID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intArticleItemID;
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
		public static bool operator ==(bForumArticleItems t1, bForumArticleItems t2) {
			//	compare values
			if(t1.m_intArticleItemID != t2.m_intArticleItemID) {
				return false;	//	because "ArticleItemID" values are Not equal
			}
	
			if(t1.m_intParentID != t2.m_intParentID) {
				return false;	//	because "ParentID" values are Not equal
			}
	
			if(t1.m_intArticleID != t2.m_intArticleID) {
				return false;	//	because "ArticleID" values are Not equal
			}
	
			if(t1.m_strTitle != t2.m_strTitle) {
				return false;	//	because "Title" values are Not equal
			}
	
			if(t1.m_intCreatedBy != t2.m_intCreatedBy) {
				return false;	//	because "CreatedBy" values are Not equal
			}
	
			if(t1.m_strDescription != t2.m_strDescription) {
				return false;	//	because "Description" values are Not equal
			}
	
			if(t1.m_intIndent != t2.m_intIndent) {
				return false;	//	because "Indent" values are Not equal
			}
	
			if(t1.m_dtDateAdded != t2.m_dtDateAdded) {
				return false;	//	because "DateAdded" values are Not equal
			}
	
			if(t1.m_bytCommentType != t2.m_bytCommentType) {
				return false;	//	because "CommentType" values are Not equal
			}
	
			if(t1.m_intScore != t2.m_intScore) {
				return false;	//	because "Score" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(bForumArticleItems t1, bForumArticleItems t2) {
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
				retValue.Append(" ArticleItemID = \"");
			retValue.Append(m_intArticleItemID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    ParentID = \"");
			retValue.Append(m_intParentID);
			retValue.Append("\"\n");
				retValue.Append("    ArticleID = \"");
			retValue.Append(m_intArticleID);
			retValue.Append("\"\n");
				retValue.Append("    Title = \"");
			retValue.Append(m_strTitle);
			retValue.Append("\"\n");
				retValue.Append("    CreatedBy = \"");
			retValue.Append(m_intCreatedBy);
			retValue.Append("\"\n");
				retValue.Append("    Description = \"");
			retValue.Append(m_strDescription);
			retValue.Append("\"\n");
				retValue.Append("    Indent = \"");
			retValue.Append(m_intIndent);
			retValue.Append("\"\n");
				retValue.Append("    DateAdded = \"");
			retValue.Append(m_dtDateAdded);
			retValue.Append("\"\n");
				retValue.Append("    CommentType = \"");
			retValue.Append(m_bytCommentType);
			retValue.Append("\"\n");
				retValue.Append("    Score = \"");
			retValue.Append(m_intScore);
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
			if (!(o is ForumArticleItems)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (ForumArticleItems)o;
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

