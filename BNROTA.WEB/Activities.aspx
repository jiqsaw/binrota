<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="Activities.aspx.cs" Inherits="Activities" %>

<%@ Register Src="UserControls/Pages/uctrlActivities.ascx" TagName="uctrlActivities"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uctrlActivities ID="UctrlActivities1" runat="server" />
</asp:Content>

