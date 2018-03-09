<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlTopForumSubjects.ascx.cs"
    Inherits="UserControls_MainPage_uctrlTopForumSubjects" %>
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="DegradeBack" valign="top">
            <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="RegionBottomTd Treb" style="padding-left: 4px;">
                        FORUMUN FAVORÝLERÝ
                    </td>
                </tr>
            </table>
            <div id="dvContent" class="dvScroll Scroll"  runat="server">
                <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
                   <asp:Repeater ID="rptForumSubjects" runat="server" >
                        <ItemTemplate>
                            <tr>
                                <td class="Forum">
                                    <strong><asp:HyperLink ID="hplTitle" runat="server" CssClass="HyperLink" Text='<%#DataBinder.Eval(Container.DataItem, "ArticleSubject") %>' NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "ArticleID", "~/Article.aspx?ArticleID={0}")%>'></asp:HyperLink></strong><br>
                                    <asp:Literal ID="ltrDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ArticleMessage") %>'></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="ForumSepTd">
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </td>
    </tr>
</table>
