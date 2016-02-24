<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetUser.aspx.cs" Inherits="CheckCenterService.Web.SystemManager.SetUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function CheckAllSelect(spanChk, gridViewFlag) {

            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id && elm[i].id.indexOf(gridViewFlag) > -1) {
                    if (elm[i].checked != xState)
                        elm[i].click();
                }
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 152px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                
                <table width="100%" class="ContentBackColor">
                    <tr>
                        <td align="left" style="padding-left: 20px; padding-top: 10px; padding-bottom: 10px">
                            当前角色名称：
                            <asp:Label ID="lblCurrentRoleName" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" style="padding-left: 20px; padding-top: 10px; padding-bottom: 10px">
                            <asp:Button ID="btnSaveTop" runat="server" Text="保存" CssClass="BtnClass" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancelTop" runat="server" Text="返回" CssClass="BtnClass" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
                <table width="100%" class="ContentBackColor">
                    <tr>
                        <td>
                            已存在用户列表
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 20px; padding-bottom: 10px">
                            <asp:Panel ID="panelgvAuthor" runat="server" CssClass="PanelBackColor" ScrollBars="Horizontal">
                                <asp:GridView ID="gvExistsUserList" runat="server" DataKeyNames="UserID" AutoGenerateColumns="false"
                                    AllowSorting="true"  EmptyDataText="暂无数据"
                                    CssClass="GridViewStyle" Width="100%" >
                                    <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Black" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="20px" HeaderStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <input id="chkAllSelect" type="checkbox" onclick="CheckAllSelect(this,'gvExistsUserList')" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbSelectUser" Checked="true" runat="server" ToolTip='<%#Eval("UserID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="UserID" HeaderText="ID" HeaderStyle-Width="50px" />
                                        <asp:BoundField DataField="UserCode" HeaderText="用户名" HeaderStyle-Width="150px" SortExpression="UserID" />
                                        <asp:BoundField DataField="UserName" HeaderText="员工姓名" HeaderStyle-Width="200px"
                                            SortExpression="UserName" />
                                        <asp:TemplateField HeaderText="部门名称" HeaderStyle-Width="80px" AccessibleHeaderText="DepartmentCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeptName" runat="server" Text='<%#GetTeamByName( Eval("DepartmentCode"))%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table width="100%" class="ContentBackColor">
                    <tr>
                        <td width="120px" align="right" style="padding-top: 10px; padding-bottom: 5px">
                            <asp:Label ID="Label1" runat="server" Text="账号或者名称："></asp:Label>
                        </td>
                        <td width="100px" align="left" style="padding-top: 10px; padding-bottom: 5px">
                            <asp:TextBox ID="txtUserIdOrName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" style="padding-top: 10px; padding-bottom: 5px" class="style1">
                            <asp:Label ID="Label2" runat="server" Text="部门名称："></asp:Label>
                        </td>
                        <td width="100px" align="right" style="padding-top: 10px; padding-bottom: 5px">
                            <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox>
                        </td>
                        <td align="left" width="100px" style="padding-top: 10px; padding-bottom: 5px">
                            <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" CssClass="BtnClass" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <table width="100%" class="ContentBackColor">
                    <tr>
                        <td>
                            待添加用户列表
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-left: 20px">
                            <asp:Panel ID="panel1" runat="server" CssClass="PanelBackColor">
                                <asp:GridView ID="gvNotExistsUserList" runat="server" DataKeyNames="UserId" AutoGenerateColumns="False"
                                    CssClass="GridViewStyle" AllowSorting="True" 
                                    PageSize="20" EmptyDataText="暂无数据" Width="100%" 
                                   >
                                    <FooterStyle CssClass="GridViewFooterStyle" Wrap="False" />
                                    <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Black" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="20px" HeaderStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <input id="chkAllSelect" type="checkbox" onclick="CheckAllSelect(this,'gvNotExistsUserList')" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbSelectUser" runat="server" ToolTip='<%#Eval("UserId") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="UserID" HeaderText="Id" HeaderStyle-Width="50px" >
                                        <HeaderStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UserCode" HeaderText="用户名" HeaderStyle-Width="150px" 
                                            SortExpression="UserCode" >
                                        <HeaderStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UserName" HeaderText="员工姓名" HeaderStyle-Width="200px"
                                            SortExpression="UserName" >
                                        <HeaderStyle Width="200px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="部门名称" SortExpression="DepartmentCode" 
                                            AccessibleHeaderText="DepartmentCode">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%#GetTeamByName(Eval("DepartmentCode")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnSaveBelow" runat="server" Text="保存" CssClass="BtnClass" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancelBelow" runat="server" Text="返回" CssClass="BtnClass" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>

