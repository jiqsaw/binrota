<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlSearchSub.ascx.cs" Inherits="UserControls_Common_uctrlSearchSub" %>

<hr style="border: dotted 1px #FFF" />

    <table border="0" cellspacing="2" cellpadding="2">
        <tr>
            <td colspan="3" class="clDarkGreen T">
                <asp:Label CssClass="clDarkGreen T" Font-Size="Larger" ID="lblSearchTitle" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtSearch" runat="server" CssClass="TextBox" Width="400"></asp:TextBox>
            </td>
            <td>
                <asp:DropDownList ID="drpCategories" runat="server" CssClass="DropDownList" Width="162"></asp:DropDownList>
            </td>
            <td>
                <asp:ImageButton ID="btnSearch" runat="server" Width="67" Height="25" ImageUrl="~/Images/Design/btnSearch.jpg" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    
<hr style="border: dotted 1px #FFF" />