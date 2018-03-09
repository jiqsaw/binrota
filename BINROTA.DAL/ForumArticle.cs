using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL {

	public class ForumArticle : BINROTA.DAL.Entities.bForumArticle
	{
        public static void SyncMainItem(int ArticleID,string Subject,string Message)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cForumSyncMItem", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ArticleID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = ArticleID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Message", SqlDbType.NText);
            param.Direction = ParameterDirection.Input;
            param.Value = Message;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Subject", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = Subject;
            cmd.Parameters.Add(param);

            //	open connection
            conn.Open();
            //	Execute command
            cmd.ExecuteNonQuery();
            //	get return value
            int retValue = 0;
            try
            {
                //	get return value of the sproc
                retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
            }
            catch (System.Exception)
            {	//	catch all possible exceptions
                retValue = 0;	//	set retValue To 0 (all ok)
            }
            //	close connection
            conn.Close();

        }
        public static int CategoryChange(int OldCategoryID, int CategoryID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cForumCategoryChange", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@CategoryID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = CategoryID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OldCategoryID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = OldCategoryID;
            cmd.Parameters.Add(param);

            //	open connection
            conn.Open();
            //	Execute command
            cmd.ExecuteNonQuery();
            //	get return value
            int retValue = 0;
            try
            {
                //	get return value of the sproc
                retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
            }
            catch (System.Exception)
            {	//	catch all possible exceptions
                retValue = 0;	//	set retValue To 0 (all ok)
            }
            //	close connection
            conn.Close();

            return retValue;
        }
        public static int ArrangeArticle(int ArticleID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cForumArrangeArticle", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ArticleID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = ArticleID;
            cmd.Parameters.Add(param);

            //	open connection
            conn.Open();
            //	Execute command
            cmd.ExecuteNonQuery();
            //	get return value
            int retValue = 0;
            try
            {
                //	get return value of the sproc
                retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
            }
            catch (System.Exception)
            {	//	catch all possible exceptions
                retValue = 0;	//	set retValue To 0 (all ok)
            }
            //	close connection
            conn.Close();

            return retValue;
        }
        public static DataTable GetArticlesTitles(int ArticleID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cArticlesTitlesSelect", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ArticleID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = ArticleID;
            cmd.Parameters.Add(param);

            //	open connection
            conn.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds.Tables[0];            
        }   
        public int CustomDelete()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cForumArticlesDelete", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ArticleID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticleID;
            cmd.Parameters.Add(param);

            //	open connection
            conn.Open();
            //	Execute command
            cmd.ExecuteNonQuery();
            //	get return value
            int retValue = 0;
            try
            {
                //	get return value of the sproc
                retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
            }
            catch (System.Exception)
            {	//	catch all possible exceptions
                retValue = 0;	//	set retValue To 0 (all ok)
            }
            //	close connection
            conn.Close();

            //	set dirty flag To false
            m_bIsDirty = false;

            return retValue;
        }
        public DataSet LoadArticlesByParams()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cForumArticlesSelect", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ArticleID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticleID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticleSubject", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strArticleSubject;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticleStatus", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticleStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCategoryID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LastPost", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strLastPost;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Replies", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intReplies;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Order", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intOrder;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCreatedBy;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Before_EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindBefore_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@After_EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindAfter_dtEndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Before_CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindBefore_dtCreateDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@After_CreateDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = m_FindAfter_dtCreateDate;
            cmd.Parameters.Add(param);


            //	open connection
            conn.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
	
	}
}
