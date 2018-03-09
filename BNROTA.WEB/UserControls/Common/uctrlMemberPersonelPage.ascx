<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlMemberPersonelPage.ascx.cs" Inherits="UserControls_Common_uctrlMemberPersonelPage"  %>

<%@ Register Src="../uctFreeTextBox.ascx" TagName="uctFreeTextBox" TagPrefix="uc2" %>
<table width="986" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td colspan="2" align="center" class="DegradeSPage">
            <table width="970" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="13" colspan="3">
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="31" width="125" align="right">
                                    <img src="Images/Design/BinrotaLogo.jpg" width="118" height="31"></td>
                                <td width="772">
                                    &nbsp;</td>
                                <td width="71" class="T clDarkGreen">
                    <asp:HyperLink ID="hplClose" runat="server" Text="x kapat" NavigateUrl="javascript:window.close()"></asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF">
                        <table width="670" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="12" rowspan="5">
                                </td>
                                <td height="10">
                                </td>
                            </tr>
<%--                            <asp:Panel ID="pnlContent" runat="server">
--%>                            <tr>
                                <td class="T clBlack">
                                    YAZINIZ
                                </td>
                            </tr>
                            <tr>
                                <td height="10">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <uc2:uctFreeTextBox ID="ftbPageContent" runat="server" />                                    
                                </td>
                            </tr>
<%--                            </asp:Panel>
--%><%--                            <asp:Panel ID="pnlMessage" runat="server">
--%>                            <tr>
                                <td height="7">
<%--                                <asp:Label ID="lbMessage" runat="server" CssClass="Message"></asp:Label>
--%>                                </td>
                            </tr>
<%--                            </asp:Panel>
--%>                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" height="1" bgcolor="#B8DFF0">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td height="1" colspan="2" bgcolor="#BADDF0">
        </td>
    </tr>
    <tr>
        <td width="595" align="right" class="StripedBottom">
            <asp:Button ID="btnSubmit" runat="server" Text="Kaydet" CssClass="Button" OnClick="btnSubmit_Click" />
            &nbsp;
            <input type="reset" name="Temizle" value="Temizle" class="Button"/>
        </td>
        <td width="391" align="center" class="StripedBottom">
            &nbsp;</td>
    </tr>
</table>
