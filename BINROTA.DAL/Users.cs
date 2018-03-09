using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL
{

    public class Users : BINROTA.DAL.Entities.bUsers
	{
        public static DataTable GetPassword(string EMail)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cUsersSelectPasswordByEMail", conn);
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

        public static DataTable GetUserIDForLogin(string EMail, string Password)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cUsersLogin", conn);
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

        
        //public static void UsersInsert(string FirstName, string LastName, string EMail, string Password, bool Gender, DateTime BirthDate, string ActivationKey, int ModifiedBy)
        //{
        //    SqlConnection conn = DBHelper.getConnection();
        //    SqlCommand cmd = DBHelper.getSprocCmd("sprocUsersInsert", conn);
        //    SqlParameter param;

        //    param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 255);
        //    param.Direction = ParameterDirection.Input;
        //    param.Value = FirstName;
        //    cmd.Parameters.Add(param);

        //    param = new SqlParameter("@LastName", SqlDbType.NVarChar, 255);
        //    param.Direction = ParameterDirection.Input;
        //    param.Value = LastName;
        //    cmd.Parameters.Add(param);

        //    param = new SqlParameter("@EMail", SqlDbType.VarChar, 255);
        //    param.Direction = ParameterDirection.Input;
        //    param.Value = EMail;
        //    cmd.Parameters.Add(param);

        //    param = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        //    param.Direction = ParameterDirection.Input;
        //    param.Value = Password;
        //    cmd.Parameters.Add(param);

        //    param = new SqlParameter("@Gender", SqlDbType.Bit, 1);
        //    param.Direction = ParameterDirection.Input;
        //    param.Value = Gender;
        //    cmd.Parameters.Add(param);

        //    param = new SqlParameter("@BirthDate", SqlDbType.DateTime, 8);
        //    param.Direction = ParameterDirection.Input;
        //    param.Value = BirthDate;
        //    cmd.Parameters.Add(param);

        //    param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar, 50);
        //    param.Direction = ParameterDirection.Input;
        //    param.Value = ActivationKey;
        //    cmd.Parameters.Add(param);

        //    param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
        //    param.Direction = ParameterDirection.Input;
        //    param.Value = ModifiedBy;
        //    cmd.Parameters.Add(param);


        //    conn.Open();

        //    cmd.ExecuteNonQuery();

        //}

	}
}
