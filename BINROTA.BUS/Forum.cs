using System;
using System.Collections.Generic;
using System.Text;
using BINROTA.DAL ;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Web.Mail; 
using BINROTA.COM;

namespace BINROTA.BUS
{
    public class Forum
    {
        #region Enumarations
        public enum ItemType
        {
            Category,
            Article,
            ArticleItem
        }
        public enum CategoryStatus
        {
            All=0,
            Active=1,
            Deactive=2
        }
        public enum ArticleItemStatus
        {
            All = 0,
            Active = 1,
            Deactive = 2
        }
        public enum ArticleStatus
        {
            NotAnswered = 0,
            Answered=1,
            Locked = 2,
            Active = 3,
            Deactive = 4,
            All = 5
        }
        #endregion

        #region Other
        public static string[] CategoryStatusDesc = new string[3] { "Hepsi", "Aktif", "Pasif"};
        public static string[] ArticleStatusDesc = new string[6] { "Cevaplanmadý", "Cevaplandý", "Kilitli", "Aktif", "Pasif", "Hepsi" };
        public static string[] ArticleItemStatusDesc = new string[3] {"Hepsi","Aktif","Pasif"};
        public static int ItemMaxPoints = 5;
        public static string LastPostTemplate = "||Date||<br>by <a href=\"../MemberPage.aspx?MemberID=||MemberID||\" class=\"ForumLink\"><b>||NickName||</b></a>";
        public static string ReplyTemplate = "<table width=\"85%\" align=\"center\" cellspacing=\"0\" cellpading=\"0\" border=\"0\"><tr><td class=\"FText12\"><hr></td></tr><tr><td><img src=\"images/icon1.gif\" border=\"0\" ><span class=\"FText11\">||TITLE||</span><br /><br />||CONTENT||</td></tr><tr><td><hr></td></tr></table>";   
        public static void GotoDefaultPage(HttpResponse response)
        {
            response.Redirect("Forum.aspx");
        }
        public static void CheckLogin(bool IsMember,HttpResponse response)
        {
            if (!IsMember)
                response.Redirect("Login.aspx");
        }
        public static DataTable GetItemStates(ItemType type,bool isAdmin)
        {
            DataTable dtStates = new DataTable();
            dtStates.Columns.Add("Text");
            dtStates.Columns.Add("Value");

            DataRow dr = null;
            switch (type)
            {
                case ItemType.Category:

                    dr = dtStates.NewRow();
                    dr["Text"]="Aktif";
                    dr["Value"]=((int)CategoryStatus.Active).ToString();
                    dtStates.Rows.Add(dr);

                    dr = dtStates.NewRow();
                    dr["Text"] = "Pasif";
                    dr["Value"] = ((int)CategoryStatus.Deactive).ToString();
                    dtStates.Rows.Add(dr);

                    break;
                case ItemType.Article:
        
                    dr = dtStates.NewRow();
                    dr["Text"] = "Cevaplanmadý";
                    dr["Value"] = ((int)ArticleStatus.NotAnswered).ToString();
                    dtStates.Rows.Add(dr);

                    dr = dtStates.NewRow();
                    dr["Text"] = "Cevaplandý";
                    dr["Value"] = ((int)ArticleStatus.Answered).ToString();
                    dtStates.Rows.Add(dr);

                    dr = dtStates.NewRow();
                    dr["Text"] = "Kilitli";
                    dr["Value"] = ((int)ArticleStatus.Locked).ToString();
                    dtStates.Rows.Add(dr);
                    
                    if (isAdmin)
                    {
                        dr = dtStates.NewRow();
                        dr["Text"] = "Pasif";
                        dr["Value"] = ((int)ArticleStatus.Deactive).ToString();
                        dtStates.Rows.Add(dr);
                    }

                    break;
                case ItemType.ArticleItem:

                    dr = dtStates.NewRow();
                    dr["Text"] = "Aktif";
                    dr["Value"] = ((int)ArticleItemStatus.Active).ToString();
                    dtStates.Rows.Add(dr);

                    dr = dtStates.NewRow();
                    dr["Text"] = "Pasif";
                    dr["Value"] = ((int)ArticleItemStatus.Deactive).ToString();
                    dtStates.Rows.Add(dr);

                    break;
            }

            return dtStates;
        }
        public static string Reply(string Title, string Content)
        {
            return ReplyTemplate.Replace("||TITLE||", Title).Replace("||CONTENT||",Content);
        }
        #endregion

