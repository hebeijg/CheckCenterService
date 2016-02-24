<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeftMenu.aspx.cs" Inherits="CheckCenterService.Web.LeftMenu" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script type="text/javascript">
    

    
    </script>

    <style type="text/css">
        .MainClass {
            background-image: url('images/正常.png');
            background-repeat: no-repeat;
            text-align: center;
            height: 27px;
            line-height: 27px;
            color: White;
            font-size: 13px;
        }

        .CurrentMainClass {
            background-image: url('images/点击.png');
            background-repeat: no-repeat;
            text-align: center;
            height: 27px;
            line-height: 27px;
            color: White;
            font-size: 13px;
        }

        .ClickSubMenu {
            color: White;
            background-color: #b6d4d2;
        }

        .SubClass {
            line-height: 30px;
            display: none;
            margin-left: 0px;
            font-size: 13px;
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#c9e1df', endColorstr='#ffffff'); /* IE6,IE7 */
            -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr='#c9e1df', endColorstr='#ffffff')"; /* IE8 */
        }

        a {
            text-decoration: none;
            color: Black;
        }

        html, body {
            margin: 0px;
            height: 100%;
        }
    </style>
    <script type="text/javascript">

        var currentExpendMenuId = -1;

        function Show(menuId) {

            var subMenu = document.getElementById("subMenu" + menuId);
            var mainMenu = document.getElementById("mainMenu" + menuId);
            var divCount = GetMainMenuCount();
            if (subMenu.style.display == "block") {
                subMenu.style.display = "none";

                mainMenu.className = "MainClass";
                SetMainMenuTopOnCos(menuId, divCount, mainMenu);
            }
            else {
                subMenu.style.display = "block";

                mainMenu.className = "CurrentMainClass";

                //subMenu.style.height = window.document.body.clientHeight - (menuId + 1) * 27;
                subMenu.style.height = window.document.body.clientHeight - divCount * 27;
                SetMainMenuTopOnExp(menuId, divCount, subMenu);

            }


            if (currentExpendMenuId != -1 && currentExpendMenuId != menuId) {
                var currentExpend = document.getElementById("subMenu" + currentExpendMenuId);
                var currentExpendMain = document.getElementById("mainMenu" + currentExpendMenuId);
                currentExpend.style.display = "none";
                currentExpendMain.className = "MainClass";
            }

            currentExpendMenuId = menuId;


        }

        function SetMainMenuTopOnCos(menuId, divCount, currentMainMenu) {
            for (var i = menuId + 1; i < divCount; i++) {
                var nextMainMenu = document.getElementById("mainMenu" + i);
                nextMainMenu.style.top = currentMainMenu.style.top + currentMainMenu.style.height;
            }
        }

        function SetMainMenuTopOnExp(menuId, divCount, subMenu) {
            if (currentExpendMenuId == -1 || currentExpendMenuId > menuId || currentExpendMenuId == menuId) {
                for (var i = menuId + 1; i < divCount; i++) {
                    var nextMainMenu = document.getElementById("mainMenu" + i);
                    nextMainMenu.style.top = subMenu.style.top + subMenu.style.height;
                }
            }
            else {
                for (var i = currentExpendMenuId + 1; i <= menuId; i++) {
                    var nextMainMenu = document.getElementById("mainMenu" + i);
                    nextMainMenu.style.top = ""
                }

                for (var i = menuId + 1; i < divCount; i++) {
                    var nextMainMenu = document.getElementById("mainMenu" + i);
                    nextMainMenu.style.top = subMenu.style.top + subMenu.style.height;
                }
            }
        }

        function GetMainMenuCount() {
            var result = 0;

            var arrDiv = $("div");
            for (var i = 0; i < arrDiv.length; i++) {
                if (arrDiv[i].id.substr(0, 8) == "mainMenu") {
                    result += 1;
                }
            }
            return result;
        }

        var previewDiv;
        var previewImg;
        var previewLink;
     
    </script>
    <base target='mainFrame' />
</head>
<body style="height: 100%; margin-left: 0px; margin-top: 0px; margin-bottom: 0px">
    <form id="form1" runat="server">

        <table style="width: 200px; background-repeat: no-repeat; height: 100%; vertical-align: top; background-image: url('images/内页页面_05.gif'); line-height: 20px">
            <tr>
                <td style="vertical-align: top; height: 100%">
                    <% =MenuUrl%>
                </td>
            </tr>
        </table>
    </form>
    <script type="text/javascript">
        Show(0);
    </script>
</body>
</html>
