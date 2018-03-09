<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlMainPlaces.ascx.cs"
    Inherits="UserControls_MainPage_uctrlMainPlaces" %>
<table width="599" class="MainCities" border="0" cellspacing="0" cellpadding="0" height="147">
    <tr>
        <td>

        <div style="padding-left: 51px; padding-top: 25px;">
                <asp:Repeater ID="rptMainPlaces" runat="server" OnItemDataBound="rptMainPlaces_ItemDataBound">
                <HeaderTemplate>
                    <table>
                        <tr>
                </HeaderTemplate>
                
                <ItemTemplate>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="61" align="center">
                        <asp:Image ID="imgMainPlaces" runat="server" Width="73" Height="61" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "PhotoPath")%>' />
                    </td>
                    </tr>
                    <tr>
                        <td height="37" align="center" class="MainCityItem">
                        <a href='<%#DataBinder.Eval(Container.DataItem, "SubjectUrl") %>' class="MainCityItem"><%#DataBinder.Eval(Container.DataItem, "Name")%></a>
                        </td>
                    </tr>
                    </table>
                </td>
                </ItemTemplate>
                
                <SeparatorTemplate>
                    <td style="width: 28px;" rowspan="4"> </td>
                </SeparatorTemplate>
                
                <FooterTemplate>
                        </tr>
                    </table>
                </FooterTemplate>
                </asp:Repeater>
        </div>
    
        </td>
    </tr>
</table>