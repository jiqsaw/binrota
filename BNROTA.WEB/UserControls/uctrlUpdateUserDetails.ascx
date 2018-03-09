<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlUpdateUserDetails.ascx.cs" Inherits="UserControls_uctrlUpdateUserDetails" %>
<%@ Register Src="uctFreeTextBox.ascx" TagName="uctFreeTextBox" TagPrefix="uc1" %>
<table>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label></td>
        <td>
        </td>
        <td style="width: 100px">
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="Label1" runat="server" Text="Ad"></asp:Label></td>
        <td>:</td>
        <td style="width: 100px">
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="Label2" runat="server" Text="Soyad"></asp:Label></td>
        <td>:
        </td>
        <td style="width: 100px">
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="Label3" runat="server" Text="Yaþadýðý Yer"></asp:Label></td>
        <td>:
        </td>
        <td style="width: 100px">
            <asp:TextBox ID="txtLivingPlace" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="Label4" runat="server" Text="Eðitimi"></asp:Label></td>
        <td>:
        </td>
        <td style="width: 100px">
            <asp:TextBox ID="txtEducation" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="Label5" runat="server" Text="Ýþi"></asp:Label></td>
        <td>:
        </td>
        <td style="width: 100px">
            <asp:TextBox ID="txtJob" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="Label6" runat="server" Text="Ýlgileri"></asp:Label></td>
        <td>:
        </td>
        <td style="width: 100px">
            <asp:TextBox ID="txtInterest" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="Label8" runat="server" Text="Motto"></asp:Label></td>
        <td>:
        </td>
        <td style="width: 100px">
            <asp:TextBox ID="txtMotto" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="Label7" runat="server" Text="Kiþisel Yazý"></asp:Label></td>
        <td>:
        </td>
        <td style="width: 100px">
            <uc1:uctFreeTextBox ID="ftbHomePageContent" runat="server" />
        </td>
    </tr>
    
    <tr>
        <td style="width: 100px">
        </td>
        <td>
        </td>
        <td style="width: 100px">
            <asp:Button ID="btnUpdate" runat="server" Text="Güncelle" OnClick="btnUpdate_Click" /></td>
    </tr>
</table>
