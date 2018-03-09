<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlPageDetail.ascx.cs"
    Inherits="UserControls_Pages_uctrlPageDetail" %>
    
    
<table class="Content" cellspacing="0" cellpadding="0" style="text-align: center;">
    <tr>
        <td valign="top" style="padding-left: 18px;">
            <table width="970" cellpadding="2" cellspacing="2" class="SubContent LogoBack">
                <tr>
                    <td style="padding: 15px;" valign="top">

                        <table style="width: 622px;">
                            <tr>
                                <td valign="top">
                                    <table class="MemberInfo" width="100%">
                                        <tr>
                                            <td>
                                                <table cellpadding="4" cellspacing="4" width="100%">
                                                    <tr>
                                                        <td style="width: 70px;">
                                                            <asp:Image BorderColor="#FFFFFF" BorderWidth="3" runat="server" ID="imgUserPicture"
                                                                Width="61" Height="65" ImageUrl="~/Images/MemberImages/asker.jpeg" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:HyperLink CssClass="Treb" Font-Size="Larger" ForeColor="#6f7f6e" runat="server"
                                                                ID="hlMemberNick"></asp:HyperLink>
                                                            <br />
                                                            <asp:Label runat="server" ID="lblMotto" CssClass="Treb" />
                                                            <br />
                                                            <br />
                                                            »
                                                            <asp:HyperLink runat="server" ID="hplMemberOtherPages" CssClass="TGray" Text="Yazarýn Diðer Yazýlarý"
                                                                NavigateUrl="" />
                                                        </td>
                                                        <td align="center">
                                                            <table width="1">
                                                                <tr>
                                                                    <td style="width: 1px; height: 72px; background-color: #FFFFFF;">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label runat="server" ID="lblMemberPoint" Font-Size="X-Large" CssClass="Treb"
                                                                ForeColor="#6f7f6e" />
                                                            <br />
                                                            Puan
                                                        </td>
                                                        <td>
                                                            <table width="1">
                                                                <tr>
                                                                    <td style="width: 1px; height: 72px; background-color: #FFFFFF;">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <span class="clDarkRed">Gezdiði Yerler: </span>
                                                            <asp:Literal runat="server" ID="ltlMemberVisited"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        
                        <br />
                        
                        <table width="920" cellpadding="2" cellspacing="2">
                            <tr>
                                <td>
                                    <asp:Label runat="server" Font-Bold="true" Font-Size="Larger" ForeColor="#977b7b" ID="lblPageTitle"></asp:Label>
                                    &nbsp;&nbsp;&nbsp; | &nbsp;&nbsp;&nbsp; (<asp:Label runat="server"
                                    CssClass="RegionHeader" ID="lblParentName"></asp:Label>
                                    >
                                    <asp:Label runat="server" CssClass="RegionHeader" ID="lblSubjectName"></asp:Label>)                                
                                </td>
                                <td style="text-align: right;">
                                    Kategorisi: <b><asp:Literal runat="server" ID="ltlPageCategory" /></b>
                                    &nbsp;&nbsp;&nbsp; | &nbsp;&nbsp;&nbsp;
                                    Gezi Tarihi: <b><asp:Literal runat="server" ID="ltlPageDate" /></b> 
                                </td>
                            </tr>
                        </table>
                        
                        <table width="100%">
                            <tr>
                                <td valign="top" width="622">
                                
                                    <table style="border: solid 2px f0f2f2;" width="100%">
                                        <tr>
                                            <td>
                                                <div style="padding: 10px;" id="dvPageDetail" runat="server">
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                </td>
                                <td style="width: 10px;"></td>
                                <td valign="top">
                                 
                                    <table style="background-color: #f8f9f9; border: solid 2px f0f2f2;" width="280">
                                        <tr>
                                            <td style="text-align: center;">
                                            
                                                <asp:Repeater runat="server" ID="rptPageContent">
                                                    <HeaderTemplate>
                                                        <table style="text-align: left;" cellpadding="1" cellspacing="1" width="90%">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td class="PageDetailExtraInfoHeader">
                                                                <b>
                                                                    <%# DataBinder.Eval(Container.DataItem, "Name") %>
                                                                </b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="PageDetailExtraInfoText">
                                                                <%# DataBinder.Eval(Container.DataItem, "PageContent") %>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                                <br /><br />
                                            </td>
                                        </tr>
                                    </table>
                                
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td style="padding: 15px;" valign="top">
                        <table style="text-align: right;">
                            <tr>
                                <td>
                                    <asp:HyperLink runat="server" ID="hlAddComment" ImageUrl="~/Images/Button/btnAddComment.jpg"></asp:HyperLink></td>
                                <td style="padding-left: 10px;">
                                    <asp:HyperLink runat="server" ID="hlAddComplain" ImageUrl="~/Images/Button/btnComplain.jpg"></asp:HyperLink></td>
                                <td style="padding-left: 10px;">
                                    <asp:DropDownList ID="drpPoints" runat="server" CssClass="DropDownList" Width="40"></asp:DropDownList>
                                    <asp:Button ID="btnAddPoints" runat="server" CssClass="Button" Text="Puan Ver" OnClick="btnAddPoints_Click" />
                                </td>
                            </tr>
                        </table>                    
                    </td>
                </tr>
                <tr>
                    <td style="padding: 15px;" valign="top">
                        <asp:Panel ID="pnlComments" runat="server" Visible="false">
                            <hr style="border: dotted 1px #d8e8f0" />
                            <table width="200">
                                <tr>
                                    <td style="padding-left: 8px;">
                                        <asp:Label CssClass="RegionHeader" runat="server" ID="lblCommentHeader"> YAZI ÝLE ÝLGÝLÝ YORUMLAR </asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <hr style="border: dotted 1px #d8e8f0" />
                            
                                <asp:Repeater ID="rptComments" runat="server">
                                    <HeaderTemplate>
                                        <table width="100%">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <table style="border: solid 1px #e7f8ff; background-color: #FFF; width: 100%;">
                                                    <tr>
                                                        <td style="padding: 8px;">
                                                            <asp:HyperLink CssClass="clDarkRed" runat="server" ID="hlCommentMemberNick" Text='<%# DataBinder.Eval(Container.DataItem, "NickName") %>'
                                                                NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "MemberID", "~/MemberPage.aspx?MemberID={0}") %>'></asp:HyperLink>
                                                            &nbsp;&nbsp;&nbsp;
                                                           
                                                            <br />
                                                            <br />
                                                            <%# DataBinder.Eval(Container.DataItem, "Comment") %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <SeparatorTemplate>
                                        <tr>
                                            <td style="height: 2px;">
                                            </td>
                                        </tr>
                                    </SeparatorTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>                            
                            
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 15px;" valign="top">
                        <table style="text-align: right;">
                            <tr id="trSubButtons" runat="server">
                                <td>
                                    <asp:HyperLink runat="server" ID="hlAddComment2" ImageUrl="~/Images/Button/btnAddComment.jpg"></asp:HyperLink></td>
                                <td style="padding-left: 10px;">
                                    <asp:HyperLink runat="server" ID="hlAddComplain2" ImageUrl="~/Images/Button/btnComplain.jpg"></asp:HyperLink></td>
                                    <td style="padding-left: 10px;">
                                    <asp:DropDownList ID="drpPoints2" runat="server" CssClass="DropDownList" Width="40"></asp:DropDownList>
                                    <asp:Button ID="btnAddPoints2" runat="server" CssClass="Button" Text="Puan Ver" OnClick="btnAddPoints2_Click"/>
                                </td>
                            </tr>
                        </table>                    
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>