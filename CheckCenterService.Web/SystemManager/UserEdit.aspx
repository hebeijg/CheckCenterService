<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="CheckCenterService.Web.SystemManager.UserEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <base target="_self" />
    <script type="text/javascript">
        function CloseWin() {
            
            //window.opener.location.reload();
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1" class="ContentBackColor">
                <tr>
                    <td colspan="4" align="center">
                        <asp:Label ID="lblBasic" Font-Size="Large" runat="server" Text="------------------------基本信息------------------------"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">

                        <asp:Label ID="lblUserID" runat="server" Text="用户ID："></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
                    </td>
                    <td align="right">
                        <asp:Label
                            ID="lblUserName" runat="server" Text="用户姓名："></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
              
                <tr>
                    <td align="right">
                        <asp:Label ID="lblTle" runat="server" Text="电话："></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTle" runat="server"></asp:TextBox>
                    </td>
                    <td align="right">

                        <asp:Label ID="lblMoblie" runat="server" Text="手机："></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMoblie" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblMail" runat="server" Text="邮箱："></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
                    </td>

                </tr>

                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btnSave" runat="server" Text="保存"
                            OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="取消" OnClientClick="return window.close();"  />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
