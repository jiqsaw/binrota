using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BINROTA.DAL;
using CARETTA.COM;
using BINROTA.COM;

namespace BINROTA.BUS
{
    public class Members
    {
        #region PhotoAlbum
        public class PhotoAlbum
        {
            public static void DeleteAlbum(int MemberPhotoID)
            {
                MemberPhotos.DeleteAlbum(MemberPhotoID);
            }
            public static void DeletePhoto(int MemberPhotoID)
            {
                MemberPhotos mPhotos = new MemberPhotos();

                mPhotos.MemberPhotoID = MemberPhotoID;
                mPhotos.Delete();
            }
            public static int InsertAlbum(string AlbumName, int MemberID)
            {

                    MemberPhotos mPhotos = new MemberPhotos();

                    mPhotos.MemberID = MemberID;
                    mPhotos.PhotoName = AlbumName;
                    mPhotos.PhotoType = (int)Enumerations.PhotoType.Album;

                    return mPhotos.Save();

            }
            public static bool InsertPhoto(string PhotoUrl, int AlbumID, int MemberID)
            {
                try
                {
                    MemberPhotos mPhotos = new MemberPhotos();

                    mPhotos.MemberID = MemberID;
                    mPhotos.PhotoUrl = PhotoUrl;
                    mPhotos.AlbumID = AlbumID;
                    mPhotos.PhotoType = (int)Enumerations.PhotoType.Photo;

                    mPhotos.Save();
                }
                catch (Exception ex)
                {
                    return false;
                }

                return true;
            }
            public static DataTable GetPhotoByMemberPhotoID(int MemberPhotoID)
            {
                MemberPhotos mPhotos = new MemberPhotos();

                mPhotos.MemberPhotoID = MemberPhotoID;
                return mPhotos.LoadByParams().Tables[0];
            }
            public static DataTable GetAlbums(int MemberID)
            {
                MemberPhotos mPhotos = new MemberPhotos();

                mPhotos.MemberID = MemberID;
                mPhotos.PhotoType = (int)Enumerations.PhotoType.Album; 
                return mPhotos.LoadByParams().Tables[0];
            }
            public static DataTable GetPhotos(int MemberID)
            {
                MemberPhotos mPhotos = new MemberPhotos();

                mPhotos.MemberID = MemberID;
                mPhotos.PhotoType = (int)Enumerations.PhotoType.Photo;
                return mPhotos.LoadByParams().Tables[0];
            }
            public static DataTable GetPhotos(int MemberID, int AlbumID)
            {
                MemberPhotos mPhotos = new MemberPhotos();

                mPhotos.MemberID = MemberID;
                mPhotos.AlbumID = AlbumID;
                mPhotos.PhotoType = (int)Enumerations.PhotoType.Photo;
                return mPhotos.LoadByParams().Tables[0];
            }
        }
        #endregion

        public static DataTable GetMemberInfoForLogin(string NickName, string Password)
        {
            BINROTA.DAL.Members objMem = new BINROTA.DAL.Members();
            objMem.NickName = NickName;
            objMem.Password = Password;
            return objMem.LoadByParams().Tables[0];
        }

        //GetMemberIDForLogin Kaldýrýlabilir
        public static DataTable GetMemberIDForLogin(string EMail, string Password)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.Members.GetMemberIDForLogin(EMail, Password);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetLast5Member()
        {
            return BINROTA.DAL.Members.GetLast5Member();
        }

        public static DataTable MemberSearch(string SearchText)
        {
            return BINROTA.DAL.Members.MemberSearch("%" + SearchText + "%");
        }

        public static DataTable MemberSearchByBirthDay(DateTime Date)
        {
            return BINROTA.DAL.Members.MemberSearchByBirthDay(Date.Day, Date.Month);
        }

        public static bool ActivateMember(string ActivationKey, int MemberID)
        {
            BINROTA.DAL.Members objMem = new BINROTA.DAL.Members();
            objMem.ActivationKey = ActivationKey;
            objMem.MemberID = MemberID;
            DataTable dt = objMem.LoadByParams().Tables[0];
            if (dt.Rows.Count > 0)
            {
                objMem.Load(int.Parse(dt.Rows[0]["MemberID"].ToString()));
                objMem.isActive = true;
                objMem.Save();
                return true;
            }
            else
                return false;
        }

