<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" Title="Untitled Page" %>

<%@ Register Src="UserControls/Common/uctrlAboutUs.ascx" TagName="uctrlAboutUs" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <uc1:uctrlAboutUs ID="UctrlAboutUs1" runat="server" />
</asp:Content>

