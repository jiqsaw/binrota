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
using BINROTA.BUS;
using BINROTA.COM;
using CARETTA.COM;

public partial class UserControls_Members_uctrlMemberPhotos : BaseUserControl
{
    #region Properties
    public int MemberID
    {
        get { return (int)(ViewState["MID"] == null ? -1 : ViewState["MID"]); }
        set { ViewState["MID"]=value;}
    }
    public int AlbumID
    {
        get { return (int)(ViewState["AID"] == null ? -1 : ViewState["AID"]); }
        set { ViewState["AID"] = value; }
    }

    public int PageLoadType
    {
        get { return (int)(ViewState["PLT"] == null ? -1 : ViewState["PLT"]); }
        set { ViewState["PLT"] = value; }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UctrlImageUpload2.UploadType = Enumerations.FileUploadType.MemberAlbumImagesBig;
            UserControl();
            BindDDL();
            BindPhotos();
            //pagindeki table witdh bozdu diye kaldýrdým
            //UctrlPaging1.PageSize = 10;
            ((HyperLink)UctrlPagings1.FindControl("hlPrevious")).Visible = false;
            ((HyperLink)UctrlPagings1.FindControl("hlNext")).Visible = false;
            ((Literal)UctrlPagings1.FindControl("ltlPageSize")).Visible = false;
            ((DropDownList)UctrlPagings1.FindControl("ddlPageSize")).Visible = false;
            ((Literal)UctrlPagings1.FindControl("ltlRecordCountTitle")).Text = "Toplam";
        }

