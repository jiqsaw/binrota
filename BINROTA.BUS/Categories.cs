using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BINROTA.BUS
{
    public class Categories
    {
        public static DataTable GetCategories()
        {
            return BINROTA.DAL.Categories.GetCategories();
        }


        public static DataTable GetCategoriesContentByPageID(int PageID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.Categories.GetCategoriesContentByPageID(PageID);
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
