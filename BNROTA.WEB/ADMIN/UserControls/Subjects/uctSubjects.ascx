<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctSubjects.ascx.cs" Inherits="ADMIN_UserControls_Subjects_uctSubjects" %>
<%@ Register Src="../../../UserControls/uctrlImageUpload.ascx" TagName="uctrlImageUpload"
    TagPrefix="uc1" %>

<table width="100%">
    <tr>
		<td colspan="2" class="ListTitle yerac" bgcolor="#525667">&nbsp;&nbsp;
		    <asp:Literal runat="server" ID="ltlSubSubTitle">
		        MEKAN YÖNETÝMÝ
		    </asp:Literal>
		</td>
    </tr>
    <tr align="left">
        <td>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td valign="top">
                                <asp:TreeView ID="tvSubjects" runat="server" OnSelectedNodeChanged="tvSubjects_SelectedNodeChanged" ShowLines="False" >
                                    <SelectedNodeStyle BackColor="#FFFF80" />
                                </asp:TreeView>
                            </td>
                            <td valign="top" style="padding-left:25px;">
                                <asp:Panel ID="pnlGeneral" runat="server">
                                    <table>
                                        <tr>
                                        <td colspan="4">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="drpContinents" CssClass="DropDownList" runat="server" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="drpContinents_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="drpCountries" CssClass="DropDownList" runat="server" Visible="false"></asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        </tr>                
                                        <tr>
                                            <td>
                                                Ýsim
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtName" runat="server" Width="250px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                                    ErrorMessage="Lütfen isim alanýný doldurunuz"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Açýklamasý
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDescription" runat="server" Rows="5" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription"
                                                    ErrorMessage="Lütfen açýklama alanýný doldurunuz"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Resim Baþlýðý
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPhotoCaption" runat="server" Width="250px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Resim
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <uc1:uctrlImageUpload ID="UctrlImageUpload1" runat="server" />
                                            </td>
                                            <td>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Image ID="imgSubjectPhoto" runat="server" BorderColor="#eef9ff" BorderWidth="3" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlCountry" runat="server" Visible="false">
                                    <table>
                                        <tr>
                                            <td>
                                                Konum
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLocation" runat="server" Width="250px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLocation"
                                                    ErrorMessage="Lütfen konum alanýný doldurunuz"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Baþkent
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCapital" runat="server" Width="250px"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCapital"
                                                    ErrorMessage="Lütfen baþkent alanýný doldurunuz"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Yüzölçümü
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtArea" runat="server" Width="250px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtArea"
                                                    ErrorMessage="Lütfen yüzölçümü alanýný doldurunuz"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Komþularý
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNeighbourhood" runat="server" Width="250px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNeighbourhood"
                                                    ErrorMessage="Lütfen komþularý alanýný doldurunuz"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Nüfus
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPopulation" runat="server" Width="250px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPopulation"
                                                    ErrorMessage="Lütfen nüfus alanýný doldurunuz"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Para Birimi
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCurrency" runat="server" Width="250px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCurrency"
                                                    ErrorMessage="Lütfen para birimi alanýný doldurunuz"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Telefon Kodu
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAreaCode" runat="server" Width="250px"></asp:TextBox>
                                            </td>
                                             <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAreaCode"
                                                    ErrorMessage="Lütfen telefon kodu alanýný doldurunuz"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Saat Dilimi
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTimeZone" runat="server" Width="250px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtTimeZone"
                                                    ErrorMessage="Lütfen saat dilimi alanýný doldurunuz"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Dil
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLanguage" runat="server" Width="250px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtLanguage"
                                                    ErrorMessage="Lütfen dil alanýný doldurunuz"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Din
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtReligion" CssClass="forms" runat="server" Width="250px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtReligion"
                                                    ErrorMessage="Lütfen din alanýný doldurunuz"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlFooter" runat="server">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnSubmit" CssClass="btn" runat="server" Text="Kaydet" OnClick="btnSubmit_Click" />
                                            </td>
                                            <td style="width:100%;">
                                                <asp:Label ID="lbMessage" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>