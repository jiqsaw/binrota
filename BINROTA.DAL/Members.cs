using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL
{

    public class Members : BINROTA.DAL.Entities.bMembers
    {

        public static DataTable GetMemberIDForLogin(string EMail, string Password)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cMembersLogin", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@EMail", SqlDbType.VarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = EMail;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Password", SqlDbType.VarChar, 50);
            param.Direction = ParameterDirection.Input;
            param.Value = Password;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetMemberDetailsByMemberID(int MemberID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cGetMemberDetailsByMemberID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@MemberID", SqlDbType.Int, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = MemberID;
            cmd.Parameters.Add(param);


            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable MemberSearch(string SearchText)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cMemberSearch", conn);
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

        public static DataTable MemberSearchByBirthDay(int Day, int Month)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cMemberSelectByBirthDay", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@Day", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Day;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Month", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = Month;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetLast5Member()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cMembersSelectLast5", conn);
            SqlDataAdapter da;
            DataTable dt = new DataTable();

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetPassword(string EMail)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cMembersSelectPasswordByEMail", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@EMail", SqlDbType.VarChar, 255);
            param.Direction = ParameterDirection.Input;
            param.Value = EMail;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetMemberByPoints(int PageTypeID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cMembersSelectByPoints", conn);
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

        public static DataTable GetMemberPointsBySubjectID(int SubjectID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("[cMembersSelectPointsBySubjectID]", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SubjectID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
