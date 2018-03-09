<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlCityDetail.ascx.cs" Inherits="UserControls_Pages_uctrlCityDetail" %>
<%@ Register Src="../Common/uctrlSearchSub.ascx" TagName="uctrlSearchSub" TagPrefix="uc3" %>
<%@ Register Src="../Common/uctrlTopAuthorsSub.ascx" TagName="uctrlTopAuthorsSub" TagPrefix="uc1" %>
<%@ Register Src="../Common/uctrlSubRightRegion.ascx" TagName="uctrlSubRightRegion" TagPrefix="uc2" %>

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
                                    <td style="height: 65px;" colspan="2" class="CountryHeader">
                                        <asp:Label runat="server" ID="lblParentName"></asp:Label> > 
                                        <asp:Label runat="server" ID="lblSubjectName"></asp:Label>
                                    </td>
                                </tr>
                                
                                <tr> <td class="VSpace"></td> </tr>
                                
                                <!-- ARAMA PANELÝ -->
                                
                                <tr>
                                    <td> 
                                     
                                        <uc3:uctrlSearchSub ID="UctrlSearchSub1" runat="server" />
                                     
                                    </td>
                                </tr>
                                
                                <!--// ARAMA PANELÝ -->

                                <tr> <td class="VSpace"></td> </tr>
                                
                                <!-- TOP YAZARLAR -->
                                <tr>
                                    <td style="background-color: #FFF;">
                                    <table>
                                    <tr>
                                    <td>
                                        <uc1:uctrlTopAuthorsSub ID="UctrlTopAuthorsSub1" runat="server" />
                                    </td>
                                    </tr>
                                    </table>
                                    </td>
                                </tr>
                                
                                <!--// TOP YAZARLAR -->
                                
                                <tr> <td class="VSpace"></td> </tr>
                                
                                <tr>
                                    <td>
                                        <asp:HyperLink ID="hplAddPAge" runat="server" ImageUrl="~/Images/Button/btnAddPage.jpg"></asp:HyperLink>
                                    </td>
                                </tr>
                                
                                <tr> <td class="VSpace"></td> </tr>
                                
                                <tr>
                                    <td>
                                        
                                        <table width="100%">
                                        
                                            <tr>
                                                <td valign="top">

                                                    <asp:DataList runat="server" ID="dlLastCategories" RepeatColumns="3">
                                                    <ItemTemplate>
                                                    
                                                    <table cellpadding="2" cellspacing="2" style="width:218px;" class="DegradeBack">
                                                        <tr>
                                                            <td class="Treb clDarkRed" style="padding: 6px 3px 0px 9px">
                                                                <%# DataBinder.Eval(Container.DataItem, "PageCategoryName") %>
                                                                <asp:Label ID="lbPageCategoryID" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "PageCategoryID")%>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>

                                                                <div style="padding: 7px;">
                                                                    <asp:Repeater ID="rptPages" runat="server">
                                                                        <ItemTemplate>
                                                                            <table>
                                                                            <asp:Label ID="lbTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Title")%>'></asp:Label>
                                                                            <asp:HyperLink ID="hlpMemberNickName" runat="server" CssClass="GrayLink"
                                                                            Text='<%#DataBinder.Eval(Container.DataItem, "NickName")%>'
                                                                            NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "MemberID", "~/MemberPage.aspx?MemberID={0}")%>'></asp:HyperLink><br />
                                                                            
                                                                            <hr style="border: solid 1px #CDE4F2;" />
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </div>
                                                                
                                                            </td>
                                                        </tr>
                                                    
                                                    </table>
                                                    
                                                    </ItemTemplate>
                                                    </asp:DataList>
                                       
                                                </td>
                                                <td>
                                                <asp:Label ID="lbNoPageFound" runat="server" Text="Bu þehirle ilgili henüz yazý girilmemiþtir" Visible="false"></asp:Label> 
                                                </td>
                                                
                                            </tr>
                                            
                                            <tr> <td style="height: 8px;"></td> </tr>
                                        
                                        </table>
                                        
                                        <br /><br />
                                        
                                    </td>
                                </tr>
                
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