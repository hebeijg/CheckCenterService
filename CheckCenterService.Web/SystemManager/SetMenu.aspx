<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetMenu.aspx.cs" Inherits="CheckCenterService.Web.SystemManager.SetRole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        
        <table width="100%" class="ContentBackColor" >
            <tr>
             <td align="left" style="padding-left:20px; padding-top:10px" >
                    当前角色名称：<asp:Label ID="lblCurrentRoleName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            >
            <tr>
                <td style="padding-left:20px">
                    <asp:RadioButtonList ID="rbDataAuthList" runat="server" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="padding-left:20px">
                    <br />
                    功能权限
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td id="trMenuList" runat="server" style="padding-left:20px">
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-left:20px">
                    <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"  CssClass="BtnClass"  />
                   
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

