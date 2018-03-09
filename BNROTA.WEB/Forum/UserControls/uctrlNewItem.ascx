<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlNewItem.ascx.cs"
    Inherits="Forum_UserControls_uctrlNewItem"%>
<%@ Register Src="ForumTextBox.ascx" TagName="ForumTextBox" TagPrefix="uc1" %>

<link rel="stylesheet" type="text/css" href="Forum/Styles/Forum.css">
<table class="Content" cellpadding="0" cellspacing="0" border="0" align="center"
    bgcolor="#ffffff">
    <tr>
        <td height="20">
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="4" cellspacing="0" border="1" align="center" width="90%" class="ForumTable">
                <tr align="center" class="ForumTHeader">
                    <td colspan="2" align="left">
                        <asp:Label ID="lblTitle" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" style="padding: 5px;" class="FText12" width="25%">
                        <b>Baðlý Kullanýcý :</b></td>
                    <td align="left" style="padding: 5px;" width="75%">
                        <asp:Label ID="lblLoggedUser" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" style="padding: 5px;" class="FText12" width="25%">
                        <b>Konu :<asp:RequiredFieldValidator ID="SubjectValidator" runat="server" ControlToValidate="txtSubject"
                            ErrorMessage="*" ValidationGroup="InsertItem"></asp:RequiredFieldValidator></b></td>
                    <td align="left" style="padding: 5px;" width="75%">
                        <asp:TextBox ID="txtSubject" runat="server" class="TextBox" Style="width: 500px;"></asp:TextBox></td>
                </tr>
                <%if (IsAdmin)
                  {%>
                <tr>
                    <td align="left" style="padding: 5px;" class="FText12" width="25%">
                        <b>Statü :</b></td>
                    <td align="left" style="padding: 5px;" width="75%">
                        <asp:DropDownList id="ddlState" runat="server"></asp:DropDownList></td>
                </tr>
                <%} %>
                <%if (ItemType==BINROTA.BUS.Forum.ItemType.Article) {%>
                <tr>
                    <td align="left" style="padding: 5px;" class="FText12" width="25%">
                        <b>Kategori :</b></td>
                    <td align="left" style="padding: 5px;" width="75%">
                        <asp:DropDownList id="ddlCategory" runat="server"></asp:DropDownList></td>
                </tr>
                <%} %>
                <tr>
                    <td align="left" valign="top" style="padding: 5px;" class="FText12" width="25%">
                        <b>Mesaj :</b></td>
                    <td align="left" style="padding: 5px;" width="75%">
                        <uc1:ForumTextBox ID="ForumTextBox1" runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td align="right" style="padding-right: 60px;">
            <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Forum/images/save.jpg" OnClick="btnSave_Click" ValidationGroup="InsertItem" /><asp:ImageButton
                ID="btnCancel" runat="server" ImageUrl="~/Forum/images/cancel.jpg" OnClick="btnCancel_Click" /><%if (IsAdmin && ItemID!=-1)
                                                                                                                 {%><asp:ImageButton
                ID="btnDelete" runat="server" ImageUrl="~/Forum/images/delete.jpg" OnClick="btnDelete_Click" />
                <%} %></td>
    </tr>
    <tr>
        <td height="20">
        </td>
    </tr>
</table>