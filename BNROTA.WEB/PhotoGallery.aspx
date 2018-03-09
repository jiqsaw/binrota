<%@ Page Language="C#" MasterPageFile="~/BinRotaM.master" AutoEventWireup="true" CodeFile="PhotoGallery.aspx.cs" Inherits="PhotoGallery" %>
<%@ Register Src="~/UserControls/PhotoGallery/uctrlPhotoGallery.ascx" TagName="uctrlPhotoGallery" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uctrlPhotoGallery ID="uctrlPhotoGallery1" runat="server" />
</asp:Content>
