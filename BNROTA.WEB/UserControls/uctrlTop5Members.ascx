<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlTop5Members.ascx.cs" Inherits="UserControls_uctrlTop5Members" %>
<table width="220" style="text-align:center">
<tr><td><b>Ýlk 10 Kullanýcý</b></td></tr>
    <tr>
        <td>
                <asp:Repeater ID="rptTop5Member" runat="server">
                            <ItemTemplate>
                                <a href='<%#DataBinder.Eval(Container.DataItem, "MemberID", "MemberVisitorHomePage.aspx?MemberID={0}")%>'>
                                    <%#DataBinder.Eval(Container.DataItem, "MemberName") %>
                                </a>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <br />
                            </SeparatorTemplate>
                        </asp:Repeater>
        </td>
    </tr>
</table>
