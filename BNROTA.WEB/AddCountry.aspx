<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="AddCountry.aspx.cs" Inherits="AddCountry" %>

<%@ Register Src="UserControls/uctrlImageUpload.ascx" TagName="uctrlImageUpload"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table>
            <tr>
                <td style="width: 100px">
        <asp:DropDownList ID="drpContinents" runat="server" AutoPostBack="True">
        </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Label ID="lbUserID" runat="server" Text="Label" Visible="False"></asp:Label></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
        <asp:Label ID="Label1" runat="server" Text="�sim"></asp:Label></td>
                <td style="width: 100px">
        <asp:TextBox ID="txtName" runat="server" Width="250px"></asp:TextBox></td>
                <td style="width: 100px">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
            ErrorMessage="L�tfen isim alan�n� doldurunuz" Width="219px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px">
        <asp:Label ID="Label2" runat="server" Height="19px" Text="A��klamas�"></asp:Label></td>
                <td style="width: 100px">
        <asp:TextBox ID="txtDescription" runat="server" Rows="5" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
                <td style="width: 100px">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription"
            ErrorMessage="L�tfen a��klama alan�n� doldurunuz" Width="226px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px">
        <asp:Label ID="Label3" runat="server" Height="19px" Text="Resim Yeri"></asp:Label></td>
                <td style="width: 100px">
                    <uc1:uctrlImageUpload ID="UctrlImageUpload1" runat="server" />
                </td>
                <td style="width: 100px">
                <asp:Image BorderColor="#eef9ff" BorderWidth="3" ID="imgCountry" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
        <asp:Label ID="Label4" runat="server" Height="19px" Text="Resim Ba�l���"></asp:Label></td>
                <td style="width: 100px">
        <asp:TextBox ID="txtPhotoCaption" runat="server" Width="250px"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label5" runat="server" Text="Konum "></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtLocation" runat="server" Width="250px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLocation"
                        ErrorMessage="L�tfen konum alan�n� doldurunuz" Width="219px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label6" runat="server" Text="Ba�kent"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtCapital" runat="server" Width="250px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCapital"
                        ErrorMessage="L�tfen ba�kent alan�n� doldurunuz" Width="219px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                    <asp:Label ID="Label7" runat="server" Text="Y�z�l��m�"></asp:Label></td>
                <td style="width: 100px; height: 21px">
                    <asp:TextBox ID="txtArea" runat="server" Width="250px"></asp:TextBox></td>
                <td style="width: 100px; height: 21px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtArea"
                        ErrorMessage="L�tfen y�z�l��m� alan�n� doldurunuz" Width="219px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                    <asp:Label ID="Label8" runat="server" Text="Kom�ular� "></asp:Label></td>
                <td style="width: 100px; height: 21px">
                    <asp:TextBox ID="txtNeighbourhood" runat="server" Width="250px"></asp:TextBox></td>
                <td style="width: 100px; height: 21px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNeighbourhood"
                        ErrorMessage="L�tfen kom�ular� alan�n� doldurunuz" Width="219px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                    <asp:Label ID="Label9" runat="server" Text="N�fus"></asp:Label></td>
                <td style="width: 100px; height: 21px">
                    <asp:TextBox ID="txtPopulation" runat="server" Width="250px"></asp:TextBox></td>
                <td style="width: 100px; height: 21px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPopulation"
                        ErrorMessage="L�tfen n�fus alan�n� doldurunuz" Width="219px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                    <asp:Label ID="Label10" runat="server" Text="Para birimi "></asp:Label></td>
                <td style="width: 100px; height: 21px">
                    <asp:TextBox ID="txtCurrency" runat="server" Width="250px"></asp:TextBox></td>
                <td style="width: 100px; height: 21px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCurrency"
                        ErrorMessage="L�tfen para birimi alan�n� doldurunuz" Width="219px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                    <asp:Label ID="Label11" runat="server" Text="Telefon kodu  "></asp:Label></td>
                <td style="width: 100px; height: 21px">
                    <asp:TextBox ID="txtAreaCode" runat="server" Width="250px"></asp:TextBox></td>
                <td style="width: 100px; height: 21px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAreaCode"
                        ErrorMessage="L�tfen telefon kodu alan�n� doldurunuz" Width="247px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                    <asp:Label ID="Label12" runat="server" Text="Saat dilimi "></asp:Label></td>
                <td style="width: 100px; height: 21px">
                    <asp:TextBox ID="txtTimeZone" runat="server" Width="250px"></asp:TextBox></td>
                <td style="width: 100px; height: 21px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtTimeZone"
                        ErrorMessage="L�tfen saat dilimi alan�n� doldurunuz" Width="219px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label13" runat="server" Text="Dil"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtLanguage" runat="server" Width="250px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtLanguage"
                        ErrorMessage="L�tfen dil alan�n� doldurunuz" Width="219px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label14" runat="server" Text="Din"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtReligion" runat="server" Width="250px"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtReligion"
                        ErrorMessage="L�tfen din alan�n� doldurunuz" Width="219px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 26px;">
                    &nbsp;</td>
                <td style="width: 100px; height: 26px;">
        <asp:Button ID="btnAddCity" runat="server" OnClick="btnSave_Click" Text="Kaydet" Width="60px" /><br />
                    <asp:Button ID="btnDelete" runat="server" CausesValidation="False" OnClick="btnDelete_Click"
                        Text="Sil" Visible="False" Width="40px" /></td>
                <td style="width: 100px; height: 26px;">
        </td>
                <td style="width: 100px; height: 26px;">
        <asp:Label ID="LabelMessage" runat="server"></asp:Label></td>
            </tr>
        </table>
    
    </div>
</asp:Content>