        #region Categories
        public static string GetCategoryStatusDesc(CategoryStatus status)
        {
            return CategoryStatusDesc[(int)status];
        }
        public static string GetCategoryTypeImgUrl(CategoryStatus status)
        {
            if (status == CategoryStatus.Active)
                return "images/on.gif";
            else if (status == CategoryStatus.Deactive)
                return "images/off.gif";

            return "";
        }
        public static DataTable GetCategories(CategoryStatus status)
        {
            ForumCategory FCategory = new ForumCategory();
            
            if(status!= CategoryStatus.All)
                FCategory.CategoryStatus = (int)status;

            DataTable dt = FCategory.LoadByParams().Tables[0];
            dt.DefaultView.Sort = "Order ASC";
            dt = dt.DefaultView.ToTable();

            return dt;
        }
        public static DataTable GetCategory(int CategoryID)
        {
            ForumCategory mCategory = new ForumCategory();
            mCategory.CategoryID = CategoryID;

            DataTable dt = mCategory.LoadByParams().Tables[0];
            dt.DefaultView.Sort = "Order ASC";
            dt = dt.DefaultView.ToTable();

            return dt;
        }
        public static bool GetCategoryName(int CategoryID,ref string CategoryName)
        {
            ForumCategory mCategory = new ForumCategory();

            if (mCategory.Load(CategoryID))
            {
                CategoryName = mCategory.CategoryName;
                return true;
            }

            return false;
        }
        public static int InsertCategory(string CategoryName,string CategoryDesc,CategoryStatus status,int UserID)
        {
            ForumCategory mCategory = new ForumCategory();

            mCategory.CategoryName = CategoryName;
            mCategory.CategoryDesc = CategoryDesc;
            mCategory.CategoryStatus = (int)status;
            mCategory.CreateDate = DateTime.Now;
            mCategory.LastPost = "Yazý yok ...";
            mCategory.CreatedBy = UserID;
            mCategory.ArticlesCount = 0;

            mCategory.Save();

            return mCategory.CategoryID;
        }
        public static void UpdateCategory(int CategoryID,string CategoryName, string CategoryDesc, CategoryStatus status)
        {
            ForumCategory mCategory = new ForumCategory();
            mCategory.Load(CategoryID);

            mCategory.CategoryName = CategoryName;
            mCategory.CategoryDesc = CategoryDesc;
            mCategory.CategoryStatus = (int)status;

            mCategory.Save();
        }
        public static void DeleteCategory(int CategoryID)
        {
            ForumCategory mCategory=new ForumCategory();
            mCategory.CategoryID = CategoryID;
            mCategory.CustomDelete();
        }
        public static void UpdateCategoryOrder(DataTable dtOrders)
        {
            for (int i = 0; i < dtOrders.Rows.Count; i++)
            {
                ForumCategory.UpdateCategoryOrder(int.Parse(dtOrders.Rows[i]["CategoryID"].ToString()), int.Parse(dtOrders.Rows[i]["Order"].ToString()));
            }
        }
        #endregion

