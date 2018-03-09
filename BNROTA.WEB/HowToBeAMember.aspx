<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HowToBeAMember.aspx.cs" Inherits="HowToBeAMember" %>

<%@ Register Src="UserControls/Pages/uctrlHowToBeAMember.ascx" TagName="uctrlHowToBeAMember"
    TagPrefix="uc1" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>BINROTA</title>
    <link rel="stylesheet" type="text/css" href="Styles/Tag.css">
    <link rel="stylesheet" type="text/css" href="Styles/Format.css">
    <link rel="stylesheet" type="text/css" href="Styles/Text.css">
    <link rel="stylesheet" type="text/css" href="Styles/Form.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:uctrlHowToBeAMember ID="UctrlHowToBeAMember1" runat="server" />
    
    </div>
    </form>
</body>
</html>
