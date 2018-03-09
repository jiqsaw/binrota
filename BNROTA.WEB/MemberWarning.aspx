<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberWarning.aspx.cs" Inherits="MemberWarning" %>

<%@ Register Src="UserControls/Pages/uctrlMemberWarning.ascx" TagName="uctrlMemberWarning"
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
                    <uc1:uctrlMemberWarning ID="UctrlMemberWarning1" runat="server" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
