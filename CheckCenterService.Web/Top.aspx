<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="CheckCenterService.Web.Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #wrap
        {
            margin: 0 auto;
            text-align: left;
        }
        
        .wrap_l
        {
            float: left;
            height: 50px;
            margin-right: 0px;
            width: 486px;
            border: 0px solid #333;
        }
        
        .wrap_m
        {
            width: auto;
            background-image: url(images/内页页面_02.gif);
            margin: 0 486px 0 0px;
            border: 0px solid #000;
            height: 73px;
        }
        
        .wrap_r
        {
            float: right;
            background-image: url(images/内页页面_03.gif);
            
             margin-top:-73px;
            top:0;
            width: 486px;
            border: 0px solid #999;
            height: 73px;
            
        }
    </style>
</head>
<body style="height: 100%; width: 100%; margin-left: 0px; margin-top: 0px;">
    <form id="form1" runat="server">
    <div id="wrap">
        <div class="wrap_l">
            
        </div>
        <div class="wrap_m">
        </div>
        <div class="wrap_r">
            <table  style="height:100%">
                <tr style="font-weight: 500;">
                    <td align="right" valign="bottom" width="286px" style="color: #0F7081; font-size: 11pt; color: White; font-weight: 700; padding-bottom:10px ">
                        欢迎：<asp:Label ID="lblCurrentUser" runat="server" Text=""></asp:Label>
                    </td>
                    <td  runat="server" id="tdVisable" align="right" style="vertical-align:bottom; font-size: 9pt; font-weight: 500; width:100px; padding-bottom:10px ">
                       
                       
                        <table>
                            <tr>
                                <td>
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Logout.png"  />
                                </td>
                                <td>
                                  <asp:LinkButton ID="lbtnLogOut" OnClientClick="" runat="server" ForeColor="Black" OnClick="lbtnLogOut_Click">退出</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                         
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
