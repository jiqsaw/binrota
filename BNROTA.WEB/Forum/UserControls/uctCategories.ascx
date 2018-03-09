<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctCategories.ascx.cs"
    Inherits="Forum_UserControls_uctCategories" %>
<%@ Register Src="uctrlNewItem.ascx" TagName="uctrlNewItem" TagPrefix="uc2" %>
<%@ Register Src="../../UserControls/Common/uctrlPaging.ascx" TagName="uctrlPaging"
    TagPrefix="uc1" %>
<link rel="stylesheet" type="text/css" href="Forum/Styles/Forum.css">
<table class="Content LogoBack" cellpadding="0" cellspacing="0" border="0" align="center" bgcolor="#ffffff">
    <tr>
        <td height="20">
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" align="center" cellspacing="0" width="90%">
                <tr>
                    <td>
                        <asp:Image runat="server" ID="imgForumTitle" ImageUrl="~/Forum/images/ForumTitle.jpg" />
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
    <%if (IsAdmin)
      { %>
      <tr>
      <td style="padding-right:60px;" align="right"><asp:ImageButton ID="btnAddCategory" ImageUrl="~/Forum/images/AddCategory.jpg" OnClick="btnAddCategory_Click" runat="server" /></td>
      </tr>
      <tr>
      <td height="10"></td>
      </tr>
    <%} %>
    <tr>
        <td>
        <asp:Repeater ID="rptCategories" runat="server">
        <HeaderTemplate>
        <table cellpadding="4" cellspacing="0" border="1" align="center" width="90%" class="ForumTable">
                <tr align="center" class="ForumTHeader">
                    <td colspan="2" width="80%" align="left">
                        <b>Forum</b></td>
                    <td>
                        <b>Konular</b></td>
                    <td nowrap>
                        <b>Son Yazý</b></td>
                    <%if(IsAdmin)
                      { %>
                    <td></td>
                    <td align="center">Sýra</td>
                      <%} %>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr align="center">
                    <td colspan="2" align="left">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td valign="top">
                                <%if (IsAdmin)
                                  { %>
                                  <%#BINROTA.BUS.Forum.GetCategoryStatusDesc((BINROTA.BUS.Forum.CategoryStatus)int.Parse(DataBinder.Eval(Container.DataItem,"CategoryStatus").ToString())) %>
                                <%}%>
                                    <img style="display: none;" src='<%#BINROTA.BUS.Forum.GetCategoryTypeImgUrl((BINROTA.BUS.Forum.CategoryStatus)int.Parse(DataBinder.Eval(Container.DataItem,"CategoryStatus").ToString())) %>' />
                                   
                                </td>
                                <td width="9">
                                </td>
                                <td class="FText11">
                                    <asp:Label ID="lblCategoryID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CategoryID")%>' Visible="false"></asp:Label>
                                    <a href='<%#DataBinder.Eval(Container.DataItem,"CategoryID","Category.aspx?CategoryID={0}") %>' class="ForumWTitle ForumLink"><%#DataBinder.Eval(Container.DataItem, "CategoryName")%></a>
                                    <br>
                                    <%#DataBinder.Eval(Container.DataItem,"CategoryDesc")%>
                                    </td>
                            </tr>
                        </table>
                    </td>
                    <td class="FText13">
                        <%#DataBinder.Eval(Container.DataItem,"ArticlesCount") %></td>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%" id="ltlink">
                            <tr align="right">
                                <td nowrap class="FText11">
                                    <%#DataBinder.Eval(Container.DataItem, "LastPost")%></td>
                            </tr>
                        </table>
                    </td>
                    <%if(IsAdmin)
                      { %>
                    <td>
                        <asp:ImageButton ID="btnEdit" OnClick="btnEdit_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CategoryID") %>'  runat="server" ImageUrl="~/Forum/images/edit.jpg" /></td>
                    <td>
                        <asp:TextBox ID="txtOrder" runat="server" class="TextBox" Width="50px" Text='<%#DataBinder.Eval(Container.DataItem,"Order")%>'></asp:TextBox>
                        </td>
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
    <%if (IsAdmin)
      {%>
    <tr>
        <td height="15"></td>
    </tr>
    <tr>
        <td align="right" style="padding-right:60px;"><asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Forum/images/save.jpg" OnClick="btnSave_Click"  /></td>
    </tr>
    <%} %>
    <tr>
        <td height="20">
        </td>
    </tr>
</table>
