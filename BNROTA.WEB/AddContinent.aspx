<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="AddContinent.aspx.cs" Inherits="AddContinent"  %>
<%@ Register Src="UserControls/uctrlImageUpload.ascx" TagName="uctrlImageUpload"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                        <uc1:uctrlImageUpload ID="UctrlImageUpload1" runat="server" />
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
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Kaydet" /><br />
                        <asp:Button ID="btnDelete" runat="server" CausesValidation="False" OnClick="btnDelete_Click"
                            Text="Sil" Visible="False" Width="40px" /></td>
                    <td style="width: 100px">
                        </td>
                    <td style="width: 100px">
                        <asp:Label ID="lbMessage" runat="server"></asp:Label></td>
                </tr>
            </table>
        </div>
    
    </div>

</asp:Content>

