<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddComplain.aspx.cs" Inherits="AddComplain" %>

<%@ Register Src="UserControls/Pages/uctrlAddComplain.ascx" TagName="uctrlAddComplain"
    TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Binrota Şikayet</title>
    <link rel="stylesheet" type="text/css" href="Styles/Tag.css" />
    <link rel="stylesheet" type="text/css" href="Styles/Format.css" />
    <link rel="stylesheet" type="text/css" href="Styles/Text.css" />
    <link rel="stylesheet" type="text/css" href="Styles/Form.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:uctrlAddComplain id="UctrlAddComplain1" runat="server">
        </uc1:uctrlAddComplain></div>
    </form>
</body>
</html>
