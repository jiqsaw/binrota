<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlMemberVisitorHomePage.ascx.cs" Inherits="UserControls_uctrlMemberVisitorHomePage" %>
<table>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td align="center">
            <asp:Label ID="lbTravelPagesHeader" runat="server" Width="200px"></asp:Label></td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/nopicture.jpeg" Width="115px" /></td>
        <td style="padding-left: 50px;">
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
        <td style="padding-left:50px" valign="top">
            <asp:Repeater ID="rptPages" runat="server">
                <ItemTemplate> 
                        <a href='<%#DataBinder.Eval(Container.DataItem, "PageID", "MemberVisitorContentPage.aspx?PageID={0}")%>'>
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
        <td colspan="3" align="center">
            <asp:Label ID="Label1" runat="server" Text="Ana Sayfa Yazýsý"></asp:Label></td>
    </tr>
    <tr>
        <td align="center" colspan="3">
            <asp:TextBox ID="txtHomePageContent" runat="server" Rows="8" TextMode="MultiLine" Width="400px" ReadOnly="true"></asp:TextBox></td>
    </tr>
</table>
