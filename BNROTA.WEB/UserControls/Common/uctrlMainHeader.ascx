<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlMainHeader.ascx.cs"
    Inherits="UserControls_MainPage_uctrlMainHeader" %>
<script language="javascript" type="text/javascript">

</script>
<table width="1004" cellpadding="0" cellspacing="0">
    <tr>
        <td class="Top">
            <table class="Content" align="center" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="573" height="118">
                        &nbsp;</td>
                    <td width="398" valign="top">
                        <table width="398" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="29" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="right" class="TopGrayText">
                                    <asp:Label ID="lbTodaysDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="pnlLogin" runat="server">
                            <table width="398" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="3" align="right" style="padding-top: 15px;" class="TopGrayText">
                                        Hoþgeldiniz,&nbsp;&nbsp;
                                        <strong><asp:HyperLink ID="hlHowToBeAMember" runat="server" CssClass="Graylink" Text="Nasýl yazar olabilirim" NavigateUrl="javascript:OpenHowToBeAMember()"></asp:HyperLink></strong>
                                        |
                                        <asp:HyperLink ID="hlRegister" runat="server" CssClass="Graylink" Text="Üye olmak için týklayýnýz" NavigateUrl="javascript:OpenRegisterForm()"></asp:HyperLink>
                                        |
                                        <asp:HyperLink ID="hlRemindPassword" runat="server" CssClass="Graylink" Text="Þifremi unuttum" NavigateUrl="javascript:OpenForgotPassword()"></asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="15" colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="171">
                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="TextBox" Style="width: 163px;"
                                            Text="Kullan&#305;c&#305; Ad&#305;"></asp:TextBox>
                                    </td>
                                    <td width="171">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" Style="width: 163px;"
                                            Text="&#350;ifre" TextMode="Password"></asp:TextBox>
                                    </td>
                                    <td width="56">
                                        <asp:ImageButton ID="imbLogin" runat="server" ImageUrl="~/Images/Design/login.jpg"
                                            Width="56" Height="20" OnClick="imbLogin_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlUserInfo" runat="server">
                            <table width="398" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="right" style="padding-top: 15px;" class="TopGrayText">
                                        <strong>Hoþgeldiniz,</strong>&nbsp;&nbsp;<asp:Label ID="lblUserName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="15">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                         <asp:HyperLink ID="hlMemberDetails" runat="server" CssClass="GrayLink" NavigateUrl="~/MemberPage.aspx" Text="Profilim"></asp:HyperLink>
                                         | <asp:HyperLink ID="hlMemberPages" runat="server" CssClass="GrayLink" NavigateUrl="~/PagesView.aspx" Text="Yazý ve yorumlarým"></asp:HyperLink>
                                         | <asp:HyperLink ID="hlAddPage" runat="server" CssClass="GrayLink" NavigateUrl="javascript:OpenAddPages()" Text="Yazý giriþi"></asp:HyperLink>
                                         |
                                        <asp:LinkButton ID="lbLogOut" runat="server" CssClass="GrayLink" Text="Güvenli çýkýþ"
                                            OnClick="lbLogOut_Click"></asp:LinkButton></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width="970" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="20">
                                </td>
                                <td width="619" class="TopMenu">
                                    <strong>
                                     <asp:HyperLink ID="hplMainPage" CssClass="Menu" runat="server" NavigateUrl="~/MainPageN.aspx">ANA SAYFA</asp:HyperLink> 
                                     &nbsp;&nbsp;|&nbsp;&nbsp; 
                                     <asp:HyperLink ID="hplOurMembers" CssClass="Menu" runat="server" NavigateUrl="~/OurMembers.aspx">BÝNROTALILAR</asp:HyperLink>  
                                     &nbsp;&nbsp;|&nbsp;&nbsp; 
                                     <asp:HyperLink ID="hplActivityCalender" CssClass="Menu" runat="server" NavigateUrl="~/Activities.aspx">ETKÝNLÝK TAKVÝMÝ</asp:HyperLink>
<%--                                     &nbsp;&nbsp;|&nbsp;&nbsp; 
                                     <asp:HyperLink ID="hplPhotoGalery" CssClass="Menu" runat="server" NavigateUrl="~/MainPageN.aspx">GALERÝ</asp:HyperLink> --%> 
                                     &nbsp;&nbsp;|&nbsp;&nbsp; 
                                     <asp:HyperLink ID="hplForum" CssClass="Menu" runat="server" NavigateUrl="~/Forum.aspx">FORUM</asp:HyperLink>  
                                     &nbsp;&nbsp;|&nbsp;&nbsp;
                                     <asp:HyperLink ID="hplFaq" CssClass="Menu" runat="server" NavigateUrl="~/Faq.aspx">SSS</asp:HyperLink> 
                                     </strong></td>
                                <td width="15">
                                    &nbsp;</td>
                                <td width="271" style="padding-top: 4px;">
                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="SearchBox" Text="Arama"></asp:TextBox>
                                </td>
                                <td width="45" style="padding-top: 3px;">
                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/Design/SearchButton.gif" OnClick="btnSearch_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
