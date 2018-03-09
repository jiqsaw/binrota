<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctSurveyManagement.ascx.cs" Inherits="ADMIN_UserControls_uctSurveyManagement" %>

<div id="dvAlert" runat="server" visible="false">
    <table width="100%">
	    <tr class="ListTitle">
		    <td colspan="2" class="ListTitle" style="background-color: Red;">&nbsp;&nbsp;
		        <asp:Literal runat="server" ID="ltlMessage">
		            
		        </asp:Literal>
		    </td>
	    </tr>
	    <tr><td></td></tr>
    </table>
</div>

<asp:Repeater runat="server" ID="rptSurveys" OnItemCommand="rptSurveys_ItemCommand">
<HeaderTemplate>
    <table width="100%">
        <tr>
            <td class="ListTitleCh"> <input type="checkbox" id="chAll" onclick="CheckAll(this.checked, 'chQuestion')" /> </td>
            <td class="ListTitle">ANKET YÖNETÝMÝ </td>
        </tr>            
</HeaderTemplate>
<ItemTemplate>
        <tr>
            <td class="rptItem" align="center" width="40"> <input type="checkbox" id="chQuestion" name="chQuestion" value='<%#DataBinder.Eval(Container.DataItem, "SurveyQuestionID") %>'> </td>
            <td style="width: 100%;" class="rptItem" id='<%#DataBinder.Eval(Container.DataItem, "SurveyQuestionID", "trItem{0}") %>' 
            onclick="<%#DataBinder.Eval(Container.DataItem, "SurveyQuestionID", "location.href='Survey.aspx?SurveyID={0}';") %>"
            onmouseover="row_over(this.id);" onmouseout="row_out(this.id);">
                <b><%#DataBinder.Eval(Container.DataItem, "SurveyQuestion")%></b> </td>
        </tr>
</ItemTemplate>
<SeparatorTemplate>
        <tr><td colspan="2"></td></tr> 
</SeparatorTemplate>
<FooterTemplate>
        <tr>
            <td colspan="2" class="ListTitle">
                <table width="100%">
                    <tr>
                        <td> <a class="bar" href="Survey.aspx">Yeni Anket Ekle</a> </td>
                        <td align="right" style="padding-right: 10px;"> 
                            <asp:LinkButton CommandName="RemoveSurvey" runat="server" ID="hlRemoveSurvey" CssClass="bar" Text="Seçili Anketleri Sil" /> 
                        </td>
                    </tr>
                </table>      
            </td>
        </tr>	
    </table>
</FooterTemplate>
</asp:Repeater>