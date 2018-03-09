using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BINROTA.DAL;
using CARETTA.COM;

namespace BINROTA.BUS
{
    public class Users
    {
        public static DataTable GetPassword(string EMail)
        {

            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.Users.GetPassword(EMail);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetUserIDForLogin(string EMail, string Password)
        {

            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.Users.GetUserIDForLogin(EMail, Password);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetUserInfoForLogin(string Email, string Password)
        {
                BINROTA.DAL.Users objUser = new BINROTA.DAL.Users();
                objUser.EMail = Email;
                objUser.Password = Password;
                return objUser.LoadByParams().Tables[0];
        }

        //public static void UsersInsert(string FirstName, string LastName, string EMail, string Password, bool Gender, DateTime BirthDate, string ActivationKey, int ModifiedBy)
        //{
        //    try
        //    {
        //        BINROTA.DAL.Users.UsersInsert(FirstName, LastName, EMail, Password, Gender, BirthDate, ActivationKey, ModifiedBy);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }


}
