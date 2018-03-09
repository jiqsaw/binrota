using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL {

	public class SurveyChoice : BINROTA.DAL.Entities.bSurveyChoice
	{

        // Soruya ait seçenekleri sil 
        public static int DeleteSurveyChoices(int SurveyQuestionID)
        {

            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("cDeleteSurveyChoices", conn);

            SqlParameter param;

            param = new SqlParameter("@SurveyQuestionID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = SurveyQuestionID;
            cmd.Parameters.Add(param);

            conn.Open();

            return cmd.ExecuteNonQuery();
        }


	}
}
