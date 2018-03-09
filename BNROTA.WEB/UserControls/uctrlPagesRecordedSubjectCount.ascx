<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlPagesRecordedSubjectCount.ascx.cs" Inherits="UserControls_uctrlPagesRecordedSubjectCount" %>
<table width="220" style="text-align:center">
<tr><td><b>En Çok Yorum Girilen Yerler</b></td></tr>
    <tr>
        <td>
                <asp:Repeater ID="rptPageSubjectCount" runat="server">
                            <ItemTemplate>
                                <a href='<%#DataBinder.Eval(Container.DataItem, "SubjectID", "Continent.aspx?PageCategoryID={0}")%>'>
                                    <%#DataBinder.Eval(Container.DataItem, "SubjectName") %>
                                </a>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <br />
                            </SeparatorTemplate>
                        </asp:Repeater>
        </td>
    </tr>
</table>
