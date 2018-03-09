<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlResult.ascx.cs" Inherits="UserControls_Common_uctrlResult" %>

<script>
    window.resizeTo(490, 300);
</script>

<table width="461" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="253" class="DegradeSPage" align="center" valign="bottom"><table width="445"  border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="31" width="118"><img src="Images/Design/BinrotaLogo.jpg" width="118" height="31"></td>
        <td width="260">&nbsp;</td>
        <td width="48" class="T clDarkGreen"><asp:HyperLink ID="hlClose" runat="server" Text="x kapat" NavigateUrl="javascript:window.close()"></asp:HyperLink></td>
      </tr>
      <tr>
        <td colspan="3" height="19"></td>
      </tr>
      <tr>
        <td colspan="3" bgcolor="#FFFFFF" height="196" align="right" valign="bottom"><table width="427" height="182" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="20" class="Treb clDarkRed">
            
                <br />

                <%
                    if (Request.QueryString["Message"] != null) { Response.Write(Request.QueryString["Message"].ToString()); }
                %>
                <br /><br />
                « <a href="javascript:history.back()">Geri Dön</a>
            
            </td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
</table>