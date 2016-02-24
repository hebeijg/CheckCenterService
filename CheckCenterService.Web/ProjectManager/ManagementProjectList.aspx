<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagementProjectList.aspx.cs" Inherits="CheckCenterService.Web.ProjectManager.ManagementProjectList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
   
    <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ValidateDelete() {
            return confirm("确认删除该项目吗？")
        }
    </script>
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
                            <asp:Label ID="Label1" runat="server" Text="项目名："></asp:Label>
                        </td>
                        <td style="width: 240px; padding-top: 10px; padding-bottom: 10px" align="left">
                            <asp:TextBox ID="txtProjectName" runat="server"></asp:TextBox>
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
                           <asp:Button ID="btnAdd" runat="server" Text="添加"  CssClass="BtnClass" OnClick="btnAdd_Click"  />
                       </td>
                   </tr>
                    <tr>
                        <td style="padding-left: 30px;">
                            <asp:Panel ID="panelgvAuthor" runat="server" CssClass="PanelBackColor" ScrollBars="Horizontal">
                                <asp:GridView ID="gvDepartmentList" runat="server" DataKeyNames="ProjectId" AutoGenerateColumns="false"
                                    CssClass="GridViewStyle" EmptyDataText="暂无数据" Width="100%" >
                                    <FooterStyle CssClass="GridViewFooterStyle" Wrap="False" />
                                    <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Black" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="项目名" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnEdit1" runat="server" PostBackUrl='<%# "~/ProjectManager/ProjectDetail.aspx?ProjectId="+Eval("ProjectId") %>' Text='<%#Eval("ProjectName") %>' OnClick="lbtnEdit_Click"   ></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CustomerName" HeaderText="客户名" HeaderStyle-Width="180px" />
                                        <asp:BoundField DataField="BusinessManagerName" HeaderText="业务主管" ItemStyle-Width="180px" />
                                        
                                        <asp:TemplateField HeaderText="修改" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnEdit" runat="server" ToolTip='<%#Eval("ProjectId") %>' OnClick="lbtnEdit_Click"  >修改</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="删除" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClientClick="return ValidateDelete();" OnClick="lbtnDelete_Click"  ToolTip='<%#Eval("ProjectId") %>'>删除</asp:LinkButton>
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

