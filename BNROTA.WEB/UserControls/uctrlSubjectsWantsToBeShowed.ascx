<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlSubjectsWantsToBeShowed.ascx.cs" Inherits="UserControls_uctrlSubjectsWantsToBeShowed" %>
<table>
    <tr>
        <td>
        <b>Gözde Olan Yerler</b>
        </td>
    </tr>
    <tr>
        <td>
                        <asp:Repeater ID="rptSubjectsWantsToBeShowed" runat="server">
                            <ItemTemplate>
                                <a href='<%#DataBinder.Eval(Container.DataItem, "MarketingGroupsItemsID", "Continent.aspx?MemberID={0}")%>'>
                                    <%#DataBinder.Eval(Container.DataItem, "Name") %>
                                </a>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <br />
                            </SeparatorTemplate>
                        </asp:Repeater>
        </td>
    </tr>
</table>
