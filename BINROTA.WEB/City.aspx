<%@ Page Language="C#" AutoEventWireup="true" CodeFile="City.aspx.cs" Inherits="City" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    
            <link type="text/css"  rel="stylesheet" href="~/Styles/Stylesheet.css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lbName" runat="server"></asp:Label></td>
                <td style="width: 6px">
                </td>
                <td style="width: 55px">
                </td>
                <td style="width: 108px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 6px">
                </td>
                <td style="width: 55px">
                </td>
                <td style="width: 108px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 20px;">
                    <asp:Label ID="Label1" runat="server" Text="Açýklama"></asp:Label></td>
                <td style="width: 6px;">
                    :</td>
                <td style="width: 55px; height: 20px;">
                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>&nbsp</td>
                <td style="width: 108px; height: 20px">
                    <asp:Button ID="btnUpdate" runat="server" Text="Düzenle" Visible="False" OnClick="btnUpdate_Click" /></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 6px">
                </td>
                <td style="width: 55px">
                </td>
                <td style="width: 108px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    </td>
                <td style="width: 6px">
                </td>
                <td style="width: 55px">
                    <asp:HyperLink ID="hpAddDetail" runat="server" Width="170px" Visible="False">Kendi görüþlerinizi ekleyin</asp:HyperLink></td>
                <td style="width: 108px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px;">
                </td>
                <td style="width: 6px; height: 21px;">
                </td>
                <td style="width: 55px; height: 21px;">
                </td>
                <td style="width: 108px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 6px">
                </td>
                <td style="width: 55px">
                </td>
                <td style="width: 108px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 6px">
                </td>
                <td style="width: 55px">
                </td>
                <td style="width: 108px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
