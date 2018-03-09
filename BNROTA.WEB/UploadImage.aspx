<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadImage.aspx.cs" Inherits="UploadImage" %>

<%@ Register Src="UserControls/uctrlImageUpload.ascx" TagName="uctrlImageUpload"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Image Upload</title>
</head>
<body>
    <form id="form1" runat="server" method="post" enctype="multipart/form-data">
    <div>
        <uc1:uctrlImageUpload ID="UctrlImageUpload1" runat="server" />
    
    </div>
    </form>
</body>
</html>
