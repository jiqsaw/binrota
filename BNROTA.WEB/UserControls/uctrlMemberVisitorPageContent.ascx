<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlMemberVisitorPageContent.ascx.cs" Inherits="UserControls_uctrlMemberVisitorPageContent" %>
<%@ Register Src="uctrlAddComment.ascx" TagName="uctrlAddComment" TagPrefix="uc1" %>
<table>
    <tr>
    <td>
        <table>
        <tr>
        <td style="width: 100px">
        <b>Baþlýk</b></td>
        <td style="width: 2px">
        <b>:</b>
        </td>
        <td style="width:auto">
        <asp:Label ID="lbTitle" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td style="width: 100px">
        <b>Gezi Türü</b>
        </td>
        <td style="width: 2px">
        <b>:</b>
        </td>
        <td style="width:auto">
        <asp:Label ID="lbPageCategory" runat="server">
        </asp:Label></td>
        </tr>
        <tr>
        <td style="width: 100px">
        <b>Seyahat Tarihi</b></td>
        <td style="width: 2px">
        <b>:</b>
        </td>
        <td style="width:auto">
        <asp:Label ID="lbTravelDate" runat="server"></asp:Label></td>
        </tr></table></td></tr>
    
  
    <tr>
        <td colspan="3" align="center"><b><asp:Label ID="lbTravelPageTitle" runat="server" Text="Seyahat Yazýsý"></asp:Label> </b></td> 
    </tr>
    <tr>
        <td colspan="3" align="center">
        <asp:TextBox ID="txtPageContent" runat="server" TextMode="MultiLine" Rows="14" Width="400" ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="3">
        <asp:LinkButton ID="lnbAddComment" runat="server" OnClick="lnbAddComment_Click" CausesValidation="False">Yorum Ekle</asp:LinkButton></td>
    </tr>
    <tr>
        <td colspan="3">
            &nbsp;</td>
    </tr>
</table>
