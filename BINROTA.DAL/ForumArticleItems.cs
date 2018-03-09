using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL {

	public class ForumArticleItems : BINROTA.DAL.Entities.bForumArticleItems
    {
        public DataSet LoadItemsByParams()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cForumArticleItemsSelectByParams", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticleItemID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ArticleID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticleID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Subject", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = m_strSubject;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CommentType", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCommentType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Score", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intScore;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ScoreCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intScoreCount;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intStatus;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@CreatedBy", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intCreatedBy;
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
        public int CustomDelete()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cForumArticleItemDelete", conn);

            SqlParameter param;

            //	Add return value param
            param = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);

            //	Add params
            param = new SqlParameter("@ArticleItemID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = m_intArticleItemID;
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
	}
}
