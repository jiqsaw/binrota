using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL {

	public class Activity : BINROTA.DAL.Entities.bActivity
	{
        public static DataTable GetActivityByDate(int ActivityType, DateTime StartDate, DateTime EndDate, bool isActive)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cActivitySelectByDateRange", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@ActivityType", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ActivityType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@StartDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = StartDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EndDate", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = EndDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = isActive;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetActivityByDate(int ActivityType, int ActivityYear, int ActivityMonth, bool isActive)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cActivitySelectByDate", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@ActivityType", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ActivityType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityYear", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ActivityYear;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ActivityMonth", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ActivityMonth;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = isActive;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetLastActivity(int ActivityType, bool isActive)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cActivitySelectLastActivity", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@ActivityType", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = ActivityType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@isActive", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            param.Value = isActive;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
	}
}
