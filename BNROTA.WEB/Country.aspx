<%@ Page Language="C#" MasterPageFile="~/BinRota.master" AutoEventWireup="true" CodeFile="Country.aspx.cs" Inherits="Country" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lbName" runat="server" Text="Label"></asp:Label></td>
                <td>
                </td>
                <td style="width: 128px">
                    <asp:TextBox ID="txtDescription" runat="server" Rows="5" TextMode="MultiLine" Width="250px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 100px">
                                <asp:Image BorderColor="#eef9ff" BorderWidth="3" ID="imgCountry" runat="server" />

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
                <td style="width: 128px">
                    <asp:LinkButton ID="btnAddTravelPage" runat="server" OnClick="btnAddTravelPage_Click" ForeColor="Red">Gezi Yaz�s� Ekle</asp:LinkButton></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    &nbsp;<asp:DropDownList ID="drpRegion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpRegion_SelectedIndexChanged"
                        Visible="False">
                    </asp:DropDownList></td>
                <td style="width: 100px">
                    <asp:Button ID="btnAddRegion" runat="server" Text="B�lge Ekle" Visible="False" OnClick="btnAddRegion_Click" /></td>
                <td style="width: 85px">
                    <asp:Button ID="btnUpdateRegion" runat="server" OnClick="btnUpdateRegion_Click" Text="B�lge D�zenle"
                        Width="90px" Visible="False" /></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label11" runat="server" Text="Konum"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 128px">
                    <asp:TextBox ID="txtLocation" runat="server" Width="250px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:Button ID="btnUpdate" runat="server" Text="D�zenle" OnClick="btnUpdate_Click" Visible="False" /></td>
                <td style="width: 100px">
                    <asp:Label ID="lbHeading" runat="server" Text="�ehirleri"></asp:Label></td>
                <td style="width: 100px">
                </td>
                <td style="width: 85px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label12" runat="server" Text="Ba�kent"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 128px">
                    <asp:TextBox ID="txtCapital" runat="server" Width="250px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
                <td style="width: 200px" rowspan="9" valign="top">
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
                <td rowspan="9" style="width: 100px" valign="top">
                    <asp:Button ID="btnAddCity" runat="server" Text="�ehir Ekle" OnClick="btnAddCity_Click" Visible="False" />
                  <asp:Button ID="btnAddCityAll" runat="server" Text="Toplu �ehir Ekle" Visible="false" OnClick="btnAddCityAll_Click" /> 
                  </td>
                <td rowspan="9" style="width: 85px" valign="top">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label13" runat="server" Text="Y�z�l��m�"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 128px">
                    <asp:TextBox ID="txtArea" runat="server" Width="250px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label14" runat="server" Text="Kom�ular�"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 128px">
                    <asp:TextBox ID="txtNeighbourhood" runat="server" Width="250px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label15" runat="server" Text="N�fus"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 128px">
                    <asp:TextBox ID="txtPopulation" runat="server" Width="250px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label16" runat="server" Text="Para Birimi"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 128px">
                    <asp:TextBox ID="txtCurrency" runat="server" Width="250px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label17" runat="server" Text="Telefon Kodu"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 128px">
                    <asp:TextBox ID="txtAreaCode" runat="server" Width="250px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label18" runat="server" Text="Zaman Dilimi"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 128px">
                    <asp:TextBox ID="txtTimeZone" runat="server" Width="250px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label19" runat="server" Text="Dil"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 128px">
                    <asp:TextBox ID="txtLanguage" runat="server" Width="250px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 100px">
                    </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label20" runat="server" Text="Din"></asp:Label></td>
                <td>
                    :</td>
                <td style="width: 128px">
                    <asp:TextBox ID="txtReligion" runat="server" Width="250px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
</asp:Content>

