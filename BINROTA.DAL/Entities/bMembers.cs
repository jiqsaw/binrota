using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CARETTA.DBI;

namespace BINROTA.DAL.Entities {

	public class bMembers {
		//transactions
		//	enum types
		protected enum Action { Insert, Update, Delete };
			//	Sub-types
		public struct PK {
				public SqlInt32 MemberID;
		}	
		
		
		protected Action m_aAction;
		protected bool m_bIsDirty;

		#region Table Members
		protected SqlInt32 m_intMemberID;
		protected SqlInt32 m_intMemberTypeID;
		protected SqlString m_strFirstName;
		protected SqlString m_strLastName;
		protected SqlString m_strNickName;
		protected SqlString m_strEMail;
		protected SqlDateTime m_dtBirthDay;
		protected SqlString m_strPassword;
		protected SqlBoolean m_bolGender;
		protected SqlInt32 m_intLivingPlace;
		protected SqlString m_strEducation;
		protected SqlInt32 m_intJobID;
		protected SqlString m_strInterests;
		protected SqlString m_strVisitedPlaces;
		protected SqlString m_strMotto;
		protected SqlString m_strPhotoPath;
		protected SqlString m_strPhotoCaption;
		protected SqlString m_strWebAddress;
		protected SqlDouble m_dblPoint;
		protected SqlBoolean m_bolisActive;
		protected SqlString m_strActivationKey;
		protected SqlDateTime m_dtCreateDate;
protected SqlDateTime m_FindBefore_dtCreateDate;
protected SqlDateTime m_FindAfter_dtCreateDate;
		protected SqlDateTime m_dtModifyDate;
protected SqlDateTime m_FindBefore_dtModifyDate;
protected SqlDateTime m_FindAfter_dtModifyDate;
		protected SqlInt32 m_intModifiedBy;
		#endregion
		
		#region Properties
	
