<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlLogin.ascx.cs" Inherits="UserControls_uctrlLogin" %>
<table border=0 cellpadding=0 cellspacing=0>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td style="width: 84px">
        </td>
    </tr>
    <tr>
    <td>Kullan�c� Ad�</td>
    <td>&nbsp; : &nbsp;</td>
    <td><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
    <td style="width: 84px"> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
            ErrorMessage="L�tfen Bir Kullan�c� ad� giriniz!" Width="204px"></asp:RequiredFieldValidator></td>
</tr><tr>
    <td>�ifre</td>
    <td>&nbsp; : &nbsp;</td>
    <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>    
    <td style="width: 84px">
        <asp:HyperLink ID="hlForgotPassword" runat="server"
            Width="113px" NavigateUrl="~/ForgotPassword.aspx">�ifremi Unuttum</asp:HyperLink></td>
</tr><tr>
    <td></td>
    <td></td>
    <td><asp:Button ID="btnLogin" runat="server" Text="Ba�lan" OnClick="btnLogin_Click" /></td>    
    <td style="width: 84px">
        <asp:Label ID="lbMessage" runat="server" Width="241px"></asp:Label></td>
    </tr>
</table>


