<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberLogin.aspx.cs" Inherits="MemberLogin" %>

<%@ Register Src="UserControls/uctrlLogin.ascx" TagName="uctrlLogin" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Binrota üye giriþ ekraný</title>
    
            <link type="text/css"  rel="stylesheet" href="~/Styles/Stylesheet.css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:uctrlLogin id="UctrlLogin1" runat="server">
        </uc1:uctrlLogin></div>
    </form>
</body>
</html>
