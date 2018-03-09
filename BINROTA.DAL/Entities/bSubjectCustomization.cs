using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities {

	public class bSubjectCustomization {
		//transactions
		//	enum types
		protected enum Action { Insert, Update, Delete };
			//	Sub-types
		public struct PK {
				public SqlInt32 SubjectCustomizationID;
		}	
		
		
		protected Action m_aAction;
		protected bool m_bIsDirty;

		#region Table Members
		protected SqlInt32 m_intSubjectCustomizationID;
		protected SqlInt32 m_intSubjectTypeID;
		protected SqlInt32 m_intSubjectID;
		protected SqlString m_strLocation;
		protected SqlString m_strCapital;
		protected SqlString m_strArea;
		protected SqlString m_strNeighbourhood;
		protected SqlString m_strPopulation;
		protected SqlString m_strCurrency;
		protected SqlString m_strAreaCode;
		protected SqlString m_strTimeZone;
		protected SqlString m_strLanguage;
		protected SqlString m_strReligion;
		#endregion
		
		#region Properties
	
		public PK PrimaryKey {
			get {
				PK pk;
				pk.SubjectCustomizationID = m_intSubjectCustomizationID;
				return pk;
			}
		}
			
		
		public int SubjectCustomizationID {
			get {
				return (int)m_intSubjectCustomizationID;
			}
			set {
				m_intSubjectCustomizationID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int SubjectTypeID {
			get {
				return (int)m_intSubjectTypeID;
			}
			set {
				m_intSubjectTypeID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int SubjectID {
			get {
				return (int)m_intSubjectID;
			}
			set {
				m_intSubjectID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Location {
			get {
				return (string)m_strLocation;
			}
			set {
				m_strLocation = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Capital {
			get {
				return (string)m_strCapital;
			}
			set {
				m_strCapital = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Area {
			get {
				return (string)m_strArea;
			}
			set {
				m_strArea = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Neighbourhood {
			get {
				return (string)m_strNeighbourhood;
			}
			set {
				m_strNeighbourhood = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Population {
			get {
				return (string)m_strPopulation;
			}
			set {
				m_strPopulation = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Currency {
			get {
				return (string)m_strCurrency;
			}
			set {
				m_strCurrency = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string AreaCode {
			get {
				return (string)m_strAreaCode;
			}
			set {
				m_strAreaCode = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string TimeZone {
			get {
				return (string)m_strTimeZone;
			}
			set {
				m_strTimeZone = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Language {
			get {
				return (string)m_strLanguage;
			}
			set {
				m_strLanguage = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Religion {
			get {
				return (string)m_strReligion;
			}
			set {
				m_strReligion = value;
				m_bIsDirty = true;
			}
		}
		
	#endregion
	
		#region Constructers

		public bSubjectCustomization() {
			Init();	//	init Object
		}
		#endregion

		#region Static Functions

		/// <summary>
		/// Gets all SubjectCustomization from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the SubjectCustomization</returns>
		
		public static SqlDataReader LoadAllReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationSelectAll", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet LoadAll() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all SubjectCustomization from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable LoadAllHashTable() {
			SqlDataReader dr = LoadAllReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates SubjectCustomization for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the SubjectCustomization records</param>
		/// <returns>The Hashtable containing SubjectCustomization objects And their ID As key.</returns>
		protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            SubjectCustomization mySubjectCustomization = new SubjectCustomization();
            
            mySubjectCustomization.m_intSubjectCustomizationID = dr.GetSqlInt32(0);
            mySubjectCustomization.m_intSubjectTypeID = dr.GetSqlInt32(1);
            mySubjectCustomization.m_intSubjectID = dr.GetSqlInt32(2);
            mySubjectCustomization.m_strLocation = dr.GetSqlString(3);
            mySubjectCustomization.m_strCapital = dr.GetSqlString(4);
            mySubjectCustomization.m_strArea = dr.GetSqlString(5);
            mySubjectCustomization.m_strNeighbourhood = dr.GetSqlString(6);
            mySubjectCustomization.m_strPopulation = dr.GetSqlString(7);
            mySubjectCustomization.m_strCurrency = dr.GetSqlString(8);
            mySubjectCustomization.m_strAreaCode = dr.GetSqlString(9);
            mySubjectCustomization.m_strTimeZone = dr.GetSqlString(10);
            mySubjectCustomization.m_strLanguage = dr.GetSqlString(11);
            mySubjectCustomization.m_strReligion = dr.GetSqlString(12);
            
            result.Add(mySubjectCustomization.SubjectCustomizationID, mySubjectCustomization);
		}
	
			return result;
		}
		
		public static DataSet LoadByParams(object intSubjectCustomizationID , object intSubjectTypeID , object intSubjectID , object strLocation , object strCapital , object strArea , object strNeighbourhood , object strPopulation , object strCurrency , object strAreaCode , object strTimeZone , object strLanguage , object strReligion) 
		{
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationSelectByParams", conn);
			SqlParameter param;
			
			
			
		        param = new SqlParameter("@SubjectCustomizationID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSubjectCustomizationID==null ? intSubjectCustomizationID : (int)intSubjectCustomizationID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSubjectTypeID==null ? intSubjectTypeID : (int)intSubjectTypeID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSubjectID==null ? intSubjectID : (int)intSubjectID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Location", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strLocation==null ? strLocation : (string)strLocation);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Capital", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strCapital==null ? strCapital : (string)strCapital);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Area", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strArea==null ? strArea : (string)strArea);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Neighbourhood", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strNeighbourhood==null ? strNeighbourhood : (string)strNeighbourhood);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Population", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPopulation==null ? strPopulation : (string)strPopulation);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Currency", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strCurrency==null ? strCurrency : (string)strCurrency);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@AreaCode", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strAreaCode==null ? strAreaCode : (string)strAreaCode);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@TimeZone", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strTimeZone==null ? strTimeZone : (string)strTimeZone);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Language", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strLanguage==null ? strLanguage : (string)strLanguage);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Religion", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strReligion==null ? strReligion : (string)strReligion);
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static DataSet LoadByParams(object intSubjectCustomizationID , object intSubjectTypeID , object intSubjectID , object strLocation , object strCapital , object strArea , object strNeighbourhood , object strPopulation , object strCurrency , object strAreaCode , object strTimeZone , object strLanguage , object strReligion,SqlConnection sqlConn,SqlTransaction sqlTran) 
		{
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationSelectByParams", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
			
		        param = new SqlParameter("@SubjectCustomizationID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSubjectCustomizationID==null ? intSubjectCustomizationID : (int)intSubjectCustomizationID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSubjectTypeID==null ? intSubjectTypeID : (int)intSubjectTypeID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSubjectID==null ? intSubjectID : (int)intSubjectID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Location", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strLocation==null ? strLocation : (string)strLocation);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Capital", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strCapital==null ? strCapital : (string)strCapital);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Area", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strArea==null ? strArea : (string)strArea);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Neighbourhood", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strNeighbourhood==null ? strNeighbourhood : (string)strNeighbourhood);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Population", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPopulation==null ? strPopulation : (string)strPopulation);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Currency", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strCurrency==null ? strCurrency : (string)strCurrency);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@AreaCode", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strAreaCode==null ? strAreaCode : (string)strAreaCode);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@TimeZone", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strTimeZone==null ? strTimeZone : (string)strTimeZone);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Language", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strLanguage==null ? strLanguage : (string)strLanguage);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Religion", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strReligion==null ? strReligion : (string)strReligion);
        cmd.Parameters.Add(param);
        
		//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static int Insert(bSubjectCustomization objSubjectCustomization) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SubjectCustomizationID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.SubjectCustomizationID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.SubjectTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Location", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Location;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Capital", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Capital;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Area", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Area;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Neighbourhood", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Neighbourhood;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Population", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Population;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Currency", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Currency;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@AreaCode", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.AreaCode;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@TimeZone", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.TimeZone;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Language", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Language;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Religion", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Religion;
        cmd.Parameters.Add(param);
        
		
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			//	close connection
			conn.Close();
		
			//	set dirty flag To false
			if (retValue != 0)
				objSubjectCustomization.SubjectCustomizationID = retValue;
			return retValue;
		}
		
		public static int Insert(bSubjectCustomization objSubjectCustomization,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationInsert", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SubjectCustomizationID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.SubjectCustomizationID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.SubjectTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Location", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Location;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Capital", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Capital;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Area", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Area;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Neighbourhood", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Neighbourhood;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Population", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Population;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Currency", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Currency;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@AreaCode", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.AreaCode;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@TimeZone", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.TimeZone;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Language", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Language;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Religion", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Religion;
        cmd.Parameters.Add(param);
        
		
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			//	close connection
			conn.Close();
		
			//	set dirty flag To false
			if (retValue != 0)
				objSubjectCustomization.SubjectCustomizationID = retValue;
			return retValue;
		}

		public static int Update(bSubjectCustomization objSubjectCustomization) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@SubjectCustomizationID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.SubjectCustomizationID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.SubjectTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Location", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Location;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Capital", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Capital;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Area", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Area;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Neighbourhood", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Neighbourhood;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Population", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Population;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Currency", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Currency;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@AreaCode", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.AreaCode;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@TimeZone", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.TimeZone;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Language", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Language;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Religion", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Religion;
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			
			//	close connection
			conn.Close();
		
		
			return retValue;
		}
		
		public static int Update(bSubjectCustomization objSubjectCustomization,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationUpdate", conn);
			cmd.Transaction=sqlTran;
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@SubjectCustomizationID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.SubjectCustomizationID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.SubjectTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Location", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Location;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Capital", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Capital;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Area", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Area;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Neighbourhood", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Neighbourhood;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Population", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Population;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Currency", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Currency;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@AreaCode", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.AreaCode;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@TimeZone", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.TimeZone;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Language", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Language;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Religion", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.Religion;
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			
			//	close connection
			conn.Close();
		
			return retValue;
		}
		
		public static int Delete(bSubjectCustomization objSubjectCustomization) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SubjectCustomizationID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.SubjectCustomizationID;
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			//	close connection
			conn.Close();
			
			return retValue;
		}
		
		public static int Delete(bSubjectCustomization objSubjectCustomization,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationUpdate", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SubjectCustomizationID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objSubjectCustomization.SubjectCustomizationID;
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			//	close connection
			conn.Close();
			
			return retValue;
		}
		
		#endregion

		#region Public Functions

			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.SubjectCustomizationID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intSubjectCustomizationID"> SubjectCustomizationID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intSubjectCustomizationID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationSelect", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for SubjectCustomizationID column
        param = new SqlParameter("@SubjectCustomizationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intSubjectCustomizationID;
        cmd.Parameters.Add(param);
        
		//	open connection
				conn.Open();
				//	Execute command And get reader
				SqlDataReader reader = cmd.ExecuteReader();
		
				bool found = false;	//	false solution
		
				//	check if  anything was found
				if(reader.Read()) {
					found = true;	//	corresponding row found
					m_aAction = Action.Update;	//	future action
		
					//	set member values
		            m_intSubjectCustomizationID = reader.GetSqlInt32(0);
            m_intSubjectTypeID = reader.GetSqlInt32(1);
            m_intSubjectID = reader.GetSqlInt32(2);
            m_strLocation = reader.GetSqlString(3);
            m_strCapital = reader.GetSqlString(4);
            m_strArea = reader.GetSqlString(5);
            m_strNeighbourhood = reader.GetSqlString(6);
            m_strPopulation = reader.GetSqlString(7);
            m_strCurrency = reader.GetSqlString(8);
            m_strAreaCode = reader.GetSqlString(9);
            m_strTimeZone = reader.GetSqlString(10);
            m_strLanguage = reader.GetSqlString(11);
            m_strReligion = reader.GetSqlString(12);
		
			} else {
			//	set key values
		            m_intSubjectCustomizationID = intSubjectCustomizationID;
	}
		
			//	close connection
			conn.Close();
			//	set dirty flag To false
			m_bIsDirty = false;
			//	return true if  a row found, otherwise false
			return found;
			
		}
		
		/// <summary>
		/// Updates the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		public int Save() {
			int retValue;
			switch(m_aAction) {
				case Action.Insert:
					//	insert row
					retValue = ins();
					//	future action To be update
					m_aAction = Action.Update;
					//	return retValue from insert
					return retValue;
				case Action.Update:
					//	check if  Objectstringdirty
					if (m_bIsDirty)	{
						//	update row And return retValue
						return upd();
					} else {
						//	return 0 (all ok)
						return 0;
					}
				case Action.Delete:
					//	delete row
					retValue = del();
					//	future action To be insert
					m_aAction = Action.Insert;
					//	return retValue from delete
					return retValue;
			}
	
			throw new System.Exception("Unknown action.");
		}
	
		/// <summary>
		/// Deletes the Object from the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		public int Delete() {
			m_aAction = Action.Delete;	//	actionstringdelete
			return Save();
		}
	
		public DataSet LoadByParams() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationSelectByParams", conn);

			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@SubjectCustomizationID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intSubjectCustomizationID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intSubjectTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intSubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Location", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strLocation;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Capital", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strCapital;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Area", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strArea;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Neighbourhood", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strNeighbourhood;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Population", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strPopulation;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Currency", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strCurrency;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@AreaCode", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strAreaCode;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@TimeZone", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strTimeZone;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Language", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strLanguage;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Religion", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strReligion;
        cmd.Parameters.Add(param);
        
	
			//	open connection
			conn.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		#endregion 

		#region Private Functions

		/// <summary>
		/// The init Function.
		/// </summary>
		protected void Init() {
			m_aAction = Action.Insert;	//	initial action
			m_bIsDirty = false;	//	Objectstring"clean" upon init
		}
		
		protected int ins() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for SubjectCustomizationID column
        param = new SqlParameter("@SubjectCustomizationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectCustomizationID;
        cmd.Parameters.Add(param);
        
        // parameter for SubjectTypeID column
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for SubjectID column
        param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectID;
        cmd.Parameters.Add(param);
        
        // parameter for Location column
        param = new SqlParameter("@Location", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strLocation;
        cmd.Parameters.Add(param);
        
        // parameter for Capital column
        param = new SqlParameter("@Capital", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCapital;
        cmd.Parameters.Add(param);
        
        // parameter for Area column
        param = new SqlParameter("@Area", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strArea;
        cmd.Parameters.Add(param);
        
        // parameter for Neighbourhood column
        param = new SqlParameter("@Neighbourhood", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strNeighbourhood;
        cmd.Parameters.Add(param);
        
        // parameter for Population column
        param = new SqlParameter("@Population", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPopulation;
        cmd.Parameters.Add(param);
        
        // parameter for Currency column
        param = new SqlParameter("@Currency", SqlDbType.VarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCurrency;
        cmd.Parameters.Add(param);
        
        // parameter for AreaCode column
        param = new SqlParameter("@AreaCode", SqlDbType.NVarChar, 10);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strAreaCode;
        cmd.Parameters.Add(param);
        
        // parameter for TimeZone column
        param = new SqlParameter("@TimeZone", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strTimeZone;
        cmd.Parameters.Add(param);
        
        // parameter for Language column
        param = new SqlParameter("@Language", SqlDbType.NVarChar, 100);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strLanguage;
        cmd.Parameters.Add(param);
        
        // parameter for Religion column
        param = new SqlParameter("@Religion", SqlDbType.NVarChar, 200);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strReligion;
        cmd.Parameters.Add(param);
        
		
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			//	close connection
			conn.Close();
		
			//	set dirty flag To false
			m_bIsDirty = false;
			if (retValue != 0)
				SubjectCustomizationID = retValue;
			return retValue;
		}
	
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		protected int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for SubjectCustomizationID column
        param = new SqlParameter("@SubjectCustomizationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectCustomizationID;
        cmd.Parameters.Add(param);
        
        // parameter for SubjectTypeID column
        param = new SqlParameter("@SubjectTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for SubjectID column
        param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectID;
        cmd.Parameters.Add(param);
        
        // parameter for Location column
        param = new SqlParameter("@Location", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strLocation;
        cmd.Parameters.Add(param);
        
        // parameter for Capital column
        param = new SqlParameter("@Capital", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCapital;
        cmd.Parameters.Add(param);
        
        // parameter for Area column
        param = new SqlParameter("@Area", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strArea;
        cmd.Parameters.Add(param);
        
        // parameter for Neighbourhood column
        param = new SqlParameter("@Neighbourhood", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strNeighbourhood;
        cmd.Parameters.Add(param);
        
        // parameter for Population column
        param = new SqlParameter("@Population", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPopulation;
        cmd.Parameters.Add(param);
        
        // parameter for Currency column
        param = new SqlParameter("@Currency", SqlDbType.VarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strCurrency;
        cmd.Parameters.Add(param);
        
        // parameter for AreaCode column
        param = new SqlParameter("@AreaCode", SqlDbType.NVarChar, 10);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strAreaCode;
        cmd.Parameters.Add(param);
        
        // parameter for TimeZone column
        param = new SqlParameter("@TimeZone", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strTimeZone;
        cmd.Parameters.Add(param);
        
        // parameter for Language column
        param = new SqlParameter("@Language", SqlDbType.NVarChar, 100);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strLanguage;
        cmd.Parameters.Add(param);
        
        // parameter for Religion column
        param = new SqlParameter("@Religion", SqlDbType.NVarChar, 200);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strReligion;
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			
			//	close connection
			conn.Close();
		
			//	set dirty flag To false
			m_bIsDirty = false;
		
			return retValue;
		}
	
		/// <summary>
		/// Deletes the Object from the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		protected int del() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocSubjectCustomizationDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for SubjectCustomizationID column
        param = new SqlParameter("@SubjectCustomizationID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectCustomizationID;
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			//	close connection
			conn.Close();
			
			//	set dirty flag To false
			m_bIsDirty = false;
		
			return retValue;
		}
		#endregion

		#region Operator Functions

	
		//	operators
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator ==(bSubjectCustomization t1, bSubjectCustomization t2) {
			//	compare values
			if(t1.m_intSubjectCustomizationID != t2.m_intSubjectCustomizationID) {
				return false;	//	because "SubjectCustomizationID" values are Not equal
			}
	
			if(t1.m_intSubjectTypeID != t2.m_intSubjectTypeID) {
				return false;	//	because "SubjectTypeID" values are Not equal
			}
	
			if(t1.m_intSubjectID != t2.m_intSubjectID) {
				return false;	//	because "SubjectID" values are Not equal
			}
	
			if(t1.m_strLocation != t2.m_strLocation) {
				return false;	//	because "Location" values are Not equal
			}
	
			if(t1.m_strCapital != t2.m_strCapital) {
				return false;	//	because "Capital" values are Not equal
			}
	
			if(t1.m_strArea != t2.m_strArea) {
				return false;	//	because "Area" values are Not equal
			}
	
			if(t1.m_strNeighbourhood != t2.m_strNeighbourhood) {
				return false;	//	because "Neighbourhood" values are Not equal
			}
	
			if(t1.m_strPopulation != t2.m_strPopulation) {
				return false;	//	because "Population" values are Not equal
			}
	
			if(t1.m_strCurrency != t2.m_strCurrency) {
				return false;	//	because "Currency" values are Not equal
			}
	
			if(t1.m_strAreaCode != t2.m_strAreaCode) {
				return false;	//	because "AreaCode" values are Not equal
			}
	
			if(t1.m_strTimeZone != t2.m_strTimeZone) {
				return false;	//	because "TimeZone" values are Not equal
			}
	
			if(t1.m_strLanguage != t2.m_strLanguage) {
				return false;	//	because "Language" values are Not equal
			}
	
			if(t1.m_strReligion != t2.m_strReligion) {
				return false;	//	because "Religion" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(bSubjectCustomization t1, bSubjectCustomization t2) {
			return !(t1 == t2);
		}
		#endregion
	
		#region Override Functions

		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" SubjectCustomizationID = \"");
			retValue.Append(m_intSubjectCustomizationID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    SubjectTypeID = \"");
			retValue.Append(m_intSubjectTypeID);
			retValue.Append("\"\n");
				retValue.Append("    SubjectID = \"");
			retValue.Append(m_intSubjectID);
			retValue.Append("\"\n");
				retValue.Append("    Location = \"");
			retValue.Append(m_strLocation);
			retValue.Append("\"\n");
				retValue.Append("    Capital = \"");
			retValue.Append(m_strCapital);
			retValue.Append("\"\n");
				retValue.Append("    Area = \"");
			retValue.Append(m_strArea);
			retValue.Append("\"\n");
				retValue.Append("    Neighbourhood = \"");
			retValue.Append(m_strNeighbourhood);
			retValue.Append("\"\n");
				retValue.Append("    Population = \"");
			retValue.Append(m_strPopulation);
			retValue.Append("\"\n");
				retValue.Append("    Currency = \"");
			retValue.Append(m_strCurrency);
			retValue.Append("\"\n");
				retValue.Append("    AreaCode = \"");
			retValue.Append(m_strAreaCode);
			retValue.Append("\"\n");
				retValue.Append("    TimeZone = \"");
			retValue.Append(m_strTimeZone);
			retValue.Append("\"\n");
				retValue.Append("    Language = \"");
			retValue.Append(m_strLanguage);
			retValue.Append("\"\n");
				retValue.Append("    Religion = \"");
			retValue.Append(m_strReligion);
			retValue.Append("\"\n");
				return retValue.ToString();
		}
	
		/// <summary>
		/// Overrides the Equals Function.
		/// </summary>
		/// <param name="o">The Object To compare With</param>
		/// <returns>Bool if the two objects are identical.</returns>
		public override bool Equals(System.Object o) {
			//	check the type of o
			if (!(o is SubjectCustomization)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (SubjectCustomization)o;
		}
	
		/// <summary>
		/// Overrides the GetHashCode Function.
		/// </summary>
		/// <returns>Bool if the two objects are identical.</returns>
		public override int GetHashCode() {
			return this.ToString().GetHashCode();
		}
		#endregion
	
	}
}

