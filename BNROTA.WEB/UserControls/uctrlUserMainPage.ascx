<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlUserMainPage.ascx.cs" Inherits="UserControls_uctrlUserMainPage" %>
<%@ Register Src="uctFreeTextBox.ascx" TagName="uctFreeTextBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
function OpenUploadForPortrait() {
    window.open("ImageUpload.aspx", 'BinrotaUpload', 'width=300,height=150,toolbar=no,resizable=yes,');
}
</script>
<table>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td style="padding-left: 50px; width: 231px;">
        <asp:Label ID="lbTravelPagesHeader" runat="server" Width="200px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 116px; height: 161px;">
            <asp:Image ID="imgPortrait" runat="server" Width="115px" ImageUrl="~/Images/MemberImages/Portrait/5/asker.jpeg" /><br />
            <asp:LinkButton OnClientClick="OpenUploadForPortrait()" ID="lnbAddNewPhoto" runat="server" Text="Resim Ekle"></asp:LinkButton>
        </td>
        <td style="padding-left: 30px; height: 161px;">
        <table>
        <tr>
        <td>Ýsim</td>
        <td>:</td>
        <td><asp:Label ID="lbName" runat="server" Text=""></asp:Label></td></tr>
        <tr>
        <td>Doðum Günü</td>
        <td>:</td>
        <td><asp:Label ID="lbBirthDate" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
        <td>Yaþadýðý Yer</td>
        <td>:</td>
        <td><asp:Label ID="lbBirthPlace" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
        <td>Eðitimi</td>
        <td>:</td>
        <td><asp:Label ID="lbEducation" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
        <td>Ýþi</td>
        <td>:</td>
        <td><asp:Label ID="lbJob" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
        <td>Puaný</td>
        <td>:</td>
        <td><asp:Label ID="lbPoints" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
        <td>Ýlgileri</td>
        <td>:</td>
        <td><asp:Label ID="lbInterests" runat="server" Text=""></asp:Label></td>
        </tr>
        </table>
        </td>
        <td style="padding-left: 50px; width: 231px; height: 161px;" valign="top">
           <asp:Repeater ID="rptPages" runat="server">
                <ItemTemplate> 
                        <a href='<%#DataBinder.Eval(Container.DataItem, "PageID", "MemberPageUpdate.aspx?PageID={0}")%>'>
                        <%#DataBinder.Eval(Container.DataItem, "TravelContentName")%>
                        </a>
                </ItemTemplate>
            <SeparatorTemplate></br></SeparatorTemplate>
            </asp:Repeater>                       
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        <asp:Label ID="lbMotto" runat="server" Text=""></asp:Label>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
            <asp:LinkButton ID="lnbBuildPhotographAlbum" runat="server">Fotoðraf Albümü Oluþtur</asp:LinkButton></td>
    </tr>
    <tr>
    <td></td>
        <td align="center">
            <asp:Label ID="Label1" runat="server" Text="Ana Sayfa Yazýsý"></asp:Label></td>
        <td></td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <uc1:uctFreeTextBox ID="ftbUserMainPageText" runat="server" />
        </td>
        <td>
        </td>
    </tr>
</table>
