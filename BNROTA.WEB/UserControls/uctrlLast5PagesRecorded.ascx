<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlLast5PagesRecorded.ascx.cs" Inherits="UserControls_uctrlLast5PagesRecorded" %>
<table width="220" style="text-align:center">
<tr><td><b>Son Girilen 10 Yorum</b></td></tr>
    <tr>
        <td>
                        <asp:Repeater ID="rptLast5PageRecorded" runat="server">
                            <ItemTemplate>
                                <a href='<%#DataBinder.Eval(Container.DataItem, "PageID", "MemberVisitorContentPage.aspx?PageID={0}")%>'>
                                    <%#DataBinder.Eval(Container.DataItem, "Title") %>
                                </a>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <br />
                            </SeparatorTemplate>
                        </asp:Repeater>
        </td>
    </tr>
</table>
