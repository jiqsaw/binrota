<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctrlSearchMap.ascx.cs" Inherits="UserControls_Common_uctrlSearchMap" %>

<script type="text/javascript">
    
    function ShowCountries(ContinentID) {
        document.getElementById('dvCountries' + ContinentID).style.display = 'block';
        document.getElementById('dvContinents').style.display = 'none';
    }
    
    function ShowCountriesAll() {
        document.getElementById('dvCountriesAll').style.display = 'block';
        document.getElementById('dvContinents').style.display = 'none';
        document.getElementById('dvCountries' + 82).style.display = 'none';
        document.getElementById('dvCountries' + 102).style.display = 'none';
        document.getElementById('dvCountries' + 103).style.display = 'none';
        document.getElementById('dvCountries' + 150).style.display = 'none';
        document.getElementById('dvCountries' + 151).style.display = 'none';
        document.getElementById('dvCountries' + 152).style.display = 'none';
    }
    
    function ShowContinents() {
        document.getElementById('dvContinents').style.display = 'block';
        document.getElementById('dvCountries' + 82).style.display = 'none';
        document.getElementById('dvCountries' + 102).style.display = 'none';
        document.getElementById('dvCountries' + 103).style.display = 'none';
        document.getElementById('dvCountries' + 150).style.display = 'none';
        document.getElementById('dvCountries' + 151).style.display = 'none';
        document.getElementById('dvCountries' + 152).style.display = 'none';
        document.getElementById('dvCountriesAll').style.display = 'none';
    }
 
</script>



