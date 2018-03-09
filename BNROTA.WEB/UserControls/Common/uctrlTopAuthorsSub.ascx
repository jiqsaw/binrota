<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlTopAuthorsSub.ascx.cs" Inherits="UserControls_Common_uctrlTopAuthorsSub" %>

<hr style="border: dotted 1px #d2f9ff" />

<div class="VSpace"></div>

<font class="BlueHeader">
EN ÇOK PUAN ALAN <asp:Label ID="lbMembersTitle" runat="server"></asp:Label> YAZARLARI
</font>

<br />

<asp:Repeater ID="rptTopAuthors" runat="server">
<ItemTemplate>
<td align="center">

        <table width="190" cellpadding="0" cellspacing="0">
            <tr>
                <td width="65" align="right">
                <asp:Image BorderWidth="2" BorderColor="#d1e1f8" ID="imgauthor" runat="server" Width="60" Height="72" 
                ImageUrl='<%# BINROTA.COM.Common.ReturnImagePath(DataBinder.Eval(Container.DataItem, "PhotoPath").ToString(), ConfigurationManager.AppSettings["MemberImagesUrl"].ToString()) %>' />
                </td>
                <td width="104" style="padding-left: 9px;">
                    <span class="clDarkRed Treb"><strong><asp:Label ID="lbAuthorNickName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "NickName")%>' CssClass="Label"></asp:Label></strong></span><br>
                    <span class="Arial clGray">
                    <asp:Label ID="lbAuthorPageCount" runat="server" CssClass="Label" 
                    Text= '<%#DataBinder.Eval(Container.DataItem, "Point")%>'>
                    </asp:Label>
                    </span><br>
                    <br>
                    <asp:HyperLink ID="hplAuthorAllPages" CssClass="TGray" runat="server" Text="Tüm Yazýlarý" 
                    NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "MemberID", "~/MemberVisitorHomePage.aspx?MemberID={0}")%>'></asp:HyperLink>
                    </td>
            </tr>
            <tr>
                <td colspan="2" height="8">
                </td>
            </tr>
        </table>

</td>
<td width="1" bgcolor="#BCDAF2"></td>
</ItemTemplate>
</asp:Repeater>

<div class="VSpace"></div>

<hr style="border: dotted 1px #d2f9ff" />