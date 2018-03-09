<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlOurMembers.ascx.cs"
    Inherits="UserControls_Members_uctrlOurMembers" %>
<%@ Register Src="../Common/uctrlNewAuthors.ascx" TagName="uctrlNewAuthors" TagPrefix="uc3" %>
<%@ Register Src="../Common/uctrlTopAuthors.ascx" TagName="uctrlTopAuthors" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Common/uctrlSubRightRegion.ascx" TagName="uctrlSubRightRegion"
    TagPrefix="uc2" %>
<table class="Content" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td width="695" colspan="3" valign="top" bgcolor="#FFFFFF" height="963">
            <!-- CONTENT -->
            <table width="695" cellspacing="0" cellpadding="0" class="SubContent LogoBack" height="918">
                <tr>
                    <td class="RegionHeader" valign="top">
                        <table width="100%">
                            <tr>
                                <td width="186" style="padding-left: 10px;">
                                    <!-- YAZARLARIMIZ SOL -->
                                    <table width="100%" cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td>
                                                <uc1:uctrlTopAuthors ID="UctrlTopAuthors1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 7px;">
                                                <%--                                                    <table width="100%" border="1" bordercolor="#b6dcef">
                                                        <tr>
                                                            <td align="center">
                                                            
sonra eklenecek                                                                <table bgcolor="#FFFFFF" width="100%">
                                                                    <tr>
                                                                        <td class="Treb RegionBottomTd"> HIZLI ARAMA </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-top: 12px; padding-left: 10px;">
                                                                            <p style="line-height: 1.8em">
                                                                            » <asp:LinkButton runat="server" ID="lnkMembersOnline" Text="Online Olanlar"></asp:LinkButton><br />
                                                                            » <asp:LinkButton runat="server" ID="lnkTodaysBirthDay" Text="Doðumgünü Olanlar" OnClick="lnkTodaysBirthDay_Click"></asp:LinkButton><br />
                                                                            </p>
                                                                       </td>
                                                                    </tr>
                                                                </table>
<br /><br />
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <uc3:uctrlNewAuthors ID="UctrlNewAuthors1" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- // YAZARLARIMIZ SOL -->
                                </td>
                                <td width="5">
                                </td>
                                <td valign="top">
                                    <!-- YAZARLARIMIZ GENEL -->
                                    <div style="padding-top: 12px;">
                                        <table width="100%" cellpadding="2" cellspacing="2">
                                            <tr>
                                                <td class="Treb clBlue">
                                                    BÝNROTALI ARA
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 12px; background-color: #e8f9ff">
                                                    <table width="100%" cellpadding="2" cellspacing="2">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox CssClass="TextBox" runat="server" ID="txtSearch" Width="400"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%--Sonra eklenecek                                                                <asp:DropDownList Width="127" ID="ddlStatus" runat="server">
                                                                    <asp:ListItem Selected="True" Text="Online" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Offline" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>--%>
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton runat="server" ID="btnSearch" ImageUrl="~/Images/Design/SearchButton.gif"
                                                                    OnClick="btnSearch_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;">
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="Treb clBlue">
                                                                BÝNROTALILAR
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Repeater ID="rptMembersResults" runat="server">
                                                                    <ItemTemplate>
                                                                        <table cellpadding="2" cellspacing="2" width="100%" border="1" bordercolor="#d0ebf9">
                                                                            <tr>
                                                                                <td align="center" width="46">
                                                                                    <asp:Image runat="server" ID="imgMember" Width="35" Height="44" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "PhotoPath")%>' />
                                                                                </td>
                                                                                <td style="padding-left: 7px;">
                                                                                    <b>
                                                                                        <asp:HyperLink runat="server" ID="hplMemberName" CssClass="T clBlack" Text='<%#DataBinder.Eval(Container.DataItem, "NickName")%>'
                                                                                            NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "MemberID", "~/MemberPage.aspx?MemberID={0}")%>'></asp:HyperLink>
                                                                                    </b>
                                                                                    <asp:Label ID="lbMemberCreateDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CreateDate")%>'></asp:Label>
                                                                                    <br />
                                                                                    <asp:Label ID="lbMotto" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Motto")%>'></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <!-- // YAZARLARIMIZ GENEL -->
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
</table>
