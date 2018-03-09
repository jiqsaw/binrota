<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<%@ Register Src="UserControls/uctrlLogin.ascx" TagName="uctrlLogin" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <uc1:uctrlLogin ID="UctrlLogin1" runat="server" />
    
    </div>
</asp:Content>

