<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlSearch.ascx.cs" Inherits="UserControls_Common_uctrlSearch" %>
<%@ Register Src="~/UserControls/Common/uctrlSubRightRegion.ascx" TagName="uctrlSubRightRegion" TagPrefix="uc2" %>

<table class="Content" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td width="695" colspan="3" valign="top">
         
        <!-- CONTENT -->
        
            <table width="695" style="height:963px;" cellspacing="0" cellpadding="0" class="SubContent DegradeBottom">
                <tr>
                    <td height="47" valign="middle" class="RegionHeader">
                        <div style="padding-top: 5px; padding-left: 25px;">
                            ARAMA SONUÇLARI
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style=" padding-left: 25px;" valign="top">
                        
                        <table border="1" bordercolor="#d6f4fb" cellpadding="2" cellspacing="2" width="93%">
                            <tr>
                                <td style="height: 60px;">
                                    

                                    <table width="100%" border="0" cellspacing="5" cellpadding="5">
                                        <tr>
                                            <td colspan="3">
                                                Aramak istediðiniz kelimeyi giriniz.
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtSearch" runat="server" CssClass="TextBox" Width="350"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpCategories" runat="server" CssClass="DropDownList" Width="162"></asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnSearch" runat="server" Width="67" Height="25" ImageUrl="~/Images/Design/btnSearch.jpg" OnClick="btnSearch_Click" />
                                            </td>
                                        </tr>
                                    </table>                                    
                                    
                                </td>
                            </tr>
                        </table>
                        
                        <br />
                        <table>
                        <tr>
                        <td>
                        <asp:Label ID="lbMessage" runat="server" Visible="false"></asp:Label>
                        </td>
                        </tr>
                        </table>
                        
                        <asp:Repeater ID="rptList" runat="server">
                            <HeaderTemplate>
                                <table width="100%">
                           </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td style="padding-bottom: 5px;">
                                        <table border="1" bordercolor="#c0f4bf" width="637">
                                            <tr>
                                                <td onmouseover="this.className='SearchResultItemOver';" onmouseout="this.className='SearchResultItem';" class="SearchResultItem" style="padding: 9px;"
                                                onclick='javascript:window.location = "<%#DataBinder.Eval(Container.DataItem, "PageID", "PageDetail.aspx?PageID={0}")%>";'>
                                                    <span class="clRed"> <asp:Label ID="lbSubjectName" CssClass="BlueHeader" Font-Bold="true" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'></asp:Label> </span> <br />
                                                    <asp:Label ID="lbTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Title")%>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>                                
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        
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
</table>