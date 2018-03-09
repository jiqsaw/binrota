<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlFaq.ascx.cs" Inherits="UserControls_uctrlFaq" %>
<%@ Register Src="~/UserControls/Common/uctrlSubRightRegion.ascx" TagName="uctrlSubRightRegion" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Common/uctrlLastTripSubjects.ascx" TagName="uctrlLastTripSubjects" TagPrefix="uc8" %>
<%@ Register Src="~/UserControls/Common/uctrlFavoritePlaces.ascx" TagName="uctrlFavoritePlaces" TagPrefix="uc6" %>

<script type="text/javascript">

function OpenCloseAnswer(dvID) {
    if (document.getElementById(dvID).style.display == 'none') {
        document.getElementById(dvID).style.display = 'block';
    } else {
        document.getElementById(dvID).style.display = 'none';
    }
}

</script>

<table class="Content" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td width="695" colspan="3" valign="top" bgcolor="#E5F8FF">
         
        <!-- CONTENT -->
        
            <table width="695" cellspacing="0" cellpadding="0" class="SubContent DegradeBottom">
                <tr>
                    <td height="47" valign="middle" class="RegionHeader">
                        <div style="padding-top: 5px; padding-left: 25px;">
                            SIKÇA SORULAN SORULAR
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style=" padding-left: 25px; vertical-align: top;">
                        <div id="dvFaq" runat="server">
                        </div>
                    </td>
                </tr>
            </table>

        <!-- //CONTENT -->

        </td>
        <td rowspan="3" class="HSpace">
        </td>
        <td width="267" rowspan="3" valign="top">
            <uc2:uctrlSubRightRegion ID="UctrlSubRightRegion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="3" class="VSpace">
        </td>
    </tr>
    <tr>
        <td width="425" height="277">
            <uc8:uctrlLastTripSubjects ID="UctrlLastTripSubjects1" runat="server" />
        </td>
        <td class="HSpace">
        </td>
        <td width="263" valign="top" bgcolor="#E5F8FF">
            <uc6:uctrlFavoritePlaces ID="UctrlFavoritePlaces1" runat="server" />
        </td>
    </tr>
</table>