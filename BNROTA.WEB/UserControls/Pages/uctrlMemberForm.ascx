<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlMemberForm.ascx.cs" Inherits="UserControls_Pages_uctrlMemberForm" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script type="text/javascript">
window.resizeTo(610, 580);
</script>

<table width="608" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="2" align="center" class="DegradeSPage">
                    <table width="608" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td colspan="3" height="13">
                             </td>
                        </tr>
                        <tr>
                            <td height="31" width="134" align="right">
                                <img src="Images/Design/BinrotaLogo.jpg" width="118" height="31">
                            </td>
                            <td width="417">
                                &nbsp;
                            </td>
                            <td width="63" class="T clDarkGreen">
                                <asp:HyperLink ID="hplClose" runat="server" Text="x kapat" NavigateUrl="javascript:window.close()"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="14">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table width="608" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="8" rowspan="2">
                                        </td>
                                        <td width="286" rowspan="2" bgcolor="#FFFFFF">
                                            <asp:Panel ID="pnlMemberForm" runat="server" Visible="true">
                                                <table width="286" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="17" rowspan="30">
                                                        </td>
                                                        <td height="11" colspan="2">
                                                            <asp:ValidationSummary ShowMessageBox="true"
                                                                ShowSummary="false"
                                                                HeaderText="You must enter a value in the following fields:"
                                                                EnableClientScript="true"
                                                                runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="BlueHeader">
                                                            &Uuml;YEL&#304;K FORMU
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="13" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="91" class="T clBlack">
                                                        Ad
                                                        </td>
                                                        <td>
                                                        <asp:TextBox ID="txtFirtsName" runat="server" CssClass="TextBox" Width="166" ForeColor="#AD0505"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen Bir Ad Giriniz" Text="*" ForeColor="red" ControlToValidate="txtFirtsName"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="4">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="91" class="T clBlack">
                                                            Soyad
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSurname" runat="server" CssClass="TextBox" Width="166" ForeColor="#AD0505"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen Bir Soyad Giriniz" Text="*" ForeColor="red" ControlToValidate="txtSurname"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="4">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="91" class="T clBlack">
                                                            Do&#287;um G&uuml;n&uuml;
                                                        </td>
                                                        <td>
                                                                    <asp:DropDownList ID="drpDay" runat="server" CssClass="DropDownList"></asp:DropDownList>&nbsp&nbsp
                                                                    <asp:DropDownList ID="drpMonth" runat="server" CssClass="DropDownList"></asp:DropDownList>&nbsp&nbsp
                                                                    <asp:DropDownList ID="drpYear" runat="server" CssClass="DropDownList"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="4">

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="91" class="T clBlack">
                                                            Ya&#351;ad&#305;&#287;&#305; Yer
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="drpCountry" runat="server" CssClass="DropDownList" Width="166" AutoPostBack="True" OnSelectedIndexChanged="drpCountry_SelectedIndexChanged"></asp:DropDownList><br />
                                                                    <asp:DropDownList ID="drpCity" runat="server" CssClass="DropDownList" Width="166"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>  
                                                        <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Lütfen Yaþadýðýnýz Þehri Seçiniz" Text="*" ForeColor="red" ControlToValidate="drpCity"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="4">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="91" class="T clBlack">
                                                            Mesle&#287;i
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpJob" runat="server" CssClass="DropDownList" Width="166"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Lütfen Bir Meslek Seçiniz" Text="*" ForeColor="red" ControlToValidate="drpJob"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="4">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="91" class="T clBlack">
                                                            Rumuz
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNickName" runat="server" CssClass="TextBox" Width="166" ForeColor="#AD0505"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Lütfen Bir Rumuz Giriniz" Text="*" ForeColor="red" ControlToValidate="txtNickName"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="4">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="91" class="T clBlack">
                                                            Email
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Width="166" ForeColor="#AD0505"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Lütfen Bir Email Adresi Giriniz" Text="*" ForeColor="red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Lütfen Düzgün Bir Email Adresi Giriniz" Text="*" ForeColor="red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="4">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="91" class="T clBlack">
                                                            &#350;ifre</td>
                                                        <td>
                                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" Width="166" ForeColor="#AD0505" TextMode="Password" ></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Lütfen Bir Þifre Giriniz" Text="*" ForeColor="red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="4">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="91" class="T clBlack">
                                                            &#350;ifre Tekrar
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPasswordAgain" runat="server" CssClass="TextBox" Width="166" ForeColor="#AD0505" TextMode="Password" ></asp:TextBox>
                                                        </td> 
                                                        <td>
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Girdiðiniz Þifre Daha Önce Girdiðiniz Þifre Ýle Ayný Deðil" Text="*" ForeColor="red" ControlToValidate="txtPasswordAgain" ControlToCompare="txtPassword"></asp:CompareValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Lütfen Þifreyi Tekrar Giriniz" Text="*" ForeColor="red" ControlToValidate="txtPasswordAgain"></asp:RequiredFieldValidator>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="4">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="91" class="T clBlack">
                                                            Cinsiyet
                                                        </td>
                                                        <td>
                                                        <asp:RadioButtonList ID="rblGender" runat="server" >
                                                            <asp:ListItem Value="true" Selected="True">Erkek</asp:ListItem>
                                                            <asp:ListItem Value="false">Kadýn</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        </td>
                                                        <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Lütfen Bir Cinsiyet Giriniz" Text="*" ForeColor="red" ControlToValidate="rblGender"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="18">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td class="T clDarkGreen">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="18">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:Button ID="btnSubmit" runat="server" Text="Kaydet" CssClass="Button" OnClick="btnSubmit_Click" />
                                                                &nbsp;
                                                                <input type="reset" name="Temizle" value="Temizle" class="Button" runat="server" id="btnClear" />
                                                            </td>

                                                    </tr>
                                                </table>
                                                </asp:Panel>
                                    <asp:Panel ID="pnlMessage" runat="server" Visible="false">
                                    <table width="286" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                    <td colspan="2" align="center">
                                    <asp:Label ID="lbMessage" runat="server"></asp:Label><br />
                                    <asp:HyperLink ID="hlBack" runat="server" Width="80" Text="Geri Dön" NavigateUrl="javascript:history.back()"></asp:HyperLink>

                                    </td>
                                    </tr>
                                    </table>
                                    </asp:Panel>

                                </td>
                                <td width="10" rowspan="2">
                                </td>
                                <td width="286" height="354" valign="top">
                                    <table width="286" class="DegradeBack" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="12" rowspan="7">
                                            </td>
                                            <td height="11" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="BlueHeader">
                                                Neden Yazar Olmal&#305;y&#305;m</td>
                                        </tr>
                                        <tr>
                                            <td height="13" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <img src="Images/Design/MemberContent1.jpg" width="266" height="126"/></td>
                                        </tr>
                                        <tr>
                                            <td height="17" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="266">
                                                Yola çýktýðým andan itibaren bir hikâyenin parçasý olduðum için, <br />
                                                Hikâyelerimi baþkalarýna anlatmak, baþkalarýnýn hikâyelerini okumak için, <br />
                                                Gördüðüm yerlerde, kendimde, insanlarda keþfettiklerimi belgelemek için,<br />
                                                Bilgi almak kadar bilgi vermenin deðerini de bildiðim için,<br />
                                                Baþka tatlarý, baþka yüzleri, baþka yaþamlarý merak ettiðim için,<br />
                                                Bir arada, ortak bir amaç belirleme ve harekete geçme özlemimi gidermek için, <br />
                                                Kendiminkinden baþka dünyalarýn varlýðýný kabul ettiðim için… <br />
                                                Ýçimdeki gezgini ve yazarý açýða çýkarmak için…

                                            </td>
                                            <td width="8">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="19">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="18" rowspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td height="8">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
   <tr>
        <td height="1" colspan="2" bgcolor="#BADDF0">
        </td>
    </tr>
<%--    <tr>
        <td width="283" align="right" class="StripedBottom">
            <asp:Button ID="btnSubmit" runat="server" Text="Kaydet" CssClass="Button" OnClick="btnSubmit_Click" />
            &nbsp;
            <input type="reset" name="Temizle" value="Temizle" class="Button" runat="server" id="btnClear" />
        </td>
        <td width="325" align="center" class="StripedBottom">
            &nbsp;</td>
    </tr>--%>
</table>
