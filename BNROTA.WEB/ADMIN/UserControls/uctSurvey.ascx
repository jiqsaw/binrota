<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctSurvey.ascx.cs" Inherits="ADMIN_UserControls_uctSurvey" %>
<div id="dvAlert" runat="server"></div>

<table width="100%">
	<tr class="ListeBaslik">
		<td colspan="2" class="ListeBaslik" bgcolor="#525667">&nbsp;&nbsp;
		    <asp:Literal runat="server" ID="ltlSubSubTitle">
		        ANKET
		    </asp:Literal>
		</td>
	</tr>
</table>

<div style="text-align: left;">
    
    <table class="itable" cellspacing="1" style="text-align: left;">
        <tr>
            <td class="hsol">
                * Soru :</td>
            <td class="hsag">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCategoryName"
                    CssClass="Error" Display="Dynamic" ErrorMessage="L�tfen Kategori Ad�n� Giriniz" SetFocusOnError="True"
                    ValidationGroup="AddCategory"></asp:RequiredFieldValidator>
                <asp:TextBox CssClass="forms" runat="server" ID="txtCategoryName" ValidationGroup="AddSerie"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="hsol">
                ��k 2:</td>
            <td class="hsag">
                <asp:TextBox CssClass="forms" runat="server" ID="txtCategoryDescription"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="hsol">
                Kategori A��klamas� [ENG]:</td>
            <td class="hsag">
                <asp:TextBox CssClass="forms" runat="server" ID="txtCategoryDescriptionENG"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="hsol">
                Aktif Anket:</td>
            <td class="hsag">
                <asp:DropDownList CssClass="DropDownList" runat="server" ID="ddlShowOrder">
                <asp:ListItem Selected="True" Text="Evet" Value="1"></asp:ListItem>
                <asp:ListItem Text="Hay�r" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="hsol">
                Aktif / Pasif:</td>
            <td class="hsag">
                <asp:DropDownList CssClass="DropDownList" runat="server" ID="ddlisActive">
                    <asp:ListItem Text="Aktif" Selected="True" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Pasif" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="halt" colspan="2" height="40">
                <asp:Button ValidationGroup="AddCategory" runat="server" ID="btnSave" Text="G�nder" CssClass="btn" OnClick="btnSave_Click" />                
                <input type="reset" value="Temizle" name="btnClear" class="btn" /></td>
        </tr>        
    </table>
    
	<table class="SfTable" cellspacing="0" cellpadding="0">
	    <tr>
	        <td> &nbsp; </td>
	    </tr>
	</table>    
    
</div>
