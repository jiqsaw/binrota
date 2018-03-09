<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlLoginPage.ascx.cs" Inherits="UserControls_uctrlLoginPage" %>
<%@ Register Src="~/UserControls/Common/uctrlSubRightRegion.ascx" TagName="uctrlSubRightRegion" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Common/uctrlLastTripSubjects.ascx" TagName="uctrlLastTripSubjects" TagPrefix="uc8" %>
<%@ Register Src="~/UserControls/Common/uctrlFavoritePlaces.ascx" TagName="uctrlFavoritePlaces" TagPrefix="uc6" %>

<table class="Content" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td width="695" colspan="3" valign="top" bgcolor="#E5F8FF">
         
        <!-- CONTENT -->
        
            <table width="695" cellspacing="0" cellpadding="0" class="SubContent DegradeBottom">
                <tr>
                    <td height="47" valign="middle" class="RegionHeader">
                        <div style="padding-top: 5px; padding-left: 25px;">
                            KULLANICI G�R���
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style=" padding-left: 25px; vertical-align: top;">
                        
                        Bu alan� kullanabilmeniz i�in sitemize �ye olman�z gerekmektedir. <br />
                        E�er �yeyseniz, a�a��daki formu kullanarak hemen giri� yapabilir ve de yorum yazabilirsiniz...
    
                        <br /><br />
                        <a href="javascript:OpenRegisterForm()" class="Graylink"> �ye Olmak ��in T�klay�n�z.</a>
                        <br /><br />
                        
                        <table width="90%" border="1" bordercolor="#e0e4e5">
                            <tr>
                                <td style="padding: 8px;">
                                    <asp:Panel runat="server" ID="pnlLogin" DefaultButton="btnSubmit">
                                    
                                    <table width="100%" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td>Kullan�c� Ad�</td>
                                            <td>    
                                                <asp:TextBox ID="txtUserName" runat="server" CssClass="TextBox" Width="350px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>�ifre</td>
                                            <td>    
                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" TextMode="Password" Width="350px" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"><br />
                                                <asp:RadioButtonList runat="server" ID="rdRememberList" RepeatDirection="Vertical">
                                                <asp:ListItem Selected="True" Text="Kullan�c� ad�m� ve �ifremi Hat�rla"></asp:ListItem>
                                                <asp:ListItem Text="Sadece kullan�c� adm�m� hat�rla"></asp:ListItem>
                                                <asp:ListItem Text="Kullan�c� ad�m� ve �ifremi her zaman sor"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                
                                                <br />
                                                
                                                <asp:Button CssClass="Button" runat="server" ID="btnSubmit" Text="Giri�" OnClick="btnSubmit_Click" />
                                                
                                                <br /><br />
                                                � <a href="javascript:OpenForgotPassword()">�ifremi Unuttum</a>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    </asp:Panel>
                                    
                                </td>
                            </tr>
                        </table>
                        
                    </td>
                </tr>
            </table>

        <!-- //CONTENT -->

        </td>
        <td rowspan="3" class="HSpace">
        </td>
        <td width="267" rowspan="3" valign="top">
            <uc2:uctrlSubRightRegion ID="UctrlSubRightRegion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="3" class="VSpace">
        </td>
    </tr>
    <tr>
        <td width="425" height="277">
            <uc8:uctrlLastTripSubjects ID="UctrlLastTripSubjects1" runat="server" />
        </td>
        <td class="HSpace">
        </td>
        <td width="263" valign="top" bgcolor="#E5F8FF">
            <uc6:uctrlFavoritePlaces ID="UctrlFavoritePlaces1" runat="server" />
        </td>
    </tr>
</table>

<script type="text/javascript">
function SetPassword(PassClientID, Password) {
    document.getElementById(PassClientID).value = Password;
}
</script>

<div runat="server" id="JsDiv"></div>