using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL {

	public class SubjectCustomization : BINROTA.DAL.Entities.bSubjectCustomization
	{

        public static DataTable GetSubjectCustomization(int SubjectID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cSubjectCountrySelect", conn);
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
