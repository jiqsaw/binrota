<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="Categories" Title="BINROTA FORUM" ValidateRequest="false"%>

<%@ Register Src="~/Forum/UserControls/uctCategories.ascx" TagName="uctCategories" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uctCategories ID="UctCategories1" runat="server" />
</asp:Content>

