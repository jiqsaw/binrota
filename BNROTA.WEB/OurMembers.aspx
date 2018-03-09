<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="OurMembers.aspx.cs" Inherits="OurMembers" %>
<%@ Register Src="UserControls/Members/uctrlOurMembers.ascx" TagName="uctrlOurMembers" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uctrlOurMembers ID="uctrlOurMembers1" runat="server" />
</asp:Content>