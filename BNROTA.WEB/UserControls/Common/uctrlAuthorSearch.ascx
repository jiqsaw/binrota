<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlAuthorSearch.ascx.cs"
    Inherits="UserControls_Common_uctrlAuthorSearch" %>
<table width="267" cellpadding="0" cellspacing="0" class="SearchAuthor">
    <tr>
        <td colspan="3" valign="top" height="26" class="RegionHeader" style="padding-left: 14px;
            padding-top: 7px;">
            BINROTALI ARA</td>
    </tr>
    <tr>
        <td width="12">
            &nbsp;</td>
        <td width="210" valign="top">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="TextBox" Width="198"></asp:TextBox>
        <td width="43" valign="top" style="padding-top: 1px;">
            <asp:ImageButton ID="imgSearch" runat="server" Width="21" Height="20"
            ImageUrl="~/Images/Design/SearchButton.gif" OnClick="imgSearch_Click" />
        </td>
    </tr>
</table>
