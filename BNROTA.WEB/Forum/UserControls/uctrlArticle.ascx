<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlArticle.ascx.cs"
    Inherits="Forum_UserControls_uctrlArticle" %>
<%@ Register Src="../../UserControls/Common/uctrlPaging.ascx" TagName="uctrlPaging"
    TagPrefix="uc1" %>
<%@ Register Src="uctrlNewItem.ascx" TagName="uctrlNewItem" TagPrefix="uc2" %>

<link rel="stylesheet" type="text/css" href="Forum/Styles/Forum.css">
<table class="Content" cellpadding="0" cellspacing="0" border="0" align="center"
    bgcolor="#ffffff">
    <tr>
        <td height="20">
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" align="center" cellspacing="0" width="90%">
                <tr>
                    <td class="FText12">
                        <asp:HyperLink runat="server" ID="hlForumTitle" NavigateUrl="~/Forum.aspx" ImageUrl="~/Forum/images/ForumTitle.jpg"></asp:HyperLink>
                        >
                        <asp:Label ID="lblCategoryName" runat="server" class="FText12"></asp:Label></b>
                    </td>
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
        <uc2:uctrlNewItem id="UctrlNewItem1" runat="server" visible="false">
        </uc2:uctrlNewItem></td>
    </tr>
    <tr>
        <td align="right" style="padding-right: 60px;"><asp:ImageButton ID="btnAddTopic" runat="server" ImageUrl="~/Forum/images/AddTopic.jpg" OnClick="btnAddTopic_Click" /></td>
    </tr>
    <tr>
        <td height="15"></td>
    </tr>
    <tr>
        <td>
            <asp:Repeater ID="rptArticles" runat="server">
                <HeaderTemplate>
                    <table cellpadding="4" cellspacing="0" border="1" align="center" width="90%" class="ForumTable">
                        <tr class="ForumTHeader">
                            <td style="padding-left: 10px;" nowrap colspan="2">
                                Konu</td>
                            <td nowrap>
                                Konuyu Açan</td>
                            <td nowrap>
                                Statüsü</td>
                            <td nowrap>
                                Yanýtlar</td>
                            <td nowrap>
                                Son Yazý</td>
                            <%if(IsAdmin)
                            { %>
                            <td></td>
                            <%} %>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr align="center">
                        <td>
                            <img src="Forum/images/icon1.gif" border="0" alt=""></td>
                        <td align="left" width="80%" class="FText12">
                            <asp:Label ID="lblArticleID" runat="server" Visible="False" Text='<%#DataBinder.Eval(Container.DataItem,"ArticleID") %>'></asp:Label>
                            <a href='<%#DataBinder.Eval(Container.DataItem,"ArticleID","Article.aspx?ArticleID={0}") %>'
                                class="ForumLink FText12">
                                <%#DataBinder.Eval(Container.DataItem,"ArticleSubject")%>
                            </a>
                        </td>
                        <td width="20%" nowrap>
                            <asp:Label ID="lblCreatedBy" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CreatedBy")%>'></asp:Label> 
                            <a href='<%#DataBinder.Eval(Container.DataItem,"CreatedBy","../MemberPage.aspx?MemberID={0}")%>' class="ForumLink FText12">
                                <%#DataBinder.Eval(Container.DataItem,"NickName")%>
                            </a>
                            <%# CheckIfAdminInserted(DataBinder.Eval(Container.DataItem,"NickName").ToString())%>
                                  
                           
                        </td>
                        <td>
                        <asp:label runat="server" ID="lblAStatus" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "ArticleStatus") %>'></asp:label>
                        <asp:panel ID="pnlAStatus" runat="server"><%#BINROTA.BUS.Forum.GetArticleStatusDesc((BINROTA.BUS.Forum.ArticleStatus)int.Parse(DataBinder.Eval(Container.DataItem, "ArticleStatus").ToString()))%></asp:panel>
                        <asp:panel ID="pnlAStatusSet" Visible="false" runat="server">
                        <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td><asp:DropDownList ID="ddlArticleStatus" runat="server"></asp:DropDownList> </td>
                            <td><asp:ImageButton ID="btnSaveStatus" runat="server" ImageUrl="~/Forum/images/ok.gif" OnClick="btnSaveStatus_Click"/></td>
                        </tr>
                        </table>
                        </asp:panel>
                        </td>
                        <td class="FText12">
                            <%#DataBinder.Eval(Container.DataItem,"Replies")%>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%" id="Table1">
                                <tr align="right">
                                    <td nowrap class="FText11">
                                        <%#DataBinder.Eval(Container.DataItem,"LastPost")%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <%if (IsAdmin)
                      { %>
                    <td>
                        <asp:ImageButton ID="btnEdit" OnClick="btnEdit_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ArticleID") %>'  runat="server" ImageUrl="~/Forum/images/edit.jpg" /></td>
                    <%} %>
                    </tr>
                    
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </td>
    </tr>
    <tr>
        <td height="15">
        </td>
    </tr>
    <tr>
        <td align="right" style="padding-right: 60px;">
            <uc1:uctrlPaging ID="UctrlPaging1" runat="server" />
        </td>
    </tr>
    <tr>
        <td height="15"></td>
    </tr>
    <tr>
        <td align="right" style="padding-right: 60px;"><asp:ImageButton ID="btnAddTopic2" runat="server" ImageUrl="~/Forum/images/AddTopic.jpg" OnClick="btnAddTopic2_Click" /></td>
    </tr>
    <tr>
        <td height="20">
        </td>
    </tr>
</table>
