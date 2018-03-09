<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtEMail" runat="server" Style="z-index: 100; left: 168px; position: absolute;
            top: 86px"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Style="z-index: 101; left: 89px; position: absolute;
            top: 88px" Text="E-posta"></asp:Label>
        <asp:Button ID="btnSubmit" runat="server" Style="z-index: 102;
            left: 214px; position: absolute; top: 127px" Text="Gönder" Width="65px" OnClick="btnSubmit_Click" />
        <asp:Label ID="lbError" runat="server" Style="z-index: 103; left: 171px; position: absolute;
            top: 44px"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEMail"
            ErrorMessage="Lütfen E-Mail adresinizi giriniz" Style="z-index: 104; left: 349px;
            position: absolute; top: 88px"></asp:RequiredFieldValidator>
        &nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Lütfen düzgün bir E-Mail adresi giriniz"
            Style="z-index: 107; left: 351px; position: absolute; top: 126px" ControlToValidate="txtEMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    
    </div>
    </form>
</body>
</html>
