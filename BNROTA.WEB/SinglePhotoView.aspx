<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SinglePhotoView.aspx.cs" Inherits="SinglePhotoView" %>

<%@ Register Src="UserControls/Common/uctrlSinglePhotoView.ascx" TagName="uctrlSinglePhotoView"
    TagPrefix="uc1" %>


<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:uctrlSinglePhotoView ID="UctrlSinglePhotoView1" runat="server" />
    
    </div>
    </form>
</body>
</html>
