<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlArticleItems.ascx.cs"
    Inherits="Forum_UserControls_uctrlArticleItems" %>
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
                            <asp:HyperLink ID="hlCategoryName" CssClass="ForumLink FText12" runat="server"></asp:HyperLink>
                            >
                            <asp:Label ID="lblArticleName" runat="server" CssClass="FText12"></asp:Label></b>
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
        <td align="right" style="padding-right: 60px;">
            <uc1:uctrlPaging ID="UctrlPaging2" runat="server" />
        </td>
    </tr>
    <tr>
        <td height="15">
        </td>
    </tr>
    <tr>
        <td>
        <table cellpadding="4" cellspacing="0" border="1" align="center" width="90%" class="ForumTable">
                        <tr class="ForumTHeader">
                            <td width="25%" align="left" style="padding-left: 10px;">
                                Yazar</td>
                            <td width="75%">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="100%" class="ForumTHeader" style="padding-left: 10px;">
                                            Konu</td>
                                        <td class="ForumTHeader" style="padding-right: 10px;">
                                            <asp:ImageButton ID="btnAddTopic" ImageUrl="~/Forum/images/AddTopicB.jpg" runat="server" OnClick="btnAddTopic_Click"/></td>
                                        <td style="padding-right: 10px;">
                                            <asp:ImageButton ID="btnReply" ImageUrl="~/Forum/images/ReplyB.jpg" runat="server" OnClick="btnReply_Click"/></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
            <asp:Repeater ID="rptArticleItems" runat="server">
                
                <ItemTemplate>
                    <tr align="center">
                        <td valign="top" align="left" class="FText11" style="padding: 10px;">
                            <asp:Label ID="lblAItemID" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"ArticleItemID")%>'
                                runat="server"></asp:Label>
                                <asp:Label ID="lblMemberID" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CreatedBy")%>' runat="server"></asp:Label>
                                <asp:Label ID="lblRMemberID" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"MemberID")%>'
                                runat="server"></asp:Label>
                                <asp:Panel ID="pnlMemberCreated" runat="server">
                            <a href='<%#DataBinder.Eval(Container.DataItem,"CreatedBy","../MemberPage.aspx?MemberID={0}")%>'>
                                <b>
                                    <%#DataBinder.Eval(Container.DataItem,"NickName")%>
                                </b></a>
                            <br /> 
                            <asp:Image ID="imgMemberProfile" runat="server" ImageUrl='<%#BINROTA.COM.Common.ReturnImagePath(DataBinder.Eval(Container.DataItem,"PhotoPath").ToString(), ConfigurationManager.AppSettings["MemberImagesUrl"].ToString()) %>'/>
                            </asp:Panel>
                            <asp:Panel ID="pnlAdminCreated" runat="server" Visible="false">
                            <b>
                                    ADMIN
                                </b>
                                </asp:Panel>
                        </td>
                        <td align="left" class="FText12" style="padding: 10px;" valign="top">
                            <img src="Forum/images/icon1.gif" border="0" alt=""><asp:Label ID="lblTitle" runat="server" CssClass="FText11" Text='<%#DataBinder.Eval(Container.DataItem,"Subject") %>'></asp:Label><br /><br />
                            <asp:Label ID="lblContent" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Reply")%>'></asp:Label>    
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td class="FText11" style="padding: 10px;" align="left">
                            <%#DataBinder.Eval(Container.DataItem,"CreateDate") %>
                            <%if (IsAdmin)
                              { %>
                                 - <%#BINROTA.BUS.Forum.GetArticleItemStatusDesc((BINROTA.BUS.Forum.ArticleItemStatus)int.Parse(DataBinder.Eval(Container.DataItem,"Status").ToString())) %>
                            <%}%>
                        </td>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="padding-left: 10px;">
                                        <img src="Forum/images/starblue.gif" /></td>
                                    <td style="padding-left: 5px;" width="62%">
                                        TOPLAM PUAN :
                                        <%#DataBinder.Eval(Container.DataItem ,"Score") %>
                                    </td>
                                    <td width="7%">
                                        PUAN :
                                    </td>
                                    <td style="width: 20px;">
                                        <asp:DropDownList ID="ddlScore" runat="server">
                                        </asp:DropDownList></td>
                                    <td style="padding-right: 10px;">
                                        <asp:ImageButton ID="btnGivePoint" ImageUrl="~/Forum/images/GivePoint.jpg" runat="server" OnClick="btnGivePoint_Click"/></td>
                                    <asp:Panel ID="pnlEdit" runat="server" Visible="false">
                                        <td style="padding-right: 10px;">
                                            <asp:ImageButton ID="btnEdit" ImageUrl="~/Forum/images/edit.jpg" runat="server" OnClick="btnEdit_Click"/></td>
                                    </asp:Panel>
                                    <td style="padding-right: 10px;">
                                        <asp:ImageButton ID="btnReply" ImageUrl="~/Forum/images/quote.jpg" runat="server" OnClick="btnQuote_Click"/></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </ItemTemplate>
                
            </asp:Repeater>
            <tr class="ForumTHeader">
                            <td width="25%" align="left" style="padding-left: 10px;">
                                </td>
                            <td width="75%">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="100%" class="ForumTHeader" style="padding-left: 10px;">
                                            </td>
                                        <td class="ForumTHeader" style="padding-right: 10px;">
                                            <asp:ImageButton ID="btnAddTopic2" ImageUrl="~/Forum/images/AddTopicB.jpg" runat="server" OnClick="btnAddTopic_Click"/></td>
                                        <td style="padding-right: 10px;">
                                            <asp:ImageButton ID="btnReply2" ImageUrl="~/Forum/images/ReplyB.jpg" runat="server" OnClick="btnReply_Click"/></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
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
        <td height="20">
        </td>
    </tr>
</table>
