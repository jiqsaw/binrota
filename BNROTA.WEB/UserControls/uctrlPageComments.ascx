<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlPageComments.ascx.cs" Inherits="UserControls_uctrlPageComments" %>

        <asp:Repeater ID="rptMemberComment" runat="server">
        <ItemTemplate>
            <asp:TextBox ID="txtMemberComments" runat="server" TextMode="MultiLine" Rows="5" Width="250" Text='<%#DataBinder.Eval(Container.DataItem, "Comment")%>'></asp:TextBox>
            <asp:Label ID="lbMemberComments" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "NickName")%>'></asp:Label>
            <br />
        
        </ItemTemplate>   
        </asp:Repeater>

