<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlMemberInfo.ascx.cs"
    Inherits="UserControls_Common_uctrlMemberInfo" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript">
function OpenUploadForPortrait() {
    window.open("ImageUpload.aspx?FileUploadType=MemberImages", 'BinrotaUpload', 'width=300,height=150,toolbar=no,resizable=no,');
}
function OpenAddPersonelPages(PageID) {
	if (PageID==null) {
		PageID = 0;
	}
    window.open("AddPersonelPage.aspx?PageID=" + PageID, 'BinrotaSayfaEkleme', 'width=800,height=800,toolbar=no,resizable=yes,scrollbars=yes,');
}
</script>

<table cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 299px">
        
            <table style="width: 100%; height:604px; border: solid 1px #FFFFFF; background-color: #43b8fe;">
                <tr>
                    <td style="padding: 15px 9px 5px 9px; vertical-align:top;"> 
                        <b><font class="Treb clWhite"> ÜYEL&#304;K B&#304;LG&#304;LER&#304;M </font></b>
                        
                        <br /><br />
                        
                        <table width="282" border="0" cellpadding="0" cellspacing="0" class="MemberInfo">
                            <tr>
                                <td height="146" width="142" align="left" valign="middle" style="padding-top: 20; padding-left: 20px;">
                                    <asp:Image ID="imgMemberPortrait" runat="server" BorderColor="#d8e8d4" BorderWidth="2" />
                                </td>
                                <td align="right"><br />
                                    <table height="124" width="125" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="T clRed">
                                                <b>
                                                    <asp:Label ID="lbNickName" runat="server"></asp:Label></b><br />
                                                <span class="T clOtherBlue">
                                                    <asp:Label ID="lbEmail" runat="server" Visible="False"></asp:Label></span></td>
                                        </tr>
                                        <tr>
                                            <td height="45">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="clRed" height="20">
                                                <asp:HyperLink ID="lnbUpdatePortrait" runat="server" CssClass="TRed" Text="Profil Foto" NavigateUrl="javascript:OpenUploadForPortrait()"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="23" valign="top" class="clRed">
                                                <asp:LinkButton ID="lnbDeletePortrait" runat="server" CssClass="TRed" Text="Resmi Kaldýr" OnClick="lnbDeletePortrait_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="140" colspan="2" align="center" valign="top"><br />
                                
                                
                                
                                    <table width="250" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="84" class="T clBlackBold" style="padding-left: 9px;">
                                                Motto
                                            </td>
                                            <td width="166">
                                                <asp:TextBox ID="txtMotto" runat="server" CssClass="TextBox" Width="166" ForeColor="#333D3F"></asp:TextBox>
                                                <asp:Label ID="lbMotto" runat="server" CssClass="Label" ForeColor="#333D3F" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="84" class="T clBlackBold" style="padding-left: 9px;">
                                                Ad
                                            </td>
                                            <td width="166">
                                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="TextBox" Width="166" ForeColor="#333D3F"></asp:TextBox>
                                                <asp:Label ID="lbFirstName" runat="server" CssClass="Label" ForeColor="#333D3F" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="84" class="T clBlackBold" style="padding-left: 9px;">
                                                Soyad
                                            </td>
                                            <td width="166">
                                                <asp:TextBox ID="txtLastName" runat="server" CssClass="TextBox" Width="166" ForeColor="#333D3F"></asp:TextBox>
                                                <asp:Label ID="lbLastName" runat="server" CssClass="Label" ForeColor="#333D3F" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="T clBlackBold" style="padding-left: 9px;">
                                                Do&#287;um G&uuml;n&uuml;
                                            </td>
                                            <td>
                                                <asp:Label ID="lbBirthDate" runat="server" CssClass="Label" ForeColor="#333D3F" Visible="false"></asp:Label>
                                                <asp:DropDownList ID="drpDay" runat="server" CssClass="DropDownList">
                                                </asp:DropDownList>&nbsp
                                                <asp:DropDownList ID="drpMonth" runat="server" CssClass="DropDownList">
                                                </asp:DropDownList>&nbsp
                                                <asp:DropDownList ID="drpYear" runat="server" CssClass="DropDownList">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="T clBlackBold" style="padding-left: 9px;" valign="top">
                                                Ya&#351;ad&#305;&#287;&#305; Yer
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                    
                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList Width="166" ID="drpCountry" runat="server" CssClass="DropDownList" AutoPostBack="True" OnSelectedIndexChanged="drpCountry_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-top: 5px;">
                                                                    <asp:DropDownList Width="166" ID="drpCity" runat="server" CssClass="DropDownList">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:Label ID="lbLivingPlace" runat="server" CssClass="Label" ForeColor="#333D3F" Visible="false"></asp:Label>
                                                    
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                
                                            </td>
                                        </tr>
                                         <tr>
                                            <td colspan="2" height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="T clBlackBold" style="padding-left: 9px;">
                                                Mesle&#287;i</td>
                                            <td>
                                                <asp:DropDownList ID="drpJob" runat="server" CssClass="DropDownList" Width="166">
                                                </asp:DropDownList>
                                                <asp:Label ID="lbJob" runat="server" CssClass="Label" ForeColor="#333D3F" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="T clBlackBold" style="padding-left: 9px;">
                                                Ýlgileri</td>
                                            <td>
                                                <asp:TextBox ID="txtInterests" runat="server" CssClass="TextBox" Width="166" ForeColor="#333D3F"></asp:TextBox>
                                                <asp:Label ID="lbInterests" runat="server" CssClass="Label" ForeColor="#333D3F" Visible="false"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="T clBlackBold" style="padding-left: 9px;">
                                                Gezdiði Yerler</td>
                                            <td>
                                                <asp:TextBox ID="txtVisitedPlaces" runat="server" CssClass="TextBox" Width="166" ForeColor="#333D3F"></asp:TextBox>
                                                <asp:Label ID="lbVisitedPlaces" runat="server" CssClass="Label" ForeColor="#333D3F" Visible="false"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" height="58">
                                    <table width="250" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="100" style="padding-left: 8px;">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Kaydet" CssClass="Button" OnClick="btnSubmit_Click" />
                                            </td>
                                            <td width="150" align="right">
                                                <asp:HyperLink ID="hplAllPages" runat="server" CssClass="HyperLink" Text="Tüm Yazýlarý" NavigateUrl=""></asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <br />
                                </td>
                            </tr>
                        </table>                        
                        
                    </td>
                </tr>
            </table>
        
        </td>
        <td style="width: 10px"></td>
        <td style="width: 388px; vertical-align: top;">
        
            <table style="width: 100%; height: 604px; border: solid 1px #FFFFFF; background-color: #c0e7ff">
                <tr>
                    <td style="padding: 15px 9px 5px 9px; vertical-align: top;"> 
                        <b><font class="BlueHeader"> SÖYLEMEK ÝSTEDÝÐÝM...</font></b> &nbsp;&nbsp;&nbsp;
                            <asp:HyperLink ID="hlpUpdatePersonelPage2" runat="server" Text="(Düzenle)" CssClass="TGray" NavigateUrl="javascript:OpenAddPersonelPages()"></asp:HyperLink>
                            <br /><br />
                        <asp:Literal ID="ltrMemberContentPage" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>        
        
        </td>
    </tr>
</table>

<%-- Arkadaþ listem aktif olunca açýlacak 
                       <table width="282" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="33" valign="middle" class="RegionHeader" style="padding-left: 6px; padding-top: 7px;">
                                    ARKADAS L&#304;STEM</td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="282" border="0" cellspacing="0" cellpadding="0" class="MemberInfo">
                                        <tr>
                                            <td width="57" height="65" align="center">
                                                <img src="Images/Content/Friend1.jpg" width="44" height="47"></td>
                                            <td width="223" class="T clRed">
                                                <b>Mehmet Mustafa Denizli </b>
                                                <br>
                                                <span class="T clOtherBlue">mustafadenizli@caretta.net</span></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="282" border="0" cellspacing="0" cellpadding="0" class="MemberInfo">
                                        <tr>
                                            <td height="65" align="center" style="width: 57px">
                                                <img src="Images/Content/Friend1.jpg" width="44" height="47"></td>
                                            <td width="223" class="T clRed">
                                                <b>Mehmet Mustafa Denizli </b>
                                                <br>
                                                <span class="T clOtherBlue">mustafadenizli@caretta.net</span></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>--%>