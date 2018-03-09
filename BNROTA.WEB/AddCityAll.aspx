<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="AddCityAll.aspx.cs" Inherits="AddCityAll" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label></td>
            <td style="width: 130px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:DropDownList ID="drpContinents" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpContinents_SelectedIndexChanged" >
                </asp:DropDownList></td>
            <td style="width: 130px">
                <asp:DropDownList ID="drpCountry" runat="server" AutoPostBack="True">
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" Text="Þehirler"></asp:Label></td>
            <td style="width: 130px">
                <asp:TextBox ID="txtName" runat="server" Rows="8" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 130px">
                <asp:Button ID="btnAddAllCities" runat="server" Text="Þehirleri Ekle" OnClick="btnAddAllCities_Click" /></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 130px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

