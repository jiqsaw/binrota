<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlForgatPassword.ascx.cs" Inherits="UserControls_Pages_uctrlForgatPassword" %>

<table width="388" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="196" class="DegradeSPage" align="center" valign="bottom"><table width="372" height="170" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="31" width="118"><img src="Images/Design/BinrotaLogo.jpg" width="118" height="31"></td>
        <td width="206">&nbsp;</td>
        <td width="48" class="T clDarkGreen">
        <asp:HyperLink ID="hlClose" runat="server" Text="x kapat" NavigateUrl="javascript:window.close()"></asp:HyperLink>
        </td>
      </tr>
      <tr>
        <td colspan="3" height="19"></td>
      </tr>
      <tr>
        <td colspan="3" bgcolor="#FFFFFF" align="right" valign="bottom"><table width="341" height="110" border="0" cellspacing="0" cellpadding="0">
          <asp:Panel ID="pnlForgotPassword" runat="server" Visible="true">
          <tr>
            <td height="27" colspan="2" valign="top" class="Treb clDarkGreen"><b>S&#304;FREM&#304; UNUTTUM</b> </td>
          </tr>
          <tr>
            <td height="30" colspan="2" class="T clBlack">
            <asp:Literal ID="ltPasswordText" runat="server" Text="&Uuml;ye olurken girmi&#351; oldu&#287;unuz mail adresinizi yaz&#305;n&#305;z.<br>
              &#350;ifreniz mail adresinize g&ouml;nderilecektir."></asp:Literal> 
            </td>
          </tr>
          <tr>
            <td height="14" colspan="2"></td>
          </tr>
          <tr>
            <td width="35">Email</td>
            <td>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Width="268" ForeColor="#AD0505"></asp:TextBox>
            </td>
          </tr>
          </asp:Panel>
          <asp:Panel ID="pnlEmailError" runat="server" Visible="false">
          <tr>
            <td height="27" colspan="2" valign="top" class="Treb clDarkGreen"></td>
          </tr>
          <tr>
            <td height="30" colspan="2" class="T clBlack">
            <asp:Literal ID="Literal1" runat="server" Text="Sisteme kayýtlý böyle bir mail adresi yoktur."></asp:Literal> 
            </td>
          </tr>
          <tr>
            <td height="14" colspan="2"></td>
          </tr>
          <tr>
            <td width="35"></td>
            <td>
            <asp:HyperLink ID="hlBack" runat="server" Text="Geri Dön" NavigateUrl="javascript:history.back()"></asp:HyperLink>
            </td>
          </tr>
          </asp:Panel>
          <asp:Panel ID="pnlEmailSuccess" runat="server" Visible="false">
          <tr>
            <td height="27" colspan="2" valign="top" class="Treb clDarkGreen"></td>
          </tr>
          <tr>
            <td height="30" colspan="2" class="T clBlack">
            <asp:Literal ID="ltrEmailSuccess" runat="server" Text="Þifreniz mail adresine gönderilmiþtir"></asp:Literal> 
            </td>
          </tr>
          <tr>
            <td height="14" colspan="2"></td>
          </tr>
          <tr>
            <td width="35"></td>
            <td>
            <asp:HyperLink ID="HyperLink1" runat="server" Text="Geri Dön" NavigateUrl="javascript:history.back()"></asp:HyperLink>
            </td>
          </tr>
          </asp:Panel>
          <tr>
            <td height="17" colspan="2"></td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="1" bgcolor="#B9DEF0"></td>
  </tr>
  <tr>
    <td class="StripedBottom" align="center">
    <asp:Button ID="btnSubmit" runat="server" CssClass="Button" Text="Kaydet" OnClick="btnSubmit_Click" />
      &nbsp;
      <input type="reset" class="Button" value="Temizle" name="Temizle" />
   </td>
  </tr>
</table>