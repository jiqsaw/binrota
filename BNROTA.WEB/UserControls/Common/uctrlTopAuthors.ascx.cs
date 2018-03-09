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
using BINROTA.COM;

public partial class UserControls_MainPage_uctrlTopAuthors : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindAuthors();
            imgAuthor.Attributes.Add("onerror", "this.src='Images/Design/NoPicture.jpg'");
        }
    }

    private void BindAuthors()
    {
        DataTable dtAuthors = BINROTA.BUS.Members.GetMemberByPoints((int)Enumerations.PageType.TravelPage);

        if (dtAuthors.Rows.Count > 0)
        {
            if (dtAuthors.Rows[0]["PhotoPath"].ToString().Trim() == "")
            {
                imgAuthor.ImageUrl = "~/Images/Design/NoPicture.jpg";
            }
            else
            {
                imgAuthor.ImageUrl = Common.ReturnImagePath(dtAuthors.Rows[0]["PhotoPath"].ToString(), ConfigurationManager.AppSettings["MemberImagesUrl"].ToString());
            }
            hlMAuthorName.Text = dtAuthors.Rows[0]["NickName"].ToString();
            hlMAuthorName.NavigateUrl = "~/MemberPage.aspx?MemberID=" + dtAuthors.Rows[0]["MemberID"].ToString(); 
            lblArticleCount.Text = dtAuthors.Rows[0]["Point"].ToString() + " Puan";
            hlAllArticles.NavigateUrl = "~/PagesView.aspx?MemberID=" + dtAuthors.Rows[0]["MemberID"].ToString(); 

            dtAuthors.Rows[0].Delete();

            rptAuthors.DataSource = dtAuthors;
            rptAuthors.DataBind();
        }    
    }
}
