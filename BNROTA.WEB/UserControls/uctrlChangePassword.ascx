<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlChangePassword.ascx.cs" Inherits="UserControls_uctrlChangePassword" %>
<table>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Eski �ifre"></asp:Label></td>
        <td>
            :</td>
        <td>
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            <td style="width:100%">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="L�tfen Eski �ifreyi Giriniz"
                    Width="169px" ControlToValidate="txtOldPassword"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Yeni �ifre"></asp:Label></td>
        <td>
            :</td>
        <td>
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            <td style="width:100%">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="L�tfen Yeni �ifreyi Giriniz" ControlToValidate="txtNewPassword"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Yeni �ifre Tekrar" Width="107px"></asp:Label></td>
        <td>
            :</td>
        <td>
            <asp:TextBox ID="txtNewPasswordAgain" runat="server" TextMode="Password"></asp:TextBox></td>
            <td style="width:100%"> 
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Tekrar Etti�iniz �ifre Girdi�iniz �ifre �le Ayn� De�il" ControlToValidate="txtNewPasswordAgain" ControlToCompare="txtNewPassword"></asp:CompareValidator></td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
            <asp:Button ID="btnChange" runat="server" OnClick="btnChange_Click" Text="De�i�tir" /></td>
        <td style="width:100%">
            <asp:Label ID="lbMessage" runat="server"></asp:Label></td>
    </tr>
</table>
