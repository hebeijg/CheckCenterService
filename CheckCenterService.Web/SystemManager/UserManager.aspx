<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManager.aspx.cs" Inherits="CheckCenterService.Web.SystemManager.UserManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.ztree.all-3.4.min.js" type="text/javascript"></script>
    <style type="text/css">
        .ztree li span.button.switch.level0
        {
            visibility: hidden;
            width: 1px;
        }
        .ztree li ul.level0
        {
            padding: 0;
            background: none;
        }
    </style>
    <script type="text/javascript">
          var t = '<%=Session["token"] %>';
        var setting = {	
            data: { simpleData: { enable: true } } , 
            edit: {
                enable: true,
                showRemoveBtn: false,
                showRenameBtn: false, 
                drag: {
                    isCopy : false,
                    isMove : true,
                    prev :true,
                    inner :true,
                    next :true
                } 
            }, 
            callback: { onDrop: teamEdit,onClick: zTreeOnClick}
        };
        var zNodes = <%=TreeJsonStr %>;
        var tree;
        $(document).ready(function () {
            tree = $.fn.zTree.init($("#treeTeam"), setting, zNodes);
            tree.expandAll(true);
            $("a[expandAll]").bind("click", function() {
                tree.expandAll($(this).attr("expandAll") === "true");
            }); 
            document.getElementById("iframe").src="UserList.aspx?token="+t+"&t="+Math.random();
        });
      
        function zTreeOnClick(event, treeId, treeNode) {
          
            var dept=treeNode.id;
            if(dept=="所有部门"){dept="";}
      
            document.getElementById("iframe").src="UserList.aspx?token="+t+"&department="+encodeURI(dept)+"&t="+Math.random();
        };
        function teamEdit(event, treeId, treeNodes, targetNode, moveType) { 
            if (targetNode == null) {
                alert("系统中只能存在一个根节点");
                location.reload();
                return;
            } 
            var selteam = [];  
            for (var i = 0; i < treeNodes.length; i++) {
                selteam.push(treeNodes[i].id); 
                if (targetNode.id != treeNodes[i].pId) {
                    alert("拖动失败，刷新页面");
                    location.reload();
                    return;
                }
            }
            tree.setting.edit.enable = false;
            $.post("/SystemManager/TeamManage.aspx",
                {
                    pid:targetNode.id, 
                    ids:selteam.join(','),
                    token:t
                },  function(data) {
                if (data == "200") {
                    tree.setting.edit.enable = true;
                } else { 
                    alert("出错了，刷新页面");
                    location.reload();
                }
            });
        } 
    //-->
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="400px" align="center" class="ContentBackColor">
            <tr>
                <td valign="top" style="width: 12%; margin-top: 0px">
                    [ <a expandall="true" href="#" title="展开全部节点" onclick="return false;">展开</a> ] &nbsp;&nbsp;[
                    <a expandall="false" href="#" title="折叠全部节点！" onclick="return false;">折叠</a> ]
                    <ul id="treeTeam" class="ztree">
                    </ul>
                </td>
                <td valign="top" style="margin-top: 0px; " >
                    <table id="departmentTab" runat="server" border="1" width="600px">
                       
                        <tr id="UserTd" valign="top">
                            <td colspan="5"  valign="top" >
                                <iframe width="100%" height="410px" id="iframe" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
