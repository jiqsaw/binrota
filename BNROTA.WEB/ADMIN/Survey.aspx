<%@ Page Language="C#" MasterPageFile="~/ADMIN/Admin.master" AutoEventWireup="true" CodeFile="Survey.aspx.cs" Inherits="ADMIN_Survey" %>
<%@ Register Src="~/ADMIN/UserControls/Survey/uctSurvey.ascx" TagName="uctSurvey" TagPrefix="uc1" %>
<%@ Register Src="~/ADMIN/UserControls/Survey/uctSurveyManagement.ascx" TagName="uctSurveyManagement" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table bgcoor="F0F0F0" cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td valign="top" style="width: 50%;"> <uc2:uctSurveyManagement ID="uctSurveyManagement1" runat="server" /> </td>
            <td valign="top" style="width: 50%;"> <uc1:uctSurvey ID="uctSurvey1" runat="server" /> </td>
        </tr>
    </table>
</asp:Content>
