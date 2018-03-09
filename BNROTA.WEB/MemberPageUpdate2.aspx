<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="MemberPageUpdate2.aspx.cs" Inherits="MemberPageUpdate2" ValidateRequest="false" %>

<%@ Register Src="UserControls/uctrlMemberPages.ascx" TagName="uctrlMemberPages"
    TagPrefix="uc8" %>

<%@ Register Src="UserControls/uctrlChangePassword.ascx" TagName="uctrlChangePassword"
    TagPrefix="uc7" %>

<%@ Register Src="UserControls/uctrlUpdateUserDetails.ascx" TagName="uctrlUpdateUserDetails"
    TagPrefix="uc6" %>

<%@ Register Src="UserControls/uctrlUserMainPage.ascx" TagName="uctrlUserMainPage"
    TagPrefix="uc5" %>

<%@ Register Src="UserControls/uctrlImageUpload.ascx" TagName="uctrlImageUpload"
    TagPrefix="uc4" %>
<%@ Register Src="UserControls/uctrlPageTree.ascx" TagName="uctrlPageTree" TagPrefix="uc1" %>
<%@ Register Src="UserControls/uctrlPageContent.ascx" TagName="uctrlPageContent"
    TagPrefix="uc2" %>
<%@ Register Src="UserControls/uctrlPageCategories.ascx" TagName="uctrlPageCategories"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
            <tr>
            <td>
            <table>
            <tr>
            <td><asp:LinkButton ID="lnbMyMainPage" Text="Kendi Ana Sayfam" runat="server" Width="135px" OnClick="lnbMyMainPage_Click" CausesValidation="False" ForeColor="red"></asp:LinkButton></td>
            <td style="width: 92px"><asp:LinkButton ID="lnbMyTravelPahge" Text="Gezi Yazýlarým" runat="server" Width="102px" OnClick="lnbMyTravelPage_Click" CausesValidation="False" ForeColor="red"></asp:LinkButton>
            </td>
            <td>
            <asp:LinkButton ID="lnbUpdateMemberInformation" Text="Bilgilerimi Güncelle" runat="server" Width="123px" CausesValidation="False" ForeColor="red" OnClick="lnbUpdateMemberInformation_Click"></asp:LinkButton>
            </td>
            <td>
            <asp:LinkButton ID="lnbChangePassword" Text="Þifremi Deðiþtir" runat="server" CausesValidation="false" ForeColor="red" OnClick="lnbChangePassword_Click" Width="100"></asp:LinkButton>
            </td>
            </tr>
            </table>
            </td>
            </tr>
    <tr>
        <td style="width: 100px">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="vwMemberHomePage" runat="server">
                <table>
                <tr>
                <td>
                    <uc5:uctrlUserMainPage ID="UctrlUserMainPage1" runat="server" />
                </td>
                </tr>
                </table>
                </asp:View>
                <asp:View ID="vwMemberTravelPages" runat="server">
                <table>
                <tr>
                <td valign="top"> 
                <uc1:uctrlPageTree ID="UctrlPageTree1" runat="server" Visible="false">
                    </uc1:uctrlPageTree>
                    <asp:Repeater ID="rptPages" runat="server" OnItemCommand="rptPages_ItemCommand">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPages" runat="server" CausesValidation="false" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PageID")%>'
                                Width="150">
                <%#DataBinder.Eval(Container.DataItem, "PageContentName")%>
            </asp:LinkButton>
                        </ItemTemplate>
                        <SeparatorTemplate>
                        </SeparatorTemplate>
                    </asp:Repeater>
                    </td>
                <td>
                    <uc2:uctrlPageContent ID="UctrlPageContent1" runat="server" />
                    </td>
                <td>
                    <uc3:uctrlPageCategories ID="UctrlPageCategories1" runat="server" />
                    </td>
                </tr>
                <tr>
                <td>
                    <asp:Button ID="btnSaveToPdf" runat="server" Text="Pdf Kaydet" OnClick="btnSaveToPdf_Click" /></td>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" Text="Güncelle" OnClick="btnUpdate_Click" CausesValidation="False" /></td>
                <td></td>
                </tr>
                </table>
                </asp:View>
                
                <asp:View ID="vwMemberInformation" runat="server">
                <table>
                <tr>
                <td>
                <uc6:uctrlUpdateUserDetails ID="UctrlUpdateUserDetails1" runat="server" />                  
                </td></tr>
                
                </table>
                </asp:View>
                <asp:View ID="vwMemberPasswordChange" runat="server">
                <table>
                <tr>
                <td style="width:100px">
                    <uc7:uctrlChangePassword id="UctrlChangePassword1" runat="server">
                    </uc7:uctrlChangePassword></td>
                </tr>
                </table>
                </asp:View>
            </asp:MultiView></td>
    </tr>
        </table>
</asp:Content>

