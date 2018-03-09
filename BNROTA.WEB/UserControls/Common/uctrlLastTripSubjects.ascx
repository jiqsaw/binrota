<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlLastTripSubjects.ascx.cs"
    Inherits="UserControls_MainPage_uctrlLastTripSubjects" %>
<table width="100%" height="100%" class="DegradeBack" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td valign="top">
            <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="Treb RegionBottomTd" style="padding-left: 0px;">
                        EN SON GÝRÝLEN YAZILAR
                    </td>
                </tr>
            </table>
            <div id="dvContent" runat="server" class="dvScroll Scroll" >   
                <asp:Repeater ID="rptLastTripSubjects" runat="server">
                <HeaderTemplate>
                <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="clBlack T">
                            <asp:HyperLink CssClass="clGrayAuthorName" runat="server" ID="hlNickName" Text='<%#DataBinder.Eval(Container.DataItem, "NickName")%>' NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "MemberID", "~/MemberPage.aspx?MemberID={0}")%>'></asp:HyperLink> <br />
                            <asp:HyperLink runat="server" ID="hlTitle" Text='<%#DataBinder.Eval(Container.DataItem, "Title")%>' NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "PageID", "~/PageDetail.aspx?PageID={0}")%>'></asp:HyperLink>
                        </td>
                    </tr>
                </ItemTemplate>
                <SeparatorTemplate>
                    <tr>
                        <td height="7">
                        </td>
                    </tr>
                    <tr>
                        <td class="TripSepTd">
                        </td>
                    </tr>
                    <tr>
                        <td height="7">
                        </td>
                    </tr>
                </SeparatorTemplate>
                <FooterTemplate>
                </table>
                </FooterTemplate>
                </asp:Repeater>
            </div>
        </td>
    </tr>
</table>
