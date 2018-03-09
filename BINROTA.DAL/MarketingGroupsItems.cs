using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL {

	public class MarketingGroupsItems : BINROTA.DAL.Entities.bMarketingGroupsItems
	{

        public static DataTable GetSubjectsWantsToBeShowed(int MarketingGroupID, DateTime ValidityDate)
        {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cSubjectsWantsToBeShowed", conn);
            SqlDataAdapter da;
            SqlParameter param;
            DataTable dt = new DataTable();

            param = new SqlParameter("@MarketingGroupID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = MarketingGroupID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ValidityDate", SqlDbType.DateTime, 8);
            param.Direction = ParameterDirection.Input;
            param.Value = ValidityDate;
            cmd.Parameters.Add(param);

            conn.Open();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

	}
}
