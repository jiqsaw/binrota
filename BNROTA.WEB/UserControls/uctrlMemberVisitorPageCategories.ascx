<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlMemberVisitorPageCategories.ascx.cs" Inherits="UserControls_uctrlMemberVisitorPageCategories" %>

<asp:Repeater ID="rptPageCategories" runat="server">
<HeaderTemplate>
    <table>
</HeaderTemplate>
<ItemTemplate>
    <tr>
        <td style="width: 330px">
            <b><asp:Label ID="lblCategoryID" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "CategoryID")%>'></asp:Label><asp:Label ID="lblCategoryName" runat="server"></asp:Label></b></td>
        <td style="width: 100px">
        </td>
    </tr>
    <tr>
        <td style="width: 330px">
            <asp:TextBox ID="txtCategoryContent" Width="400" TextMode="MultiLine" Rows="3" runat="server" ReadOnly="true"></asp:TextBox></td>
    </tr>
</ItemTemplate>
<FooterTemplate>
    </table>
</FooterTemplate>
</asp:Repeater>