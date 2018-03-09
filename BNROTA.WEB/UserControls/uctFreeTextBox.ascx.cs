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

public partial class UserControls_uctFreeTextBox : System.Web.UI.UserControl
{
    public string Text
    {
        get { return Request.Form[FreeTextBox1.ClientID]; }
        set { FreeTextBox1.Text = value; }
    }	

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Request.QueryString["SubjectID"] != null)
            //{
            FreeTextBoxControls.Toolbar toolb = new FreeTextBoxControls.Toolbar();
            FreeTextBoxControls.ToolbarButton tb = new FreeTextBoxControls.ToolbarButton();

            tb.Title = "Insert Image";
            tb.ButtonImage = "insertimage";
            //tb.ScriptBlock = "javascript:window.open('UploadImage.aspx?ftbID=" + this.ClientID + "_FreeTextBox1&SubjectID=" + Request.QueryString["SubjectID"].ToString() + "'," + "'popup','width=500,height=300,scrollbars=no,resizable=no')";
            tb.ScriptBlock = "javascript:window.open('UploadImage.aspx?ftbID=" + this.ClientID + "_FreeTextBox1" + "'," + "'popup','width=500,height=300,scrollbars=no,resizable=no')";
            toolb.Items.Add(tb);
            FreeTextBox1.Toolbars.Add(toolb);
            //}
        }
    }
}
