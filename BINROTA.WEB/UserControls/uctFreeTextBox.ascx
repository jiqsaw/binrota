<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctFreeTextBox.ascx.cs" Inherits="UserControls_uctFreeTextBox" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<FTB:FREETEXTBOX id="FreeTextBox1" FormatHtmlTagsToXhtml="true" 
    ButtonFolder="images" ToolbarImagesLocation="ExternalFile" 
    JavaScriptLocation="ExternalFile" ButtonImagesLocation="ExternalFile" 
    ConvertHtmlSymbolsToHtmlCodes="False" SupportFolder="~/UserControls/FreeTextBox/" 
    DownLevelMode="TextArea" AutoParseStyles="True" 
    ToolbarStyleConfiguration="Office2003" AutoGenerateToolbarsFromString="true" 
	ToolbarLayout="Bold, italic, Underline, ToolbarSeparator, JustifyLeft, 
	JustifyCenter, JustifyRight, JustifyFull|
	BulletedList, NumberedList, Indent, Outdent|
	insertTable; insertTableRowBefore, insertTableRowAfter, 
	DeleteTableRow;insertTableColumnBefore, insertTableColumnAfter, DeleteTableColumn;
	EditTable|Cut, Copy, Paste, Delete, Undo, Redo|
	insertDiv;insertimageFromGallery, insertimage;
	Preview;SelectAll, EditStyle|
	FontForeColorPicker, FontBackColorPicker, FontFacesMenu, FontSizesMenu"
	AllowHtmlMode="True" BreakMode="LineBreak" runat="Server" Width="100%" 
	Height="250px" ImageGalleryPath="~/images/Admin/Images/ContentImages" 
	ImageGalleryUrl="ImageGallery.aspx?rif={0}&amp;cif={0}" 
	ButtonOverImage="False" RenderMode="NotSet">
</FTB:FREETEXTBOX>