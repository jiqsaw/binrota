<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="MemberPageUpdate.aspx.cs" Inherits="MemberPageUpdate" ValidateRequest="false" %>
<%@ Register Src="UserControls/uctrlPageTree.ascx" TagName="uctrlPageTree" TagPrefix="uc1" %>
<%@ Register Src="UserControls/uctrlPageContent.ascx" TagName="uctrlPageContent"
    TagPrefix="uc2" %>
<%@ Register Src="UserControls/uctrlPageCategories.ascx" TagName="uctrlPageCategories"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <uc1:uctrlPageTree ID="UctrlPageTree1" runat="server" Visible="false">
                    </uc1:uctrlPageTree>
                    <asp:Repeater ID="rptPages" runat="server" OnItemCommand="rptPages_ItemCommand">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPages" runat="server" CausesValidation="false" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PageID")%>'
                                Width="150">
                <%#DataBinder.Eval(Container.DataItem, "PageContentName")%>
            </asp:LinkButton>
                        </ItemTemplate>
                        <SeparatorTemplate>
                        </SeparatorTemplate>
                    </asp:Repeater>
                </td>
                <td style="width: 100px">
                    <uc2:uctrlPageContent ID="UctrlPageContent1" runat="server" />
                </td>
                <td style="width: 100px">
                    <uc3:uctrlPageCategories ID="UctrlPageCategories1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    <asp:Button ID="btnUpdate" runat="server" Text="Güncelle" OnClick="btnUpdate_Click" CausesValidation="False" /></td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
</asp:Content>

