<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlTripCategories.ascx.cs"
    Inherits="UserControls_MainPage_uctrlTripCategories" %>
<table border="1" bordercolor="#FFFFFF" class="TripCategories" width="100%" height="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td valign="top">
            <table width="94%" border="0" align="right" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3" class="clDarkBlack Treb" style="padding-top: 14px; padding-bottom: 13px;">
                        <strong>SEYAHAT KATEGOR&#304;LER&#304; </strong>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:DataList ID="dlTripCategories"  runat="server" RepeatColumns="3" Width="100%" OnItemDataBound="dlTripCategories_ItemDataBound">
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="line-height: 1.9;">
                                            &not;
                                            <asp:HyperLink ID="hplPageCategory" runat="server"
                                            Text='<%#DataBinder.Eval(Container.DataItem, "PageCategoryName").ToString() + " (" + DataBinder.Eval(Container.DataItem, "PageCount").ToString() + ")"%>'
                                            ToolTip='<%#DataBinder.Eval(Container.DataItem, "PageCount") %>'
                                            NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "PageCategoryID", "~/Search.aspx?PageCategoryID={0}")%>'
                                            ></asp:HyperLink>

                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
