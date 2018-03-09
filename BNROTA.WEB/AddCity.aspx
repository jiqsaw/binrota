<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="AddCity.aspx.cs" Inherits="AddCity"  %>
<%@ Register Src="UserControls/uctrlImageUpload.ascx" TagName="uctrlImageUpload"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
            <table>
                <tr>
                    <td style="width: 100px">
                        <asp:DropDownList ID="drpContinents" runat="server" OnSelectedIndexChanged="drpContinents_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="drpCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpCountry_SelectedIndexChanged">
                        </asp:DropDownList></td>
                    <td style="width: 132px"><asp:DropDownList ID="drpRegion" runat="server" Visible="False">
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label1" runat="server" Text="Ýsim"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtName" runat="server" Width="250px"></asp:TextBox></td>
                    <td style="width: 132px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                            ErrorMessage="Lütfen bir isim giriniz" Width="174px"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label2" runat="server" Height="19px" Text="Açýklamasý"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtDescription" runat="server" Rows="5" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
                    <td style="width: 132px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription"
                            ErrorMessage="Lütfen bir açýklama giriniz" Width="180px"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label3" runat="server" Height="19px" Text="Resim Yeri"></asp:Label></td>
                    <td style="width: 100px">
                        <uc1:uctrlImageUpload ID="UctrlImageUpload1" runat="server" />
                    </td>
                    <td style="width: 132px">
                        &nbsp;<asp:Image ID="imgCity" runat="server" BorderColor="#eef9ff" BorderWidth="3" /></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label4" runat="server" Height="19px" Text="Resim Baþlýðý"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtPhotoCaption" runat="server" Width="250px"></asp:TextBox></td>
                    <td style="width: 132px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 25px;">
                        <asp:Button ID="btnSave" runat="server" Text="Kaydet" OnClick="btnSave_Click" /><br />
                        <br />
                        <asp:Button ID="btnDelete" runat="server" Text="Sil" Visible="False" Width="40px"  CausesValidation="False" OnClick="btnDelete_Click"  /></td>
                    <td style="width: 100px; height: 25px;" valign="top">
                        </td>
                    <td style="width: 132px; height: 25px;">
                        <asp:Label ID="lbMessage" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

</asp:Content>

