<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctSurvey.ascx.cs" Inherits="ADMIN_UserControls_uctSurvey" %>
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



<table width="100%">
	<tr class="ListTitle">
		<td colspan="2" class="ListTitle" bgcolor="#525667">&nbsp;&nbsp;
		    <asp:Literal runat="server" ID="ltlSubSubTitle">
		        ANKET
		    </asp:Literal>
		</td>
	</tr>
</table>

<div style="text-align: left;">
    
    <table class="itable" style="text-align: left;">
        <tr><td colspan="2"></td></tr> 
        <tr>
            <td class="CellLeft" style="width: 130px;"> * Soru :</td>
            <td class="CellRight">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSurveyQuestion"
                    CssClass="Error" Display="none" ErrorMessage="Lütfen Anket Sorusunu Giriniz" SetFocusOnError="True"
                    ValidationGroup="AddSurvey"></asp:RequiredFieldValidator>
                <asp:TextBox CssClass="forms" runat="server" ID="txtSurveyQuestion" ValidationGroup="AddSurvey"></asp:TextBox>
            </td>
        </tr>
        <tr><td colspan="2"></td></tr>
        <asp:ValidationSummary runat="server" ID="ErrVsAddSurvey" ValidationGroup="AddSurvey" ShowMessageBox="true" ShowSummary="false" />
                <asp:Panel runat="server" ID="pnlNew">
                        <tr>
                            <td class="CellExtra" colspan="2">
                                SEÇENEKLER</td>
                        </tr>
                        <tr><td colspan="2"></td></tr>
                        <tr>
                            <td class="CellLeft">
                                * Seçenek :</td>
                            <td class="CellRight">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNewChoice"
                                    CssClass="Error" Display="none" ErrorMessage="Lütfen Seçeneði Giriniz" SetFocusOnError="True"
                                    ValidationGroup="AddChoice"></asp:RequiredFieldValidator>
                                <asp:TextBox CssClass="forms" runat="server" ID="txtNewChoice" ValidationGroup="AddChoice"></asp:TextBox>
                            </td>
                        </tr>
                        <tr><td colspan="2"></td></tr>
                        <tr>
                            <td class="CellLeft">
                                * Oy Sayýsý :</td>
                            <td class="CellRight">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                Display="none" ControlToValidate="txtNewChoiceVote"
                                ErrorMessage="Lütfen Seçeneðin Oy Sayýsýný Giriniz" SetFocusOnError="True" 
                                ValidationGroup="AddChoice" Text="0"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtNewChoiceVote" 
                                ErrorMessage="Lütfen Oy Sayýsýný Rakam Olarak Giriniz" MaximumValue="1000000" MinimumValue="0" 
                                SetFocusOnError="True" Display="None" Type="Integer" ValidationGroup="AddChoice"></asp:RangeValidator>                                
                                
                                <asp:TextBox CssClass="forms" Text="0" runat="server" ID="txtNewChoiceVote" ValidationGroup="AddChoice"></asp:TextBox>
                            </td>
                        </tr>
                        <tr><td colspan="2"></td></tr>  
                        <tr>
                            <td colspan="2" class="CellRight" style="height: 24px; text-align: center;">
                                <asp:LinkButton CssClass="bar" runat="server" ID="lnkAddChoice" ValidationGroup="AddChoice" Text="Seçeneði Ekle" OnClick="lnkAddChoice_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr><td colspan="2"></td></tr>
                </asp:Panel>        
        
        <tr>
            <td colspan="2">
                <asp:ValidationSummary runat="server" ID="ErrVsAddCoice" ValidationGroup="AddChoice" ShowMessageBox="true" ShowSummary="false" />
                <asp:Panel runat="server" ID="pnlEdit" Visible="false">
                    <asp:Repeater runat="server" ID="rptChoises" OnItemCommand="rptChoises_ItemCommand">
                    <HeaderTemplate>
                        <table class="itable" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="CellLeft" style="height: 27px;">Seçenek</td>
                            <td class="CellLeft">Oy</td>
                            <td class="CellLeft">Seçim</td>
                        </tr>
                        <tr><td colspan="3"></td></tr>                        
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="CellRight">
                                <asp:TextBox CssClass="forms" runat="server" ID="txtChoice" Text='<%# DataBinder.Eval(Container.DataItem, "SurveyChoice") %>'></asp:TextBox>
                            </td>
                            <td class="CellRight">
                                <asp:TextBox CssClass="forms" runat="server" ID="txtVoteNumber" Text='<%# DataBinder.Eval(Container.DataItem, "SurveyVoteNumber") %>'></asp:TextBox></td>
                            <td class="CellBottom" style="text-align: left; padding-left: 15px;"> 
                                <asp:LinkButton OnClientClick="return confirm('Seçeneði çýkartmak istediðinizden emin misiniz?');" CssClass="bar" runat="server" ID="lnkRemoveChoice" CausesValidation="false" Text="Çýkar" 
                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "SurveyChoiceID") %>'
                                ></asp:LinkButton></td>
                        </tr>                        
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <tr><td colspan="3"></td></tr>
                    </SeparatorTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                    </asp:Repeater>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="CellLeft">
                Aktif Anket:</td>
            <td class="CellRight">
                <asp:DropDownList CssClass="DropDownList" runat="server" ID="ddlisMain">
                <asp:ListItem Selected="True" Text="Evet" Value="True"></asp:ListItem>
                <asp:ListItem Text="Hayýr" Value="False"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr><td colspan="2"></td></tr>        
        <tr>
            <td class="CellLeft">
                Aktif / Pasif:</td>
            <td class="CellRight">
                <asp:DropDownList CssClass="DropDownList" runat="server" ID="ddlisActive">
                    <asp:ListItem Text="Aktif" Selected="True" Value="True"></asp:ListItem>
                    <asp:ListItem Text="Pasif" Value="False"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr><td colspan="2"></td></tr>        
        <tr>
            <td class="CellBottom" colspan="2" height="40">
                <asp:Button ValidationGroup="AddSurvey" runat="server" ID="btnSave" Text="Gönder" CssClass="btn" OnClick="btnSave_Click" />                
                <input type="reset" value="Reset" name="btnClear" class="btn" /></td>
        </tr>        
    </table>
    
</div>
