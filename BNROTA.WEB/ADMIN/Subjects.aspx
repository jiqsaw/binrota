<%@ Page Language="C#" MasterPageFile="~/ADMIN/Admin.master" AutoEventWireup="true" CodeFile="Subjects.aspx.cs" Inherits="ADMIN_Subjects" Title="Mekan Yönetimi" %>

<%@ Register Src="UserControls/Subjects/uctSubjects.ascx" TagName="uctSubjects" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:uctSubjects ID="UctSubjects1" runat="server" />
</asp:Content>

