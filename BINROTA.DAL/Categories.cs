using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL {

    public class Categories : BINROTA.DAL.Entities.bCategories
	{
        public static DataTable GetCategories()
        {
            return BINROTA.DAL.Categories.LoadAll().Tables[0];
        }


        public static DataTable GetCategoriesContentByPageID(int PageID)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cGetCategoriesContentByPageID", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@PageID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = PageID;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

	}
}
