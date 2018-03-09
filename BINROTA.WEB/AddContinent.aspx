<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddContinent.aspx.cs" Inherits="AddContinent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <table>
                <tr>
                    <td style="width: 100px">
                        &nbsp;</td>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="lbUserID" runat="server" Text="Label" Visible="False"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label1" runat="server" Text="Ýsim"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                            ErrorMessage="Lütfen bir isim giriniz" Width="174px"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label2" runat="server" Height="19px" Text="Açýklamasý"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription"
                            ErrorMessage="Lütfen bir açýklama giriniz" Width="168px"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label3" runat="server" Height="19px" Text="Resim Yeri"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtPhotoPath" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label4" runat="server" Height="19px" Text="Resim Baþlýðý"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtPhotoCaption" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Kaydet" /></td>
                    <td style="width: 100px">
                        <asp:Button ID="btnMainPage" runat="server" OnClick="btnMainPage_Click" Text="Ana Sayfa" CausesValidation="False" /></td>
                    <td style="width: 100px">
                        <asp:Label ID="lbMessage" runat="server"></asp:Label></td>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>
