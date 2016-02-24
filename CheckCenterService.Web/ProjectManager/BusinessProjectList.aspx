<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessProjectList.aspx.cs" Inherits="CheckCenterService.Web.ProjectManager.BusinessProjectList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
                                <asp:Button ID="btnSearch" runat="server" CssClass="BtnClass"
                                    Text="查询" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%" class="ContentBackColor">

                        <tr>
                            <td style="padding-left: 30px;">
                                <asp:Panel ID="panelgvAuthor" runat="server" CssClass="PanelBackColor" ScrollBars="Horizontal">
                                    <asp:GridView ID="gvDepartmentList" runat="server" DataKeyNames="ProjectId" AutoGenerateColumns="false"
                                        CssClass="GridViewStyle" EmptyDataText="暂无数据" Width="100%">
                                        <FooterStyle CssClass="GridViewFooterStyle" Wrap="False" />
                                        <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" ForeColor="Black" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="项目名" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnEdit1" runat="server" PostBackUrl='<%# "~/ProjectManager/ProjectDetail.aspx?ProjectId="+Eval("ProjectId") %>' Text='<%#Eval("ProjectName") %>' OnClick="lbtnEdit_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ManagermentName" HeaderText="经营主任" ItemStyle-Width="180px" />
                                            <asp:BoundField DataField="CustomerName" HeaderText="客户名" HeaderStyle-Width="180px" />
                                            <asp:BoundField DataField="ResponseName" HeaderText="负责人" ItemStyle-Width="180px" />

                                            <asp:TemplateField HeaderText="设置" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnEdit" runat="server" ToolTip='<%#Eval("ProjectId") %>' OnClick="lbtnEdit_Click">设置</asp:LinkButton>
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
