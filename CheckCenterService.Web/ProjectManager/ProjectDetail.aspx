<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectDetail.aspx.cs" Inherits="CheckCenterService.Web.ProjectManager.ProjectDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="ContentBackColor">

                <tr>
                    <td align="right">

                        <asp:Label ID="lable1" runat="server" Text="项目名："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblProjectName" runat="server" Text="项目名："></asp:Label>
                    </td>

                </tr>

                <tr>
                    <td align="right">
                        <asp:Label ID="label2" runat="server" Text="客户名："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCustomerName" runat="server" Text="客户名："></asp:Label>

                    </td>

                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="label3" runat="server" Text="业务主任："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblBusinessName" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
                  <tr>
                    <td align="right">
                        <asp:Label ID="label7" runat="server" Text="负责人："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblResponseName" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="label5" runat="server" Text="创建人："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCreateUser" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="label1" runat="server" Text="创建时间："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCreateDate" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="label6" runat="server" Text="修改人："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblModifityUser" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="label4" runat="server" Text="修改时间："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblModifityDate" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
            </table>
        </div>
    </form>
</body>
</html>
