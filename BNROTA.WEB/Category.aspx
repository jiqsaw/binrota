<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="ForumCategory" Title="BINROTA FORUM" ValidateRequest="false"%>

<%@ Register Src="~/Forum/UserControls/uctrlArticle.ascx" TagName="uctrlArticle" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc2:uctrlArticle ID="UctrlArticle1" runat="server" />
</asp:Content>

