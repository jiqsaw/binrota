using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CARETTA.DBI
{

    public static class DBHelper
    {
         public static SqlParameter[] GenerateSPParameters(string ConnectionString, string SPName, object[] ParameterValues)
        {
            SqlParameter[] SPParameters = SqlHelperParameterCache.GetSpParameterSet(ConnectionString, SPName, true);
            int counter = 1;
            for(counter = 1; counter < SPParameters.Length; counter++)
            {
                SPParameters[counter].Value = ParameterValues[counter - 1];
            }
            return SPParameters;
        }

        // Dataset d�nd�ren SELECT SP' lerini �al��t�rmak i�in
        public static DataSet ExecuteSPReturnsDS(string ConnectionString, string SPName, params object[] ParameterValues)
        {
            return SqlHelper.ExecuteDataset(ConnectionString, System.Data.CommandType.StoredProcedure, SPName, GenerateSPParameters(ConnectionString,SPName, ParameterValues));
        }

        // Parametre d�nd�rmeyen UPDATE, DELETE SP' lerini �al��t�rmak i�in
        public static void ExecuteSP(string ConnectionString, string SPName, params object[] ParameterValues)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, System.Data.CommandType.StoredProcedure, SPName, GenerateSPParameters(ConnectionString,SPName, ParameterValues));
        }

        public static void ExecuteSP(SqlConnection conn, SqlTransaction tran, string SPName, params object[] ParameterValues)
        {
            SqlHelper.ExecuteNonQuery(conn, tran, System.Data.CommandType.StoredProcedure, SPName, GenerateSPParameters(conn.ConnectionString, SPName, ParameterValues));
        }

        // Tek bir parametre d�nd�ren INSERT SP' lerini �al��t�rmak i�in
        public static Int64 ExecuteSPReturnsID(string ConnectionString, string SPName, params object[] ParameterValues)
        {
            SqlParameter[] Parameters = GenerateSPParameters(ConnectionString, SPName, ParameterValues);
            SqlHelper.ExecuteNonQuery(ConnectionString, System.Data.CommandType.StoredProcedure, SPName, Parameters);
            return Convert.ToInt64(Parameters[0].Value);
        }

        public static Int64 ExecuteSPReturnsID(SqlConnection conn, SqlTransaction tran, string SPName, params object[] ParameterValues)
        {
            SqlParameter[] Parameters = GenerateSPParameters(conn.ConnectionString, SPName, ParameterValues);
            SqlHelper.ExecuteNonQuery(conn, tran, System.Data.CommandType.StoredProcedure, SPName, Parameters);
            return Convert.ToInt64(Parameters[0].Value);
        }

        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }

        /// <summary>
        /// Yeni bir SqlConnection instance'� d�nd�r�r.
        /// </summary>
        /// <returns>SqlConnection nesnesi.</returns>
        public static SqlConnection getConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        
        /// <summary>
        /// �stenen stored procedure'un ismi ile, ilgili stored procedure'un, yeni bir instance'�n� yarat�p d�nd�r�r.
        /// </summary>
        /// <param name="strSprocName">Nesnesi istenen stored procedure'un ismi.</param>
        /// <param name="conn">Veritaban� ba�lant�s� nesnesi.</param>
        /// <returns>Yeni yarat�lan SQLCommand nesnesi.</returns>
        public static SqlCommand getSprocCmd(string strSprocName, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(strSprocName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
    }
}