        //UctrlPaging1.PagerChanged += new EventHandler(UctrlPaging1_PagerChanged);
        //UctrlPaging1.ItemName = "resim";
    }

    //protected void UctrlPaging1_PagerChanged(object sender, EventArgs e)
    //{
    //    BindPhotos(); 
    //}


    //private void BindPhotos()
    //{
    //    PagedDataSource pds = new PagedDataSource();
    //    pds.AllowPaging = true;

    //    pds.DataSource = (DataView)(AlbumID==-1 ? Members.PhotoAlbum.GetPhotos(MemberID).DefaultView: Members.PhotoAlbum.GetPhotos(MemberID,AlbumID).DefaultView);

    ////    UctrlPaging1.RecordCount = pds.DataSourceCount;
    //      pds.PageSize = 30;//UctrlPaging1.PageSize;
    ////    pds.CurrentPageIndex = UctrlPaging1.CurrentPage - 1;

    //      //dlMemberPhotos.DataSource = pds;
    //      //dlMemberPhotos.DataBind();
    //}
    private void UserControl()
    {
        DataTable dt = null;
        if (CARETTA.COM.Util.IsNumeric(Request.QueryString["MemberID"]))
        {
            this.MemberID = int.Parse(Request.QueryString["MemberID"]);
            dt = BINROTA.BUS.Members.GetMemberDetailsByMemberID(this.MemberID);
            if (SessRoot == null) 
            {
                this.MemberID = int.Parse(Request.QueryString["MemberID"]);
                this.PageLoadType = (int)Enumerations.PageLoadType.Visitor;
            }
            else if (SessRoot.UserID != this.MemberID) 
            { 
                this.MemberID = int.Parse(Request.QueryString["MemberID"]);
                this.PageLoadType = (int)Enumerations.PageLoadType.Visitor;
            }
            else if (SessRoot.UserID == this.MemberID) 
            { 
                this.MemberID = SessRoot.UserID;
                this.PageLoadType = (int)Enumerations.PageLoadType.Member;
            }
        }
        else if (SessRoot != null)
        {
            this.MemberID = SessRoot.UserID;
            this.PageLoadType = (int)Enumerations.PageLoadType.Member;
        }
        else Common.GotoDefaultPage(this.Response);
    }

    private void SetVisibles()
    {
        if (this.PageLoadType == (int)Enumerations.PageLoadType.Visitor)
        {
            pnlAddAlbumPhoto.Visible = false;

        }
    }

    protected void ddlAlbums_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void BindDDL()
    {
        DataTable dt = BINROTA.BUS.Members.PhotoAlbum.GetAlbums(this.MemberID);
        if (dt.Rows.Count > 0)
        {
            DDLHelper.BindDDL(ref ddlAlbumList, BINROTA.BUS.Members.PhotoAlbum.GetAlbums(this.MemberID), "PhotoName", "MemberPhotoID", "");
            DDLHelper.BindDDL(ref ddlAlbumList2, BINROTA.BUS.Members.PhotoAlbum.GetAlbums(this.MemberID), "PhotoName", "MemberPhotoID", "");
        }
    }

    protected void btnUploadImage_Click(object sender, ImageClickEventArgs e)
    {

    }

    private void BindPhotos()
    {
        if (ddlAlbumList2.Items.Count > 0)
        {
            DataTable dt = BINROTA.BUS.Members.PhotoAlbum.GetPhotos(this.MemberID, Convert.ToInt32(ddlAlbumList2.SelectedValue));
            if (dt.Rows.Count < 1)
            {
                dlMemberPhotos.Visible = false;
            }
            else
            {
                dlMemberPhotos.Visible = true;
            }
            UctrlPagings1.GeneratePager(ref dt, dlMemberPhotos, 6);
            //((Label)UctrlPagings1.FindControl("lblRecordCount")).Text = dt.Rows.Count.ToString();
            //dlMemberPhotos.DataSource = dt;
            //dlMemberPhotos.DataBind();
            foreach (DataListItem dlitem in dlMemberPhotos.Items)
            {
                ((Button)dlitem.FindControl("btnImageDelete")).Attributes.Add("onclick", "return confirm('Resmi silmek istediðinizden emin misiniz?');");
                ((Image)dlitem.FindControl("imgPhoto")).Attributes.Add("onerror", "this.src='Images/Design/NoPicture.jpg';");
            }
            ddlAlbumList2.Visible = true;
            lbAlbumTitle2.Text = "Albüm Adý";
        }
        else
        {
            ddlAlbumList2.Visible = false;
            lbAlbumTitle2.Text = "Albümünüz bulunamamýþtýr";
            //Response.Write("<script>document.getElementById('AddPhotoLink').style.display = 'none'</script>");
                    

        }
        SetVisibles();
    }

    protected void btnImageDelete_Click(object sender,EventArgs e)
    {
        //int.Parse(((ImageButton)sender).CommandArgument);
        DataTable dt = BINROTA.BUS.Members.PhotoAlbum.GetPhotoByMemberPhotoID(int.Parse(((Button)sender).CommandArgument));
        if (dt.Rows.Count > 0)
        {
            BINROTA.BUS.Members.PhotoAlbum.DeletePhoto(int.Parse(((Button)sender).CommandArgument));
            BINROTA.COM.Common.DeleteImage(dt.Rows[0]["PhotoUrl"].ToString(), Request.MapPath(ConfigurationManager.AppSettings["MemberAlbumImagesPathBig"].ToString()));
            BINROTA.COM.Common.DeleteImage(dt.Rows[0]["PhotoUrl"].ToString(), Request.MapPath(ConfigurationManager.AppSettings["MemberAlbumImagesPathSmall"].ToString()));
            BindPhotos();
        }
        
    }
    protected void btnNewAddAlbum_Click(object sender, EventArgs e)
    {
        if (txtNewAlbumName.Text != "")
        {
            int AlbumID = BINROTA.BUS.Members.PhotoAlbum.InsertAlbum(txtNewAlbumName.Text, SessRoot.UserID);
            BindDDL();
            ddlAlbumList.SelectedValue = AlbumID.ToString();
            ddlAlbumList2.SelectedValue = AlbumID.ToString();
            txtNewAlbumName.Text = "";
            BindPhotos();
        }
    }
    protected void btnNewAddPhoto_Click(object sender, EventArgs e)
    {
        if (int.Parse(ddlAlbumList.SelectedValue) > 0)
        {
            if (((FileUpload)UctrlImageUpload2.FindControl("fupImg")).HasFile)
            {
                string imageuploded = "";
                imageuploded = UctrlImageUpload2.SendFile("");
                BINROTA.BUS.Members.PhotoAlbum.InsertPhoto(imageuploded, int.Parse(ddlAlbumList.SelectedValue.ToString()), SessRoot.UserID);
                ddlAlbumList2.SelectedValue = ddlAlbumList.SelectedValue;
                BindPhotos();
            }
            else
            {
                //TODO: Oray Hata Mesajý

            }
        }
    }
    protected void ddlAlbumList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPhotos();
    }
    protected void dlMemberPhotos_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if ((Enumerations.PageLoadType)this.PageLoadType == Enumerations.PageLoadType.Visitor) {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                e.Item.FindControl("btnImageDelete").Visible = false;
            }
        }
    }
}
