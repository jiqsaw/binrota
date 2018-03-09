<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Country.aspx.cs" Inherits="Country" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BINROTA ÜLKE</title>
    
        <link type="text/css"  rel="stylesheet" href="~/Styles/Stylesheet.css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lbName" runat="server" Text="Label"></asp:Label></td>
                <td>
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    </td>
                <td style="width: 100px">
                </td>
                <td style="width: 85px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td>
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    &nbsp;<asp:DropDownList ID="drpRegion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpRegion_SelectedIndexChanged"
                        Visible="False">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Button ID="btnAddRegion" runat="server" Text="Bölge Ekle" Visible="False" OnClick="btnAddRegion_Click" /></td>
                <td style="width: 85px">
                    <asp:Button ID="btnUpdateRegion" runat="server" OnClick="btnUpdateRegion_Click" Text="Bölge Düzenle"
                        Width="90px" /></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label11" runat="server" Text="Konum"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    <asp:Label ID="lbHeading" runat="server" Text="Þehirleri"></asp:Label></td>
                <td style="width: 100px">
                </td>
                <td style="width: 85px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label12" runat="server" Text="Baþkent"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtCapital" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px" rowspan="10" valign="top">
                                        <asp:Repeater ID="rptCities" runat="server">
                            <ItemTemplate>
                                <a href='<%#DataBinder.Eval(Container.DataItem, "SubjectID", "City.aspx?SubjectID={0}")%>'>
                                    <%#DataBinder.Eval(Container.DataItem, "Name") %>
                                </a>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <br />
                            </SeparatorTemplate>
                        </asp:Repeater>
                </td>
                <td rowspan="10" style="width: 100px" valign="top">
                    <asp:Button ID="btnAddCity" runat="server" Text="Þehir Ekle" OnClick="btnAddCity_Click" Visible="False" /></td>
                <td rowspan="10" style="width: 85px" valign="top">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label13" runat="server" Text="Yüzölçümü"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtArea" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label14" runat="server" Text="Komþularý"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtNeighbourhood" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label15" runat="server" Text="Nüfus"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtPopulation" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label16" runat="server" Text="Para Birimi"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtCurrency" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label17" runat="server" Text="Telefon Kodu"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtAreaCode" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label18" runat="server" Text="Zaman Dilimi"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtTimeZone" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label19" runat="server" Text="Dil"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtLanguage" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Button ID="btnUpdate" runat="server" Text="Düzenle" OnClick="btnUpdate_Click" Visible="False" /></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label20" runat="server" Text="Din"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtReligion" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td>
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
