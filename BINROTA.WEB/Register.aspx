<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<div style="text-align: center">
            <table id="TABLE1" style="width: 526px; height: 338px">
                <tr>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="Label11" runat="server" Text="Üye Bilgileri"></asp:Label></td>
                    <td style="width: 80px">
                        <asp:Label ID="lbMessage" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label1" runat="server" Text="Adýnýz"></asp:Label></td>
                    <td style="width: 80px">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen bir isim giriniz!" ControlToValidate="txtName" Width="137px"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label2" runat="server" Text="Soyadýnýz"></asp:Label></td>
                    <td style="width: 80px">
                        <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen bir soyad giriniz!" Width="144px" ControlToValidate="txtSurname"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label></td>
                    <td style="width: 80px">
                        <asp:TextBox ID="txtEMail" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Lütfen bir Email adresi giriniz!" ControlToValidate="txtEMail" Width="185px"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Lütfen doðru bir Email adresi giriniz!" ControlToValidate="txtEMail" Width="223px" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label9" runat="server" Text="Rumuz"></asp:Label></td>
                    <td style="width: 80px">
                        <asp:TextBox ID="txtNickName" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Lütfen bir rumuz giriniz!" ControlToValidate="txtNickName" Width="150px"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label3" runat="server" Text="Doðum Yýlý"></asp:Label></td>
                    <td style="width: 80px">
                        <asp:DropDownList ID="drpBirthYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpBirthYear_SelectedIndexChanged">
                        </asp:DropDownList>&nbsp;</td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label5" runat="server" Text="Doðum Tarihi"></asp:Label></td>
                    <td style="width: 80px">
                        <asp:Calendar ID="clBirthDate" runat="server" 
                            BackColor="#FFFFCC" BorderColor="#FFCC66"
                            BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                            ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                            <SelectorStyle BackColor="#FFCC66" />
                            <OtherMonthDayStyle ForeColor="#CC9966" />
                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                        </asp:Calendar>
                        </td>
                    <td style="width: 100px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label6" runat="server" Text="Þifre"></asp:Label></td>
                    <td style="width: 80px">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Lütfen bir þifre giriniz!" ControlToValidate="txtPassword" Width="137px"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label7" runat="server" Text="Þifrenizi Tekrarlayýn"></asp:Label></td>
                    <td style="width: 40px">
                        &nbsp;
                        <asp:TextBox ID="txtPasswordControl" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Girdiðiniz þifreler birbiriyle ayný deðildir!" ControlToCompare="txtPassword" ControlToValidate="txtPasswordControl" Width="238px"></asp:CompareValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 26px;">
                        <asp:Label ID="Label8" runat="server" Text="Cinsiyetiniz"></asp:Label></td>
                    <td style="width: 80px; height: 26px;">
                          <asp:RadioButton ID="rbMale" runat="server" Text="Erkek" /><asp:RadioButton ID="rbFemale" runat="server" Text="Kadýn" /></td>
                    <td style="width: 100px; height: 26px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 26px">
                    </td>
                    <td style="width: 80px; height: 26px">
                        <asp:Button ID="btnSubmit" runat="server" Text="Gönder" OnClick="btnSubmit_Click" /></td>
                    <td style="width: 100px; height: 26px">
                        <asp:Button ID="btnMainPage" runat="server" CausesValidation="False" OnClick="btnMainPage_Click"
                            Text="Ana Sayfa" /></td>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>
