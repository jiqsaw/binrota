<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="ActivityDetail.aspx.cs" Inherits="ActivityDetail" %>

<%@ Register Src="UserControls/Pages/uctrlActivityDetail.ascx" TagName="uctrlActivityDetail"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uctrlActivityDetail id="UctrlActivityDetail1" runat="server">
    </uc1:uctrlActivityDetail>
</asp:Content>

