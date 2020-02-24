<%@ Page Title="找回密码" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="GetPassword.aspx.cs" Inherits="GetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layui-card">
        <div class="layui-card-header" style="text-align: center; font-size: large;">找回密码</div>
    </div>
    <div class="layui-card">
        <div class="layui-card-body layui-form">
             <div class="layui-row">
                 <div class="layui-col-lg8 layui-col-lg-offset4">
                     <div class="layui-form-item">
                         <label class="layui-form-label">用户名</label>
                         <div class="layui-input-inline">
                             <asp:TextBox ID="txtUserName" runat="server" CssClass="layui-input" autocomplete="off" placeholder="请输入用户名"></asp:TextBox>
                         </div>
                         <div class="layui-form-mid layui-word-aux" style="color: red;">
                             <asp:RequiredFieldValidator ID="rfvtxtUserName" ControlToValidate="txtUserName" runat="server">*必填项！</asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="layui-form-item">
                         <label class="layui-form-label">邮箱</label>
                         <div class="layui-input-inline">
                             <asp:TextBox ID="txtEmail" runat="server" CssClass="layui-input" autocomplete="off" placeholder="请输入邮箱" TextMode="Email"></asp:TextBox>
                         </div>
                         <div class="layui-form-mid layui-word-aux">
                             <asp:RequiredFieldValidator ID="rfvtxtEmail" ControlToValidate="txtEmail" runat="server">*必填项！</asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="revtxtEmail" ControlToValidate="txtEmail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">邮箱格式不正确！</asp:RegularExpressionValidator>
                         </div>
                     </div>
                     <div class="layui-form-item">
                         <div style="margin-left: 110px;">
                             <asp:Button ID="BtnGetPsd" runat="server" Text="找回密码" CssClass="layui-btn" Width="190px" OnClick="BtnGetPsd_Click"/>
                         </div>
                     </div>
                     <div style="margin-left: 110px;">
                         <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                     </div>
                 </div>
             </div>
        </div>
    </div>
</asp:Content>

