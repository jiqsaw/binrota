<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlAddPage.ascx.cs"
    Inherits="UserControls_Pages_uctrlAddPage" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../uctFreeTextBox.ascx" TagName="uctFreeTextBox" TagPrefix="uc2" %>
<%@ Register Src="../uctrlPageCategories.ascx" TagName="uctrlPageCategories" TagPrefix="uc1" %>

<script type="text/javascript">
window.resizeTo(1000,800)
</script>

<table width="986" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td colspan="2" align="center" class="DegradeSPage">
            <table width="970" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="13" colspan="3">
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="31" width="125" align="right">
                                    <img src="Images/Design/BinrotaLogo.jpg" width="118" height="31"></td>
                                <td width="772">
                                    &nbsp;</td>
                                <td width="71" class="T clDarkGreen">
                    <asp:HyperLink ID="hplClose" runat="server" Text="x kapat" NavigateUrl="javascript:window.close()"></asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="14" colspan="3">
                    </td>
                </tr>
                <asp:Panel ID="pnlPageContent" runat="server" Visible="true">
                <tr>
                    <td width="670" bgcolor="#FFFFFF" valign="top">
                    
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

 <table width="670" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="16" rowspan="9">
                                    &nbsp;</td>
                                <td width="287" height="10" colspan="2">
                                </td>
                                <td width="367" colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="BlueHeader">
                                    GEZ&#304; YAZISI EKLE
                                </td>
                                <td width="367" colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td height="16" colspan="2">

                                </td>
                                <td width="367" colspan="2">
                                </td>
                            </tr>
                            <tr> 

                                <td width="42" class="T clBlack">
                                    K&#305;ta</td>
                                <td width="245">
                                    <asp:DropDownList ID="drpContinent" runat="server" AutoPostBack="true" CssClass="DropDownList" ForeColor="#AD0505" Width="200" OnSelectedIndexChanged="drpContinent_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                <td width="78" class="T clBlack">
                                    Ba&#351;l&#305;k</td>
                                <td width="289">
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="TextBox" Width="276" ForeColor="#AD0505"></asp:TextBox>
                                    </td> 
                                    
                            </tr>
                            <tr>
                                <td colspan="2" height="5">
                                </td>
                                <td width="367" colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td class="T clBlack">
                                    &Uuml;lke</td>
                                <td>
                                    <asp:DropDownList ID="drpCountry" runat="server" AutoPostBack="true" CssClass="DropDownList" ForeColor="#AD0505" Width="200" OnSelectedIndexChanged="drpCountry_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td class="T clBlack">
                                    Gezi T&uuml;r&uuml;
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpPageCategory" runat="server" CssClass="DropDownList" Width="200" ForeColor="#AD0505"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" height="5">
                                </td>
                                <td width="367" colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td class="T clBlack">
                                    &#350;ehir</td>
                                <td>
                                    <asp:DropDownList ID="drpCity" runat="server" CssClass="DropDownList" Width="200" ForeColor="#AD0505"></asp:DropDownList>
                                </td>
                                <td class="T clBlack">
                                    Seyahat Tarihi
                                </td>
                                <td>
                                     <asp:DropDownList ID="drpDay" runat="server" CssClass="DropDownList" Width="50"></asp:DropDownList>&nbsp&nbsp
                                     <asp:DropDownList ID="drpMonth" runat="server" CssClass="DropDownList" Width="50"></asp:DropDownList>&nbsp&nbsp
                                     <asp:DropDownList ID="drpYear" runat="server" CssClass="DropDownList" Width="70"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" height="9">
                                </td>
                                <td colspan="2">
                                </td>
                            </tr>
                        </table>

</ContentTemplate>
</asp:UpdatePanel>
                        
                    </td>
                    <td rowspan="3" class="HSpace">
                        &nbsp;</td>
                    <td rowspan="3" bgcolor="#FFFFFF" width="291" valign="top">
                        <table cellpadding="10px">
                        <tr>
                        <td>
                                  <uc1:uctrlPageCategories ID="UctrlPageCategories1" runat="server" />
              
                        </td>
                        </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="VSpace">
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#FFFFFF">
                        <table width="670" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="12" rowspan="5">
                                </td>
                                <td height="10">
                                </td>
                            </tr>
                            <tr>
                                <td class="T clBlack">
                                    ANLATMAK &#304;STED&#304;KLER&#304;N&#304;Z
                                </td>
                            </tr>
                            <tr>
                                <td height="10">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <uc2:uctFreeTextBox ID="ftbPageContent" runat="server" />                                    
                                </td>
                            </tr>
                            <tr>
                                <td height="7">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" height="1" bgcolor="#B8DFF0">
                    </td>
                </tr>
                </asp:Panel>
            </table>
        </td>
    </tr>
    <tr>
        <td height="1" colspan="2" bgcolor="#BADDF0">
        </td>
    </tr>
    <asp:Panel ID="pnlButtons" runat="server" Visible="true">
    <tr>
        <td width="595" align="right" class="StripedBottom">
            <asp:Button ID="btnSubmit" runat="server" Text="Kaydet" CssClass="Button" OnClick="btnSubmit_Click" />
            &nbsp;
            <input type="reset" name="Temizle" value="Temizle" class="Button"/>
        </td>
        <td width="391" align="center" class="StripedBottom">
            &nbsp;</td>
    </tr>
    </asp:Panel>
    
    <asp:Panel ID="pnlMessage" runat="server" Visible="false">
        <tr align="center" valign="middle">
            <td>
                <asp:Label ID="lbMessage" runat="server" CssClass="Label" Font-Size="15"></asp:Label>&nbsp&nbsp<br /><br />
                <asp:HyperLink ID="hlBack" runat="server" Text="Geri Dön" NavigateUrl="javascript:history.back()" Font-Size="15"></asp:HyperLink>
            </td>
        </tr>
    </asp:Panel> 
    
</table>
