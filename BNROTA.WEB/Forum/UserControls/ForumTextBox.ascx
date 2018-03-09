<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForumTextBox.ascx.cs" Inherits="Forum_UserControls_ForumTextBox" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<FTB:FreeTextBox ID="FreeTextBox1" FormatHtmlTagsToXhtml="true" ButtonFolder="button"
                            ToolbarImagesLocation="ExternalFile" JavaScriptLocation="ExternalFile" ButtonImagesLocation="ExternalFile"
                            ConvertHtmlSymbolsToHtmlCodes="False" SupportFolder="~/UserControls/FreeTextBox/"
                            DownLevelMode="TextArea" AutoParseStyles="True" ToolbarStyleConfiguration="Office2003"
                            AutoGenerateToolbarsFromString="true" ToolbarLayout="Bold, italic, Underline, ToolbarSeparator, JustifyLeft, JustifyRight,
	JustifyCenter,JustifyCenter, JustifyFull|
	BulletedList, NumberedList, Indent, Outdent|
	insertTable; insertTableRowBefore, insertTableRowAfter, 
	DeleteTableRow;insertTableColumnBefore, insertTableColumnAfter, DeleteTableColumn;
	EditTable|Cut, Copy, Paste, Delete, Undo, Redo|
	insertDiv;insertimage;
	Preview;SelectAll, EditStyle|
	FontForeColorPicker, FontBackColorPicker, FontFacesMenu, FontSizesMenu" AllowHtmlMode="True" BreakMode="LineBreak"
                            runat="Server" Width="100%" Height="330px" ImageGalleryPath="~/images/Admin/Images/ContentImages"
                            ImageGalleryUrl="UploadImage.aspx?rif={0}&amp;cif={0}" ButtonOverImage="False"
                            RenderMode="NotSet">
                        </FTB:FreeTextBox>

                        <script type="text/javascript">
                var tds = document.getElementsByTagName("img");
                for (var i = tds.length; --i >= 0;) {
                               var td = tds[i];
                               td.src = td.src.replace('ýmages','button').replace('ý','i');
                }
                        </script>