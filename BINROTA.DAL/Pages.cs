using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;
using System.Collections;

namespace BINROTA.DAL
{

    public class Pages : BINROTA.DAL.Entities.bPages
	{

        public static void InsertPage(int MemberID, int SubjectID, int PageTypeID, int PageCategoryID, string Title, string PageContent, DateTime TravelDate, string PhotoPath, string PhotoCaption, int ParentPageID, DateTime ModifyDate, int ModifiedBy,DataTable dtCategories)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cPagesInsert", conn);
            SqlParameter param;

            conn.Open();

            SqlTransaction Tran = conn.BeginTransaction(IsolationLevel.Serializable);
            cmd.Transaction = Tran;
            try
            {
                // Önce Gezi yazýsý ekleniyo
                param = new SqlParameter("@MemberID", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Input;
                param.Value = MemberID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Input;
                param.Value = SubjectID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Input;
                param.Value = null;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PageTypeID", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Input;
                param.Value = PageTypeID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PageCategoryID", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Input;
                param.Value = PageCategoryID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Title", SqlDbType.NVarChar, 255);
                param.Direction = ParameterDirection.Input;
                param.Value = Title;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PageContent", SqlDbType.NText);
                param.Direction = ParameterDirection.Input;
                param.Value = PageContent;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TravelDate", SqlDbType.DateTime, 8);
                param.Direction = ParameterDirection.Input;
                param.Value = TravelDate;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PhotoPath", SqlDbType.NVarChar, 255);
                param.Direction = ParameterDirection.Input;
                param.Value = PhotoPath;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar, 255);
                param.Direction = ParameterDirection.Input;
                param.Value = PhotoCaption;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ParentPageID", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Input;
                param.Value = ParentPageID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ModifyDate", SqlDbType.DateTime, 8);
                param.Direction = ParameterDirection.Input;
                param.Value = ModifyDate;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Input;
                param.Value = ModifiedBy;
                cmd.Parameters.Add(param);

                SqlParameter paramOut = new SqlParameter("@PageID", SqlDbType.Int, 4);
                paramOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramOut);

                cmd.ExecuteNonQuery();


                //Bir önceki komutla eklenen gezi yazýsýna kategoriler ekleniyor 
                for (int i = 0; i < dtCategories.Rows.Count; i++)
                {
                    cmd = DBHelper.getSprocCmd("cPagesInsert", conn);
                    cmd.Transaction = Tran;

                    param = new SqlParameter("@MemberID", SqlDbType.Int, 4);
                    param.Direction = ParameterDirection.Input;
                    param.Value = MemberID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
                    param.Direction = ParameterDirection.Input;
                    param.Value = SubjectID;
                    cmd.Parameters.Add(param);

                    //buna bakacan unutma
                    param = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
                    param.Direction = ParameterDirection.Input;
                    param.Value = int.Parse(dtCategories.Rows[i]["CategoryID"].ToString());
                    cmd.Parameters.Add(param);

                    //buna bakacan unutma
                    param = new SqlParameter("@PageTypeID", SqlDbType.Int, 4);
                    param.Direction = ParameterDirection.Input;
                    param.Value = 3;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PageCategoryID", SqlDbType.Int, 4);
                    param.Direction = ParameterDirection.Input;
                    param.Value = null;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Title", SqlDbType.NVarChar, 255);
                    param.Direction = ParameterDirection.Input;
                    param.Value = null;
                    cmd.Parameters.Add(param);

                    //buna bakacan unutma
                    param = new SqlParameter("@PageContent", SqlDbType.NVarChar, 4000);
                    param.Direction = ParameterDirection.Input;
                    param.Value = dtCategories.Rows[i]["CategoryContent"].ToString();
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PhotoPath", SqlDbType.NVarChar, 255);
                    param.Direction = ParameterDirection.Input;
                    param.Value = null;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar, 255);
                    param.Direction = ParameterDirection.Input;
                    param.Value = null;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ParentPageID", SqlDbType.Int, 4);
                    param.Direction = ParameterDirection.Input;
                    param.Value = int.Parse(paramOut.Value.ToString());
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ModifyDate", SqlDbType.DateTime, 8);
                    param.Direction = ParameterDirection.Input;
                    param.Value = ModifyDate;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
                    param.Direction = ParameterDirection.Input;
                    param.Value = ModifiedBy;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                }
                

