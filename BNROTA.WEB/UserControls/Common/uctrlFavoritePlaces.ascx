<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlFavoritePlaces.ascx.cs" Inherits="UserControls_Common_uctrlFavoritePlaces" %>
<table width="100%" height="100%" border="0"  cellspacing="0" class="DegradeBack" cellpadding="0">
  <tr>
    <td height="38" valign="top"><table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td class="RegionBottomTd Treb" style="padding-left: 4px;"> FAVORÝ ROTALAR </td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td valign="top" height="207">
    <div id="dvContent" class="dvScroll Scroll" runat="server">
      <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
        <asp:Repeater ID="rptFavoritePlaces" runat="server" OnItemDataBound="rptFavoritePlaces_ItemDataBound">
        <ItemTemplate>
        <tr>
          <td width="81" align="left">
          <asp:Image ID="imgFavoritePlaces" runat="server" Width="73" Height="61" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "PhotoPath")%>' />
          </td>
          <td class="SNewsTitle">
          <a href='<%#DataBinder.Eval(Container.DataItem, "SubjectUrl") %>'><%#DataBinder.Eval(Container.DataItem, "Name")%></a>
          <br />
          <asp:Literal ID="ltrPagesCount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PageCount")%>'></asp:Literal>
          </td>
        </tr>
        <tr>
          <td height="12"></td>
        </tr>
        <tr>
          <td colspan="2" class="PlottedSepTd"></td>
        </tr>
        <tr>
          <td height="12"></td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>


      </table>
    </div></td>
  </tr>
</table>