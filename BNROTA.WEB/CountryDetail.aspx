<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="CountryDetail.aspx.cs" Inherits="CountryDetail" %>

<%@ Register Src="UserControls/Pages/uctrlCountryDetail.ascx" TagName="uctrlCountryDetail"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <uc1:uctrlCountryDetail ID="UctrlCountryDetail1" runat="server" />
</asp:Content>

