<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户注册</title>
    <link rel="stylesheet" href="layui/css/layui.css" />
    <script src="layui/layui.js" type="text/javascript"></script>
    <style type="text/css">
        body{
            background-color:rgb(93,172,129);
        } 
        .rightCss{
            margin:50px auto;
            padding:25px;
            width:350px;
            border-radius:5px;
            background-color:rgba(255, 255, 255,0.7);
        }
        h2{
            line-height:50px;
           text-align:center;
        }
    </style>
</head>
<body >
    <div class="layui-container">
        <div class="layui-row">
            <a href="Default.aspx"><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo.png" Height="50px"/></a>
        </div>
        <hr class="layui-bg-gray">
        <div class="layui-row">
                  <form id="form1" runat="server" class="layui-form">
                    <div class="rightCss">
                        <ul>
                            <li><h2>用户注册</h2></li>
                            <li>
                                <div class="layui-form-item">
                                    <label class="layui-form-label layui-icon layui-icon-username">用户名</label>
                                    <div class="layui-input-block">
                                     <asp:TextBox ID="txtUserName" runat="server" CssClass="layui-input" placeholder="请输入用户名"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rvfUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="用户名不能为空！" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="layui-form-item">
                                    <label class="layui-form-label layui-icon layui-icon-password">密&nbsp;&nbsp; 码</label>
                                    <div class="layui-input-block">
                                     <asp:TextBox ID="txtPsd" runat="server" CssClass="layui-input" placeholder="请输入密码" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvPsd" runat="server" ErrorMessage="密码不能为空！" ControlToValidate="txtPsd" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="layui-form-item">
                                    <label class="layui-form-label">确认密码</label>
                                    <div class="layui-input-block">
                                     <asp:TextBox ID="PsdConfirm" runat="server" CssClass="layui-input" placeholder="请输入确认密码" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="确认密码不能为空！" ControlToValidate="PsdConfirm" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一致！" ControlToCompare="txtPsd" ControlToValidate="PsdConfirm" Display="None"></asp:CompareValidator>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="layui-form-item">
                                    <label class="layui-form-label">邮箱</label>
                                    <div class="layui-input-block">
                                     <asp:TextBox ID="TxtEmail" runat="server" CssClass="layui-input" placeholder="请输入邮箱" TextMode="Email"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtEmail" ErrorMessage="邮箱不能为空！" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="邮箱格式不正确！" ControlToValidate="TxtEmail" Display="None" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </li>
                            <li> 
                               <div class="layui-form-item">
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">立即前往登录>></asp:HyperLink>
                               </div>
                            </li>
                            <li>
                                <div class="layui-form-item">
                                    <asp:Button ID="BtnRegister" runat="server" Text="注册" CssClass="layui-btn layui-btn-fluid  layui-btn-radius" OnClick="BtnRegister_Click"/>
                                </div>
                            </li>
                             <li>
                                <div class="layui-form-item">
                                   <input type="reset" title="重置" class="layui-btn layui-btn-fluid  layui-btn-radius"/>
                                </div>
                            </li>
                             <li>
                                <div class="layui-form-item">
                                    <asp:Label ID="lblRegisterMsg" runat="server" Text="" ForeColor="Red" Font-Bold="False" Font-Size="Large"></asp:Label>
                                </div>
                            </li>
                        </ul>
                    </div>
                      <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </form>
        </div>
    </div>
</body>
</html>
