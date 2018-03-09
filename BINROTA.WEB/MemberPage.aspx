<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberPage.aspx.cs" Inherits="MemberPage" ValidateRequest="false"%>

<%@ Register Src="UserControls/uctFreeTextBox.ascx" TagName="uctFreeTextBox" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Binrota Kullanýcý sayfasý</title>
    
            <link type="text/css"  rel="stylesheet" href="~/Styles/Stylesheet.css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 41px">
                    <asp:Label ID="Label1" runat="server" Text="Baþlýk"></asp:Label>:</td>
                <td rowspan="1" style="width: 100px">
                    <asp:TextBox ID="txtTitle" runat="server" Width="229px"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
                <td style="width: 111px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 41px">
                </td>
                <td rowspan="7" style="width: 100px">
                    <uc1:uctFreeTextBox ID="ftbPageContent" runat="server" />
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 111px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 41px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 111px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 41px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 111px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:DropDownList ID="drpCategories" runat="server">
                    </asp:DropDownList></td>
                <td style="width: 41px">
                    <asp:Label ID="Label2" runat="server" Text="Görüþ"></asp:Label>:</td>
                <td style="width: 100px">
                    <asp:Button CausesValidation="false" ID="btnAdd" runat="server" Text="Görüþ Ekle" OnClick="btnAdd_Click" /></td>
                <td style="width: 111px">
                    <asp:Label ID="lbMessage" runat="server" Width="200px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 41px">
                </td>
                <td style="width: 100px">
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Güncelle" /></td>
                <td style="width: 111px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 41px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 111px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 41px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 111px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