<table width="532" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" style="height: 278px; background-color: #FFF;" id="dvArea">
                
                <div id="dvContinents">
                    <map name="FPMap0" id="FPMap0">
                        <area href="javascript:ShowCountries('150')" alt="KUZEY AMERIKA" shape="poly" coords="217, 32, 201, 51, 162, 69, 151, 88, 114, 101, 106, 116, 108, 130, 125, 134, 98, 149, 86, 150, 52, 134, 29, 105, 18, 82, 6, 70, 6, 44, 54, 31, 145, 25, 220, 26, 220, 33" />
                        <area href="javascript:ShowCountries('151')" alt="GÜNEY AMERÝKA" shape="poly" coords="94, 157, 122, 145, 147, 160, 167, 172, 183, 181, 169, 209, 157, 219, 131, 242, 123, 255, 131, 263, 124, 266, 109, 259, 116, 220, 117, 199, 101, 187, 101, 170, 98, 157" />
                        <area href="javascript:ShowCountries('103')" alt="AFRÝKA" shape="poly" coords="208, 128, 209, 152, 225, 163, 247, 160, 254, 169, 260, 185, 259, 199, 268, 228, 289, 227, 299, 207, 319, 212, 326, 190, 308, 185, 305, 177, 328, 151, 327, 146, 316, 147, 303, 141, 292, 115, 272, 111, 271, 115, 258, 109, 257, 105, 234, 106, 221, 112" />
                        <area href="javascript:ShowCountries('152')" alt="OKYANUSYA" shape="poly" coords="461, 185, 431, 207, 434, 225, 451, 229, 465, 223, 481, 235, 490, 244, 500, 218, 488, 197, 483, 188" />
                        <area href="javascript:ShowCountries('82')" alt="AVRUPA" shape="poly" coords="225, 108, 221, 98, 233, 86, 220, 78, 233, 61, 270, 47, 307, 48, 308, 67, 305, 98, 297, 109, 263, 104, 253, 96, 242, 100, 237, 102, 222, 104, 222, 99" />
                        <area href="javascript:ShowCountries('102')" alt="ASYA" shape="poly" coords="296, 115, 312, 93, 312, 50, 369, 39, 416, 34, 447, 43, 500, 45, 526, 47, 528, 71, 499, 87, 469, 112, 444, 121, 424, 142, 424, 150, 419, 152, 394, 138, 392, 132, 376, 142, 375, 156, 363, 150, 360, 134, 343, 126, 342, 137, 325, 144, 312, 140" />
                    </map>
                    <img alt="" src="Images/Content/WorldMap.jpg" width="532" height="276" usemap="#FPMap0" style="border-width: 0px;"/>
                </div>
                
                <%--Avrupa--%>
                <div id="dvCountries82" class="dvCountriesBack" style="background: #FFFFFF url('Images/BackGrounds/CountriesBack.jpg') no-repeat;">
                    <br />
                
                    <div class="dvScroll Scroll SearchMap">
                    <asp:DataList ID="dlCountries82" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">    
                                <ItemTemplate>
                                    <table cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td style="height: 22px; padding-left: 45px;">
                                                · <b><asp:HyperLink CssClass="GrayLink" ID="hplCountry" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "SubjectID", "~/CountryDetail.aspx?SubjectID={0}")%>'></asp:HyperLink></b>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>  
                    </asp:DataList>
                    </div>
                    
                    <br />
                </div>
                
                <%--Asya--%>
                <div id="dvCountries102" class="dvCountriesBack" style="background: #FFFFFF url('Images/BackGrounds/CountriesBack.jpg') no-repeat;">
                    <br />
                
                    <div class="dvScroll Scroll SearchMap">
                    <asp:DataList ID="dlCountries102" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">    
                                <ItemTemplate>
                                    <table cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td style="height: 22px; padding-left: 45px;">
                                                · <b><asp:HyperLink CssClass="GrayLink" ID="hplCountry" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "SubjectID", "~/CountryDetail.aspx?SubjectID={0}")%>'></asp:HyperLink></b>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>  
                    </asp:DataList>
                    </div>
                    
                    <br />
                </div>
                
                <%--Afrika--%>     
                <div id="dvCountries103" class="dvCountriesBack" style="background: #FFFFFF url('Images/BackGrounds/CountriesBack.jpg') no-repeat;">
                    <br />
                
                    <div class="dvScroll Scroll SearchMap">
                    <asp:DataList ID="dlCountries103" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">    
                                <ItemTemplate>
                                    <table cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td style="height: 22px; padding-left: 30px;">
                                                · <b><asp:HyperLink CssClass="GrayLink" ID="hplCountry" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "SubjectID", "~/CountryDetail.aspx?SubjectID={0}")%>'></asp:HyperLink></b>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>  
                    </asp:DataList>
                    </div>
                    
                    <br />
                </div>
                
               <%-- Kuzey Amerika--%>
                <div id="dvCountries150" class="dvCountriesBack" style="background: #FFFFFF url('Images/BackGrounds/CountriesBack.jpg') no-repeat;">
                    <br />
                
                    <div class="dvScroll Scroll SearchMap">
                    <asp:DataList ID="dlCountries150" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">    
                                <ItemTemplate>
                                    <table cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td style="height: 22px; padding-left: 10px;">
                                                · <b><asp:HyperLink CssClass="GrayLink" ID="hplCountry" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "SubjectID", "~/CountryDetail.aspx?SubjectID={0}")%>'></asp:HyperLink></b>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>  
                    </asp:DataList>
                    </div>
                    
                    <br />
                </div>
                
               <%-- Güney Amerika --%>              
                <div id="dvCountries151" class="dvCountriesBack" style="background: #FFFFFF url('Images/BackGrounds/CountriesBack.jpg') no-repeat;">
                    <br />
                
                    <div class="dvScroll Scroll SearchMap">
                    <asp:DataList ID="dlCountries151" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">    
                                <ItemTemplate>
                                    <table cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td style="height: 22px; padding-left: 55px;">
                                                · <b><asp:HyperLink CssClass="GrayLink" ID="hplCountry" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "SubjectID", "~/CountryDetail.aspx?SubjectID={0}")%>'></asp:HyperLink></b>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>  
                    </asp:DataList>
                    </div>
                    
                    <br />
                </div>
                
                <%--Okyanusya--%>
                <div id="dvCountries152" class="dvCountriesBack" style="background: #FFFFFF url('Images/BackGrounds/CountriesBack.jpg') no-repeat;">
                    <br />
                
                    <div class="dvScroll Scroll SearchMap">
                    <asp:DataList ID="dlCountries152" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">    
                                <ItemTemplate>
                                    <table cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td style="height: 22px; padding-left: 40px;">
                                                · <b><asp:HyperLink CssClass="GrayLink" ID="hplCountry" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "SubjectID", "~/CountryDetail.aspx?SubjectID={0}")%>'></asp:HyperLink></b>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>  
                    </asp:DataList>
                    </div>
                    
                    <br />
                </div>
                                
                <div id="dvCountriesAll" class="dvCountriesBack" style="background: #FFFFFF url('Images/BackGrounds/CountriesBack.jpg') no-repeat;">
                    <br />
                
                    <div class="dvScroll Scroll SearchMap">
                    <asp:DataList ID="dlCountriesAll" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">    
                                <ItemTemplate>
                                    <table cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td style="height: 22px; width: 33%; padding-left: 10px;">
                                                · <b><asp:HyperLink CssClass="GrayLink" ID="hplCountry" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "SubjectID", "~/CountryDetail.aspx?SubjectID={0}")%>'></asp:HyperLink></b>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>  
                    </asp:DataList>
                    </div>
                    
                    <br />
                </div>
            
            </td>
        </tr>
        <tr>
            <td class="RegionBottomTd Treb" align="right">
               <asp:HyperLink CssClass="Treb clBlue Czg" ID="lnbMapSearch" runat="server" Text="HAR&#304;TADAN YAZILARA ULAÞ" NavigateUrl="javascript:ShowContinents()"></asp:HyperLink>
               &nbsp;&nbsp;|&nbsp;&nbsp;
               <asp:HyperLink CssClass="Treb clBlue Czg" ID="lnbCountryList" runat="server" Text="TÜM ÜLKELER" NavigateUrl="javascript:ShowCountriesAll();"></asp:HyperLink>
            </td>
        </tr>
</table>