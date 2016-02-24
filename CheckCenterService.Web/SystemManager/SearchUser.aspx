<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchUser.aspx.cs" Inherits="CheckCenterService.Web.SystemManager.SearchUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查询用户</title>
    <base target="_self" />
    <script type="text/javascript">
        function CloseWin(userId) {

            window.returnValue = userId;
            window.close();
            
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>

                <tr>
                    <td>用户名：
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                    <td>部门：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDepartment" runat="server"></asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="right">
                        <asp:Button ID="btnSave" runat="server" Text="确定"  OnClick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="panelgvAuthor" runat="server" CssClass="PanelBackColor" ScrollBars="Horizontal">
                            <asp:GridView ID="gvUserList" runat="server" DataKeyNames="Userid,UserName" AutoGenerateColumns="false"
                                CssClass="GridViewStyle" EmptyDataText="暂无数据" Width="100%">
                                <FooterStyle CssClass="GridViewFooterStyle" Wrap="False" />
                                <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" ForeColor="Black" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbUserId" runat="server" ToolTip='<%# Eval("UserId") %>' /> 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UserCode" HeaderText="用户Code" HeaderStyle-Width="80px" />
                                    <asp:BoundField DataField="UserName" HeaderText="用户名" ItemStyle-Width="380px" />
                                    <asp:BoundField DataField="DepartmentCode" HeaderText="部门" ItemStyle-Width="380px" />

                                </Columns>
                            </asp:GridView>
                        </asp:Panel>

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
