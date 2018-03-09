using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing;
using BINROTA.COM;

public partial class UserControls_uctrlImageUpload : BaseUserControl
{

    #region Properties
    public string FileName
    {
        get
        {
            return fupImg.FileName;
        }
    }
    public Enumerations.FileUploadType UploadType
    {
        get
        {
            return (ViewState["UpT"] == null ? Enumerations.FileUploadType.ContentImages : (Enumerations.FileUploadType)(ViewState["UpT"]));
        }
        set
        {
            ViewState["UpT"] = value;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["FileUploadType"] != null)
                if(Request.QueryString["FileUploadType"].ToString() == Enumerations.FileUploadType.MemberImages.ToString())
                    this.UploadType = Enumerations.FileUploadType.MemberImages;
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (this.UploadType == Enumerations.FileUploadType.MemberImages)
        {
            DataTable dt = BINROTA.BUS.Members.GetMemberDetailsByMemberID(SessRoot.UserID);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["PhotoPath"].ToString() != "")
                {
                    Common.DeleteImage(dt.Rows[0]["PhotoPath"].ToString(), Request.MapPath(ConfigurationManager.AppSettings["MemberImagesPath"].ToString()));
                }
            }
            string AddedFileName = SendFile("");
            BINROTA.BUS.Members.MemberPortraitUpdate(SessRoot.UserID, AddedFileName);
        }
        else
        {
            SendFile("");
        }
    }

    public string SendFile(string DirectoryName)
    {
        try
        {


            if (fupImg.HasFile)
            {
                string FilePath = "";
                string TempFilePath = Request.MapPath(ConfigurationManager.AppSettings["TempImagesPath"].ToString());

                switch (this.UploadType)
                {
                    case Enumerations.FileUploadType.ContentImages:
                        FilePath = Request.MapPath(ConfigurationManager.AppSettings["ContentImagesPath"].ToString());

                        break;
                    case Enumerations.FileUploadType.SubjectImages:
                        FilePath = Request.MapPath(ConfigurationManager.AppSettings["SubjectImagesPath"].ToString());

                        break;
                    case Enumerations.FileUploadType.ContentOtherImages:
                        FilePath = Common.ArrangeFilePath(UploadType, DirectoryName);

                        break;
                    case Enumerations.FileUploadType.MemberImages:
                        FilePath = Request.MapPath(ConfigurationManager.AppSettings["MemberImagesPath"].ToString());

                        break;
                    case Enumerations.FileUploadType.MemberAlbumImagesSmall:
                        FilePath = Request.MapPath(ConfigurationManager.AppSettings["MemberAlbumImagesPathSmall"].ToString());

                        break;
                    case Enumerations.FileUploadType.MemberAlbumImagesBig:
                        FilePath = Request.MapPath(ConfigurationManager.AppSettings["MemberAlbumImagesPathBig"].ToString());

                        break;
                    case Enumerations.FileUploadType.ActivityImages:
                        FilePath = Request.MapPath(ConfigurationManager.AppSettings["ActivityImagesPath"].ToString());

                        break;
                }

                string FileName = fupImg.FileName;
                string FileUrl = Common.ArrangeFileUrl(UploadType, DirectoryName);
                string FileSmallName = "";
                string FileExtention = "";

                int iPoint = FileName.LastIndexOf(".");

                if (iPoint != -1)
                {
                    FileExtention = FileName.Substring(iPoint);
                    FileSmallName = FileName.Substring(0, iPoint);

                    if (FileName.Substring(iPoint + 1) == ".exe")
                    {
                        lblStatus.Text = ".exe uzantýlý dosya gönderemezsiniz.";
                        return "";
                    }
                }
                if (this.UploadType == Enumerations.FileUploadType.ContentImages || this.UploadType == Enumerations.FileUploadType.MemberAlbumImagesBig || this.UploadType == Enumerations.FileUploadType.MemberAlbumImagesSmall)
                {
                    FileSmallName = SessRoot.UserID.ToString();
                    FileName = SessRoot.UserID.ToString() + FileExtention;
                }

                if (fupImg.PostedFile.ContentLength > 10240000)
                {
                    lblStatus.Text = "10 mb boyutundan büyük boyutta dosya gönderemezsiniz.";
                    return "";
                }

                int verNum = 1;
                while (System.IO.File.Exists(FilePath + FileName))
                {
                    FileName = FileSmallName + "_" + verNum.ToString() + FileExtention;
                    verNum += 1;
                }

                fupImg.SaveAs(TempFilePath + ("Temp" + FileName));
                ChangeSize(TempFilePath + ("Temp" + FileName), FilePath + FileName);
                if (this.UploadType == Enumerations.FileUploadType.MemberAlbumImagesSmall)
                {
                    FilePath = Request.MapPath(ConfigurationManager.AppSettings["MemberAlbumImagesPathSmall"].ToString());
                    while (System.IO.File.Exists(FilePath + FileName))
                    {
                        FileName = FileSmallName + "_" + verNum.ToString() + FileExtention;
                        verNum += 1;
                    }
                    ChangeSize(TempFilePath + ("Temp" + FileName), FilePath + FileName);
                    this.UploadType = Enumerations.FileUploadType.MemberAlbumImagesBig;
                }
                BINROTA.COM.Common.DeleteImage(("Temp" + FileName), TempFilePath);

                if (UploadType == Enumerations.FileUploadType.ContentImages)
                {
                    UseImage(Common.ReturnImagePathForContent(FileName, ConfigurationManager.AppSettings["ContentImagesUrl"].ToString()));
                }
                else
                    if (UploadType == Enumerations.FileUploadType.MemberImages)
                    {
                        Response.Write("<script>window.opener.location.reload()</script>");
                    }
                return FileName;
            }

            return "";
        }
        catch (Exception)
        {
            return "";
        }
    }
    private void UseImage(string ImageUrl)
    {
        string jScript = "";
        jScript += "<script>";
        jScript += "imageLink = '<img src=\" " + ImageUrl + "\"/>';";
        jScript += "window.opener.FTB_API['" + Request.QueryString["ftbID"].ToString() + "'].InsertHtml(imageLink);";
        jScript += "this.focus();";
        jScript += "this.close();";
        jScript += "</script>";

        Response.Write(jScript);
    }

    #region Image Size Changing Functions
    System.Drawing.Image imgConverted = null;
    private void ChangeSize(string SourceFilePath, string DestFilePath)
    {
        if (System.IO.File.Exists(SourceFilePath))
            if (!System.IO.File.Exists(DestFilePath))
            {
                FromFile(SourceFilePath);
                Convert();
                ToFile(DestFilePath);

            }
    }

    private void FromFile(string filePath)
    {
        System.IO.FileStream fs = new System.IO.FileStream(filePath, FileMode.Open, FileAccess.Read);
        byte[] imgData = new byte[fs.Length];

        try
        {
            fs.Read(imgData, 0, int.Parse(fs.Length.ToString()));
            fs.Close();

            imgConverted = System.Drawing.Image.FromStream(new MemoryStream(imgData));
        }
        catch (Exception)
        {
        }
    }

    private void ToFile( string filePath)
    {
        MemoryStream ms = new MemoryStream();

        imgConverted.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        byte[] imgData = new byte[ms.Length];

        ms.Position = 0;
        ms.Read(imgData, 0, (int)ms.Length);

        FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);

        try
        {
            fs.Write(imgData, 0, int.Parse(ms.Length.ToString()));
            fs.Close();
        }
        catch (Exception)
        {
        }
    }

    private void Convert()
    {
        bool blnKeepAspectRation;
        bool blnFactorToWidth;
        decimal decFactor = 0;
        string strHeight;
        string strWidth;
        int intOriginalHeight;
        int intOriginalWidth;
        int intNewWidth;
        int intNewHeight;
        System.Drawing.Image imgNewImage;

        intOriginalHeight = imgConverted.Height;
        intOriginalWidth = imgConverted.Width;

        strWidth = "*";
        strHeight = "*";

        blnKeepAspectRation = false;
        blnFactorToWidth = false;


        switch (this.UploadType)
        {
            case Enumerations.FileUploadType.ContentImages:
                if (intOriginalWidth > int.Parse(ConfigurationManager.AppSettings["ContentWidth"].ToString()))
                { strWidth = ConfigurationManager.AppSettings["ContentWidth"].ToString(); }
                else if (intOriginalHeight > int.Parse(ConfigurationManager.AppSettings["ContentHeight"].ToString()))
                { strHeight = ConfigurationManager.AppSettings["ContentHeight"].ToString(); }

                break;
            case Enumerations.FileUploadType.SubjectImages:
                if (intOriginalWidth > int.Parse(ConfigurationManager.AppSettings["SubjectWidth"].ToString()))
                    {
                        int TestingHeight = 0;
                        decimal TestingdecFactor = 0;
                        strWidth = ConfigurationManager.AppSettings["SubjectWidth"].ToString();
                        TestingdecFactor = decimal.Parse(strWidth) / decimal.Parse(imgConverted.Width.ToString());
                        TestingHeight = (int)Math.Floor(intOriginalHeight * TestingdecFactor);
                        if (TestingHeight > int.Parse(ConfigurationManager.AppSettings["SubjectHeight"].ToString()))
                        {
                            strWidth = "*";
                            strHeight = ConfigurationManager.AppSettings["SubjectHeight"].ToString(); ;
                        }
                    }
                    else if (intOriginalHeight > int.Parse(ConfigurationManager.AppSettings["SubjectHeight"].ToString()))
                    {
                        strHeight = ConfigurationManager.AppSettings["SubjectHeight"].ToString();
                    }
                
                break;
            case Enumerations.FileUploadType.ContentOtherImages:

                break;
            case Enumerations.FileUploadType.MemberImages:
                {
                    if (intOriginalWidth > int.Parse(ConfigurationManager.AppSettings["MemberPortraitWidth"].ToString()))
                    { strWidth = ConfigurationManager.AppSettings["MemberPortraitWidth"].ToString(); }
                    else if (intOriginalHeight > int.Parse(ConfigurationManager.AppSettings["MemberPortraitHeight"].ToString()))
                    {
                        strHeight = ConfigurationManager.AppSettings["MemberPortraitHeight"].ToString();
                    }
                }
                break;
            case Enumerations.FileUploadType.MemberAlbumImagesSmall:
                if (intOriginalWidth > int.Parse(ConfigurationManager.AppSettings["MemberAlbumPhotoSmallWidth"].ToString()))
                {
                    int TestingHeight = 0;
                    decimal TestingdecFactor = 0;
                    strWidth = ConfigurationManager.AppSettings["MemberAlbumPhotoSmallWidth"].ToString();
                    TestingdecFactor = decimal.Parse(strWidth) / decimal.Parse(imgConverted.Width.ToString());
                    TestingHeight = (int)Math.Floor(intOriginalHeight * TestingdecFactor);
                    if (TestingHeight > int.Parse(ConfigurationManager.AppSettings["MemberAlbumPhotoSmallHeigth"].ToString()))
                    {
                        strWidth = "*";
                        strHeight = ConfigurationManager.AppSettings["MemberAlbumPhotoSmallHeigth"].ToString();
                    }
                }
                else if (intOriginalHeight > int.Parse(ConfigurationManager.AppSettings["MemberAlbumPhotoSmallHeigth"].ToString()))
                {
                    strHeight = ConfigurationManager.AppSettings["MemberAlbumPhotoSmallHeigth"].ToString();
                }
                break;
            case Enumerations.FileUploadType.MemberAlbumImagesBig:
                if (intOriginalWidth > int.Parse(ConfigurationManager.AppSettings["MemberAlbumPhotoBigWidth"].ToString()))
                { strWidth = ConfigurationManager.AppSettings["MemberAlbumPhotoBigWidth"].ToString(); }
                else if (intOriginalHeight > int.Parse(ConfigurationManager.AppSettings["MemberAlbumPhotoSmallHeigth"].ToString()))
                {
                    strHeight = ConfigurationManager.AppSettings["MemberAlbumPhotoSmallHeigth"].ToString();
                }
                this.UploadType = Enumerations.FileUploadType.MemberAlbumImagesSmall;

                break;

            case Enumerations.FileUploadType.ActivityImages:
                
                if (intOriginalWidth > int.Parse(ConfigurationManager.AppSettings["ActivityImagesWidth"].ToString()))
                {
                    int TestingHeight = 0;
                    decimal TestingdecFactor = 0;
                    strWidth = ConfigurationManager.AppSettings["ActivityImagesWidth"].ToString();
                    TestingdecFactor = decimal.Parse(strWidth) / decimal.Parse(imgConverted.Width.ToString());
                    TestingHeight = (int)Math.Floor(intOriginalHeight * TestingdecFactor);
                    if (TestingHeight > int.Parse(ConfigurationManager.AppSettings["ActivityImagesHeight"].ToString()))
                    {
                        strWidth = "*";
                        strHeight = ConfigurationManager.AppSettings["ActivityImagesHeight"].ToString();
                    }
                }
                else if (intOriginalHeight > int.Parse(ConfigurationManager.AppSettings["ActivityImagesHeight"].ToString()))
                {
                    strHeight = ConfigurationManager.AppSettings["ActivityImagesHeight"].ToString();
                }

                break;
        }

        if (!(strWidth == "*") & !(strHeight == "*"))
        {
            //Width Önemli deðil Height'a göre factor edilecek
            blnKeepAspectRation = false;
        }
        else if (!(strWidth == "*"))
        {
            blnFactorToWidth = true;
            decFactor = decimal.Parse(strWidth) / decimal.Parse(imgConverted.Width.ToString());
            blnKeepAspectRation = true;
        }
        //Width belli
        else if (!(strHeight == "*"))
        {
            blnFactorToWidth = false;
            decFactor = decimal.Parse(strHeight) / decimal.Parse(imgConverted.Height.ToString());
            blnKeepAspectRation = true;
        }

        if (blnKeepAspectRation)
        {
            if (blnFactorToWidth)
            {
                intNewWidth = int.Parse(strWidth);
                intNewHeight = (int)Math.Floor(intOriginalHeight * decFactor);
            }
            else
            {
                intNewWidth = (int)Math.Floor(intOriginalWidth * decFactor);
                intNewHeight = int.Parse(strHeight);
            }
        }
        else
        {
            //img = New Bitmap(img, New Size(CInt(strWidth), CInt(strHeight)))
            intNewWidth = intOriginalWidth;
            intNewHeight = intOriginalHeight;
        }



        //ms = New MemoryStream()

        imgNewImage = new Bitmap(intNewWidth, intNewHeight);
        System.Drawing.Graphics graphic;
        graphic = System.Drawing.Graphics.FromImage(imgNewImage);
        graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        graphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        graphic.DrawImage(imgConverted, 0, 0, intNewWidth, intNewHeight);
        imgConverted = imgNewImage;
    }
    #endregion
}
