<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="Article.aspx.cs" Inherits="ForumArticle" Title="BINROTA FORUM" ValidateRequest="false"%>

<%@ Register Src="UserControls/uctrlArticleItems.ascx" TagName="uctrlArticleItems"
    TagPrefix="uc2" %>

<%@ Register Src="UserControls/uctCategories.ascx" TagName="uctCategories" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc2:uctrlArticleItems id="UctrlArticleItems1" runat="server">
    </uc2:uctrlArticleItems>
</asp:Content>