        #region Articles
        public static ArticleStatus GetArticleStatus(int ArticleID)
        {
            ForumArticle mArticle = new ForumArticle();

            if (mArticle.Load(ArticleID))
            {
                return (ArticleStatus) mArticle.ArticleStatus;
            }

            return ArticleStatus.Active;
        }
        public static DataTable GetArticle(int ArticleID)
        {
            ForumArticle mArticle = new ForumArticle();
            mArticle.ArticleID = ArticleID;

            return mArticle.LoadByParams().Tables[0];
        }
        public static string GetArticleStatusDesc(ArticleStatus status)
        {
            return ArticleStatusDesc[(int)status];
        }
        public static DataTable GetArticleTitles(int ArticleID)
        {
            return ForumArticle.GetArticlesTitles(ArticleID);   
        }
        public static DataTable GetAllArticlesStatusDescForUser()
        {
            DataTable dtStatus = new DataTable();

            dtStatus.Columns.Add("Text");
            dtStatus.Columns.Add("Value");

            for (int i = 0; i < (int) ArticleStatus.Locked; i++)
            {
                DataRow dr = dtStatus.NewRow();

                dr["Text"] = ArticleStatusDesc[i];
                dr["Value"] = i.ToString();

                dtStatus.Rows.Add(dr);
            }

            return dtStatus;
        }
        public static DataTable GetAllArticlesStatusDescForAdmin()
        {
            DataTable dtStatus = new DataTable();

            dtStatus.Columns.Add("Text");
            dtStatus.Columns.Add("Value");

            for (int i = 0; i < ArticleStatusDesc.Length; i++)
            {
                DataRow dr = dtStatus.NewRow();

                dr["Text"] = ArticleStatusDesc[i];
                dr["Value"] = i.ToString();

                dtStatus.Rows.Add(dr);
            }

            return dtStatus;
        }
        public static DataTable GetArticles(int CategoryID, ArticleStatus status)
        {
            ForumArticle mArticles = new ForumArticle();
            mArticles.CategoryID = CategoryID;
            mArticles.ArticleStatus = (int)status;

            return mArticles.LoadArticlesByParams().Tables[0]; 
        }
        public static void UpdateArticleStatus(int ArticleID, ArticleStatus status)
        {
            ForumArticle mArticle = new ForumArticle();
            mArticle.Load(ArticleID);

            mArticle.ArticleStatus = (int)status;
            mArticle.Save();
        }
        public static int InsertArticle(string Subject, string Message, ArticleStatus status, int CategoryID, int UserID,string NickName)
        {
            SqlConnection conn = CARETTA.DBI.DBHelper.getConnection();
            conn.Open();

            SqlTransaction Tran = conn.BeginTransaction(IsolationLevel.Serializable);

            int ArticleID;
            try
            {
                DateTime CreateDate = DateTime.Now;
                string LastPost = LastPostTemplate.Replace("||MemberID||", UserID.ToString()).Replace("||NickName||", NickName).Replace("||Date||", CreateDate.ToShortDateString() + " " + CreateDate.ToShortTimeString());

                ForumArticle mArticle = new ForumArticle();
                mArticle.ArticleSubject = Subject;
                mArticle.ArticleMessage = Message;
                mArticle.ArticleStatus = (int)status;
                mArticle.CategoryID = CategoryID;
                mArticle.CreatedBy = UserID;
                mArticle.Replies = 0;
                mArticle.LastPost = LastPost;
                mArticle.LastPostDate = CreateDate;
                mArticle.CreateDate = CreateDate;
                mArticle.Save(); 
                ArticleID=mArticle.ArticleID; 

                ForumCategory mCategory=new ForumCategory();
                mCategory.Load(CategoryID);
                mCategory.LastPost = LastPost;
                mCategory.LastPostDate = CreateDate;
                mCategory.ArticlesCount += 1;
                mCategory.Save();

                ForumArticleItems mItem = new ForumArticleItems();
                mItem.ArticleID = mArticle.ArticleID;
                mItem.CreateDate = CreateDate;
                mItem.CreatedBy = UserID;
                mItem.Reply = Message;
                mItem.Subject = Subject;
                mItem.Score = 0;
                mItem.ScoreCount = 0;
                mItem.Status = (int)ArticleItemStatus.Active;
                mItem.Save();


                Tran.Commit();
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }

            return ArticleID;
        }
        public static void UpdateArticle(int ArticleID,string Subject, string Message, ArticleStatus status, int CategoryID)
        {
            SqlConnection conn = CARETTA.DBI.DBHelper.getConnection();
            conn.Open();

            SqlTransaction Tran = conn.BeginTransaction(IsolationLevel.Serializable);

            try
            { 
                ForumArticle mArticle = new ForumArticle();
                if (mArticle.Load(ArticleID))
                {
                    bool CategoryChanged = false;
                    int OldCategoryID=0;
                    if (mArticle.CategoryID != CategoryID)
                    {
                        CategoryChanged = true;
                        OldCategoryID=mArticle.CategoryID;
                    }

                    bool StatusChanged = false;
                    if (mArticle.ArticleStatus != (int)status)
                    {
                        StatusChanged = true;
                    }

                    bool SyncNeeded = false;
                    if (mArticle.ArticleSubject != Subject || mArticle.ArticleMessage != Message)
                    {
                        SyncNeeded = true;
                    }

                    mArticle.ArticleSubject = Subject;
                    mArticle.ArticleMessage = Message;
                    mArticle.ArticleStatus = (int)status;
                    mArticle.CategoryID = CategoryID;
                    mArticle.Save();

                    if (CategoryChanged)
                    {
                        ForumArticle.CategoryChange(OldCategoryID, CategoryID);
                    }

                    if (SyncNeeded)
                    {
                        ForumArticle.SyncMainItem(ArticleID,Subject,Message);
                    }

                    if (StatusChanged && (!CategoryChanged))
                        ForumCategory.ArrangeCategory(CategoryID);

                    Tran.Commit();
                }
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public static void DeleteArticle(int ArticleID)
        {
            ForumArticle mArticle = new ForumArticle();
            mArticle.ArticleID = ArticleID;
            mArticle.CustomDelete();
        }
        #endregion

        #region ArticleItems
        public static string GetArticleItemStatusDesc(ArticleItemStatus status)
        {
            return ArticleItemStatusDesc[(int)status];
        }
        public static void GivePoint(int ArticleItemID, int Score)
        {
            ForumArticleItems mItem = new ForumArticleItems();
            
            if (mItem.Load(ArticleItemID))
            {
                mItem.Score += Score;
                mItem.ScoreCount += 1;
                mItem.Save();
            }
        }
        public static DataTable GetArticleItem(int ArticleItemID)
        {
            ForumArticleItems mArticleItem = new ForumArticleItems();
            mArticleItem.ArticleItemID = ArticleItemID;

            return mArticleItem.LoadByParams().Tables[0];
        }
        public static DataTable GetArticleItems(int ArticleID, ArticleItemStatus status)
        {
            ForumArticleItems FAItems = new ForumArticleItems();

            if (status != ArticleItemStatus.All)
                FAItems.Status = (int)status;

            FAItems.ArticleID = ArticleID;

            return FAItems.LoadItemsByParams().Tables[0];
        }
        public static DataTable GetItemScores()
        {
            DataTable dtPoints = new DataTable();
            dtPoints.Columns.Add("Text");
            dtPoints.Columns.Add("Value");

            for (int i = 5; i >0; i--)
            {
                DataRow dr = dtPoints.NewRow();
                dr["Text"] = i.ToString();
                dr["Value"] = i.ToString();

                dtPoints.Rows.Add(dr);
            }

            return dtPoints;
        }
        public static int InsertArticleItem(int CategoryID,int ArticleID,string Subject,string Reply,ArticleItemStatus status,int UserID,string NickName)
        {
            SqlConnection conn = CARETTA.DBI.DBHelper.getConnection();
            conn.Open();

            SqlTransaction Tran = conn.BeginTransaction(IsolationLevel.Serializable);

            int ArticleItemID;
            try
            {
                DateTime CreateDate = DateTime.Now;
                string LastPost = LastPostTemplate.Replace("||MemberID||", UserID.ToString()).Replace("||NickName||", NickName).Replace("||Date||", CreateDate.ToShortDateString() + " " + CreateDate.ToShortTimeString());

                ForumArticleItems mArticleItem = new ForumArticleItems();
                mArticleItem.ArticleID  = ArticleID;
                mArticleItem.CreateDate  = CreateDate;
                mArticleItem.CreatedBy = UserID;
                mArticleItem.Reply  = Reply;
                mArticleItem.Score = 0;
                mArticleItem.ScoreCount = 0;
                mArticleItem.Status = (int)status;
                mArticleItem.Subject = Subject;
                mArticleItem.Save();
                ArticleItemID = mArticleItem.ArticleItemID;

                ForumArticle mArticle = new ForumArticle();
                mArticle.Load(ArticleID);
                mArticle.LastPost = LastPost;
                mArticle.LastPostDate = CreateDate;
                mArticle.Replies += 1;
                mArticle.Save();

                ForumCategory mCategory = new ForumCategory();
                mCategory.Load(CategoryID);
                mCategory.LastPost = LastPost;
                mCategory.LastPostDate = CreateDate;
                mCategory.Save();

                Tran.Commit();
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }

            return ArticleItemID;

        }
        public static void UpdateArticleItem(int ArticleItemID, string Subject, string Reply, ArticleItemStatus status)
        {
            SqlConnection conn = CARETTA.DBI.DBHelper.getConnection();
            conn.Open();

            SqlTransaction Tran = conn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                ForumArticleItems mArticleItem = new ForumArticleItems();
                mArticleItem.Load(ArticleItemID);

                bool StatusChanged = false;
                if (mArticleItem.Status != (int)status)
                    StatusChanged = true;

                mArticleItem.Reply = Reply;
                mArticleItem.Status = (int)status;
                mArticleItem.Subject = Subject;
                mArticleItem.Save();

                if (StatusChanged)
                    ForumArticle.ArrangeArticle(mArticleItem.ArticleID);

                Tran.Commit();
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }

        }
        public static void UpdateArticleItem(int ArticleItemID,int ArticleID, string Subject, string Reply, ArticleItemStatus status)
        {
            SqlConnection conn = CARETTA.DBI.DBHelper.getConnection();
            conn.Open();

            SqlTransaction Tran = conn.BeginTransaction(IsolationLevel.Serializable);
 
            try
            { 
                ForumArticleItems mArticleItem = new ForumArticleItems();
                mArticleItem.Load(ArticleItemID);

                bool StatusChanged = false;
                if (mArticleItem.Status != (int)status)
                    StatusChanged = true;
                
                mArticleItem.Reply = Reply;
                mArticleItem.Status = (int)status;
                mArticleItem.Subject = Subject;
                mArticleItem.Save();

                ForumArticle mArticle = new ForumArticle();
                mArticle.Load(ArticleID);
                mArticle.ArticleMessage = Reply;
                mArticle.ArticleSubject = Subject;
                mArticle.Save();

                if (StatusChanged)
                    ForumArticle.ArrangeArticle(mArticleItem.ArticleID);
                
                Tran.Commit();
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }

        }
        public static void DeleteArticleItem(int ArticleItemID)
        {
            ForumArticleItems mArticleItems = new ForumArticleItems();
            mArticleItems.ArticleItemID = ArticleItemID;
            mArticleItems.CustomDelete();
        }
        #endregion
    }
}
