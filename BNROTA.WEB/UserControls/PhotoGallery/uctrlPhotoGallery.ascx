<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlPhotoGallery.ascx.cs" Inherits="UserControls_PhotoGallery_uctrlPhotoGallery" %>

<table width="100%" cellspacing="0" cellpadding="0" style="text-align: center;">
    <tr>
        <td colspan="3" valign="top">
        
        <!-- CONTENT -->
        
            <table width="970" cellspacing="0" cellpadding="0" class="SubContent DegradeBottom">
                <tr>
                    <td style="width: 10px;"></td>
                    <td style="width: 178px; padding-top: 2px; padding-bottom: 2px;" valign="top">
                        
                        <table width="100%;">
                            <tr>
                                <td class="PhotoGalleryBack" style="height: 6px"></td>
                            </tr>
                            <tr> <td style="height: 2px;"></td> </tr>
                            <tr>
                                <td style="height: 35px; padding-left: 10px; background-color: #fbf9f4;" class="RegionHeader">
                                    ALBÜMLER
                                </td>
                            </tr>
                            <tr> <td style="height: 2px;"></td> </tr>
                            <tr>
                                <td class="PhotoGalleryBack" style="width: 100%; text-align: center;">
 <%--                               
                                    <asp:Repeater runat="server" ID="rptAlbums">
                                        <ItemTemplate>--%>
                                                                        
                                    <br /><br />
                                    
                                    <table width="150" cellpadding="2" cellspacing="2" style="background-color: #FFFFFF;">
                                        <tr>
                                            <td>
                                                
                                                <table width="144" style="cursor: pointer;" onclick="location.href='PhotoGallery.aspx?AlbumID=';">
                                                    <tr>
                                                        <td> <asp:Image runat="server" Width="144" Height="47" ImageUrl="~/Images/PhotoGallery/Gallery1.jpg" /> </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 27px;">
                                                             Marmara Resimleri
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 4px; background-color: #deedcb"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 2px;"></td>
                                                    </tr>
                                                </table>                                                
                                                
                                            </td>
                                        </tr>
                                    </table>
                                    
<%--                                        </ItemTemplate>
                                    </asp:Repeater>--%>
                                    
                                    <br /><br />
                                    
                                    <table width="150" cellpadding="2" cellspacing="2" style="background-color: #FFFFFF;">
                                        <tr>
                                            <td>
                                                
                                                <table width="144" style="cursor: pointer;" onclick="location.href='PhotoGallery.aspx?AlbumID=';">
                                                    <tr>
                                                        <td> <asp:Image runat="server" Width="144" Height="47" ImageUrl="~/Images/PhotoGallery/Gallery1.jpg" /> </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 27px; background-color: #fbf9f4;">
                                                             Marmara Resimleri
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 4px; background-color: #deedcb"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 2px;"></td>
                                                    </tr>
                                                </table>                                                
                                                
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    
                                    
                                    <br /><br />
                                
                                </td>
                            </tr>
                            <tr><td style="height: 4px; background-color: #fbf9f4;"></td></tr>
                        </table>
                    
                    </td>
                    <td style="padding-left: 20px;" class="RegionHeader" valign="top">
                        <div style="padding-top: 17px; padding-left: 8px;">
                            MARMARA RESÝMLERÝ
                        </div>
                        
                        <asp:Panel runat="server" ID="pnlPhotos">
                            
                         <table cellpadding="5" cellspacing="5" width="96%">
                            <tr>
                                <td>
                                    <asp:Image BorderWidth="3" CssClass="ImgGallery" runat="server" ImageUrl="~/Images/PhotoGallery/Gallery2.jpg" /></td>
                                <td>
                                    <asp:Image BorderWidth="3" CssClass="ImgGallery" runat="server" ImageUrl="~/Images/PhotoGallery/Gallery3.jpg" /></td>
                                <td>
                                    <asp:Image BorderWidth="3" CssClass="ImgGallery" runat="server" ImageUrl="~/Images/PhotoGallery/Gallery4.jpg" /></td>
                                <td>
                                    <asp:Image BorderWidth="3" CssClass="ImgGallery" runat="server" ImageUrl="~/Images/PhotoGallery/Gallery5.jpg" /></td>
                                                                                                                                                
                            </tr>
                            <tr><td colspan="4" style="height: 4px;"></td></tr>
                            <tr>
                                <td>
                                    <asp:Image BorderWidth="3" CssClass="ImgGallery" runat="server" ImageUrl="~/Images/PhotoGallery/Gallery7.jpg" /></td>
                                <td>
                                    <asp:Image BorderWidth="3" CssClass="ImgGallery" runat="server" ImageUrl="~/Images/PhotoGallery/Gallery6.jpg" /></td>
                                <td>
                                    <asp:Image BorderWidth="3" CssClass="ImgGallery" runat="server" ImageUrl="~/Images/PhotoGallery/Gallery2.jpg" /></td>
                                <td>
                                    <asp:Image BorderWidth="3" CssClass="ImgGallery" runat="server" ImageUrl="~/Images/PhotoGallery/Gallery4.jpg" /></td>
                                                                                                                                                
                            </tr>
                         </table>   
                            
                            <br /> <br />
                            <table width="655" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="right" class="Verd10px clRed ">
                                        1 | 2 | 3 | 4</td>
                                </tr>
                            </table>
                            
                        </asp:Panel>
                        
                        <br /><br />
                        
                    </td>
                </tr>
            </table>

        <!-- //CONTENT -->
        
        </td>
    </tr>
</table>