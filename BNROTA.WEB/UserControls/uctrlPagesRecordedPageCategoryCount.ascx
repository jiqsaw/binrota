<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlPagesRecordedPageCategoryCount.ascx.cs" Inherits="UserControls_uctrlRecordedPageCategoryCount" %>
<table width="220" style="text-align:center">

    <tr><td><b>En Çok Girilen Kategoriler</b></td></tr>
    <tr>
        
        <td>
        <asp:Repeater ID="rptPageCategoryCount" runat="server">
                            <ItemTemplate>
                                <a href='<%#DataBinder.Eval(Container.DataItem, "PageCategoryID", "Continent.aspx?PageCategoryID={0}")%>'>
                                    <%#DataBinder.Eval(Container.DataItem, "PageCategoryName") %>
                                </a>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <br />
                            </SeparatorTemplate>
                        </asp:Repeater>
        </td>
    </tr>
</table>
