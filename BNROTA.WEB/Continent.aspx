<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="Continent.aspx.cs" Inherits="Continent" %>

<%@ Register Src="UserControls/uctFreeTextBox.ascx" TagName="uctFreeTextBox" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                        <asp:TextBox ID="txtDescription" runat="server" Rows="5" TextMode="MultiLine" Width="250px" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 101px" valign="bottom">
                        <asp:Button ID="btnUpdate" runat="server" Text="Düzenle" OnClick="btnUpdate_Click" Visible="False" /></td>
                    <td style="width: 100px" valign="bottom">
                        <asp:Label ID="Label1" runat="server" Text="Ülkeleri"></asp:Label></td>
                    <td style="width: 100px" valign="bottom">
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
                    <td style="width: 200px">
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
                    <td style="width: 100px" rowspan="1" valign="top">
                        <asp:Button ID="btnAdd" runat="server" Text="Ülke Ekle" OnClick="btnAdd_Click" Visible="False" /></td>
                    <td rowspan="1" style="width: 100px" valign="top">
                    </td>
                </tr>
            </table>

</asp:Content>

