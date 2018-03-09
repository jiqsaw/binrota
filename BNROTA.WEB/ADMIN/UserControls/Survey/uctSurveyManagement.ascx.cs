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

public partial class ADMIN_UserControls_uctSurveyManagement : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptSurveys.DataSource = BINROTA.BUS.Survey.GetAllSurveys();
            rptSurveys.DataBind();
        }
    }

    public void ToFinish(string Message)
    {
        dvAlert.Visible = true;
        ltlMessage.Text = Message;
    }

    protected void rptSurveys_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.Footer))
        {
            ArrayList arrQuestionID;
            if (e.CommandName == "RemoveSurvey") {
                arrQuestionID = new ArrayList();
                arrQuestionID.AddRange(Request.Form["chQuestion"].ToString().Split(','));
                BINROTA.BUS.Survey objSurvey = new BINROTA.BUS.Survey();
                if (objSurvey.Delete(arrQuestionID))
                {
                    ToFinish("Seçtiðiniz Anketler Silinmiþtir");
                }
                else {
                    ToFinish("Hata!.. Seçtiðiniz Anketler SÝLÝNEMEDÝ");
                }
            }
        }
    }
}
