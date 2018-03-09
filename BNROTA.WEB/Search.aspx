<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>
<%@ Register Src="UserControls/Common/uctrlSearch.ascx" TagName="uctrlSearch" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uctrlSearch ID="uctrlSearch1" runat="server" />
</asp:Content>
