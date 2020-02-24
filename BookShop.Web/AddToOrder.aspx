<%@ Page Title="提交订单" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="AddToOrder.aspx.cs" Inherits="AddToOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layui-row">
        <div class="layui-col-lg4 layui-col-lg-offset4">
            <div class="layui-card bg-lightgreen" style="color:white;">
                <div class="layui-card-header" style="font-size:large;text-align:center;color:white;">提交订单</div>
                <div class="layui-card-body">
                    <div class="layui-form-item">
                        <label class="layui-form-label">用户名</label>
                        <div class="layui-input-block">
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="layui-input" placeholder="请输入用户名"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtUserName" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ForeColor="Red">用户名不能为空！</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">寄送地址</label>
                        <div class="layui-input-block">
                            <asp:TextBox ID="txtUserAdd" runat="server" CssClass="layui-input" placeholder="请输入寄送地址"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtUserAdd" runat="server" ControlToValidate="txtUserAdd" ForeColor="Red" Display="Dynamic">地址不能为空！</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">邮政编号</label>
                        <div class="layui-input-block">
                            <asp:TextBox ID="txtZip" runat="server" CssClass="layui-input" placeholder="请输入邮政编号"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revtxtZip" runat="server" ControlToValidate="txtZip" ValidationExpression="\d{6}" Display="Dynamic" ForeColor="Red">邮政编号格式不正确！</asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label class="layui-form-label">手机号码</label>
                        <div class="layui-input-block">
                            <asp:TextBox ID="txtTel" runat="server" CssClass="layui-input" placeholder="请输入手机号码"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtTel" runat="server" ControlToValidate="txtTel" ForeColor="Red" Display="Dynamic">联系方式不能为空！</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revtxtTel" runat="server" ControlToValidate="txtTel" ForeColor="Red" Display="Dynamic" ValidationExpression="\d{11}">手机号码格式不正确！</asp:RegularExpressionValidator>
                        </div>
                    </div>
                     <div class="layui-form-item">
                        <label class="layui-form-label">支付密码</label>
                        <div class="layui-input-block">
                            <asp:TextBox ID="txtPayPsd" runat="server" CssClass="layui-input" placeholder="请输入支付密码" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtPayPsd" runat="server" ControlToValidate="txtPayPsd" ForeColor="Red" Display="Dynamic">支付密码不能为空！</asp:RequiredFieldValidator>
                            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <div style="font-size:large;">
                        共需要支付&nbsp;&nbsp;<asp:Label ID="lblTotalPrice" runat="server" Text=""></asp:Label>&nbsp;&nbsp;元&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblAmountErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </div>
            <div>
                <asp:Button ID="BtnSubmitOrder" runat="server" Text="提交订单" CssClass="layui-btn layui-btn-fluid layui-btn-danger" OnClick="BtnSubmitOrder_Click" />
            </div>
        </div>
    </div>
</asp:Content>

