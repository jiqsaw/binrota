using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BINROTA.BUS
{
    public class PageCategories
    {
        public static DataTable GetPageCategoriesAll()
        {
            return BINROTA.DAL.PageCategories.GetPageCategoriesAll();
        }

        public static DataTable GetPageCategoriesByPageCategoryID(int PageCategoryID)
        {
            BINROTA.DAL.PageCategories objPageCat = new BINROTA.DAL.PageCategories();
            objPageCat.PageCategoryID = PageCategoryID;
            return objPageCat.LoadByParams().Tables[0];
        }

    }
}
