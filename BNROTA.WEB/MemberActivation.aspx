<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberActivation.aspx.cs" Inherits="MemberActivation" %>

<%@ Register Src="UserControls/Pages/uctrlMemberActivation.ascx" TagName="uctrlMemberActivation"
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
                <td style="width: 100px">
                    <uc1:uctrlMemberActivation id="UctrlMemberActivation1" runat="server">
                    </uc1:uctrlMemberActivation></td>
            </tr>
        </table>
       
    
    </div>
    </form>
</body>
</html>
