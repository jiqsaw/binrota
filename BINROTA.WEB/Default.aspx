<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" validateRequest="false"%>

<%@ Register Src="UserControls/uctFreeTextBox.ascx" TagName="uctFreeTextBox" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;<table>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 80px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:DropDownList ID="drpCategories" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpCategories_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>
                <td style="width: 80px">
                    <asp:Label ID="lbMessage" runat="server" Width="100px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px">
        <asp:TreeView ID="tvSubjects" runat="server" OnSelectedNodeChanged="tvSubjects_SelectedNodeChanged">
        </asp:TreeView>
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    <uc1:uctFreeTextBox ID="ftbPageContent" runat="server" />
                </td>
                <td style="width: 80px">
                    <asp:Button ID="btnUpdate" runat="server" Text="Güncelle" OnClick="btnUpdate_Click" CausesValidation="False" /></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 80px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 80px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 80px">
                </td>
            </tr>
        </table>
        &nbsp; &nbsp;
        &nbsp;&nbsp;
    
    </div>
        &nbsp;
    </form>
</body>
</html>
