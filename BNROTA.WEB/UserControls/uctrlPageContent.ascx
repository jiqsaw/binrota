<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlPageContent.ascx.cs" Inherits="UserControls_uctrlPageContent" %>
<%@ Register Src="uctFreeTextBox.ascx" TagName="uctFreeTextBox" TagPrefix="uc1" %>
<table>
    <tr>
        <td style="width: 141px">
        <b>Ba�l�k</b></td>
        <td>
        <b>:</b>
        </td>
        <td style="width: 111px">
            <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>&nbsp
            </td>
    </tr>
    <tr>
        <td style="width: 141px">
        <b>Gezi T�r�</b>
        </td>
        <td>
        <b>:</b>
        </td>
        <td style="width: 111px">
            <asp:DropDownList ID="drpPageCategory" runat="server">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 141px">
        </td>
        <td>
        </td>
        <td style="width: 111px">
            <asp:Label ID="Label1" runat="server" Text="G�n:" Width="40px"></asp:Label><asp:DropDownList
                ID="drpDay" runat="server" Width="60px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 141px">
        <b>Seyahat Tarihi</b></td>
        <td>
        <b>:</b>
        </td>
        <td style="width: 111px">
            <asp:Label ID="Label2" runat="server" Text="Ay:" Width="40px"></asp:Label><asp:DropDownList ID="drpMonth" runat="server" Width="60px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 141px">
        </td>
        <td>
        </td>
        <td style="width: 111px">
            <asp:Label ID="Label3" runat="server" Text="Y�l:" Width="40px"></asp:Label><asp:DropDownList
                ID="drpYear" runat="server" Width="60px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 141px">
        <b>Seyahat Yaz�s�</b></td>
        <td>
        <b>:</b>
        </td>
        <td style="width: 111px">
            <uc1:uctFreeTextBox ID="ftbPageContent" runat="server" />
        </td>
    </tr>
</table>
