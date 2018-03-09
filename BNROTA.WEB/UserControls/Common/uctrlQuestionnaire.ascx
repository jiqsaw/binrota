<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlQuestionnaire.ascx.cs"
    Inherits="UserControls_MainPage_uctrlQuestionnaire" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="SurveyBack" valign="top">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
<%-- arka plan rengi             bgcolor="#44b8ff"--%>
            <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="Treb clNavy" style="height: 38px; padding-left: 4px; padding-right: 14px; padding-top: 7px;">
                        <b>ANKET</b></td>
                </tr>
                <tr>
                    <td class="AnketSepTd">
                    </td>
                </tr>
                <tr>
                    <td class="AnketQuestion TopBottom7">
                        <asp:Label ID="lbSurveyQuestion" runat="server"></asp:Label>    
                    </td>
                </tr>
                <tr>
                    <td class="AnketSepTd">
                    </td>
                </tr>
                <asp:Panel ID="pnlSurvey" runat="server" Visible="true">
                <tr>
                    <td class="TopBottom7">
                        <table width="100%" border="0" cellpadding="0" cellspacing="2">
                            <tr>
                                <td class="Questionnaire">
                                    <asp:RadioButtonList ID="rblSurveyChoices" runat="server" DataTextField="SurveyChoice" DataValueField="SurveyChoiceID">
                                    </asp:RadioButtonList>
                                </td>

                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Gönder" CssClass="Button" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="Verd clBlue">
                        <asp:LinkButton CssClass="TGray" ID="lnbSurveyResult" runat="server" Text="Anket Sonu&ccedil;lar&#305;" OnClick="lnbSurveyResult_Click"></asp:LinkButton>
                    </td>
                </tr>
                </asp:Panel>
                <asp:Panel ID="pnlSurveyResult" runat="server" Visible="false">
                <asp:Repeater ID="rptSurveyResult" runat="server">
                <ItemTemplate>
                <tr style="height:5px">
                <td>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label ID="lbSurveyChoice" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SurveyChoice") %>'></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Image ID="imgSurveyResultBar" runat="server" Height="6" ImageUrl="~/Images/Design/SurveyResultBar.gif" />
                <asp:Label ID="lbSurveyResult" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SurveyAnswer") %>'></asp:Label>
                </td>
                </tr>
                <tr style="height:5px">
                <td>
                </td>
                </tr>
                </ItemTemplate>
                </asp:Repeater>
                </asp:Panel>
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
