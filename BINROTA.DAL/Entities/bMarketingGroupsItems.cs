using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities {

	public class bMarketingGroupsItems {
		//transactions
		//	enum types
		protected enum Action { Insert, Update, Delete };
			//	Sub-types
		public struct PK {
				public SqlInt32 MarketingGroupsItemsID;
		}	
		
		
		protected Action m_aAction;
		protected bool m_bIsDirty;

		#region Table Members
		protected SqlInt32 m_intMarketingGroupsItemsID;
		protected SqlInt32 m_intMarketingGroupID;
		protected SqlInt32 m_intSubjectID;
		protected SqlDateTime m_dtValidityDate;
		#endregion
		
		#region Properties
	
		public PK PrimaryKey {
			get {
				PK pk;
				pk.MarketingGroupsItemsID = m_intMarketingGroupsItemsID;
				return pk;
			}
		}
			
		
		public int MarketingGroupsItemsID {
			get {
				return (int)m_intMarketingGroupsItemsID;
			}
			set {
				m_intMarketingGroupsItemsID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int MarketingGroupID {
			get {
				return (int)m_intMarketingGroupID;
			}
			set {
				m_intMarketingGroupID = value;
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
		
			
		
		public DateTime ValidityDate {
			get {
				return (DateTime)m_dtValidityDate;
			}
			set {
				m_dtValidityDate = value;
				m_bIsDirty = true;
			}
		}
		
	#endregion
	
		#region Constructers

		public bMarketingGroupsItems() {
			Init();	//	init Object
		}
		#endregion

		#region Static Functions

		/// <summary>
		/// Gets all MarketingGroupsItems from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the MarketingGroupsItems</returns>
		
		public static SqlDataReader LoadAllReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMarketingGroupsItemsSelectAll", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet LoadAll() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMarketingGroupsItemsSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all MarketingGroupsItems from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable LoadAllHashTable() {
			SqlDataReader dr = LoadAllReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates MarketingGroupsItems for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the MarketingGroupsItems records</param>
		/// <returns>The Hashtable containing MarketingGroupsItems objects And their ID As key.</returns>
		protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            MarketingGroupsItems myMarketingGroupsItems = new MarketingGroupsItems();
            
            myMarketingGroupsItems.m_intMarketingGroupsItemsID = dr.GetSqlInt32(0);
            myMarketingGroupsItems.m_intMarketingGroupID = dr.GetSqlInt32(1);
            myMarketingGroupsItems.m_intSubjectID = dr.GetSqlInt32(2);
            myMarketingGroupsItems.m_dtValidityDate = dr.GetSqlDateTime(3);
            
            result.Add(myMarketingGroupsItems.MarketingGroupsItemsID, myMarketingGroupsItems);
		}
	
			return result;
		}
		
		public static DataSet LoadByParams(object intMarketingGroupsItemsID , object intMarketingGroupID , object intSubjectID , object dtValidityDate) 
		{
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMarketingGroupsItemsSelectByParams", conn);
			SqlParameter param;
			
			
			
		        param = new SqlParameter("@MarketingGroupsItemsID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intMarketingGroupsItemsID==null ? intMarketingGroupsItemsID : (int)intMarketingGroupsItemsID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MarketingGroupID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intMarketingGroupID==null ? intMarketingGroupID : (int)intMarketingGroupID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSubjectID==null ? intSubjectID : (int)intSubjectID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ValidityDate", SqlDbType.SmallDateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtValidityDate==null ? dtValidityDate : (DateTime)dtValidityDate);
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static DataSet LoadByParams(object intMarketingGroupsItemsID , object intMarketingGroupID , object intSubjectID , object dtValidityDate,SqlConnection sqlConn,SqlTransaction sqlTran) 
		{
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMarketingGroupsItemsSelectByParams", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
			
		        param = new SqlParameter("@MarketingGroupsItemsID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intMarketingGroupsItemsID==null ? intMarketingGroupsItemsID : (int)intMarketingGroupsItemsID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MarketingGroupID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intMarketingGroupID==null ? intMarketingGroupID : (int)intMarketingGroupID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intSubjectID==null ? intSubjectID : (int)intSubjectID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ValidityDate", SqlDbType.SmallDateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtValidityDate==null ? dtValidityDate : (DateTime)dtValidityDate);
        cmd.Parameters.Add(param);
        
		//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static int Insert(bMarketingGroupsItems objMarketingGroupsItems) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMarketingGroupsItemsInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@MarketingGroupsItemsID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.MarketingGroupsItemsID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MarketingGroupID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.MarketingGroupID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ValidityDate", SqlDbType.SmallDateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.ValidityDate;
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
				objMarketingGroupsItems.MarketingGroupsItemsID = retValue;
			return retValue;
		}
		
		public static int Insert(bMarketingGroupsItems objMarketingGroupsItems,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMarketingGroupsItemsInsert", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@MarketingGroupsItemsID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.MarketingGroupsItemsID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MarketingGroupID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.MarketingGroupID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ValidityDate", SqlDbType.SmallDateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.ValidityDate;
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
				objMarketingGroupsItems.MarketingGroupsItemsID = retValue;
			return retValue;
		}

		public static int Update(bMarketingGroupsItems objMarketingGroupsItems) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMarketingGroupsItemsUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@MarketingGroupsItemsID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.MarketingGroupsItemsID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MarketingGroupID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.MarketingGroupID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ValidityDate", SqlDbType.SmallDateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.ValidityDate;
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
		
		public static int Update(bMarketingGroupsItems objMarketingGroupsItems,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMarketingGroupsItemsUpdate", conn);
			cmd.Transaction=sqlTran;
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@MarketingGroupsItemsID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.MarketingGroupsItemsID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MarketingGroupID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.MarketingGroupID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.SubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ValidityDate", SqlDbType.SmallDateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.ValidityDate;
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
		
		public static int Delete(bMarketingGroupsItems objMarketingGroupsItems) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMarketingGroupsItemsDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@MarketingGroupsItemsID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.MarketingGroupsItemsID;
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
		
		public static int Delete(bMarketingGroupsItems objMarketingGroupsItems,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMarketingGroupsItemsUpdate", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@MarketingGroupsItemsID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMarketingGroupsItems.MarketingGroupsItemsID;
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
			return Load(pk.MarketingGroupsItemsID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intMarketingGroupsItemsID"> MarketingGroupsItemsID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intMarketingGroupsItemsID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMarketingGroupsItemsSelect", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for MarketingGroupsItemsID column
        param = new SqlParameter("@MarketingGroupsItemsID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intMarketingGroupsItemsID;
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
		            m_intMarketingGroupsItemsID = reader.GetSqlInt32(0);
            m_intMarketingGroupID = reader.GetSqlInt32(1);
            m_intSubjectID = reader.GetSqlInt32(2);
            m_dtValidityDate = reader.GetSqlDateTime(3);
		
			} else {
			//	set key values
		            m_intMarketingGroupsItemsID = intMarketingGroupsItemsID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMarketingGroupsItemsSelectByParams", conn);

			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@MarketingGroupsItemsID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intMarketingGroupsItemsID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MarketingGroupID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intMarketingGroupID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@SubjectID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intSubjectID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ValidityDate", SqlDbType.SmallDateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_dtValidityDate;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMarketingGroupsItemsInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for MarketingGroupsItemsID column
        param = new SqlParameter("@MarketingGroupsItemsID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intMarketingGroupsItemsID;
        cmd.Parameters.Add(param);
        
        // parameter for MarketingGroupID column
        param = new SqlParameter("@MarketingGroupID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intMarketingGroupID;
        cmd.Parameters.Add(param);
        
        // parameter for SubjectID column
        param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectID;
        cmd.Parameters.Add(param);
        
        // parameter for ValidityDate column
        param = new SqlParameter("@ValidityDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtValidityDate;
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
				MarketingGroupsItemsID = retValue;
			return retValue;
		}
	
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		protected int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMarketingGroupsItemsUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for MarketingGroupsItemsID column
        param = new SqlParameter("@MarketingGroupsItemsID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intMarketingGroupsItemsID;
        cmd.Parameters.Add(param);
        
        // parameter for MarketingGroupID column
        param = new SqlParameter("@MarketingGroupID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intMarketingGroupID;
        cmd.Parameters.Add(param);
        
        // parameter for SubjectID column
        param = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intSubjectID;
        cmd.Parameters.Add(param);
        
        // parameter for ValidityDate column
        param = new SqlParameter("@ValidityDate", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtValidityDate;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMarketingGroupsItemsDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for MarketingGroupsItemsID column
        param = new SqlParameter("@MarketingGroupsItemsID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intMarketingGroupsItemsID;
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
		public static bool operator ==(bMarketingGroupsItems t1, bMarketingGroupsItems t2) {
			//	compare values
			if(t1.m_intMarketingGroupsItemsID != t2.m_intMarketingGroupsItemsID) {
				return false;	//	because "MarketingGroupsItemsID" values are Not equal
			}
	
			if(t1.m_intMarketingGroupID != t2.m_intMarketingGroupID) {
				return false;	//	because "MarketingGroupID" values are Not equal
			}
	
			if(t1.m_intSubjectID != t2.m_intSubjectID) {
				return false;	//	because "SubjectID" values are Not equal
			}
	
			if(t1.m_dtValidityDate != t2.m_dtValidityDate) {
				return false;	//	because "ValidityDate" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(bMarketingGroupsItems t1, bMarketingGroupsItems t2) {
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
				retValue.Append(" MarketingGroupsItemsID = \"");
			retValue.Append(m_intMarketingGroupsItemsID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    MarketingGroupID = \"");
			retValue.Append(m_intMarketingGroupID);
			retValue.Append("\"\n");
				retValue.Append("    SubjectID = \"");
			retValue.Append(m_intSubjectID);
			retValue.Append("\"\n");
				retValue.Append("    ValidityDate = \"");
			retValue.Append(m_dtValidityDate);
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
			if (!(o is MarketingGroupsItems)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (MarketingGroupsItems)o;
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

