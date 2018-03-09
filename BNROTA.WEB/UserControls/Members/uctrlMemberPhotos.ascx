<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlMemberPhotos.ascx.cs" Inherits="UserControls_Members_uctrlMemberPhotos" %>
<%@ Register Src="../Common/uctrlPagings.ascx" TagName="uctrlPagings" TagPrefix="uc3" %>
<%@ Register Src="../Common/uctrlPaging.ascx" TagName="uctrlPaging" TagPrefix="uc2" %>
<%@ Register Src="../uctrlImageUpload.ascx" TagName="uctrlImageUpload" TagPrefix="uc1" %>

<script type="text/javascript">
    function ShowHide(HideID, ShowID) {
        document.getElementById(ShowID).style.display = 'block';
        document.getElementById(HideID).style.display = 'none';
    }
</script>

<table width="273" style="height:600px;" cellspacing="0" cellpadding="0">
    <tr>
        <td style="height: 16px;"></td>
    </tr>
    <tr>
        <td class="BlueHeader" style="padding-left:10px;">FOTOÐRAFLARIM</td>
    </tr>
    <tr>
        <td style="height: 10px;"></td>
    </tr>
    <tr>
        <td style="text-align: left; padding-left: 10px;">
            <asp:Panel ID="pnlAddAlbumPhoto" runat="server">
            <div id="AddAlbumLink">
            » <a href="javascript:ShowHide('AddAlbumLink', 'AddAlbum')" class="clRed"> Albüm Eklemek Ýçin Týklayýnýz </a>
            </div>
            <div id="AddAlbum" style="display: none;">
            
                <table width="94%" cellpadding="2" cellspacing="2" style="border: solid 1px #FFF">
                    <tr>
                        <td style="padding: 3px 3px 3px 3px">
                            
                            <table cellpadding="3" cellspacing="3" width="100%">
                                <tr>
                                    <td>
                                        Albüm Adý: 
                                        <asp:TextBox Width="167" CssClass="TextBox" runat="server" ID="txtNewAlbumName"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                        <table width="100%">
                                            <tr>
                                                <td style="text-align: left;">
                                                    x <a href="javascript:ShowHide('AddAlbum', 'AddAlbumLink')">kapat</a>
                                                </td>
                                                <td style="text-align: right;">
                                                    <asp:Button CssClass="Button" runat="server" ID="btnNewAddAlbum" Text="Albüm Ekle" OnClick="btnNewAddAlbum_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                    </tr>
                </table>
            
            </div>            
            
            <br />
            
            <div id="AddPhotoLink">
            » <a href="javascript:ShowHide('AddPhotoLink', 'AddPhoto')" class="clRed"> Fotoðraf Eklemek Ýçin Týklayýnýz </a>
            </div>
            <div id="AddPhoto" style="display: none;">
                <table width="94%" cellpadding="2" cellspacing="2" style="border: solid 1px #FFF">
                    <tr>
                        <td style="padding: 3px 3px 3px 3px; text-align: left;">
                            
                            <table cellpadding="3" cellspacing="3" width="100%">
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lbMessage" runat="server" Text="Lütfen bir albüm seçiniz" ForeColor="red" Visible="false"></asp:Label><br />
                                        <asp:Label ID="lbAlbumTitle" Text="Albüm Adý" runat="server" Width="70"></asp:Label>
                                        <asp:DropDownList CssClass="DropDownList" runat="server" ID="ddlAlbumList" Width="100"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <uc1:uctrlImageUpload ID="UctrlImageUpload2" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                        <table width="100%">
                                            <tr>
                                                <td style="text-align: left;">
                                                    x <a href="javascript:ShowHide('AddPhoto', 'AddPhotoLink')">kapat</a>
                                                </td>
                                                <td style="text-align: right;">
                                                    <asp:Button CssClass="Button" runat="server" ID="btnNewAddPhoto" Text="Fotoðraf Ekle" OnClick="btnNewAddPhoto_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                    </tr>
                </table>

            </div>
            </asp:Panel>
        </td>
    </tr>
    <tr align="center">
        <td valign="top">
                 <table style="width: 100%; height: 414px">
                    <tr>
                        <td style="padding-top: 6px; padding-left: 10px; vertical-align:top;">
                            <asp:Label ID="lbAlbumTitle2" Text="" runat="server"></asp:Label>
                            <asp:DropDownList  CssClass="DropDownList" runat="server" ID="ddlAlbumList2" OnSelectedIndexChanged="ddlAlbumList2_SelectedIndexChanged" AutoPostBack="True" Width="181px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:9px;padding-right:9px; text-align: left;" valign="top">
                            <asp:DataList Width="100%" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Table" ID="dlMemberPhotos" runat="server" OnItemDataBound="dlMemberPhotos_ItemDataBound">
                            <ItemStyle VerticalAlign="Top" />
                                <ItemTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0" align="center" style="padding-top:10;">
                                        <tr>
                                            <td valign="top">
                                                <a href="javascript:Zoom('<%#"MemberAlbumImages/Big/" + DataBinder.Eval(Container.DataItem, "PhotoUrl").ToString() %>')">
                                                <asp:Image id="imgPhoto" runat="server" ImageUrl='<%# BINROTA.COM.Common.ReturnImagePath(DataBinder.Eval(Container.DataItem, "PhotoUrl").ToString(), ConfigurationManager.AppSettings["MemberAlbumImagesUrlSmall"].ToString()) %>' BorderColor="#FFFFFF" BorderWidth="3"/> </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top:2px;padding-bottom:5px;">
                                                <asp:Button id="btnImageDelete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"MemberPhotoID")%>' CssClass="Button" Text="Sil" runat="server" OnClick="btnImageDelete_Click"/>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                 </table>
        </td>
    </tr>
    <tr>
    <td>
      <uc3:uctrlPagings ID="UctrlPagings1" runat="server" Visible="false" />
     
    </td>
    </tr>

</table>