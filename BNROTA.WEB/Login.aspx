<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Register Src="UserControls/uctrlLoginPage.ascx" TagName="uctrlLoginPage" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uctrlLoginPage ID="uctrlLoginPage1" runat="server" />
</asp:Content>
