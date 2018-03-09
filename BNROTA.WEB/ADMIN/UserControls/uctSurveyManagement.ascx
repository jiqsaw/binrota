<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctSurveyManagement.ascx.cs" Inherits="ADMIN_UserControls_uctSurveyManagement" %>

<asp:Repeater runat="server" ID="rptSurveys">
<HeaderTemplate>
    <table width="100%">
        <tr>
            <td class="ListeBaslik">ANKET YÖNETÝMÝ </td>
        </tr>            
</HeaderTemplate>
<ItemTemplate>
        <tr id='<%#DataBinder.Eval(Container.DataItem, "SurveyQuestionID", "trItem{0}") %>' onmouseover="row_over(this.id);" onmouseout="row_out(this);">
            <td class="rptItem">
                <b><%#DataBinder.Eval(Container.DataItem, "SurveyQuestion")%></b> </td>
        </tr>
</ItemTemplate>
<FooterTemplate>
        <tr>
            <td class="ListeBaslik"> <a class="bar" href="Survey.aspx">Yeni Anket Ekle</a> </td>
        </tr>	
    </table>
</FooterTemplate>
</asp:Repeater>