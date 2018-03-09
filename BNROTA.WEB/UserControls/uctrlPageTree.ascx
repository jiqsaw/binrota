<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlPageTree.ascx.cs" Inherits="UserControls_uctrlPageTree" %>
<table>
    <tr>
        <td style="width: 100px">
            <asp:TreeView ID="tvSubjects" runat="server" OnSelectedNodeChanged="tvSubjects_SelectedNodeChanged" ShowLines="True" >
                <SelectedNodeStyle BackColor="#FFFF80" />
            </asp:TreeView>
        </td>
    </tr>
</table>
