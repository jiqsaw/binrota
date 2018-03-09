<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="MainPage" %>

<%@ Register Src="UserControls/uctrlSubjectsWantsToBeShowed.ascx" TagName="uctrlSubjectsWantsToBeShowed"
    TagPrefix="uc5" %>

<%@ Register Src="UserControls/uctrlLast5PagesRecorded.ascx" TagName="uctrlLast5PagesRecorded"
    TagPrefix="uc4" %>

<%@ Register Src="UserControls/uctrlPagesRecordedSubjectCount.ascx" TagName="uctrlPagesRecordedSubjectCount"
    TagPrefix="uc3" %>

<%@ Register Src="UserControls/uctrlTop5Members.ascx" TagName="uctrlTop5Members"
    TagPrefix="uc2" %>

<%@ Register Src="UserControls/uctrlPagesRecordedPageCategoryCount.ascx" TagName="uctrlPagesRecordedPageCategoryCount"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table>
                <tr>
                    <td rowspan="3" valign="top">
                        <asp:Repeater ID="rptMenu" runat="server">
                            <ItemTemplate>
                                <a href='<%#DataBinder.Eval(Container.DataItem, "SubjectID", "Continent.aspx?SubjectID={0}")%>'>
                                    <%#DataBinder.Eval(Container.DataItem, "Name") %>
                                </a>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <br />
                            </SeparatorTemplate>
                        </asp:Repeater>
                    </td>
                    <td style="padding-left: 10px;">
                        <asp:Button ID="btnAddContinent" runat="server" Text="Kýta Ekle" OnClick="btnAddContinent_Click" Visible="False" /></td>
                    <td style="padding-left: 30px;" valign="top" align="center">
                        <uc1:uctrlPagesRecordedPageCategoryCount id="UctrlRecordedPageCategoryCount1" runat="server">
                        </uc1:uctrlPagesRecordedPageCategoryCount></td>
                    <td style="padding-left: 30px;" valign="top">
                        <uc2:uctrlTop5Members id="UctrlTop5Members1" runat="server">
                        </uc2:uctrlTop5Members></td>
                </tr>
     <tr>
         <td style="padding-left: 10px">
             </td>
         <td align="center" style="padding-left: 30px" valign="top">
             <uc3:uctrlPagesRecordedSubjectCount ID="UctrlPagesRecordedSubjectCount1" runat="server"/>
         </td>
         <td style="padding-left: 30px" valign="top">
         
             <uc4:uctrlLast5PagesRecorded ID="UctrlLast5PagesRecorded1" runat="server"/>
         </td>
     </tr>
     <tr>
         <td style="padding-left: 10px">
             &nbsp;</td>
         <td align="center" style="padding-left: 30px" valign="top">
             <uc5:uctrlSubjectsWantsToBeShowed ID="UctrlSubjectsWantsToBeShowed1" runat="server" />
         </td>
         <td style="padding-left: 30px" valign="top">
             <b>En Çok Tartýþýlan 5 Forum Konusu</b>
            
             </td>
     </tr>
            </table>
</asp:Content>

