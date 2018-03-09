using System;

    public class Enumerations
    {
        public enum PhotoType
        {
            Album=0,
            Photo=1
        }

        public enum ForumCategoryStatus
        {
            Closed = 0,
            Active = 1
        }

        public enum ForumArticleStatus
        {
            Closed = 0,
            Active = 1,
            Solved = 2
        }

        public enum SaveMode
        {
            Insert = 0,
            Update = 1
        }

        public enum SubjectType
        {
            Kita = 1,
            Ulke = 2,
            Sehir = 3,
            Bolge = 4
        }

        public enum SubjectInsertResult
        {
            Success = 0,
            AlreadyExist = 1,
            Failure = 2
        }

        public enum LoginType
        {
            Member = 1,
            User = 2
        }

        public enum RememberType
        {
            EmailAndPassword = 0,
            Email = 1,
            NoRemember = 2
        }

        public enum MemberType
        {
            NewMember = 1,
            Moderator = 2,
            SuperModerator = 3
        }

        public enum PageType
        {
            HomePage = 1,
            TravelPage = 2,
            TravelCategoryPage = 3
        }

        public enum FileUploadType
        {
            ContentImages = 0,
            ContentOtherImages = 1,
            SubjectImages = 2,
            MemberImages = 3,
            MemberAlbumImagesSmall = 4,
            MemberAlbumImagesBig = 5,
            ActivityImages = 6
        }

        public enum MarketingGroups
        {
            OnPlanaCikarilmakIstenenYerler = 4
        }

        public enum PageCommentStatus
        {
            WaitingApproved = 0,
            Approved = 1
        }

        public enum ActivityType
        {
            News = 1,
            Activity = 2
        }

        public enum MemberRegisterControl
        {
            Success = 0,
            NickNameExist = 1,
            EmailExist = 2
        }

        public enum ContinentSubjectID
        {
            Avrupa = 82,
            Asya = 102,
            Afrika = 103,
            GuneyAmerika = 151,
            KuzeyAmerika = 150,
            Okyanusya = 152
        }

        public enum PageLoadType
        {
            Member = 1,
            Visitor = 2
        }

        public enum SearchType
        {
            SearchByText = 1,
            SearchByCategoryID = 2,
            SearchBySubjectID = 3,
            SearchByTextCategoryIDSubjectID = 4,
        }
    }