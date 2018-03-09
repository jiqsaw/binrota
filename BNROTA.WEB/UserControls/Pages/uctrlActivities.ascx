<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlActivities.ascx.cs"
    Inherits="UserControls_Pages_uctrlActivities" %>
<%@ Register Src="../Common/uctrlFavoritePlaces.ascx" TagName="uctrlFavoritePlaces"
    TagPrefix="uc3" %>
<%@ Register Src="../Common/uctrlLastTripSubjects.ascx" TagName="uctrlLastTripSubjects"
    TagPrefix="uc1" %>
<%@ Register Src="../Common/uctrlTopForumSubjects.ascx" TagName="uctrlTopForumSubjects"
    TagPrefix="uc2" %>


<table class="Content" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td colspan="5" valign="top" class="DegradeBack">
            <table width="970" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="21">
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px;" class="BlueHeader">
                        ETK&#304;NL&#304;K TAKV&#304;M&#304;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="padding-right: 22px;">
                        <table cellspacing="4" cellpadding="4" class="BackLogoColor">
                            <tr>
                                <td class="Treb clRed">
                                    Tarih Seç </td>
                                <td align="center">
                                    <asp:DropDownList ID="ddlDate" runat="server" CssClass="DropDownList" Width="130" ></asp:DropDownList></td>
                                <td>
                                    <asp:Button runat="server" ID="btnSearch" Text="Git" CssClass="Button" OnClick="btnSearch_Click"/></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="20">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Repeater ID="rptDays" runat="server">
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <td width="135" class="Treb clBlack" style="padding-left: 8px;">
                                    <b><i>
                                        <%#DataBinder.Eval(Container.DataItem,"DayName")%>
                                    </i></b>
                                </td>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tr>
                                <tr>
                                    <td colspan="7" height="2">
                                    </td>
                                </tr>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:DataList ID="dlCalendar" runat="server" RepeatColumns="7" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <table class='<%#DataBinder.Eval(Container.DataItem,"CssClass")%>' border="0" cellspacing="0"
                                    cellpadding="0">
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="5">
                                        </td>
                                        <td class="CalendarTitle">
                                            <%#DataBinder.Eval(Container.DataItem,"DayNo") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" height="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="5">
                                        </td>
                                        <td height="103" align="left" valign="top" class="Treb clWhite">
                                            <div class="dvScroll Scroll" style="width: 125; height: 93;">
                                               <%#DataBinder.Eval(Container.DataItem,"Activities")%>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="padding-right: 22px;">
                        <table width="265" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>       </td>
        </tr>
</table>
