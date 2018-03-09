using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CARETTA.COM;

namespace BINROTA.BUS
{
    public class Menu
    {
        public static DataTable GetCategories()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.Categories.LoadAll().Tables[0];
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetDDLMemberTypes() {

            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.MemberTypes.LoadAll().Tables[0];

            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }


    }
}
