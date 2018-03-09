<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Zoom.aspx.cs" Inherits="Zoom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
    <head>
    <title>Loading...</title>

<script type="text/javascript">

var isNN,isIE;

if (parseInt(navigator.appVersion.charAt(0))>=4){
	isNN=(navigator.appName=="Netscape")?1:0;
	isIE=(navigator.appName.indexOf("Microsoft")!=-1)?1:0;
}

function reSizeToImage(){

	var Wd = document.images["imgId"].width;
	var Hg = document.images["imgId"].height;

    if (Wd > 1000) { Wd = 1000; }
    if (Hg > 660) { Hg = 660; }

	if (isIE!=""){
		window.resizeTo(Wd + 29, Hg + 38);
	}
	
	if (isNN){
	    window.innerWidth = Wd;
	    window.innerHeight = Hg;
	}
}

function SetTitle(){
	document.title="BINROTA";
}

</script>

<style>
body {
	margin: 0px;
}
</style>

</head>

<body onload="reSizeToImage();SetTitle();self.focus()">

    <% string FileName = Request.QueryString["Image"].ToString(); %>

    <img name="imgId" src="Images/<%=FileName%>" style="display:block; cursor: pointer;" onclick="self.close()">

</body>

</html>
