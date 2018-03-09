using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace BINROTA.BUS
{
    public class Pages
    {
     
        public static void PagesInsert(int MemberID, int SubjectID, int PageTypeID, int PageCategoryID, string Title, string PageContent, DateTime TravelDate, string PhotoPath, string PhotoCaption, int ParentPageID, DateTime ModifyDate, int ModifiedBy, DataTable dtCategories)
        {
            try
            {

                BINROTA.DAL.Pages.InsertPage(MemberID, SubjectID, PageTypeID, PageCategoryID, Title, PageContent, TravelDate, PhotoPath, PhotoCaption, ParentPageID, ModifyDate, ModifiedBy, dtCategories);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static void PagesUpdate(int PageID, int SubjectID, int PageCategoryID, string Title, string PageContent, DateTime TravelDate, string PhotoPath, string PhotoCaption, DateTime ModifyDate, int ModifiedBy,Hashtable htCategories)
        {

            try
            {
                DataTable PageIDCategories = new DataTable();
                PageIDCategories = BINROTA.DAL.Pages.GetPageByParentPageID(PageID);

                BINROTA.DAL.Pages.UpdatePage(PageID, SubjectID, PageCategoryID, Title, PageContent, TravelDate, PhotoCaption, PhotoPath, ModifyDate, ModifiedBy, htCategories, PageIDCategories);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void DeletePage(int PageID)
        {
            BINROTA.DAL.Pages objPage = new BINROTA.DAL.Pages();
            objPage.Load(PageID);
            objPage.isDeleted = true;
            objPage.Save();
        }

        public static DataTable GetPageForExistanceControl(int MemberID, int SubjectID, int PageTypeID)
        {

            BINROTA.DAL.Pages objPage = new BINROTA.DAL.Pages();
            objPage.MemberID = MemberID;
            objPage.SubjectID = SubjectID;
            objPage.PageTypeID = PageTypeID;
            objPage.isDeleted = false;
            return objPage.LoadByParams().Tables[0];

        }

        public static DataTable GetPageForExistanceControl(int ParentPageID, int CategoryID)
        {
            BINROTA.DAL.Pages objPage = new BINROTA.DAL.Pages();
            objPage.ParentPageID = ParentPageID;
            objPage.CategoryID = CategoryID;
            objPage.isDeleted = false;
            return objPage.LoadByParams().Tables[0];
        }

        public static DataTable GetPageForExistanceControl(int PageID)
        {
            BINROTA.DAL.Pages objPage = new BINROTA.DAL.Pages();
            objPage.PageID = PageID;
            objPage.isDeleted = false;
            return objPage.LoadByParams().Tables[0];
        }

        public static DataTable GetPageForExistanceControlByPageType(int PageID, int PageTypeID)
        {
            BINROTA.DAL.Pages objPage = new BINROTA.DAL.Pages();
            objPage.PageID = PageID;
            objPage.PageTypeID = PageTypeID;
            objPage.isDeleted = false;
            return objPage.LoadByParams().Tables[0];
        }

        public static DataTable PageSearch(string SearchText, int PageCategoryID, int SubjectID)
        {
            return BINROTA.DAL.Pages.PageSearch("%" + SearchText + "%", PageCategoryID, SubjectID);
        }

        public static DataTable PageSearch(string SearchText, int PageCategoryID)
        {
            return BINROTA.DAL.Pages.PageSearch("%" + SearchText + "%", PageCategoryID);
        }

        public static DataTable PageSearchForSubject(string SearchText)
        {
            return BINROTA.DAL.Pages.PageSearchForSubject("%" + SearchText + "%");
        }

        public static DataTable GetPageAndMemberDetailBySubjectdIDAndPageTypeID(int SubjectID, Enumerations.PageType PageType, int PageCategoryID)
        {
            return BINROTA.DAL.Pages.GetPageAndMemberDetailBySubjectdIDAndPageTypeID(SubjectID, (int)PageType, PageCategoryID);
        }

        public static DataTable GetUserPages(int MemberID)
        {
            BINROTA.DAL.Pages objPage = new BINROTA.DAL.Pages();
            objPage.MemberID = MemberID;
            objPage.isDeleted = false;
            return objPage.LoadByParams().Tables[0];
        }

        public static DataTable GetUserPages(int MemberID, int PageTypeID)
        {
            return BINROTA.DAL.Pages.GetUserPages(MemberID, PageTypeID, false);
        }

        public static DataTable GetPageCountByPageCategoryID(int PageTypeID)
        {
            return BINROTA.DAL.Pages.GetPageCountByPageCategoryID(PageTypeID);
        }

        public static DataTable GetPageCountBySubjectID(int PageTypeID)
        {
            return BINROTA.DAL.Pages.GetPageCountBySubjectID(PageTypeID);
        }

        public static DataTable GetPageCountByPageTypeIDAndSubjectID(int PageTypeID, int SubjectID)
        {
            return BINROTA.DAL.Pages.GetPageCountByPageTypeIDAndSubjectID(PageTypeID, SubjectID);
        }

        public static DataTable GetLast5PagesRecorded(int PageTypeID)
        {
            return BINROTA.DAL.Pages.GetLast5PagesRecorded(PageTypeID);
        }

        public static DataTable GetLast5PagesRecorded(int PageTypeID, int SubjectID)
        {
            return BINROTA.DAL.Pages.GetLast5PagesRecorded(PageTypeID, SubjectID);
        }

        public static DataTable MemberHomePageLoad(int MemberID)
        {
            BINROTA.DAL.Pages objPage = new BINROTA.DAL.Pages();
            objPage.MemberID = MemberID;
            objPage.PageTypeID = (int)Enumerations.PageType.HomePage;
            objPage.isDeleted = false;
            return objPage.LoadByParams().Tables[0];
        }

        public static void MemberHomePageUpdate(int MemberID, string PageContent)
        {

            DataTable dt = BINROTA.BUS.Pages.GetUserPages(MemberID, (int)Enumerations.PageType.HomePage);
            if (dt.Rows.Count > 0)
            {
                int PageID = int.Parse(dt.Rows[0]["PageID"].ToString());
                BINROTA.DAL.Pages objPage = new BINROTA.DAL.Pages();
                objPage.Load(PageID);
                objPage.PageContent = PageContent;
                objPage.ModifyDate = DateTime.Now;
                objPage.ModifiedBy = MemberID;
                objPage.isDeleted = false;
                objPage.Save();
            }
            else
            {
                BINROTA.DAL.Pages objPage = new BINROTA.DAL.Pages();
                objPage.MemberID = MemberID;
                objPage.PageTypeID = (int)Enumerations.PageType.HomePage;
                objPage.PageContent = PageContent;
                objPage.CreateDate = DateTime.Now;
                objPage.ModifyDate = DateTime.Now;
                objPage.ModifiedBy = MemberID;
                objPage.isDeleted = false;
                objPage.Save();
            }
        }

    }
}
