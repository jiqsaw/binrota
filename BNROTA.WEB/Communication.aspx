<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="Communication.aspx.cs" Inherits="Communication" Title="Untitled Page" %>

<%@ Register Src="UserControls/Common/uctrlCommunication.ascx" TagName="uctrlCommunication"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc2:uctrlCommunication ID="UctrlCommunication1" runat="server" />
</asp:Content>

