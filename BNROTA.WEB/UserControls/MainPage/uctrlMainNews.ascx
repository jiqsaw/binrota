<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlMainNews.ascx.cs"
    Inherits="UserControls_MainPage_uctrlMainNews" %>
<table width="431" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="Padding6px" bgcolor="#FFFFFF"">
            <table class="MainNews" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                   
                        <table cellpadding="3" cellspacing="3">
                            <tr>
                                <td class="NewsTitle" style="vertical-align: top;">
                                    <asp:Image ID="imgMNews" BorderColor="#FFFFFF" BorderWidth="3" runat="server" Width="156" Height="98"/>
                                </td>
                                <td class="NewsSpot" style="line-height: 1.3em;">
                                    <asp:HyperLink ID="hplMTitle" runat="server" CssClass="SNewsTitle"></asp:HyperLink> <br />
                                    <asp:Image runat="server" ID="imgArrow" ImageUrl="~/Images/Design/NewsArrow.jpg" />
                                    <asp:Label ID="lbMDescription" runat="server" CssClass="T clBlack"></asp:Label>
                                    <asp:HyperLink ID="hplDetails" Font-Bold="true" runat="server" Text="»»»" CssClass="T clBlack"></asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                        
                    </td>
                </tr>
            </table>

            <asp:Repeater ID="rptNews" runat="server" OnItemDataBound="rptNews_ItemDataBound">
            <ItemTemplate>
                <table class="News" border="0" cellspacing="0" cellpadding="0">

                    <tr>
                        <td align="left" style="width: 50px; padding-left: 8px; padding-right: 8px;">
                            <a href='<%#DataBinder.Eval(Container.DataItem, "ActivityID", "News.aspx?ActivityID={0}")%>'>
                            <asp:Image BorderColor="#FFFFFF" BorderWidth="3" runat="server" ID="imgNews" Width="48" Height="39" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "PhotoPath")%>' />
                            </a>
                        </td>
                        <td class="NewsTitle">
                            
                            <asp:HyperLink ID="lbTitle" runat="server" CssClass="SNewsTitle"
                            Text='<%#DataBinder.Eval(Container.DataItem, "ActivityTitle")%>'
                            NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "ActivityID", "~/News.aspx?ActivityID={0}")%>'></asp:HyperLink>
                            <br />
                            <asp:HyperLink ID="lbDescription" runat="server" CssClass="T clBlack"
                            Text='<%#DataBinder.Eval(Container.DataItem, "Description")%>'
                            NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "ActivityID", "~/News.aspx?ActivityID={0}")%>'>></asp:HyperLink>                            
                            
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            </asp:Repeater>
            
        </td>
    </tr>
    <tr>
        <td>
            <table width="431" bgcolor="#ffffff" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="352" align="left" class="RegionBottomTd Treb">
                        PANO
                    </td>
                    <td width="79" align="right" class="Treb clDarkBlack" style="padding-right: 12px;">
                        1 | 2 | 3</td>
                </tr>
            </table>
        </td>
    </tr>
</table>
