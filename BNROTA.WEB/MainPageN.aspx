<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainPageN.aspx.cs" Inherits="MainPageN" %>

<%@ Register Src="UserControls/Common/uctrlSearchMap.ascx" TagName="uctrlSearchMap"
    TagPrefix="uc12" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="UserControls/Pages/uctrlCountryDetail.ascx" TagName="uctrlCountryDetail"
    TagPrefix="uc10" %>

<%@ Register Src="UserControls/Common/uctrlMainHeader.ascx" TagName="uctrlMainHeader"
    TagPrefix="uc8" %>
<%@ Register Src="UserControls/Common/uctrlMainFooter.ascx" TagName="uctrlMainFooter"
    TagPrefix="uc9" %>

<%@ Register Src="UserControls/Common/uctrlTopForumSubjects.ascx" TagName="uctrlTopForumSubjects"
    TagPrefix="uc7" %>
<%@ Register Src="UserControls/Common/uctrlQuestionnaire.ascx" TagName="uctrlQuestionnaire"
    TagPrefix="uc6" %>
<%@ Register Src="UserControls/Common/uctrlLastTripSubjects.ascx" TagName="uctrlLastTripSubjects"
    TagPrefix="uc5" %>
<%@ Register Src="UserControls/Common/uctrlTopAuthors.ascx" TagName="uctrlTopAuthors"
    TagPrefix="uc4" %>
<%@ Register Src="UserControls/MainPage/uctrlMainPlaces.ascx" TagName="uctrlMainPlaces"
    TagPrefix="uc3" %>
<%@ Register Src="UserControls/Common/uctrlTripCategories.ascx" TagName="uctrlTripCategories"
    TagPrefix="uc2" %>
<%@ Register Src="UserControls/MainPage/uctrlMainNews.ascx" TagName="uctrlMainNews"
    TagPrefix="uc1" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>BINROTA</title>
    <link rel="stylesheet" type="text/css" href="Styles/Tag.css">
    <link rel="stylesheet" type="text/css" href="Styles/Format.css">
    <link rel="stylesheet" type="text/css" href="Styles/Text.css">
    <link rel="stylesheet" type="text/css" href="Styles/Form.css">
    <script language="javascript" src="Scripts/Custom.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table width="1004" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="Top" >
                    <uc8:uctrlMainHeader ID="UctrlMainHeader1" runat="server" />
                </td>
            </tr>
            <tr>
                <td valign="top" >
                    <table class="Content" align="center" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="532">
                                <uc12:uctrlSearchMap ID="UctrlSearchMap1" runat="server" />
                            </td>
                            <td class="HSpace">
                            </td>
                            <td valign="top">
                                <uc1:uctrlMainNews ID="UctrlMainNews1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="VSpace" >
                </td>
            </tr>
            <tr>
                <td >
                    <table class="Content" align="center" cellpadding="0" cellspacing="0">
                        <tr>	
                            <td width="364" height="147">
                                <uc2:uctrlTripCategories ID="UctrlTripCategories1" runat="server" />
                            </td>
                            <td class="HSpace">
                            </td>
                            <td width="599">
                                <uc3:uctrlMainPlaces ID="UctrlMainPlaces1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="VSpace" >
                </td>
            </tr>
            <tr>
                <td >
                    <table class="Content" height="277" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="182" valign="top">
                                <uc4:uctrlTopAuthors ID="UctrlTopAuthors1" runat="server" />
                            </td>
                            <td class="HSpace">
                            </td>
                            <td width="342" valign="top">
                                <uc5:uctrlLastTripSubjects ID="UctrlLastTripSubjects1" runat="server" />
                            </td>
                            <td class="HSpace">
                            </td>
                            <td width="240" valign="top">
                                                                                        <uc7:uctrlTopForumSubjects ID="UctrlTopForumSubjects1" runat="server"></uc7:uctrlTopForumSubjects>


                               
                            </td>
                            <td class="HSpace">
                            </td>
                            <td width="183" valign="top">
                                                         <uc6:uctrlQuestionnaire ID="UctrlQuestionnaire1" runat="server" />

                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="VSpace" >
                </td>
            </tr>
            <tr>
                <td style="height: 13px">
                    <uc9:uctrlMainFooter ID="UctrlMainFooter1" runat="server" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
