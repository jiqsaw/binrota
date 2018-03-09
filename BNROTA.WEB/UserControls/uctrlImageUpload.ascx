<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlImageUpload.ascx.cs" Inherits="UserControls_uctrlImageUpload" %>
<%--<form id="form1" runat="server" method="post" enctype="multipart/form-data">--%>
<asp:Label ID="lblStatus" runat="server"></asp:Label>
<asp:FileUpload ID="fupImg" runat="server" />
<%if (UploadType == Enumerations.FileUploadType.ContentImages || UploadType == Enumerations.FileUploadType.MemberImages)
  {%>
<asp:Button ID="btnSend" CssClass="Button" runat="server" OnClick="btnSend_Click" Text="Gönder" />
<%} %>