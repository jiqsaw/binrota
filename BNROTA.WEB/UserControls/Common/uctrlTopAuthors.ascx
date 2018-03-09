<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlTopAuthors.ascx.cs"
    Inherits="UserControls_MainPage_uctrlTopAuthors" %>
<table width="100%" height="100%" class="DegradeBack" border="0" cellspacing="0"
    cellpadding="0">
    <tr>
        <td colspan="2" class="Treb RegionBottomTd">
            EN BEÐENÝLENLER</td>
    </tr>
    <tr>
        <td width="41%" align="right">
            <asp:Image ID="imgAuthor" runat="server" Width="60" Height="72" />
        </td>
        <td width="59%" style="padding-left: 9px;">
            <strong>
                <asp:HyperLink ID="hlMAuthorName" CssClass="clNavy Treb" runat="server"></asp:HyperLink></strong><br/>
            <asp:Label ID="lblArticleCount" CssClass="Arial clGray" runat="server"></asp:Label><br/>
            <br>
            <asp:HyperLink ID="hlAllArticles" CssClass="TGray" runat="server">Tüm Yaz&#305;lar&#305;</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td colspan="2" height="9">
        </td>
    </tr>
    <tr>
        <td colspan="2" valign="top">
            <asp:Repeater ID="rptAuthors" runat="server">
                <ItemTemplate>
                    <table width="93%" class="Author" cellpadding="0" cellspacing="0"
                    style="border-bottom-width: 0px; cursor: pointer;" align="center"  
                    onclick='javascript:window.location = "<%#DataBinder.Eval(Container.DataItem, "MemberID", "MemberPage.aspx?MemberID={0}")%>";'>
                        <tr>
                            <td class="Treb clNavy" valign="bottom" style="padding: 6px 5px;">
                                <b><%#DataBinder.Eval(Container.DataItem,"NickName")%></b>&nbsp;
                                <font class="clGrayAuthorName">
                                (<%#DataBinder.Eval(Container.DataItem,"Point") %> Puan)</font>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </td>
    </tr>
</table>
