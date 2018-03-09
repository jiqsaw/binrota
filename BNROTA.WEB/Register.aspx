<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table id="TABLE1" style="width: 526px; height: 338px">
                <tr>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="Label11" runat="server" Text="�ye Bilgileri"></asp:Label></td>
                    <td style="width: 80px">
                        <asp:Label ID="lbMessage" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label1" runat="server" Text="Ad�n�z"></asp:Label></td>
                    <td style="width: 80px">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="L�tfen bir isim giriniz!" ControlToValidate="txtName" Width="137px"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label2" runat="server" Text="Soyad�n�z"></asp:Label></td>
                    <td style="width: 80px">
                        <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="L�tfen bir soyad giriniz!" Width="144px" ControlToValidate="txtSurname"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label></td>
                    <td style="width: 80px">
                        <asp:TextBox ID="txtEMail" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="L�tfen bir Email adresi giriniz!" ControlToValidate="txtEMail" Width="185px"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="L�tfen do�ru bir Email adresi giriniz!" ControlToValidate="txtEMail" Width="223px" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label9" runat="server" Text="Rumuz"></asp:Label></td>
                    <td style="width: 80px">
                        <asp:TextBox ID="txtNickName" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="L�tfen bir rumuz giriniz!" ControlToValidate="txtNickName" Width="150px"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label3" runat="server" Text="Do�um Y�l�"></asp:Label></td>
                    <td style="width: 80px">
                        <asp:DropDownList ID="drpBirthYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpBirthYear_SelectedIndexChanged">
                        </asp:DropDownList>&nbsp;</td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label5" runat="server" Text="Do�um Tarihi"></asp:Label></td>
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
             <asp:Label ID="Label21" runat="server" Text="Ya�ad��� Yer"></asp:Label></td>
         <td style="width: 80px">
             <asp:DropDownList ID="drpCountry" runat="server" OnSelectedIndexChanged="drpCountry_SelectedIndexChanged" AutoPostBack="True">
             </asp:DropDownList>
             <asp:DropDownList ID="drpCity" runat="server">
             </asp:DropDownList></td>
         <td style="width: 100px">
         </td>
     </tr>
     <tr>
         <td style="width: 100px">
             <asp:Label ID="Label23" runat="server" Text="Mesle�i"></asp:Label></td>
         <td style="width: 80px">
             <asp:TextBox ID="txtJob" runat="server"></asp:TextBox></td>
         <td style="width: 100px">
         </td>
     </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label6" runat="server" Text="�ifre"></asp:Label></td>
                    <td style="width: 80px">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="L�tfen bir �ifre giriniz!" ControlToValidate="txtPassword" Width="137px"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label7" runat="server" Text="�ifrenizi Tekrarlay�n"></asp:Label></td>
                    <td style="width: 40px">
                        &nbsp;
                        <asp:TextBox ID="txtPasswordControl" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td style="width: 100px">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Girdi�iniz �ifreler birbiriyle ayn� de�ildir!" ControlToCompare="txtPassword" ControlToValidate="txtPasswordControl" Width="238px"></asp:CompareValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 18px;">
                        <asp:Label ID="Label8" runat="server" Text="Cinsiyetiniz"></asp:Label></td>
                    <td style="width: 80px; height: 18px;">
                        <asp:RadioButtonList ID="rblGender" runat="server">
                            <asp:ListItem Value="true">Erkek</asp:ListItem>
                            <asp:ListItem Value="false">Kad�n</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td style="width: 100px; height: 18px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 26px">
                    </td>
                    <td style="width: 80px; height: 26px">
                        <asp:Button ID="btnSubmit" runat="server" Text="G�nder" OnClick="btnSubmit_Click" /></td>
                    <td style="width: 100px; height: 26px">
                        </td>
                </tr>
            </table>
</asp:Content>

