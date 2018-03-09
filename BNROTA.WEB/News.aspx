<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<%@ Register Src="UserControls/Pages/uctrlNewsPage.ascx" TagName="uctrlNewsPage"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uctrlNewsPage id="UctrlNewsPage1" runat="server">
    </uc1:uctrlNewsPage>
</asp:Content>

