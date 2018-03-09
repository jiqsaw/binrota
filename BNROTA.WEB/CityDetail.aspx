<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="CityDetail.aspx.cs" Inherits="CityDetail" %>
<%@ Register Src="~/UserControls/Pages/uctrlCityDetail.ascx" TagName="CityDetail" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:CityDetail ID="CityDetail1" runat="server" />
</asp:Content>

