using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BINROTA.BUS
{
    public class Faq
    {
        public static DataTable GetFaq()
        {
            try
            {
                return BINROTA.DAL.Faq.LoadAll().Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

    }
}
