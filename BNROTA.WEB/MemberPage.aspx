<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="MemberPage.aspx.cs" Inherits="MemberPage"  %>

<%@ Register Src="UserControls/Pages/uctrlMemberPage.ascx" TagName="uctrlMemberPage"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uctrlMemberPage ID="UctrlMemberPage1" runat="server" />
</asp:Content>

