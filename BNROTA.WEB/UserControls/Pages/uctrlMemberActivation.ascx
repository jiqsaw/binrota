<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlMemberActivation.ascx.cs" Inherits="UserControls_Pages_uctrlMemberActivation" %>


<table width="320" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="DegradeSPage" align="center">
            <table width="300" border="0" cellspacing="0" cellpadding="0">
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
                                <td width="102">
                                    &nbsp;</td>
                                <td width="71" class="T clDarkGreen">
                    <asp:HyperLink ID="hplClose" runat="server" Text="x kapat" NavigateUrl="javascript:window.close()"></asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="14" colspan="3">
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                    <asp:Label ID="lbMessage" runat="server"></asp:Label>

                    </td>
                </tr>
            </table>
        </td>
    </tr>


</table>
