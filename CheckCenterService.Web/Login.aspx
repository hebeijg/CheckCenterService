<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CheckCenterService.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>质量检测系统</title>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width:100%;height:100%; align-content:center">
        <tr>
            <td  style="align-content:center;border:1px">
                <table style="align-items:center">
                    <tr>
                        <td style="align-content:center">用户名：</td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" Text="fanruiquan"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            密码：
                        </td>
                        <td>
                             <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Text="123456"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