		public PK PrimaryKey {
			get {
				PK pk;
				pk.MemberID = m_intMemberID;
				return pk;
			}
		}
			
		
		public int MemberID {
			get {
				return (int)m_intMemberID;
			}
			set {
				m_intMemberID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int MemberTypeID {
			get {
				return (int)m_intMemberTypeID;
			}
			set {
				m_intMemberTypeID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string FirstName {
			get {
				return (string)m_strFirstName;
			}
			set {
				m_strFirstName = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string LastName {
			get {
				return (string)m_strLastName;
			}
			set {
				m_strLastName = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string NickName {
			get {
				return (string)m_strNickName;
			}
			set {
				m_strNickName = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string EMail {
			get {
				return (string)m_strEMail;
			}
			set {
				m_strEMail = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public DateTime BirthDay {
			get {
				return (DateTime)m_dtBirthDay;
			}
			set {
				m_dtBirthDay = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Password {
			get {
				return (string)m_strPassword;
			}
			set {
				m_strPassword = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public bool Gender {
			get {
				return (bool)m_bolGender;
			}
			set {
				m_bolGender = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int LivingPlace {
			get {
				return (int)m_intLivingPlace;
			}
			set {
				m_intLivingPlace = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Education {
			get {
				return (string)m_strEducation;
			}
			set {
				m_strEducation = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int JobID {
			get {
				return (int)m_intJobID;
			}
			set {
				m_intJobID = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Interests {
			get {
				return (string)m_strInterests;
			}
			set {
				m_strInterests = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string VisitedPlaces {
			get {
				return (string)m_strVisitedPlaces;
			}
			set {
				m_strVisitedPlaces = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string Motto {
			get {
				return (string)m_strMotto;
			}
			set {
				m_strMotto = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string PhotoPath {
			get {
				return (string)m_strPhotoPath;
			}
			set {
				m_strPhotoPath = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string PhotoCaption {
			get {
				return (string)m_strPhotoCaption;
			}
			set {
				m_strPhotoCaption = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string WebAddress {
			get {
				return (string)m_strWebAddress;
			}
			set {
				m_strWebAddress = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public double Point {
			get {
				return (double)m_dblPoint;
			}
			set {
				m_dblPoint = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public bool isActive {
			get {
				return (bool)m_bolisActive;
			}
			set {
				m_bolisActive = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public string ActivationKey {
			get {
				return (string)m_strActivationKey;
			}
			set {
				m_strActivationKey = value;
				m_bIsDirty = true;
			}
		}
		
					public DateTime FindBefore_CreateDate {
			get {
				return (DateTime)m_FindBefore_dtCreateDate;
			}
			set {
				m_FindBefore_dtCreateDate = value;
				m_bIsDirty = true;
			}
		}
		
		public DateTime FindAfter_CreateDate {
			get {
				return (DateTime)m_FindAfter_dtCreateDate;
			}
			set {
				m_FindAfter_dtCreateDate = value;
				m_bIsDirty = true;
			}
		}
		
		
		
		public DateTime CreateDate {
			get {
				return (DateTime)m_dtCreateDate;
			}
			set {
				m_dtCreateDate = value;
				m_bIsDirty = true;
			}
		}
		
					public DateTime FindBefore_ModifyDate {
			get {
				return (DateTime)m_FindBefore_dtModifyDate;
			}
			set {
				m_FindBefore_dtModifyDate = value;
				m_bIsDirty = true;
			}
		}
		
		public DateTime FindAfter_ModifyDate {
			get {
				return (DateTime)m_FindAfter_dtModifyDate;
			}
			set {
				m_FindAfter_dtModifyDate = value;
				m_bIsDirty = true;
			}
		}
		
		
		
		public DateTime ModifyDate {
			get {
				return (DateTime)m_dtModifyDate;
			}
			set {
				m_dtModifyDate = value;
				m_bIsDirty = true;
			}
		}
		
			
		
		public int ModifiedBy {
			get {
				return (int)m_intModifiedBy;
			}
			set {
				m_intModifiedBy = value;
				m_bIsDirty = true;
			}
		}
		
	#endregion
	
		#region Constructers

		public bMembers() {
			Init();	//	init Object
		}
		#endregion

		#region Static Functions

		/// <summary>
		/// Gets all Members from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Members</returns>
		
		public static SqlDataReader LoadAllReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMembersSelectAll", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet LoadAll() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMembersSelectAll", conn);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all Members from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable LoadAllHashTable() {
			SqlDataReader dr = LoadAllReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates Members for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Members records</param>
		/// <returns>The Hashtable containing Members objects And their ID As key.</returns>
		protected static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Members myMembers = new Members();
            
            myMembers.m_intMemberID = dr.GetSqlInt32(0);
            myMembers.m_intMemberTypeID = dr.GetSqlInt32(1);
            myMembers.m_strFirstName = dr.GetSqlString(2);
            myMembers.m_strLastName = dr.GetSqlString(3);
            myMembers.m_strNickName = dr.GetSqlString(4);
            myMembers.m_strEMail = dr.GetSqlString(5);
            myMembers.m_dtBirthDay = dr.GetSqlDateTime(6);
            myMembers.m_strPassword = dr.GetSqlString(7);
            myMembers.m_bolGender = dr.GetSqlBoolean(8);
            myMembers.m_intLivingPlace = dr.GetSqlInt32(9);
            myMembers.m_strEducation = dr.GetSqlString(10);
            myMembers.m_intJobID = dr.GetSqlInt32(11);
            myMembers.m_strInterests = dr.GetSqlString(12);
            myMembers.m_strVisitedPlaces = dr.GetSqlString(13);
            myMembers.m_strMotto = dr.GetSqlString(14);
            myMembers.m_strPhotoPath = dr.GetSqlString(15);
            myMembers.m_strPhotoCaption = dr.GetSqlString(16);
            myMembers.m_strWebAddress = dr.GetSqlString(17);
            myMembers.m_dblPoint = dr.GetSqlDouble(18);
            myMembers.m_bolisActive = dr.GetSqlBoolean(19);
            myMembers.m_strActivationKey = dr.GetSqlString(20);
            myMembers.m_dtCreateDate = dr.GetSqlDateTime(21);
            myMembers.m_dtModifyDate = dr.GetSqlDateTime(22);
            myMembers.m_intModifiedBy = dr.GetSqlInt32(23);
            
            result.Add(myMembers.MemberID, myMembers);
		}
	
			return result;
		}
		
		public static DataSet LoadByParams(object intMemberID , object intMemberTypeID , object strFirstName , object strLastName , object strNickName , object strEMail , object dtBirthDay , object strPassword , object bolGender , object intLivingPlace , object strEducation , object intJobID , object strInterests , object strVisitedPlaces , object strMotto , object strPhotoPath , object strPhotoCaption , object strWebAddress , object dblPoint , object bolisActive , object strActivationKey , object dtFindBefore_CreateDate,object dtFindAfter_CreateDate , object dtFindBefore_ModifyDate,object dtFindAfter_ModifyDate , object intModifiedBy) 
		{
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMembersSelectByParams", conn);
			SqlParameter param;
			
			
			
		        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intMemberID==null ? intMemberID : (int)intMemberID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intMemberTypeID==null ? intMemberTypeID : (int)intMemberTypeID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strFirstName==null ? strFirstName : (string)strFirstName);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LastName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strLastName==null ? strLastName : (string)strLastName);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@NickName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strNickName==null ? strNickName : (string)strNickName);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EMail", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strEMail==null ? strEMail : (string)strEMail);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@BirthDay", SqlDbType.SmallDateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtBirthDay==null ? dtBirthDay : (DateTime)dtBirthDay);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Password", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPassword==null ? strPassword : (string)strPassword);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Gender", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=(bolGender==null ? bolGender : (bool)bolGender);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LivingPlace", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intLivingPlace==null ? intLivingPlace : (int)intLivingPlace);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Education", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strEducation==null ? strEducation : (string)strEducation);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@JobID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intJobID==null ? intJobID : (int)intJobID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Interests", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strInterests==null ? strInterests : (string)strInterests);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@VisitedPlaces", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strVisitedPlaces==null ? strVisitedPlaces : (string)strVisitedPlaces);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Motto", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strMotto==null ? strMotto : (string)strMotto);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoPath==null ? strPhotoPath : (string)strPhotoPath);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoCaption==null ? strPhotoCaption : (string)strPhotoCaption);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@WebAddress", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strWebAddress==null ? strWebAddress : (string)strWebAddress);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Point", SqlDbType.Float);
        param.Direction = ParameterDirection.Input;
        param.Value=(dblPoint==null ? dblPoint : (double)dblPoint);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isActive", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=(bolisActive==null ? bolisActive : (bool)bolisActive);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strActivationKey==null ? strActivationKey : (string)strActivationKey);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_CreateDate==null ? dtFindBefore_CreateDate : (DateTime)dtFindBefore_CreateDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_CreateDate==null ? dtFindAfter_CreateDate : (DateTime)dtFindAfter_CreateDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_ModifyDate==null ? dtFindBefore_ModifyDate : (DateTime)dtFindBefore_ModifyDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_ModifyDate==null ? dtFindAfter_ModifyDate : (DateTime)dtFindAfter_ModifyDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intModifiedBy==null ? intModifiedBy : (int)intModifiedBy);
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static DataSet LoadByParams(object intMemberID , object intMemberTypeID , object strFirstName , object strLastName , object strNickName , object strEMail , object dtBirthDay , object strPassword , object bolGender , object intLivingPlace , object strEducation , object intJobID , object strInterests , object strVisitedPlaces , object strMotto , object strPhotoPath , object strPhotoCaption , object strWebAddress , object dblPoint , object bolisActive , object strActivationKey , object dtFindBefore_CreateDate,object dtFindAfter_CreateDate , object dtFindBefore_ModifyDate,object dtFindAfter_ModifyDate , object intModifiedBy,SqlConnection sqlConn,SqlTransaction sqlTran) 
		{
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMembersSelectByParams", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
			
		        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intMemberID==null ? intMemberID : (int)intMemberID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intMemberTypeID==null ? intMemberTypeID : (int)intMemberTypeID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strFirstName==null ? strFirstName : (string)strFirstName);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LastName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strLastName==null ? strLastName : (string)strLastName);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@NickName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strNickName==null ? strNickName : (string)strNickName);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EMail", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strEMail==null ? strEMail : (string)strEMail);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@BirthDay", SqlDbType.SmallDateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtBirthDay==null ? dtBirthDay : (DateTime)dtBirthDay);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Password", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPassword==null ? strPassword : (string)strPassword);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Gender", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=(bolGender==null ? bolGender : (bool)bolGender);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LivingPlace", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intLivingPlace==null ? intLivingPlace : (int)intLivingPlace);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Education", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strEducation==null ? strEducation : (string)strEducation);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@JobID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intJobID==null ? intJobID : (int)intJobID);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Interests", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strInterests==null ? strInterests : (string)strInterests);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@VisitedPlaces", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strVisitedPlaces==null ? strVisitedPlaces : (string)strVisitedPlaces);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Motto", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strMotto==null ? strMotto : (string)strMotto);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoPath==null ? strPhotoPath : (string)strPhotoPath);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strPhotoCaption==null ? strPhotoCaption : (string)strPhotoCaption);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@WebAddress", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strWebAddress==null ? strWebAddress : (string)strWebAddress);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Point", SqlDbType.Float);
        param.Direction = ParameterDirection.Input;
        param.Value=(dblPoint==null ? dblPoint : (double)dblPoint);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isActive", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=(bolisActive==null ? bolisActive : (bool)bolisActive);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=(strActivationKey==null ? strActivationKey : (string)strActivationKey);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_CreateDate==null ? dtFindBefore_CreateDate : (DateTime)dtFindBefore_CreateDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_CreateDate==null ? dtFindAfter_CreateDate : (DateTime)dtFindAfter_CreateDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindBefore_ModifyDate==null ? dtFindBefore_ModifyDate : (DateTime)dtFindBefore_ModifyDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=(dtFindAfter_ModifyDate==null ? dtFindAfter_ModifyDate : (DateTime)dtFindAfter_ModifyDate);
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=(intModifiedBy==null ? intModifiedBy : (int)intModifiedBy);
        cmd.Parameters.Add(param);
        
		//	open connection
			conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
			
			return ds;
		}
		
		public static int Insert(bMembers objMembers) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMembersInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.MemberID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.MemberTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.FirstName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LastName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.LastName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@NickName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.NickName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EMail", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.EMail;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@BirthDay", SqlDbType.SmallDateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.BirthDay;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Password", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Password;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Gender", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Gender;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LivingPlace", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.LivingPlace;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Education", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Education;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@JobID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.JobID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Interests", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Interests;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@VisitedPlaces", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.VisitedPlaces;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Motto", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Motto;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@WebAddress", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.WebAddress;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Point", SqlDbType.Float);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Point;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isActive", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.isActive;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.ActivationKey;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.CreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.ModifiedBy;
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
				objMembers.MemberID = retValue;
			return retValue;
		}
		
		public static int Insert(bMembers objMembers,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMembersInsert", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.MemberID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.MemberTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.FirstName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LastName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.LastName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@NickName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.NickName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EMail", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.EMail;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@BirthDay", SqlDbType.SmallDateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.BirthDay;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Password", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Password;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Gender", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Gender;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LivingPlace", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.LivingPlace;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Education", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Education;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@JobID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.JobID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Interests", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Interests;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@VisitedPlaces", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.VisitedPlaces;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Motto", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Motto;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@WebAddress", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.WebAddress;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Point", SqlDbType.Float);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Point;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isActive", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.isActive;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.ActivationKey;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.CreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.ModifiedBy;
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
				objMembers.MemberID = retValue;
			return retValue;
		}

		public static int Update(bMembers objMembers) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMembersUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.MemberID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.MemberTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.FirstName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LastName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.LastName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@NickName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.NickName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EMail", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.EMail;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@BirthDay", SqlDbType.SmallDateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.BirthDay;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Password", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Password;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Gender", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Gender;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LivingPlace", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.LivingPlace;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Education", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Education;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@JobID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.JobID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Interests", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Interests;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@VisitedPlaces", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.VisitedPlaces;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Motto", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Motto;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@WebAddress", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.WebAddress;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Point", SqlDbType.Float);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Point;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isActive", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.isActive;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.ActivationKey;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.CreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.ModifiedBy;
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
		
		public static int Update(bMembers objMembers,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMembersUpdate", conn);
			cmd.Transaction=sqlTran;
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.MemberID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.MemberTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.FirstName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LastName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.LastName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@NickName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.NickName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EMail", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.EMail;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@BirthDay", SqlDbType.SmallDateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.BirthDay;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Password", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Password;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Gender", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Gender;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LivingPlace", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.LivingPlace;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Education", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Education;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@JobID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.JobID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Interests", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Interests;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@VisitedPlaces", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.VisitedPlaces;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Motto", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Motto;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.PhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.PhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@WebAddress", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.WebAddress;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Point", SqlDbType.Float);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.Point;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isActive", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.isActive;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.ActivationKey;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.CreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.ModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.ModifiedBy;
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
		
		public static int Delete(bMembers objMembers) {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMembersDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.MemberID;
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
		
		public static int Delete(bMembers objMembers,SqlConnection sqlConn,SqlTransaction sqlTran) {
			//	construct new connection and command objects
			SqlConnection conn = sqlConn;
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMembersUpdate", conn);
			cmd.Transaction=sqlTran;
			
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=objMembers.MemberID;
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
			return Load(pk.MemberID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intMemberID"> MemberID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intMemberID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMembersSelect", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for MemberID column
        param = new SqlParameter("@MemberID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intMemberID;
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
		            m_intMemberID = reader.GetSqlInt32(0);
            m_intMemberTypeID = reader.GetSqlInt32(1);
            m_strFirstName = reader.GetSqlString(2);
            m_strLastName = reader.GetSqlString(3);
            m_strNickName = reader.GetSqlString(4);
            m_strEMail = reader.GetSqlString(5);
            m_dtBirthDay = reader.GetSqlDateTime(6);
            m_strPassword = reader.GetSqlString(7);
            m_bolGender = reader.GetSqlBoolean(8);
            m_intLivingPlace = reader.GetSqlInt32(9);
            m_strEducation = reader.GetSqlString(10);
            m_intJobID = reader.GetSqlInt32(11);
            m_strInterests = reader.GetSqlString(12);
            m_strVisitedPlaces = reader.GetSqlString(13);
            m_strMotto = reader.GetSqlString(14);
            m_strPhotoPath = reader.GetSqlString(15);
            m_strPhotoCaption = reader.GetSqlString(16);
            m_strWebAddress = reader.GetSqlString(17);
            m_dblPoint = reader.GetSqlDouble(18);
            m_bolisActive = reader.GetSqlBoolean(19);
            m_strActivationKey = reader.GetSqlString(20);
            m_dtCreateDate = reader.GetSqlDateTime(21);
            m_dtModifyDate = reader.GetSqlDateTime(22);
            m_intModifiedBy = reader.GetSqlInt32(23);
		
			} else {
			//	set key values
		            m_intMemberID = intMemberID;
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
            SqlCommand cmd = DBHelper.getSprocCmd("sprocMembersSelectByParams", conn);

			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        param = new SqlParameter("@MemberID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intMemberID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@MemberTypeID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intMemberTypeID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strFirstName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LastName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strLastName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@NickName", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strNickName;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@EMail", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strEMail;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@BirthDay", SqlDbType.SmallDateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_dtBirthDay;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Password", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strPassword;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Gender", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=m_bolGender;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@LivingPlace", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intLivingPlace;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Education", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strEducation;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@JobID", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intJobID;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Interests", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strInterests;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@VisitedPlaces", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strVisitedPlaces;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Motto", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strMotto;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strPhotoPath;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strPhotoCaption;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@WebAddress", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strWebAddress;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Point", SqlDbType.Float);
        param.Direction = ParameterDirection.Input;
        param.Value=m_dblPoint;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@isActive", SqlDbType.Bit);
        param.Direction = ParameterDirection.Input;
        param.Value=m_bolisActive;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar);
        param.Direction = ParameterDirection.Input;
        param.Value=m_strActivationKey;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindBefore_dtCreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_CreateDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindAfter_dtCreateDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@Before_ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindBefore_dtModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@After_ModifyDate", SqlDbType.DateTime);
        param.Direction = ParameterDirection.Input;
        param.Value=m_FindAfter_dtModifyDate;
        cmd.Parameters.Add(param);
        
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param.Direction = ParameterDirection.Input;
        param.Value=m_intModifiedBy;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMembersInsert", conn);
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for MemberID column
        param = new SqlParameter("@MemberID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intMemberID;
        cmd.Parameters.Add(param);
        
        // parameter for MemberTypeID column
        param = new SqlParameter("@MemberTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intMemberTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for FirstName column
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strFirstName;
        cmd.Parameters.Add(param);
        
        // parameter for LastName column
        param = new SqlParameter("@LastName", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strLastName;
        cmd.Parameters.Add(param);
        
        // parameter for NickName column
        param = new SqlParameter("@NickName", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strNickName;
        cmd.Parameters.Add(param);
        
        // parameter for EMail column
        param = new SqlParameter("@EMail", SqlDbType.VarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strEMail;
        cmd.Parameters.Add(param);
        
        // parameter for BirthDay column
        param = new SqlParameter("@BirthDay", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBirthDay;
        cmd.Parameters.Add(param);
        
        // parameter for Password column
        param = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPassword;
        cmd.Parameters.Add(param);
        
        // parameter for Gender column
        param = new SqlParameter("@Gender", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolGender;
        cmd.Parameters.Add(param);
        
        // parameter for LivingPlace column
        param = new SqlParameter("@LivingPlace", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intLivingPlace;
        cmd.Parameters.Add(param);
        
        // parameter for Education column
        param = new SqlParameter("@Education", SqlDbType.NVarChar, 250);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strEducation;
        cmd.Parameters.Add(param);
        
        // parameter for JobID column
        param = new SqlParameter("@JobID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intJobID;
        cmd.Parameters.Add(param);
        
        // parameter for Interests column
        param = new SqlParameter("@Interests", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strInterests;
        cmd.Parameters.Add(param);
        
        // parameter for VisitedPlaces column
        param = new SqlParameter("@VisitedPlaces", SqlDbType.NVarChar, 1000);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strVisitedPlaces;
        cmd.Parameters.Add(param);
        
        // parameter for Motto column
        param = new SqlParameter("@Motto", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strMotto;
        cmd.Parameters.Add(param);
        
        // parameter for PhotoPath column
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPhotoPath;
        cmd.Parameters.Add(param);
        
        // parameter for PhotoCaption column
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPhotoCaption;
        cmd.Parameters.Add(param);
        
        // parameter for WebAddress column
        param = new SqlParameter("@WebAddress", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strWebAddress;
        cmd.Parameters.Add(param);
        
        // parameter for Point column
        param = new SqlParameter("@Point", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblPoint;
        cmd.Parameters.Add(param);
        
        // parameter for isActive column
        param = new SqlParameter("@isActive", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisActive;
        cmd.Parameters.Add(param);
        
        // parameter for ActivationKey column
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strActivationKey;
        cmd.Parameters.Add(param);
        
        // parameter for CreateDate column
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtCreateDate;
        cmd.Parameters.Add(param);
        
        // parameter for ModifyDate column
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtModifyDate;
        cmd.Parameters.Add(param);
        
        // parameter for ModifiedBy column
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intModifiedBy;
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
				MemberID = retValue;
			return retValue;
		}
	
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		protected int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMembersUpdate", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for MemberID column
        param = new SqlParameter("@MemberID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intMemberID;
        cmd.Parameters.Add(param);
        
        // parameter for MemberTypeID column
        param = new SqlParameter("@MemberTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intMemberTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for FirstName column
        param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strFirstName;
        cmd.Parameters.Add(param);
        
        // parameter for LastName column
        param = new SqlParameter("@LastName", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strLastName;
        cmd.Parameters.Add(param);
        
        // parameter for NickName column
        param = new SqlParameter("@NickName", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strNickName;
        cmd.Parameters.Add(param);
        
        // parameter for EMail column
        param = new SqlParameter("@EMail", SqlDbType.VarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strEMail;
        cmd.Parameters.Add(param);
        
        // parameter for BirthDay column
        param = new SqlParameter("@BirthDay", SqlDbType.SmallDateTime, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtBirthDay;
        cmd.Parameters.Add(param);
        
        // parameter for Password column
        param = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPassword;
        cmd.Parameters.Add(param);
        
        // parameter for Gender column
        param = new SqlParameter("@Gender", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolGender;
        cmd.Parameters.Add(param);
        
        // parameter for LivingPlace column
        param = new SqlParameter("@LivingPlace", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intLivingPlace;
        cmd.Parameters.Add(param);
        
        // parameter for Education column
        param = new SqlParameter("@Education", SqlDbType.NVarChar, 250);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strEducation;
        cmd.Parameters.Add(param);
        
        // parameter for JobID column
        param = new SqlParameter("@JobID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intJobID;
        cmd.Parameters.Add(param);
        
        // parameter for Interests column
        param = new SqlParameter("@Interests", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strInterests;
        cmd.Parameters.Add(param);
        
        // parameter for VisitedPlaces column
        param = new SqlParameter("@VisitedPlaces", SqlDbType.NVarChar, 1000);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strVisitedPlaces;
        cmd.Parameters.Add(param);
        
        // parameter for Motto column
        param = new SqlParameter("@Motto", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strMotto;
        cmd.Parameters.Add(param);
        
        // parameter for PhotoPath column
        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPhotoPath;
        cmd.Parameters.Add(param);
        
        // parameter for PhotoCaption column
        param = new SqlParameter("@PhotoCaption", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strPhotoCaption;
        cmd.Parameters.Add(param);
        
        // parameter for WebAddress column
        param = new SqlParameter("@WebAddress", SqlDbType.NVarChar, 255);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strWebAddress;
        cmd.Parameters.Add(param);
        
        // parameter for Point column
        param = new SqlParameter("@Point", SqlDbType.Float, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dblPoint;
        cmd.Parameters.Add(param);
        
        // parameter for isActive column
        param = new SqlParameter("@isActive", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisActive;
        cmd.Parameters.Add(param);
        
        // parameter for ActivationKey column
        param = new SqlParameter("@ActivationKey", SqlDbType.NVarChar, 50);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strActivationKey;
        cmd.Parameters.Add(param);
        
        // parameter for CreateDate column
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtCreateDate;
        cmd.Parameters.Add(param);
        
        // parameter for ModifyDate column
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtModifyDate;
        cmd.Parameters.Add(param);
        
        // parameter for ModifiedBy column
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intModifiedBy;
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
			SqlCommand cmd = DBHelper.getSprocCmd("sprocMembersDelete", conn);
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for MemberID column
        param = new SqlParameter("@MemberID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intMemberID;
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
		public static bool operator ==(bMembers t1, bMembers t2) {
			//	compare values
			if(t1.m_intMemberID != t2.m_intMemberID) {
				return false;	//	because "MemberID" values are Not equal
			}
	
			if(t1.m_intMemberTypeID != t2.m_intMemberTypeID) {
				return false;	//	because "MemberTypeID" values are Not equal
			}
	
			if(t1.m_strFirstName != t2.m_strFirstName) {
				return false;	//	because "FirstName" values are Not equal
			}
	
			if(t1.m_strLastName != t2.m_strLastName) {
				return false;	//	because "LastName" values are Not equal
			}
	
			if(t1.m_strNickName != t2.m_strNickName) {
				return false;	//	because "NickName" values are Not equal
			}
	
			if(t1.m_strEMail != t2.m_strEMail) {
				return false;	//	because "EMail" values are Not equal
			}
	
			if(t1.m_dtBirthDay != t2.m_dtBirthDay) {
				return false;	//	because "BirthDay" values are Not equal
			}
	
			if(t1.m_strPassword != t2.m_strPassword) {
				return false;	//	because "Password" values are Not equal
			}
	
			if(t1.m_bolGender != t2.m_bolGender) {
				return false;	//	because "Gender" values are Not equal
			}
	
			if(t1.m_intLivingPlace != t2.m_intLivingPlace) {
				return false;	//	because "LivingPlace" values are Not equal
			}
	
			if(t1.m_strEducation != t2.m_strEducation) {
				return false;	//	because "Education" values are Not equal
			}
	
			if(t1.m_intJobID != t2.m_intJobID) {
				return false;	//	because "JobID" values are Not equal
			}
	
			if(t1.m_strInterests != t2.m_strInterests) {
				return false;	//	because "Interests" values are Not equal
			}
	
			if(t1.m_strVisitedPlaces != t2.m_strVisitedPlaces) {
				return false;	//	because "VisitedPlaces" values are Not equal
			}
	
			if(t1.m_strMotto != t2.m_strMotto) {
				return false;	//	because "Motto" values are Not equal
			}
	
			if(t1.m_strPhotoPath != t2.m_strPhotoPath) {
				return false;	//	because "PhotoPath" values are Not equal
			}
	
			if(t1.m_strPhotoCaption != t2.m_strPhotoCaption) {
				return false;	//	because "PhotoCaption" values are Not equal
			}
	
			if(t1.m_strWebAddress != t2.m_strWebAddress) {
				return false;	//	because "WebAddress" values are Not equal
			}
	
			if(t1.m_dblPoint != t2.m_dblPoint) {
				return false;	//	because "Point" values are Not equal
			}
	
			if(t1.m_bolisActive != t2.m_bolisActive) {
				return false;	//	because "isActive" values are Not equal
			}
	
			if(t1.m_strActivationKey != t2.m_strActivationKey) {
				return false;	//	because "ActivationKey" values are Not equal
			}
	
			if(t1.m_dtCreateDate != t2.m_dtCreateDate) {
				return false;	//	because "CreateDate" values are Not equal
			}
	
			if(t1.m_dtModifyDate != t2.m_dtModifyDate) {
				return false;	//	because "ModifyDate" values are Not equal
			}
	
			if(t1.m_intModifiedBy != t2.m_intModifiedBy) {
				return false;	//	because "ModifiedBy" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(bMembers t1, bMembers t2) {
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
				retValue.Append(" MemberID = \"");
			retValue.Append(m_intMemberID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    MemberTypeID = \"");
			retValue.Append(m_intMemberTypeID);
			retValue.Append("\"\n");
				retValue.Append("    FirstName = \"");
			retValue.Append(m_strFirstName);
			retValue.Append("\"\n");
				retValue.Append("    LastName = \"");
			retValue.Append(m_strLastName);
			retValue.Append("\"\n");
				retValue.Append("    NickName = \"");
			retValue.Append(m_strNickName);
			retValue.Append("\"\n");
				retValue.Append("    EMail = \"");
			retValue.Append(m_strEMail);
			retValue.Append("\"\n");
				retValue.Append("    BirthDay = \"");
			retValue.Append(m_dtBirthDay);
			retValue.Append("\"\n");
				retValue.Append("    Password = \"");
			retValue.Append(m_strPassword);
			retValue.Append("\"\n");
				retValue.Append("    Gender = \"");
			retValue.Append(m_bolGender);
			retValue.Append("\"\n");
				retValue.Append("    LivingPlace = \"");
			retValue.Append(m_intLivingPlace);
			retValue.Append("\"\n");
				retValue.Append("    Education = \"");
			retValue.Append(m_strEducation);
			retValue.Append("\"\n");
				retValue.Append("    JobID = \"");
			retValue.Append(m_intJobID);
			retValue.Append("\"\n");
				retValue.Append("    Interests = \"");
			retValue.Append(m_strInterests);
			retValue.Append("\"\n");
				retValue.Append("    VisitedPlaces = \"");
			retValue.Append(m_strVisitedPlaces);
			retValue.Append("\"\n");
				retValue.Append("    Motto = \"");
			retValue.Append(m_strMotto);
			retValue.Append("\"\n");
				retValue.Append("    PhotoPath = \"");
			retValue.Append(m_strPhotoPath);
			retValue.Append("\"\n");
				retValue.Append("    PhotoCaption = \"");
			retValue.Append(m_strPhotoCaption);
			retValue.Append("\"\n");
				retValue.Append("    WebAddress = \"");
			retValue.Append(m_strWebAddress);
			retValue.Append("\"\n");
				retValue.Append("    Point = \"");
			retValue.Append(m_dblPoint);
			retValue.Append("\"\n");
				retValue.Append("    isActive = \"");
			retValue.Append(m_bolisActive);
			retValue.Append("\"\n");
				retValue.Append("    ActivationKey = \"");
			retValue.Append(m_strActivationKey);
			retValue.Append("\"\n");
				retValue.Append("    CreateDate = \"");
			retValue.Append(m_dtCreateDate);
			retValue.Append("\"\n");
				retValue.Append("    ModifyDate = \"");
			retValue.Append(m_dtModifyDate);
			retValue.Append("\"\n");
				retValue.Append("    ModifiedBy = \"");
			retValue.Append(m_intModifiedBy);
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
			if (!(o is Members)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Members)o;
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