                Tran.Commit();
            }
            catch (Exception)
            {
                Tran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        public static void UpdatePage(int PageID, int SubjectID, int PageCategoryID, string Title, string PageContent, DateTime TravelDate, string PhotoPath, string PhotoCaption, DateTime ModifyDate, int ModifiedBy, Hashtable htCategories , DataTable PageIDCategories)
        {
            //Tran konulacak Unutma
            BINROTA.DAL.Pages objPage = new BINROTA.DAL.Pages();
            objPage.Load(PageID);
            objPage.SubjectID = SubjectID;
            objPage.PageCategoryID = PageCategoryID;
            objPage.Title = Title;
            objPage.PageContent = PageContent;
            objPage.TravelDate = TravelDate;
            objPage.ModifyDate = ModifyDate;
            objPage.ModifiedBy = ModifiedBy;
            objPage.Save();

            for (int i = 0; i < PageIDCategories.Rows.Count; i++)
            {
                BINROTA.DAL.Pages objPageCategory = new BINROTA.DAL.Pages();
                objPageCategory.Load(int.Parse(PageIDCategories.Rows[i]["PageID"].ToString()));
                objPageCategory.SubjectID = SubjectID;
                objPageCategory.PageContent = htCategories[PageIDCategories.Rows[i]["CategoryID"].ToString()].ToString();
                objPageCategory.ModifyDate = ModifyDate;
                objPageCategory.ModifiedBy = ModifiedBy;
                objPageCategory.Save();
            }


        }

        public static DataTable GetPageByParentPageID(int ParentPageID)
        {

            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cPagesByParentPageIDSelect", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@ParentPageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ParentPageID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetPageAndMemberDetailBySubjectdIDAndPageTypeID(int SubjectID, int PageTypeID, int PageCategoryID)
        {

            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cGetPageAndMemberDetailBySubjectdIDAndPageTypeID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageTypeID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PageTypeID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageCategoryID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PageCategoryID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetPageCountByPageCategoryID(int PageTypeID)
        {

            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cPagesByPageCategoryIDSelectCount", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@PageTypeID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PageTypeID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetPageCountBySubjectID(int PageTypeID)
        {

            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cPagesBySubjectIDSelectCount", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@PageTypeID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PageTypeID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetPageCountByPageTypeIDAndSubjectID(int PageTypeID, int SubjectID)
        {

            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cPagesSelectCountBySubjectIDAndPageTypeID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@PageTypeID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PageTypeID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetLast5PagesRecorded(int PageTypeID)
        {

            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cPagesLast5PagesRecorded", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@PageTypeID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PageTypeID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetLast5PagesRecorded(int PageTypeID, int SubjectID)
        {

            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cPagesLast5PagesRecorded", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@PageTypeID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PageTypeID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable PageSearch(string SearchText, int PageCategoryID, int SubjectID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cPageSearchBySubjectIDAndPageCategoryID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@SearchText", SqlDbType.NVarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = SearchText;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageCategoryID", SqlDbType.Int, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = PageCategoryID;
            cmd.Parameters.Add(param); 

            param = new SqlParameter("@SubjectID", SqlDbType.Int, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectID;
            cmd.Parameters.Add(param); 

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable PageSearch(string SearchText, int PageCategoryID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cPageSearchByCategoryID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@SearchText", SqlDbType.NVarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = SearchText;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageCategoryID", SqlDbType.Int, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = PageCategoryID;
            cmd.Parameters.Add(param); 

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable PageSearchForSubject(string SearchText)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cPageSearchByOnlySearchText", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@SearchText", SqlDbType.NVarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = SearchText;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetUserPages(int MemberID, int PageTypeID, bool isDeleted)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cGetUserPages", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@MemberID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = MemberID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PageTypeID", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = PageTypeID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isDeleted", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = isDeleted;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
	}
}
