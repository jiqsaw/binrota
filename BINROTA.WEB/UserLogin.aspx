<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<%@ Register Src="UserControls/uctrlLogin.ascx" TagName="uctrlLogin" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Binrota kullan�c� giri� ekran�</title>
    
            <link type="text/css"  rel="stylesheet" href="~/Styles/Stylesheet.css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:uctrlLogin ID="UctrlLogin1" runat="server" />
    
    </div>
    </form>
</body>
</html>
