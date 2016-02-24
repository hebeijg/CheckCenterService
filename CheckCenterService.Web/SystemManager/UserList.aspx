<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="CheckCenterService.Web.SystemManager.UserList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        function AddUser(userId)
        {
            var departmentId = <%=DepartmentId %>;

            var winFeatures = "dialogHeight:350px;dialogWeight:200px;";
            window.showModalDialog("UserEdit.aspx?department=" + departmentId + "&UserId="+userId, form1, winFeatures);
        }

        function ValidateDelete()
        {
            return confirm("确认删除该用户吗？")
        }
    </script>
    <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <script type="text/javascript">
          

        </script>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                
                <table width="100%" class="ContentBackColor" id="tabSave" runat="server">
                    <tr>
                        <td style="width: 110px; padding-top: 10px; padding-bottom: 10px" align="right">
                            <asp:Label ID="Label1" runat="server" Text="用户名："></asp:Label>
                        </td>
                        <td style="width: 240px; padding-top: 10px; padding-bottom: 10px" align="left">
                            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        </td>
                        <td align="left" style="padding-top: 10px; padding-bottom: 10px">
                            <asp:Button ID="btnSearch" runat="server"  CssClass="BtnClass"
                                Text="查询" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
                <table width="100%" class="ContentBackColor">
                   <tr>
                       <td align="right">
                           <asp:Button ID="btnAdd" runat="server" Text="添加"  CssClass="BtnClass" OnClientClick=" AddUser(0);return false;"  />
                       </td>
                   </tr>
                    <tr>
                        <td style="padding-left: 30px;">
                            <asp:Panel ID="panelgvAuthor" runat="server" CssClass="PanelBackColor" ScrollBars="Horizontal">
                                <asp:GridView ID="gvUserList" runat="server" DataKeyNames="UserId" AutoGenerateColumns="false"
                                    CssClass="GridViewStyle" EmptyDataText="暂无数据" Width="100%" >
                                    <FooterStyle CssClass="GridViewFooterStyle" Wrap="False" />
                                    <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Black" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="UserCode" HeaderText="UserCode" HeaderStyle-Width="50px" />
                                        <asp:BoundField DataField="UserName" HeaderText="用户名" HeaderStyle-Width="80px" />
                                        <asp:BoundField DataField="DepartmentName" HeaderText="部门" ItemStyle-Width="380px" />
                                         <asp:BoundField DataField="MobilePhone" HeaderText="电话" ItemStyle-Width="380px" />
                                         <asp:BoundField DataField="EMail" HeaderText="邮箱" ItemStyle-Width="380px" />
                                         <asp:BoundField DataField="CreatedDate" HeaderText="创建时间" ItemStyle-Width="380px" />
                                        <asp:TemplateField HeaderText="修改" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnEdit" runat="server"  OnClientClick='<%#"AddUser("+Eval("UserId")+");return false;" %>'  >修改</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="删除" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClientClick="return ValidateDelete();" OnClick="lbtnDelete_Click"  ToolTip='<%#Eval("UserId") %>'>删除</asp:LinkButton>
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

