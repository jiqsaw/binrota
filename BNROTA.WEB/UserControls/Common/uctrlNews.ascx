<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlNews.ascx.cs" Inherits="UserControls_Common_uctrlNews" %>
<table width="100%" style="height: 100%;" border="1" cellspacing="1" class="DegradeBack" cellpadding="1">
    <tr>
        <td height="38" valign="top">
            <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="RegionBottomTd Treb" style="padding-left: 4px;">
                        PANO</td>
                </tr>
            </table>
        </td>
    </tr>
      <tr>
        <td height="224" valign="top">
        <div id="dvContent" runat="server" class="dvScroll Scroll">
          <table width="92%" border="0" align="center" cellpadding="3" cellspacing="3">
          
          <asp:Repeater ID="rptNews" runat="server" OnItemDataBound="rptNews_ItemDataBound">
          <ItemTemplate>
              <tr>
                <td width="56" align="left">
                <a href='<%#DataBinder.Eval(Container.DataItem, "ActivityID", "News.aspx?ActivityID={0}")%>'>
                <asp:Image BorderColor="#97d5ea" BorderWidth="3" ID="imgNews" runat="server" Width="48" Height="39" 
                ImageUrl='<%#DataBinder.Eval(Container.DataItem, "PhotoPath")%>' />
                </a>
                </td>
              <td><span class="SNewsTitle">
              <asp:HyperLink ID="hplNewsTitle" runat="server" CssClass="T clBlack" 
              Text='<%#DataBinder.Eval(Container.DataItem, "ActivityTitle")%>'
              NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "ActivityID", "~/News.aspx?ActivityID={0}")%>'></asp:HyperLink>
              </span><br />
                      <span class="T clBlack">
                      <asp:HyperLink ID="ltrNewsDescription" runat="server" CssClass="T clBlack"
                      Text='<%#CARETTA.COM.Util.Left(DataBinder.Eval(Container.DataItem, "Description").ToString(), 80) + "..."%>'
                      NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "ActivityID", "~/News.aspx?ActivityID={0}")%>'></asp:HyperLink>
              </span></td>
            </tr>
            <tr>
              <td colspan="2" class="PlottedSepTd"></td>
            </tr>
         </ItemTemplate>
          </asp:Repeater>

          </table>
          
          
          
          
        </div>
        </td>
      </tr>
      <tr>
        <td style="text-align: right; padding-right: 15px; height: 30px; background-color: #cae9f7;">
            &not; <asp:HyperLink runat="server" ID="hlAllNews" Text="t&uuml;m haberler" NavigateUrl="~/News.aspx"></asp:HyperLink>
        </td>
      </tr>
</table>