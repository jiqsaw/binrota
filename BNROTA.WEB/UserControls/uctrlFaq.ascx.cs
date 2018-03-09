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
using System.Text;

public partial class UserControls_uctrlFaq : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtFaq = BINROTA.BUS.Faq.GetFaq();

            StringBuilder strTemp = new StringBuilder();
            strTemp.Append("<table width='616' cellpadding='2' cellspacing='2'>");

            for (int i = 0; i < dtFaq.Rows.Count; i++)
            {
                strTemp.Append("<tr>");
                strTemp.Append("<td style='width: 610px; background-color: #d2f9ff; padding-left: 15px;'>");

                strTemp.Append("· <b><a class='clNavy' style='line-height: 1.9em;' id='a" + i.ToString() + "' href=javascript:OpenCloseAnswer('dv" + i.ToString() + "');>" + dtFaq.Rows[i]["Question"].ToString() + "</a></b>");

                strTemp.Append("<div id='dv" + i.ToString() + "' style='display: none;'><br>");
                strTemp.Append(dtFaq.Rows[i]["Answer"].ToString());
                strTemp.Append("<br><br></div>");

                strTemp.Append("</td></tr>");
            }

            strTemp.Append("</table>");

            dvFaq.InnerHtml = strTemp.ToString();

        }
    }

    

}
