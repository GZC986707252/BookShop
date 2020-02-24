 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="layui/css/layui.css" />
    <script src="layui/layui.js" type="text/javascript"></script>
    <style type="text/css">
        body{
            background-color:rgb(93,172,129);
        }
        .leftCss{
            margin:50px auto;
         /*   padding:100px;*/
            text-align:center;
            color: #333333;
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
    <title>用户登录</title>
    <script>
        function LoginLoading(){
            var id = document.getElementById("loading");
            id.className += " layui-anim layui-anim-rotate layui-anim-loop";
            return true;
        }
        layui.use('form', function () {
            var form = layui.form;
        });
    </script>
</head>
<body >
    <div class="layui-container" >
        <div class="layui-row">
            <a href="Default.aspx"><asp:Image ID="Image2" runat="server"  ImageUrl="~/Images/logo.png" Height="50px"/></a>
        </div>
        <hr class="layui-bg-gray" />
        <div class="layui-row">
            <div class="layui-col-xs7">
                <div class="leftCss">
                    <div>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/01.png" Height="280px" Width="333px"/>
                    </div>
                   <h1><strong>书籍是人类进步的阶梯！</strong></h1>
                </div>
            </div>
             <div class="layui-col-xs5">
                  <form id="form1" runat="server" class="">
                    <div class="rightCss  layui-form">
                        <ul>
                            <li><h2>用户登录</h2></li>
                            <li>
                                <div class="layui-form-item">
                                    <label class="layui-form-label layui-icon layui-icon-username">用户名</label>
                                    <div class="layui-input-block">
                                     <asp:TextBox ID="txtUserName" runat="server" CssClass="layui-input" placeholder="用户名"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rvfUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="用户名不能为空！" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="layui-form-item">
                                    <label class="layui-form-label layui-icon layui-icon-password">密&nbsp;&nbsp; 码</label>
                                    <div class="layui-input-block">
                                     <asp:TextBox ID="txtPsd" runat="server" CssClass="layui-input" placeholder="密码" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvPsd" runat="server" ErrorMessage="密码不能为空！" ControlToValidate="txtPsd" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </li>
                            <li> 
                               <div class="layui-form-item">
                                   <label class="layui-form-label" style="width:130px;">
                                       <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/GetPassword.aspx">忘记密码？点这里>></asp:HyperLink>
                                   </label>
                                   <div class="layui-input-inline" style="margin-left: 80px;width:100px;">
                                       <input id="LoginType" type="checkbox" runat="server" lay-skin="switch" lay-text="后台登录|普通登录" />
                                   </div>
                               </div>
                            </li>
                            <li>
                                <div class="layui-form-item">
                                     <asp:LinkButton ID="BtnLogin" runat="server" CssClass="layui-btn layui-btn-fluid  layui-btn-radius" OnClick="BtnLogin_Click" OnClientClick="return LoginLoading();">
                                        <i id="loading" class="layui-icon layui-icon-loading"></i>登录
                                    </asp:LinkButton>
                                </div>
                            </li>
                            <li>
                                <div class="layui-form-item">
                                    <a href="Register.aspx" class="layui-btn layui-btn-fluid  layui-btn-radius">前往注册</a>
                                </div>
                            </li>
                            <li>
                                <div class="layui-form-item">
                                    <asp:Label ID="lblLoginMsg" runat="server" Text="" ForeColor="Red" Font-Bold="False" Font-Size="Large"></asp:Label>
                                </div>
                            </li>
                        </ul>
                    </div>
                      <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </form>
             </div>
        </div>
    </div>
</body>
</html>
