<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="City.aspx.cs" Inherits="City"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lbName" runat="server"></asp:Label></td>
                <td style="width: 6px">
                </td>
                <td style="width: 55px">
                    <asp:Image ID="imgCity" runat="server" BorderColor="#eef9ff" BorderWidth="3" />
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
                    <asp:TextBox ID="txtDescription" runat="server" Rows="5" TextMode="MultiLine" Width="250px" ReadOnly="True"></asp:TextBox>&nbsp</td>
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
                    <asp:HyperLink ID="hpAddDetail" runat="server" Width="106px" Visible="False" ForeColor="Red">Gezi Yazýsý Ekle</asp:HyperLink></td>
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
</asp:Content>

