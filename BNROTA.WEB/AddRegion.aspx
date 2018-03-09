<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="AddRegion.aspx.cs" Inherits="AddRegion" Title="Untitled Page" %>

<%@ Register Src="UserControls/uctrlImageUpload.ascx" TagName="uctrlImageUpload"
    TagPrefix="uc2" %>

<%@ Register Src="UserControls/uctrlLogin.ascx" TagName="uctrlLogin" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <table>
                <tr>
                    <td style="width: 100px">
                        <asp:DropDownList ID="drpContinents" runat="server" OnSelectedIndexChanged="drpContinents_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="drpCountry" runat="server" AutoPostBack="True">
                        </asp:DropDownList></td>
                    <td style="width: 100px"></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label1" runat="server" Text="Ýsim"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtName" runat="server" Width="250px"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                            ErrorMessage="Lütfen bir isim giriniz" Width="174px"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label2" runat="server" Height="19px" Text="Açýklamasý"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtDescription" runat="server" Rows="5" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription"
                            ErrorMessage="Lütfen bir açýklama giriniz" Width="168px"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label3" runat="server" Height="19px" Text="Resim Yeri"></asp:Label></td>
                    <td style="width: 100px">
                        <uc2:uctrlImageUpload ID="UctrlImageUpload1" runat="server" />
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label4" runat="server" Height="19px" Text="Resim Baþlýðý"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtPhotoCaption" runat="server" Width="250px"></asp:TextBox></td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Button ID="btnSave" runat="server" Text="Kaydet" OnClick="btnSave_Click" /><br />
                        <asp:Button ID="btnDelete" runat="server" CausesValidation="False" OnClick="btnDelete_Click"
                            Text="Sil" Visible="False" Width="40px" /></td>
                    <td style="width: 100px">
                        </td>
                    <td style="width: 100px">
                        <asp:Label ID="lbMessage" runat="server"></asp:Label></td>
                </tr>
            </table>
</asp:Content>

