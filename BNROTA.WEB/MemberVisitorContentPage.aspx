<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="MemberVisitorContentPage.aspx.cs" Inherits="MemberVisitorContentPage" Title="Untitled Page" ValidateRequest="false" %>

<%@ Register Src="UserControls/uctrlPageComments.ascx" TagName="uctrlPageComments"
    TagPrefix="uc2" %>

<%@ Register Src="UserControls/uctrlAddComment.ascx" TagName="uctrlAddComment" TagPrefix="uc1" %>

<%@ Register Src="UserControls/uctrlMemberVisitorPageCategories.ascx" TagName="uctrlMemberVisitorPageCategories"
    TagPrefix="uc4" %>

<%@ Register Src="UserControls/uctrlMemberVisitorPageContent.ascx" TagName="uctrlMemberVisitorPageContent"
    TagPrefix="uc3" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="width: 51px" valign="top">
            <table>
            <tr>
            <td>
            <b><asp:Label ID="lbTitle" runat="server"></asp:Label></b>
            </td>
            </tr>
            <tr>
            <td>
            <asp:Repeater ID="rptPages" runat="server" OnItemCommand="rptPages_ItemCommand">
            <ItemTemplate>
            
            <asp:LinkButton runat="server" ID="lnkPages" Width="150" CausesValidation="false" 
            CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PageID")%>'>
                <%#DataBinder.Eval(Container.DataItem, "PageContentName")%>
            </asp:LinkButton>
            </ItemTemplate>
            <SeparatorTemplate></SeparatorTemplate>            
            </asp:Repeater>
            </td>
            </tr>
            </table>
            
            </td>
            <td valign="top">
            <table>
            <tr>
            <td><uc3:uctrlMemberVisitorPageContent ID="UctrlMemberVisitorPageContent1" runat="server" /></td>            </tr>
            <tr>
            <td><uc2:uctrlPageComments ID="UctrlPageComments1" runat="server" /></td>
            </tr>
            </table>
            </td>
            
            <td valign="top">
                <uc4:uctrlMemberVisitorPageCategories ID="UctrlMemberVisitorPageCategories1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <uc1:uctrlAddComment ID="UctrlAddComment1" runat="server" Visible="false" />
            </td>
            <td>
            </td>
        </tr>
    </table>

</asp:Content>

