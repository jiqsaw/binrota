    <%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlPageCategories.ascx.cs" Inherits="UserControls_uctrlPageCategories" %>

<asp:Repeater ID="rptPageCategories" runat="server">
<HeaderTemplate>
    <table>
</HeaderTemplate>
<ItemTemplate>
    <tr>
        <td style="width: 330px">
            <b><asp:Label ID="lblCategoryID" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "CategoryID")%>'></asp:Label><asp:Label ID="lblCategoryName" runat="server"></asp:Label></b></td>
    </tr>
    <tr>
    <td height="3">
    </td>
    </tr>
    <tr>
        <td style="width: 330px">
            <asp:TextBox ID="txtCategoryContent" Width="268" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox></td>
    </tr>
</ItemTemplate>
<FooterTemplate>
    </table>
</FooterTemplate>
</asp:Repeater>
