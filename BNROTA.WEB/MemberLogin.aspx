<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="MemberLogin.aspx.cs" Inherits="MemberLogin" %>
<%@ Register Src="UserControls/uctrlLogin.ascx" TagName="uctrlLogin" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <uc1:uctrlLogin id="UctrlLogin1" runat="server">
        </uc1:uctrlLogin>
</asp:Content>

