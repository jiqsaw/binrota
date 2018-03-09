<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ADMIN_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    
    <title>BÝNROTA YÖNETÝM</title>
    
    <link runat="server" href="~/ADMIN/Styles/General.css" rel="stylesheet" type="text/css" />    

</head>
<body>
    <form id="form1" runat="server">

<table width="100%" style="height: 100%;">
<tr>
    <td align="center">
    <br /><br /><br /><br />

    <div>
        <img alt="" src="Images/Logo2.jpg" />
    </div>
    
    <br />
        
    <table border="1" cellpadding="0" width="420" style="border-color: #FFF; text-align: left;">
	    <tr>
		    <td class="CellTitle" style="height: 30px">BÝNROTA ADMIN GÝRÝÞÝ</td>
	    </tr>
	    <tr>
		    <td>
		        
			    <table class="itable" cellspacing="1">

				    <tr>
					    <td class="CellLeft">Kullanýcý:</td>
					    <td class="CellRight">
					        <asp:TextBox width="200" runat="server" ID="txtUserName" CssClass="forms" ValidationGroup="Login"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                                Display="None" ErrorMessage="Lütfen Kullanýcý Adýný Giriniz" SetFocusOnError="True"
                                ValidationGroup="Login"></asp:RequiredFieldValidator></td>
				    </tr>
				    <tr>
					    <td class="CellLeft">Þifre:</td>
					    <td class="CellRight">
					        <asp:TextBox width="200" runat="server" ID="txtPassword" CssClass="forms" TextMode="Password" ValidationGroup="Login"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" SetFocusOnError="true"
                                Display="None" ErrorMessage="Lüften Þifrenizi Giriniz" ValidationGroup="Login"></asp:RequiredFieldValidator></td>
				    </tr>
				    <tr>
					    <td class="CellBottom" colspan="2" height="34">
					        <asp:Button ID="btnLogin" runat="server" CssClass="btn" Text="Giriþ" OnClick="btnLogin_Click" ValidationGroup="Login" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="Login" />
					    </td>
				    </tr>

			    </table>		
		    </td>
	    </tr>
    </table>
    <br />
    
        <table runat="server" id="tblError" bgcolor="red" width="400" cellpadding="2" cellspacing="2">
            <tr>
                <td height="27">&nbsp;&nbsp;
                    <asp:Label ID="lblError" runat="server" ForeColor="White" Font-Bold="True" Font-Names="Verdana" Font-Size="Small" Text=""></asp:Label></td>
            </tr>
        </table>
        
    </td>       
</tr>
</table>

    </form>
</body>
</html>
