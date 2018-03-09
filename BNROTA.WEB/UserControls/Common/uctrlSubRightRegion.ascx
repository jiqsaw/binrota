<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlSubRightRegion.ascx.cs" Inherits="UserControls_Common_uctrlSubRightRegion" %>
<%@ Register Src="../Common/uctrlSearchFMap.ascx" TagName="uctrlSearchFMap" TagPrefix="uc3" %>
<%@ Register Src="../Common/uctrlTripCategories.ascx" TagName="uctrlTripCategories"
    TagPrefix="uc2" %>
<%@ Register Src="../Common/uctrlNews.ascx" TagName="uctrlNews" TagPrefix="uc4" %>
<%@ Register Src="../Common/uctrlAuthorSearch.ascx" TagName="uctrlAuthorSearch" TagPrefix="uc5" %>
<%@ Register Src="../Common/uctrlTopForumSubjects.ascx" TagName="uctrlTopForumSubjects"
    TagPrefix="uc7" %>
    
<table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td valign="top" height="202">
                        <uc2:uctrlTripCategories ID="UctrlTripCategories1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="VSpace">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <uc3:uctrlSearchFMap ID="UctrlSearchFMap1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="VSpace">
                    </td>
                </tr>
                <tr>
                    <td valign="top" height="267">
                        <uc4:uctrlNews ID="UctrlNews1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="VSpace">
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc5:uctrlAuthorSearch ID="UctrlAuthorSearch1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="VSpace">
                    </td>
                </tr>
                <tr>
                    <td height="277">
                        <uc7:uctrlTopForumSubjects ID="UctrlTopForumSubjects1" runat="server" />
                    </td>
                </tr>
            </table>