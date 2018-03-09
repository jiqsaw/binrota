using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace BINROTA.BUS
{
    public class PagePoints
    {
        public static bool PagePointsInsert(int PageID, int MemberID, int Points)
        {
            BINROTA.DAL.PagePoints objPagePoint = new BINROTA.DAL.PagePoints();
            objPagePoint.PageID = PageID;
            objPagePoint.MemberID = MemberID;
            if (MemberID != 0)
            {
                if (objPagePoint.LoadByParams().Tables[0].Rows.Count > 0)
                {
                    return false;
                }
            }
            objPagePoint.Points = Points;
            objPagePoint.Save();
            return true;
        }
    }
}
