<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlAddComment.ascx.cs" Inherits="UserControls_uctrlAddComment" %>
<table>
    <tr>
        <td colspan="3" align="center">
        <asp:Label ID="lbTitle" runat="server" Text=""></asp:Label>
        </td>
        <td style="width:150px">
            <asp:DropDownList ID="drpCategories" runat="server">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Yorum"></asp:Label></td>
        <td>
            :</td>
        <td>
            <asp:TextBox ID="txtComment" runat="server" Rows="4" TextMode="MultiLine" Width="260px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtComment"
                    ErrorMessage="Lütfen Bir Yazý Giriniz"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td colspan="3">
            &nbsp; &nbsp;&nbsp;
            <asp:RadioButtonList ID="rblPoints" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="5">&#199;ok Ýyi</asp:ListItem>
                <asp:ListItem Value="4">Ýyi</asp:ListItem>
                <asp:ListItem Selected="True" Value="3">Normal</asp:ListItem>
                <asp:ListItem Value="2">K&#246;t&#252;</asp:ListItem>
                <asp:ListItem Value="1">&#199;ok K&#246;t&#252;</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
        <asp:Button ID="btnSend" runat="server" Text="Gönder" OnClick="btnSend_Click" /></td>
    </tr>
    <tr>
        <td colspan="3">
        </td>
        <td>
            <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label></td>
    </tr>
</table>
