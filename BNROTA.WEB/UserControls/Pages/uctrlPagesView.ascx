<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlPagesView.ascx.cs" Inherits="UserControls_Pages_uctrlPagesView" %>
<%@ Register Src="../Common/uctrlPagings.ascx" TagName="uctrlPagings" TagPrefix="uc3" %>

<%@ Register Src="../Common/uctrlSubRightRegion.ascx" TagName="uctrlSubRightRegion"
    TagPrefix="uc2" %>
<%@ Register Src="../Common/uctrlLastTripSubjects.ascx" TagName="uctrlLastTripSubjects"
    TagPrefix="uc8" %>
<%@ Register Src="../Common/uctrlFavoritePlaces.ascx" TagName="uctrlFavoritePlaces"
    TagPrefix="uc6" %>    
<%@ Register Src="../Common/uctrlMemberInfo.ascx" TagName="uctrlMemberInfo" TagPrefix="uc1" %>

<script language="javascript" type="text/javascript">
function OpenAddPages(PageID) {
	if (PageID==null) {
		PageID = 0;
	}
    window.open("AddPage.aspx?PageID=" + PageID, 'BinrotaSayfaEkleme', 'width=1000,height=800,toolbar=no,resizable=yes,scrollbars=yes,');
}
</script>

<table class="Content" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td width="695" colspan="3" valign="top" class="SubContent DegradeBottom">
            <table width="695" cellspacing="0" cellpadding="0" >
            <tr>
              <td width="16" rowspan="36"></td>
              <td height="21" colspan="2">&nbsp;</td>
            </tr>
            <tr>
               <td colspan="2" class="LogoColorHeader">ROTALAR </td>
            </tr>
            
            <tr  runat="server" id="trPages" visible="false" >
                <td colspan="2"><asp:Label runat="server" text="Gezi yazýsý bulunamamýþtýr"></asp:Label> </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Repeater ID="rptPages" runat="server" OnItemDataBound="rptPages_ItemDataBound">
                    
                    <ItemTemplate>
                    <table>
                        <tr>
                            <td height="8" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table width="658" border="0" cellspacing="0" cellpadding="0" class="DottedBorder" >
                                    <tr>
                                          <td class="Verd10px clRed " style="padding:15px;">
                                              <asp:Label ID="lbTitle" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Title")%>'></asp:Label>
                                              <br />
                                              <span class="Verd10px clBlack">
                                                    <asp:Literal ID="ltrContent" runat="server" Text='<%#CARETTA.COM.Util.Left(BINROTA.COM.Common.ClearHtmlComments(CARETTA.COM.Util.ClearHtmlTags(DataBinder.Eval(Container.DataItem, "PageContent").ToString())), 200) + "..."%>'></asp:Literal> 
                                               </span>  
                                          </td>
                                    </tr>
                              </table>
                            </td>
                        </tr>
                        <tr>
                        <td height="5" colspan="2"></td>
                        </tr>
                        <tr>
                              <td width="598" align="right">
                              <asp:HyperLink ID="hplGoToDetail" runat="server" Width="91" Height="17" ImageUrl="~/Images/Design/btnGotoDetail.gif"
                              NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "PageID", "~/PageDetail.aspx?PageID={0}")%>'></asp:HyperLink>   
                              &nbsp;&nbsp;&nbsp;
                              <asp:HyperLink ID="hplEdit" runat="server" Width="67" Height="17" ImageUrl="~/Images/Design/btnEdit.gif" 
                              NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "PageID", "javascript:OpenAddPages({0})") %>'></asp:HyperLink>
                              &nbsp;&nbsp;&nbsp;
                              <asp:ImageButton id="btnPageDelete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PageID")%>' runat="server" OnClick="btnPageDelete_Click" Width="34" Height="17" ImageUrl="~/Images/Design/btnPageDelete.jpg" />
                              
                              </td>
                              <td width="81">&nbsp;</td>
                        </tr>
                    </table>
                    </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr>
              <td colspan="2" height="40"></td>
            </tr>
            <tr>
                <td colspan="2" style="padding-right:20px;">
                
                    <uc3:uctrlPagings ID="UctrlPagings1" runat="server" />

                </td>
            </tr>
            <tr>
              <td colspan="2" style="padding-left:16px">
              <asp:HyperLink ID="hplAddPAge" runat="server" ImageUrl="~/Images/Button/btnAddPage.jpg" NavigateUrl="javascript:OpenAddPages()"></asp:HyperLink>
              </td>
            </tr>
            <tr>
              <td colspan="2" height="37">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="2" class="BlueHeader">YORUMLARIM </td>
            </tr>
            <tr>
              <td colspan="2" height="9"></td>
            </tr>
            <tr>
              <td colspan="2"><table width="658" border="0" cellspacing="0" cellpadding="0" class="DottedBorder" >
                <tr runat="server" id="trComments" visible="false">
                <td><asp:Label ID="Label1" runat="server" text="Yorum bulunamamýþtýr"></asp:Label> </td>
                </tr>
                <tr>
                  <td style="padding:15px;">
                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <asp:Repeater ID="rptComments" runat="server">
                  <ItemTemplate>
                  <tr>
                      <td class="clRed "><b>::</b>
                      <asp:HyperLink ID="hlComments" runat="server" CssClass="TRed" Text='<%#DataBinder.Eval(Container.DataItem, "Comment")%>' NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "PageID", "~/PageDetail.aspx?PageID={0}")%>'></asp:HyperLink>
                      </td>
                  </tr>
                    <tr>
                      <td height="6"></td>
                    </tr>
                  </ItemTemplate>
                  </asp:Repeater>
                  </table>
                  </td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td colspan="2" height="35">&nbsp;</td>
            </tr>
            
          </table>
        </td>
        <td rowspan="3" class="HSpace">
        </td>
        <td width="267" rowspan="3" valign="top">
            <uc2:uctrlSubRightRegion ID="UctrlSubRightRegion1" runat="server" />
        </td>
    </tr>
</table>
