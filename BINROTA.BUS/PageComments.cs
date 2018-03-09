using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BINROTA.DAL;
using CARETTA.COM;
using BINROTA.COM; 

namespace BINROTA.BUS
{
    public class PageComments
    {
        public static void PageCommnetInsert(int MemberID, int PageID, string Comment, int Point, int Status)
        {
            BINROTA.DAL.PageComments objPageCom = new BINROTA.DAL.PageComments();
            objPageCom.MemberID = MemberID;
            objPageCom.PageID = PageID;
            objPageCom.Comment = Comment;
            objPageCom.Point = Point;
            objPageCom.Status = Status; 
            objPageCom.Save();
        }

        public static void PageCommentUpdate(int PageCommentID, string Comment, int Point)
        {
            BINROTA.DAL.PageComments objPageCom = new BINROTA.DAL.PageComments();
            objPageCom.Load(PageCommentID);
            objPageCom.Comment = Comment;
            objPageCom.Point = Point;
            objPageCom.Save();
        }

        public static void PageCommentUpdate(int PageCommentID, int Status)
        {
            BINROTA.DAL.PageComments objPageCom = new BINROTA.DAL.PageComments();
            objPageCom.Load(PageCommentID);
            objPageCom.Status = Status;
            objPageCom.Save();
        }

        //public static DataTable GetPageComments(int PageID)
        //{
        //    BINROTA.DAL.PageComments objPageCom = new BINROTA.DAL.PageComments();
        //    objPageCom.PageID = PageID;
        //    return objPageCom.LoadByParams().Tables[0];
        //}

        public static DataTable GetPageComments(int PageID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = BINROTA.DAL.PageComments.GetPageComments(PageID);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public static DataTable GetMemberComments(int MemberID)
        {
            BINROTA.DAL.PageComments objPageCom = new BINROTA.DAL.PageComments();
            objPageCom.MemberID = MemberID;
            return objPageCom.LoadByParams().Tables[0];
        }

    }
}
