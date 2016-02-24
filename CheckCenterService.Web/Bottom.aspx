<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bottom.aspx.cs" Inherits="CheckCenterService.Web.Bottom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .topline {	BACKGROUND: url(images/内页页面_12.gif) repeat-x 0px -0px; font-size:12px; BORDER-LEFT: #fff 0px solid; WIDTH: auto; HEIGHT: 49px;}
    .toplineimg {BACKGROUND: url(images/内页页面_12.gif) no-repeat  0px 0px;  HEIGHT: 49px}
    BODY {	PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-TOP: 0px}
    </style>
</head>
<body  class="topline">
    <form id="form1" runat="server">
    <div align="right"  class="toplineimg">
        <asp:Label ID="lblVersion"  runat="server" Text=""></asp:Label></div>
    </form>
</body>
</html>

