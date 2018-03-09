<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="PagesView.aspx.cs" Inherits="PagesView" %>

<%@ Register Src="UserControls/Pages/uctrlPagesView.ascx" TagName="uctrlPagesView"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <uc1:uctrlPagesView ID="UctrlPagesView1" runat="server" />
</asp:Content>

