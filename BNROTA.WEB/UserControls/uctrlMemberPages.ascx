<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlMemberPages.ascx.cs" Inherits="UserControls_uctrlMemberPages" %>
<table>
    <tr>
        <td style="width:100%">
            &nbsp;<asp:Repeater ID="rptPages" runat="server" OnItemCommand="rptPages_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkPages" runat="server" CausesValidation="false" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PageID")%>'
                        Width="150">
                <%#DataBinder.Eval(Container.DataItem, "PageContentName")%>
            </asp:LinkButton>
                </ItemTemplate>
                <SeparatorTemplate>
                <br />
                </SeparatorTemplate>
            </asp:Repeater>
        </td>
    </tr>
</table>
