<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlCommunication.ascx.cs" Inherits="UserControls_Common_uctrlCommunication" %>
<%@ Register Src="uctrlFavoritePlaces.ascx" TagName="uctrlFavoritePlaces" TagPrefix="uc3" %>
<%@ Register Src="uctrlLastTripSubjects.ascx" TagName="uctrlLastTripSubjects" TagPrefix="uc2" %>
<%@ Register Src="uctrlSubRightRegion.ascx" TagName="uctrlSubRightRegion" TagPrefix="uc1" %>
<table class="Content" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td width="695" colspan="4" valign="top" style="background-color:White; padding:30;">
        <table style="height:543px;">
        <tr>
        <td style="height:25;">
        </td>
        </tr>
        <tr>
        <td class="BlueHeader">
        <b>ÝLETÝÞÝM FORMU</b><br /><br />
        <asp:Panel ID="pnlForm" runat="server" Visible="true">
                <table style="background-color:#E5F8FF; border-style:dotted; border-width:thin; width:600;">
                <tr>
                <td colspan="2"><br /><br />
                </td>
                </tr>
                <tr>
                <td style="padding-left:30; width:100;">
                    Ad Soyad
                </td>
                <td>
                <asp:TextBox ID="txtFullName" runat="server" CssClass="TextBox" Width="350"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td style="padding-left:30; width:100;">
                    Email
                </td>
                <td>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Width="350"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td style="padding-left:30; width:100;">
                    Mesajýnýz
                </td>
                <td>
                <asp:TextBox ID="txtMessage" TextMode="MultiLine" Rows="5" runat="server" Width="350"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td style="padding-left:50;">
                <br />
                    <asp:Button ID="btnSubmit" runat="server" Text="Gönder" CssClass="Button" OnClick="btnSubmit_Click" />
                </td>
                <td>
                <br />
                    <input type="reset" name="Reset" value="Temizle" class="Button" />
                    
                </td>
                </tr>
                <tr>
                <td style="height:25;">
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlEmailSuccess" runat="server" Visible="false">
        <table style="background-color:#E5F8FF; border-style:dotted; border-width:thin; width:600;">
          <tr>
            <td height="27" colspan="2" valign="top" class="Treb clDarkGreen"></td>
          </tr>
          <tr>
            <td height="30" colspan="2" class="T clBlack">
            <asp:Literal ID="ltrEmailSuccess" runat="server" Text=""></asp:Literal> 
            </td>
          </tr>
          <tr>
            <td height="14" colspan="2"></td>
          </tr>
          <tr>
            <td width="35"></td>
            <td>
            <asp:HyperLink ID="HyperLink1" runat="server" Text="Geri Dön" NavigateUrl="javascript:history.back()"></asp:HyperLink>
            </td>
          </tr>
          </table>
          </asp:Panel>
        </td>
        </tr>
        
        </table>
        </td>
        <td rowspan="3" class="HSpace">
        </td>
        <td width="267" rowspan="3" valign="top">
            <uc1:uctrlSubRightRegion ID="UctrlSubRightRegion1" runat="server" />
        
        </td>
    </tr>
    <tr>
        <td colspan="4" class="VSpace">
        </td>
    </tr>
    <tr>
    <td width="425">
        <uc2:uctrlLastTripSubjects ID="UctrlLastTripSubjects1" runat="server" />
    </td>
    <td class="VSpace" style="width:8;">
    </td>
    <td width="263" valign="top" bgcolor="#E5F8FF">
        <uc3:uctrlFavoritePlaces ID="UctrlFavoritePlaces1" runat="server" />
    </td>
    <td></td>
    </tr>
</table>
