<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageUpload.aspx.cs" Inherits="ImageUpload" %>

<%@ Register Src="UserControls/uctrlImageUpload.ascx" TagName="uctrlImageUpload"
    TagPrefix="uc1" %>


<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>BINROTA</title>
    <link rel="stylesheet" type="text/css" href="Styles/Tag.css" />
    <link rel="stylesheet" type="text/css" href="Styles/Format.css" />
    <link rel="stylesheet" type="text/css" href="Styles/Text.css" />
    <link rel="stylesheet" type="text/css" href="Styles/Form.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <uc1:uctrlImageUpload ID="UctrlImageUpload1" runat="server" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
