using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Configuration;
using System.IO;
using System.Text;

namespace BINROTA.COM
{
    public class Common
    {
        public delegate void CommentAddClickHandler(string Header, int PageID);

        public static void ForumGotoDefaultPage(HttpResponse PageResponse)
        {
            PageResponse.Redirect("~/MainPageN.aspx");
        }
        public static void GotoDefaultPage()
        {
            System.Web.HttpContext.Current.Response.Redirect("MainPageN.aspx");
        }
        public static void GotoDefaultPage(HttpResponse PageResponse)
        {
            PageResponse.Redirect("~/MainPageN.aspx");
        }
        public static string ArrangeFilePath(Enumerations.FileUploadType UploadType, string FileDirectory)
        {
            string DirectoryPath = "";

            switch (UploadType)
            {
                case Enumerations.FileUploadType.ContentImages:
                    DirectoryPath = ConfigurationManager.AppSettings["ContentImagesPath"].ToString() + FileDirectory + "\\";

                    break;
                case Enumerations.FileUploadType.SubjectImages:
                    DirectoryPath = ConfigurationManager.AppSettings["SubjectImagesPath"].ToString() + FileDirectory + "\\";
                    break;
                case Enumerations.FileUploadType.ContentOtherImages:
                    DirectoryPath = ConfigurationManager.AppSettings["ContentOtherImagesPath"].ToString().Replace("||FileDirectory||", FileDirectory);
                    break;
                case Enumerations.FileUploadType.MemberImages:
                    DirectoryPath = ConfigurationManager.AppSettings["MemberImagesPath"].ToString() + FileDirectory + "\\";
                    break;
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(DirectoryPath);

            if (!directoryInfo.Exists)
                Directory.CreateDirectory(DirectoryPath);

            return DirectoryPath;
        }
        public static string ArrangeFileUrl(Enumerations.FileUploadType UploadType, string FileDirectory)
        {
            string Url = "";

            switch (UploadType)
            {
                case Enumerations.FileUploadType.ContentImages:
                    Url = ConfigurationManager.AppSettings["ContentImagesUrl"].ToString() + FileDirectory + "/";
                    break;

                case Enumerations.FileUploadType.SubjectImages:
                    Url = ConfigurationManager.AppSettings["SubjectImagesUrl"].ToString();
                    break;
                case Enumerations.FileUploadType.ContentOtherImages:
                    Url = ConfigurationManager.AppSettings["ContentOtherImagesUrl"].ToString().Replace("||FileDirectory||", FileDirectory);
                    break;
            }

            return Url;
        }
        public static string ReturnImagePath(string FileName, string ImagePath)
        {
            return "~/" + ImagePath + "/" + FileName;
        }
        public static string ReturnImagePathForContent(string FileName, string ImagePath)
        {
            return ImagePath + "/" + FileName;
        }
        public static bool DeleteImage(string FileName, string ImagePath)
        {
            try
            {
                if (File.Exists(ImagePath + FileName))
                {
                    File.Delete(ImagePath + FileName);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }


        }
        public static string ReturnPageReferrerName()
        {
            if (System.Web.HttpContext.Current.Request.UrlReferrer != null)
            {
                return System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.UrlReferrer.ToString());
            }
            else
            {
                return "MainPageN.aspx";
            }

            return null;
        }
        public static string ReturnStarsHtml(int Points)
        {
            StringBuilder sbStar = new StringBuilder();

            for (int i = 0; i < Points; i++)
            {
                sbStar.Append("<img src='Images/Icon/Star.png'>&nbsp;");
            }

            return sbStar.ToString();

        } 
        public static int GetWeeks(DateTime stdate, DateTime eddate)
        {

            TimeSpan t = eddate - stdate;
            int iDays;

            if (t.Days < 7)
            {
                if (stdate.DayOfWeek > eddate.DayOfWeek)
                    return 1; //It is accross the week 

                else
                    return 0; // same week
            }
            else
            {
                iDays = t.Days - 7 + (int)stdate.DayOfWeek;
                int i = 0;
                int k = 0;

                for (i = 1; k < iDays; i++)
                {
                    k += 7;
                }

                if (i > 1 && eddate.DayOfWeek != DayOfWeek.Sunday) i -= 1;
                return i;
            }
        }

        public static string ClearHtmlComments(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "&nbsp;", "");
        }

        public static double DateDiff(string datePart, DateTime startDate, DateTime endDate)
        {
            //Get the difference in terms of TimeSpan
            TimeSpan T;

            T = endDate - startDate;

            //Get the difference in terms of Month and Year.
            int sMonth, eMonth, sYear, eYear;
            sMonth = startDate.Month;
            eMonth = endDate.Month;
            sYear = startDate.Year;
            eYear = endDate.Year;
            double Months, Years = 0;
            Months = eMonth - sMonth;
            Years = eYear - sYear;
            Months = Months + (Years * 12);

            switch (datePart.ToUpper())
            {
                case "WW":
                case "DW":
                    return (double)GetWeeks(startDate, endDate);
                case "MM":
                    return Months;
                case "YY":
                case "YYYY":
                    return Years;
                case "QQ":
                case "QQQQ":
                    //Difference in Terms of Quater
                    return Math.Ceiling((double)T.Days / 90.0);
                case "MI":
                case "N":
                    return T.TotalMinutes;
                case "HH":
                    return T.TotalHours;
                case "SS":
                    return T.TotalSeconds;
                case "MS":
                    return T.TotalMilliseconds;
                case "DD":
                default:
                    return T.Days;
            }
        }
    }
}
