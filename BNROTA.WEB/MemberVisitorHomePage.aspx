<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="MemberVisitorHomePage.aspx.cs" Inherits="MemberVisitorHomePage" Title="Untitled Page" ValidateRequest="false" %>

<%@ Register Src="UserControls/uctrlMemberVisitorHomePage.ascx" TagName="uctrlMemberVisitorHomePage"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="width: 100px">
                <uc1:uctrlMemberVisitorHomePage ID="UctrlMemberVisitorHomePage1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

