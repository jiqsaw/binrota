<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlAddComment.ascx.cs"
    Inherits="UserControls_Pages_uctrlAddComment" %>
<script>
    window.resizeTo(461, 343);
</script>

<table width="461" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td height="253" class="DegradeSPage" align="center" valign="bottom">
            <table width="445" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="31" width="118">
                        <img src="Images/Design/BinrotaLogo.jpg" width="118" height="31"></td>
                    <td width="260">
                        &nbsp;</td>
                    <td width="48" class="T clDarkGreen">
                        <asp:HyperLink ID="hlClose" runat="server" Text="x kapat" NavigateUrl="javascript:window.close()"></asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="3" height="19">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF" height="196" align="right" valign="bottom">
                        <table width="427" height="182" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="29" valign="top" class="Treb clDarkGreen">
                                    <b>YORUM EKLE </b>
                                </td>
                            </tr>
                            <tr>
                                <td height="20" class="T clBlack">
                                    Yorumunuz</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtComment" runat="server" Width="410" Rows="7" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="16" align="center">
                                    <%--                <asp:RadioButtonList ID="rblComment" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">&#199;ok K&#246;t&#252;</asp:ListItem>
                    <asp:ListItem Value="2">K&#246;t&#252;</asp:ListItem>
                    <asp:ListItem Selected="True" Value="3">Normal</asp:ListItem>
                    <asp:ListItem Value="4">Ýyi</asp:ListItem>
                    <asp:ListItem Value="5">&#199;ok Ýyi</asp:ListItem>
                </asp:RadioButtonList>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td height="1" bgcolor="#B9DEF0">
        </td>
    </tr>
    <tr>
        <td class="StripedBottom" align="center">
            <asp:Button ID="btnSubmit" runat="server" CssClass="Button" Text="Kaydet" OnClick="btnSubmit_Click" />
            &nbsp;
            <input type="reset" name="Submit2" value="Temizle" class="Button"></td>
    </tr>
</table>
