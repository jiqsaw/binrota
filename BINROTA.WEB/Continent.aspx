<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Continent.aspx.cs" Inherits="Continent" %>

<%@ Register Src="UserControls/uctFreeTextBox.ascx" TagName="uctFreeTextBox" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BINROTA KITA</title>
    
        <link type="text/css"  rel="stylesheet" href="~/Styles/Stylesheet.css" />
        
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="lbName" runat="server"></asp:Label></td>
                    <td>
                    </td>
                    <td style="width: 128px">
                    </td>
                    <td style="width: 101px">
                    </td>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                    </td>
                    <td>
                        </td>
                    <td style="width: 128px">
                        </td>
                    <td style="width: 101px">
                        </td>
                    <td style="width: 100px"></td>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label2" runat="server" Text="Açýklama"></asp:Label></td>
                    <td>
                        :</td>
                    <td style="width: 128px">
                        <asp:Label ID="lbDescription" runat="server" Text="Label"></asp:Label></td>
                    <td style="width: 101px">
                        </td>
                    <td style="width: 100px">
                        </td>
                    <td style="width: 100px">
                        <asp:Label ID="Label1" runat="server" Text="Ülkeleri"></asp:Label></td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label3" runat="server" Text="Resim Yeri"></asp:Label></td>
                    <td>
                        :</td>
                    <td style="width: 128px">
                        <asp:Label ID="lbPhotoPath" runat="server" Text="Label"></asp:Label></td>
                    <td style="width: 101px">
                        <asp:Button ID="btnUpdate" runat="server" Text="Düzenle" OnClick="btnUpdate_Click" Visible="False" /></td>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px" rowspan="5" valign="top">
                    <asp:Repeater ID="rptCountries" runat="server">
                            <ItemTemplate>
                                <a href='<%#DataBinder.Eval(Container.DataItem, "SubjectID", "Country.aspx?SubjectID={0}")%>'>
                                    <%#DataBinder.Eval(Container.DataItem, "Name") %>
                                </a>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <br />
                            </SeparatorTemplate>
                        </asp:Repeater>
                    </td>
                    <td rowspan="5" style="width: 100px" valign="top">
                    <asp:Button ID="btnAdd" runat="server" Text="Ülke Ekle" OnClick="btnAdd_Click" Visible="False" /></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                    </td>
                    <td>
                    </td>
                    <td style="width: 128px">
                    </td>
                    <td style="width: 101px">
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                    </td>
                    <td>
                    </td>
                    <td style="width: 128px">
                    </td>
                    <td style="width: 101px">
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                    </td>
                    <td>
                    </td>
                    <td style="width: 128px">
                    </td>
                    <td style="width: 101px">
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                    </td>
                    <td>
                    </td>
                    <td style="width: 128px">
                    </td>
                    <td style="width: 101px">
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
