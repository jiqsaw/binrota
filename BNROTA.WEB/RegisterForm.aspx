<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterForm.aspx.cs" Inherits="RegisterForm" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="UserControls/Pages/uctrlMemberForm.ascx" TagName="uctrlMemberForm" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


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
        <asp:ScriptManager ID="ScrMng1" runat="server">
        </asp:ScriptManager>
    <div>
    
        <table>
            <tr>
                <td style="width: 100px">
                    <uc1:uctrlMemberForm ID="UctrlMemberForm1" runat="server" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
