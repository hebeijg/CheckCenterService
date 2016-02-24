<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectSetResponse.aspx.cs" Inherits="CheckCenterService.Web.ProjectManager.ProjectSetResponse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        function findUser() {
            var winFeatures = "dialogHeight:350px;dialogWeight:200px;";
            var returnvalue = window.showModalDialog("../SystemManager/SearchUser.aspx", form1, winFeatures);
            if (returnvalue != undefined) {
                var userId = 0;
                var userName = "";

                var userMessage = returnvalue.split('-');
                if (userMessage.length == 2) {
                    var lblBussiness = document.getElementById("<%=lblResponseName.ClientID %>")

                   if (lblBussiness != null) {

                       lblBussiness.innerText = userMessage[1];
                   }

                   var hidUserId = document.getElementById("<%=hidUserId.ClientID %>")

                   if (hidUserId) {
                       hidUserId.value = userMessage[0];
                   }
               }

           }


       }

    </script>

</head>
<body>
    <form id="form1" runat="server">
         <asp:HiddenField ID="hidUserId" runat="server" />
        <div>
            <table class="ContentBackColor">

                <tr>
                    <td align="right">

                        <asp:Label ID="lable1" runat="server" Text="项目名："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblProjectName" runat="server" Text=""></asp:Label>
                    </td>

                </tr>

                <tr>
                    <td align="right">
                        <asp:Label ID="label2" runat="server" Text="客户名："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCustomerName" runat="server" Text=""></asp:Label>

                    </td>

                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="label5" runat="server" Text="经营主任："></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCreateUser" runat="server" Text=""></asp:Label>
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
                     <td >
                        <asp:Button ID="Button1" runat="server" Text="...." OnClientClick="findUser();return false;" /></td>
                </tr>

                  <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btnSave" runat="server" Text="保存"
                            OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
