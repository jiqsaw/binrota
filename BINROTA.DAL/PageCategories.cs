using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL
{

    public class PageCategories : BINROTA.DAL.Entities.bPageCategories
    {
        public static DataTable GetPageCategoriesAll()
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cGetCategoriesAll", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }

}
