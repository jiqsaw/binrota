<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlAddComplain.ascx.cs" Inherits="UserControls_Pages_uctrlAddComplain" %>
<script>
    window.resizeTo(461, 343);
</script>
<table width="461" border="0" cellspacing="0" cellpadding="0" style="vertical-align:top">
  <tr>
    <td height="253" class="DegradeSPage" align="center" valign="bottom">
    <table width="445"  border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="31" width="118"><img src="Images/Design/BinrotaLogo.jpg" width="118" height="31"></td>
        <td width="260">&nbsp;</td>
        <td width="48" class="T clDarkGreen"><asp:HyperLink ID="hlClose" runat="server" Text="x kapat" NavigateUrl="javascript:window.close()"></asp:HyperLink></td>
      </tr>
      <tr>
        <td colspan="3" height="19"></td>
      </tr>
            <asp:Panel ID="pnlMessage" runat="server" Visible="false" >
                <tr>
                        <td colspan="3" bgcolor="#FFFFFF" height="196" align="right" valign="top" style="padding-top:20;">
                        <table width="445" style="vertical-align:top"  border="0" cellspacing="0" cellpadding="0">
                        <tr>
                        <td align="center">
                        <asp:Label ID="lbMessage" runat="server"></asp:Label>
                        </td>
                        <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text="Geri Dön" NavigateUrl="javascript:history.back()"></asp:HyperLink>
                        </td>
                        </tr>
                        </table> 
                        </td>
                </tr>
            </asp:Panel>
          <asp:Panel ID="pnlForm" runat="server" Visible="true">
                  <tr>
                    <td colspan="3" bgcolor="#FFFFFF" height="196" align="right" valign="bottom"><table width="427" height="182" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td height="29" valign="top" class="Treb clDarkGreen"><b>ÞÝKAYET GÖNDER</b> </td>
                      </tr>
                      <tr>
                        <td height="20" class="T clBlack">Þikayetiniz</td>
                      </tr>
                      
                      <tr>
                        <td><asp:TextBox ID="txtMessage" runat="server" Width="410" Rows="7" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                    </table>
                    </td>

                  </tr>
          </asp:Panel>
    </table>
    </td>
  </tr>
  <tr>
    <td height="1" bgcolor="#B9DEF0"></td>
  </tr>
  <tr>
    <td  class="StripedBottom" align="center"><asp:Button ID="btnSubmit" runat="server" CssClass="Button" Text="Gönder" OnClick="btnSubmit_Click"/>
      &nbsp;
    <input type="reset" name="Submit2" value="Temizle" class="Button" />
    </td>
  </tr>
</table>