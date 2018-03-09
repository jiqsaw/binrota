<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlMemberPage.ascx.cs" Inherits="UserControls_Pages_uctrlMemberPage" %>
<%@ Register Src="../Members/uctrlMemberPhotos.ascx" TagName="uctrlMemberPhotos"
    TagPrefix="uc4" %>
<%@ Register Src="../Common/uctrlTopForumSubjects.ascx" TagName="uctrlTopForumSubjects"
    TagPrefix="uc3" %>
<%@ Register Src="../Common/uctrlSubRightRegion.ascx" TagName="uctrlSubRightRegion" TagPrefix="uc2" %>
<%@ Register Src="../Common/uctrlLastTripSubjects.ascx" TagName="uctrlLastTripSubjects" TagPrefix="uc8" %>
<%@ Register Src="../Common/uctrlFavoritePlaces.ascx" TagName="uctrlFavoritePlaces" TagPrefix="uc6" %>    
<%@ Register Src="../Common/uctrlMemberInfo.ascx" TagName="uctrlMemberInfo" TagPrefix="uc1" %>

<table style="width: 989px" cellspacing="0" cellpadding="0">

    <tr>
        <td style="padding-left: 16px;">
        
        <table style="width: 100%">
            <tr>
                <td style="vertical-align: top;"> <uc1:uctrlMemberInfo ID="UctrlMemberInfo1" runat="server"></uc1:uctrlMemberInfo> </td>
                <td style="width: 6px"></td>
                <td style="width: 272px" valign="top">
                    <table style="width: 100%; border: solid 1px #FFFFFF; background-color: #9cdaff">
                        <tr>
                            <td valign="top">
                                <uc4:uctrlMemberPhotos ID="UctrlMemberPhotos1" runat="server" />
                            </td>
                        </tr>
                    </table>            
                
                </td>
            </tr>
        </table>

        </td>
    </tr>
</table>