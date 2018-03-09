<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<%@ Register Src="UserControls/Pages/uctrlForgatPassword.ascx" TagName="uctrlForgatPassword"
    TagPrefix="uc1" %>


<html>
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
        <table>
            <tr>
                <td style="width: 100px">
                    <uc1:uctrlForgatPassword ID="UctrlForgatPassword1" runat="server" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
