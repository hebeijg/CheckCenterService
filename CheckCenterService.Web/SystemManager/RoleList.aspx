<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="CheckCenterService.Web.SystemManager.RoleList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <script type="text/javascript">
            function CheckRoleName() {

                var txtRoleName = document.getElementById("<%=txtRoleName.ClientID %>");

                if (txtRoleName.value == "") {
                    alert("请输入角色名称");
                    return false;
                }
                else {
                    return true;
                }
            }

            function ValidateDelete(obj) {
                if (obj.title == "1") {
                    return confirm("该角色下有关联用户，确认删除该角色吗？");
                }
                else {
                    return confirm("确实删除该角色吗？");
                }

            }
        </script>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                
                <table width="100%" class="ContentBackColor" id="tabSave" runat="server">
                    <tr>
                        <td style="width: 110px; padding-top: 10px; padding-bottom: 10px" align="right">
                            <asp:Label ID="Label1" runat="server" Text="角色名称："></asp:Label>
                        </td>
                        <td style="width: 240px; padding-top: 10px; padding-bottom: 10px" align="left">
                            <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
                        </td>
                        <td align="left" style="padding-top: 10px; padding-bottom: 10px">
                            <asp:Button ID="btnSave" runat="server" OnClientClick="return CheckRoleName() " CssClass="BtnClass"
                                Text="保存" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
                <table width="100%" class="ContentBackColor">
                   
                    <tr>
                        <td style="padding-left: 30px;">
                            <asp:Panel ID="panelgvAuthor" runat="server" CssClass="PanelBackColor" ScrollBars="Horizontal">
                                <asp:GridView ID="gvRoleList" runat="server" DataKeyNames="RoleId" AutoGenerateColumns="false"
                                    CssClass="GridViewStyle" EmptyDataText="暂无数据" Width="100%" OnRowDataBound="gvRoleList_RowDataBound">
                                    <FooterStyle CssClass="GridViewFooterStyle" Wrap="False" />
                                    <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Black" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="RoleId" HeaderText="RoleId" HeaderStyle-Width="50px" />
                                        <asp:BoundField DataField="RoleName" HeaderText="角色名称" HeaderStyle-Width="80px" />
                                        <asp:BoundField DataField="RoleName" HeaderText="用户" ItemStyle-Width="380px" />
                                        <asp:TemplateField HeaderText="修改" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" ToolTip='<%#Eval("RoleId") %>'>修改</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="删除" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" OnClientClick=' return ValidateDelete(this)  '>删除</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="设置权限" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hlSetRole" runat="server" NavigateUrl='<%# "~/SystemManager/SetMenu.aspx?token="+Session["token"]+"&Id="+Eval("RoleId") %>'>设置权限</asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="设置用户" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hlSetUser" runat="server" NavigateUrl='<%# "~/SystemManager/SetUser.aspx?token="+Session["token"]+"&Id="+Eval("RoleId") %>'>设置用户</asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>

