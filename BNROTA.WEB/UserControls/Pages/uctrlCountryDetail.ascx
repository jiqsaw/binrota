<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlCountryDetail.ascx.cs" Inherits="UserControls_Pages_uctrlCountryDetail" %>
<%@ Register Src="../Common/uctrlSearchSub.ascx" TagName="uctrlSearchSub" TagPrefix="uc3" %>
<%@ Register Src="../Common/uctrlSubRightRegion.ascx" TagName="uctrlSubRightRegion" TagPrefix="uc2" %>
<%@ Register Src="../Common/uctrlLastTripSubjects.ascx" TagName="uctrlLastTripSubjects" TagPrefix="uc8" %>
<%@ Register Src="../Common/uctrlFavoritePlaces.ascx" TagName="uctrlFavoritePlaces" TagPrefix="uc6" %>
<%@ Register Src="../Common/uctrlMemberInfo.ascx" TagName="uctrlMemberInfo" TagPrefix="uc1" %>
<%@ Register Src="../Common/uctrlTopAuthorsSub.ascx" TagName="uctrlTopAuthorsSub" TagPrefix="uc0" %>

<div style="padding-left: 17px;">

    <table class="Content" cellspacing="0" cellpadding="0" style="text-align: center;">
                <tr>
                    <td colspan="3" align="center" valign="top" style="width: 695px;">
                        
                        <!-- CONTENT -->
                        
                        <table cellspacing="0" cellpadding="0" class="SubContent ReverseDegrade">
                            <tr>
                                <td class="CountryAndCityTbl">
                                        
                                    <!-- ÝÇERÝK -->

                                    <table width="660">
                                        <tr>
                                            <td style="height: 60px;" class="CountryHeader">
                                            <asp:Label ID="lbCountryName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="T clNavy" style="padding-right: 20px;">
                                            <asp:Label ID="lbDescription" runat="server"></asp:Label> 
                                            </td>
                                        </tr>
                                        <tr><td class="VSpace"></td></tr>
                                        <tr>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td valign="top" style="padding-right: 5px;" runat="server" id="tdImage">
                                                            <asp:Image BorderColor="#eef9ff" BorderWidth="3" ID="imgCountry" runat="server" />
                                                        </td>
                                                        <td>
                                              
                                                            <table width="373" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="top" class="CountryAttribute">
                                                            Konum</td>
                                                        <td width="3">
                                                        </td>
                                                        <td class="CountryAttrDesc">
                                                            <asp:Label ID="lbLocation" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" height="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="CountryAttribute">
                                                            Ba&#351;kent</td>
                                                        <td width="3">
                                                        </td>
                                                        <td class="CountryAttrDesc">
                                                            <asp:Label ID="lbCapital" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" height="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="CountryAttribute">
                                                            Yüzölçümü
                                                        </td>
                                                        <td width="3">
                                                        </td>
                                                        <td class="CountryAttrDesc">
                                                            <asp:Label ID="lbArea" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" height="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="CountryAttribute">
                                                            Kom&#351;ular&#305;</td>
                                                        <td width="3">
                                                        </td>
                                                        <td class="CountryAttrDesc">
                                                            <asp:Label ID="lbNeighbourhood" runat="server"></asp:Label>    
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" height="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="CountryAttribute">
                                                            N&uuml;fus</td>
                                                        <td width="3">
                                                        </td>
                                                        <td class="CountryAttrDesc">
                                                            <asp:Label ID="lbPopulatiob" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" height="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="CountryAttribute">
                                                            Para Birimi
                                                        </td>
                                                        <td width="3">
                                                        </td>
                                                        <td class="CountryAttrDesc">
                                                            <asp:Label ID="lbCurrency" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" height="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="CountryAttribute">
                                                            Telefon Kodu
                                                        </td>
                                                        <td width="3">
                                                        </td>
                                                        <td class="CountryAttrDesc">
                                                            <asp:Label ID="lbAreaCode" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" height="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="CountryAttribute">
                                                            Zaman Dilimi
                                                        </td>
                                                        <td width="3">
                                                        </td>
                                                        <td class="CountryAttrDesc">
                                                            <asp:Label ID="lbTimeZone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" height="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="CountryAttribute">
                                                            Dil</td>
                                                        <td width="3">
                                                        </td>
                                                        <td class="CountryAttrDesc">
                                                            <asp:Label ID="lbLanuage" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" height="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="CountryAttribute">
                                                            Din</td>
                                                        <td width="3">
                                                        </td>
                                                        <td class="CountryAttrDesc">
                                                            <asp:Label ID="lbReligion" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                              
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr><td class="VSpace"></td></tr>
                                        <tr>
                                            <td>
                                            
                                                <uc3:uctrlSearchSub ID="uctrlSearchSub1" runat="server" />

                                            </td>
                                        </tr>
                                        <tr><td class="VSpace"></td></tr>
                                        <tr>
                                            <td align="left">
                                                <asp:DataList ID="dlCities" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                                                    <ItemTemplate>
                                                        <table cellpadding="1" cellspacing="0">
                                                        <tr>
                                                        <td width="155" class="CountryCities" onmouseover="this.style.background='#BCDAF2';"
                                                            onmouseout="this.style.background='#FFFFFF';" 
                                                            onclick='javascript:window.location = "<%#DataBinder.Eval(Container.DataItem, "Url")%>";'>
                                                            <asp:Label ID="lbCity" runat="server" 
                                                            Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'></asp:Label>
                                                        </td>
                                                        <td width="10">
                                                        </td>
                                                        </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                      
                                        <tr>
                                            <td>
                                            <hr style="border: dotted 1px #d2f9ff" />
                                                <table width="642" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td align="right">
                                                              <asp:HyperLink ID="hplAddPAge" runat="server" ImageUrl="~/Images/Button/btnAddPage.jpg"></asp:HyperLink>
                                                         </td>
                                                    </tr>
                                                </table>
                                            <hr style="border: dotted 1px #d2f9ff" />
                                            </td>
                                        </tr>

                                        <tr id="trTopAuthors" runat="server">
                                            <td>                                  
                                                <uc0:uctrlTopAuthorsSub ID="uctrlTopAuthorsSub1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr><td class="VSpace"></td></tr>
                                        <tr id="trLastPages" runat="server">
                                            <td align="left" height="220" valign="top">
                                            <font class="BlueHeader">
                                            <asp:Label ID="lbPagesTitle" runat="server"></asp:Label> YAZILARI
                                            </font> <br />
                                                <div class="dvScroll Scroll" style="width: 661px; height: 220px;">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    
                                                        <asp:Repeater ID="rptLastPages" runat="server">
                                                        <ItemTemplate>
                                                        <tr>
                                                            <td class="clBlack T">
                                                                <strong>
                                                                <asp:Label ID="lbSubjectName" runat="server" CssClass="Label" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'></asp:Label>
                                                                </strong>
                                                                <asp:Label ID="lbMemberNickName" runat="server" CssClass="Label" Text='<%#DataBinder.Eval(Container.DataItem, "NickName")%>'></asp:Label><br />
                                                                <asp:HyperLink ID="hlPageTitle" runat="server" CssClass="Label" Text='<%#DataBinder.Eval(Container.DataItem, "Title")%>'
                                                                NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "PageID", "~/PageDetail.aspx?PageID={0}")%>'></asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="7">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TripSepTd">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="7">
                                                            </td>
                                                        </tr>
                                                        
                                                        </ItemTemplate>
                                                        
                                                        </asp:Repeater>
                                                        
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr><td class="VSpace"></td></tr>                                   
                                    </table>

                                    <!-- //ÝÇERÝK -->
                                    
                                </td>
                            </tr>
                        </table>
                        
                        <!-- //CONTENT -->
                    
                    </td>
                    <td class="HSpace"> </td>
                    <td style="width: 267px;" rowspan="3" valign="top">
                        <uc2:uctrlSubRightRegion ID="UctrlSubRightRegion1" runat="server" />
                    </td>
                </tr>
                <tr> <td colspan="3" class="VSpace"></td> </tr>
            </table>

</div>
