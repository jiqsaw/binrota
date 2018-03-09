using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL {

	public class SurveyQuestion : BINROTA.DAL.Entities.bSurveyQuestion
	{
        public static DataTable GetMainSurveyQuestion()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cGetMainSurveyQuestion", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetSurveyDetails(int SurveyID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cproc_GetSurveyDetails", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@SurveyID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SurveyID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

	}
}