        public static DataTable GetPassword(string EMail)
        {

            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.Members.GetPassword(EMail);
                if (dt.Rows.Count < 1)
                {
                    dt = BINROTA.DAL.Users.GetPassword(EMail);
                }
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static int MemberInsert(string FirstName, string LastName, string NickName, string Email, DateTime BirthDay, int JobID, int LivingPlace, string Password, bool Gender, DateTime ModifyDate, string ActivationKey)
        {

            BINROTA.DAL.Members objMem = new BINROTA.DAL.Members();
            objMem.BirthDay = BirthDay;
            objMem.EMail = Email;
            objMem.FirstName = FirstName;
            objMem.Gender = Gender;
            objMem.LastName = LastName;
            objMem.JobID = JobID;
            objMem.LivingPlace = LivingPlace;
            objMem.Education = "";
            objMem.VisitedPlaces = "";
            objMem.MemberTypeID = (int)Enumerations.MemberType.NewMember;
            objMem.NickName = NickName;
            objMem.Password = Password;
            objMem.ActivationKey = ActivationKey;
            objMem.CreateDate = DateTime.Today;
            objMem.ModifyDate = ModifyDate;
            objMem.isActive = false;
            objMem.Point = 0;
            return objMem.Save();

        }

        public static Enumerations.MemberRegisterControl MemberRegisterControl(string NickName, string Email)
        {
            BINROTA.DAL.Members objMem = new BINROTA.DAL.Members();
            objMem.NickName = NickName;
            if (objMem.LoadByParams().Tables[0].Rows.Count > 0)
            {
                return Enumerations.MemberRegisterControl.NickNameExist;
            }
            else
            {
                BINROTA.DAL.Members objMemEmail = new BINROTA.DAL.Members();
                objMemEmail.EMail = Email;
                if (objMemEmail.LoadByParams().Tables[0].Rows.Count > 0)
                {
                    return Enumerations.MemberRegisterControl.EmailExist;
                }
                else
                    return Enumerations.MemberRegisterControl.Success;
            }

        }

        public static void MemberUpdate(int MemberID, string FirstName, string LastName, int JobID, int LivingPlace, string Interests, string Motto, string VisitedPlaces, DateTime BirthDay)
        {
            BINROTA.DAL.Members objMem = new BINROTA.DAL.Members();
            objMem.Load(MemberID);
            objMem.FirstName = FirstName;
            objMem.LastName = LastName;
            objMem.JobID = JobID;
            objMem.LivingPlace = LivingPlace;
            objMem.Interests = Interests;
            objMem.BirthDay = BirthDay;
            objMem.VisitedPlaces = VisitedPlaces;
            objMem.Motto = Motto;
            objMem.Save();

        }

        public static void MemberPortraitUpdate(int MemberID, string PhotoPath)
        {
            BINROTA.DAL.Members objMem = new BINROTA.DAL.Members();
            objMem.Load(MemberID);
            objMem.PhotoPath = PhotoPath;
            objMem.Save();
        }

        public static void MemberPasswordUpdate(int MemberID, string Password)
        {
            BINROTA.DAL.Members objMem = new BINROTA.DAL.Members();
            objMem.Load(MemberID);
            objMem.Password = Password;
            objMem.Save();
        }


        public static DataTable GetMemberDetailsByMemberID(int MemberID)
        {
            return BINROTA.DAL.Members.GetMemberDetailsByMemberID(MemberID);
        }

        public static DataTable GetMemberByPoints(int PageTypeID)
        {
            return BINROTA.DAL.Members.GetMemberByPoints(PageTypeID);
        }

        public static DataTable GetMemberPointsBySubjectID(int SubjectID)
        {
            return BINROTA.DAL.Members.GetMemberPointsBySubjectID(SubjectID);
        }

    }
}
