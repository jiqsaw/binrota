<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlNewsPage.ascx.cs" Inherits="UserControls_Pages_uctrlNewsPage" %>

<table align="center" cellpadding="0" cellspacing="0" class="Content">
      <tr>
        <td width="970" align="right" valign="top" class="DegradeBottom SubContent ">
		<table width="960" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="9" colspan="3"></td>
          </tr>
          <tr>
            <td width="273" valign="top" class="DegradeBlue"><table width="268" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="16" colspan="2"></td>
              </tr>
              <tr>
                <td width="21">&nbsp;</td>
                <td width="247" class="BlueHeader">HABERLER</td>
              </tr>
              <tr>
                <td colspan="2" height="10"></td>
              </tr>
              <tr>
                <td colspan="2" align="center">                
                <asp:DropDownList ID="drpNewsDate" runat="server" CssClass="DropDownList" Width="180" OnSelectedIndexChanged="drpNewsDate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
              </tr>
              <tr>
                <td colspan="2" height="15"></td>
              </tr>
              <tr>
                <td colspan="2" align="left" valign="top" height="538">
                
                <asp:Panel runat="server" ID="pnlNoNews" Visible="false">
                    <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Seçtiðiniz tarihte haber bulunmamaktadýr.
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                
				<div id="dvHasNews" runat="server" class="dvScroll Scroll" style="width: 260; height: 537;">

                <asp:Repeater ID="rptNews" runat="server">
                <HeaderTemplate>
                    <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                </HeaderTemplate>
                <ItemTemplate>
                <tr>
                <td width="56" align="left">
            <a href='<%#DataBinder.Eval(Container.DataItem, "ActivityID", "News.aspx?ActivityID={0}")%>'>
                    <asp:Image Width="48" Height="39" runat="server" ID="imgNewsImage" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "PhotoPath")%>' />
                </a>
                </td>
                <td>
                <asp:HyperLink ID="hplNewsTitle" runat="server" CssClass="SNewsTitle" 
                    Text='<%#DataBinder.Eval(Container.DataItem, "ActivityTitle")%>'
                    NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "ActivityID", "~/News.aspx?ActivityID={0}")%>'></asp:HyperLink>
                <br />
<%--                <asp:HyperLink ID="hplDescriptin" runat="server" CssClass="T clBlack" 
                    Text='<%#DataBinder.Eval(Container.DataItem, "Description")%>'
                    NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "ActivityID", "~/News.aspx?ActivityID={0}")%>'></asp:HyperLink>  --%>  
                </td>
                </tr>
                <tr>
                <td height="12"></td>
                </tr>
                <tr>
                <td colspan="2" class="PlottedSepTd"></td>
                </tr>
                <tr>
                <td height="12"></td>
                </tr> 
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
                </asp:Repeater>
          
		        </div>
		        
		        
		        </td>
              </tr>
              <tr>
                <td colspan="2">&nbsp;</td>
              </tr>
              
            </table></td>
            <td width="13" valign="top">&nbsp;</td>
            <td width="700" align="left" valign="top"><table width="667" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="15"></td>
              </tr>
              <tr>
                <td class="BlueHeader"><asp:Label ID="lbTitle" runat="server"></asp:Label></td>
              </tr>
              <tr>
                <td height="12"></td>
              </tr>
              <tr>
                <td class="T clBlack">
                <asp:Literal ID="ltrNewsContent" runat="server"></asp:Literal>
                </td>
              </tr>
              <tr>
                <td>&nbsp;</td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td colspan="3">&nbsp;</td>
          </tr>
          
          
        </table>
		</td>
       
        </tr>
	  </table>