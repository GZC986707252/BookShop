<%@ Page Title="安全管理" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="Security.aspx.cs" Inherits="Security"  Theme="MyThemes"%>

<%@ Register Src="~/UserControl/UserInfoCard.ascx" TagPrefix="uc1" TagName="UserInfoCard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layui-row layui-col-space10">
        <div class="layui-col-lg4 layui-col-lg-offset2">
            <div class="layui-tab layui-tab-brief"">
                <ul class="layui-tab-title">
                    <li class="layui-this">修改登录密码</li>
                    <li>设置支付密码</li>
                    <li>重置支付密码</li>
                </ul>
                <div class="layui-tab-content">
                    <!--修改登录密码-->
                    <div class="layui-tab-item layui-show">
                        <div class="layui-card bg-lightgreen" style="color:white;">
                            <div class="layui-card-header text-center" style="font-size: 25px;">修改登录密码</div>
                            <div class="layui-card-body">
                                <ul>
                                    <li>
                                        <div class="layui-form-item">
                                            <label class="layui-form-label">旧密码</label>
                                            <div class="layui-input-block">
                                                <asp:TextBox ID="txtOldPsd" runat="server" CssClass="layui-input" placeholder="请输入旧密码" TextMode="Password"></asp:TextBox>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="layui-form-item">
                                            <label class="layui-form-label">新密码</label>
                                            <div class="layui-input-block">
                                                <asp:TextBox ID="txtNewPsd" runat="server" CssClass="layui-input" placeholder="请输入新密码" TextMode="Password"></asp:TextBox>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="layui-form-item">
                                            <label class="layui-form-label">确认密码</label>
                                            <div class="layui-input-block">
                                                <asp:TextBox ID="txtNewPsdConfirm" runat="server" CssClass="layui-input" placeholder="再次输入新密码" TextMode="Password"></asp:TextBox>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblRevisePsdMsg" runat="server"></asp:Label>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="BtnPsdRevise" EventName="Click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div>
                            <asp:Button ID="BtnPsdRevise" runat="server" Text="立即修改" CssClass="layui-btn layui-btn-danger layui-btn-fluid" OnClick="BtnPsdRevise_Click"/>
                        </div>
                    </div>
                    <!--设置支付密码-->
                    <div class="layui-tab-item">
                         <div class="layui-card bg-lightgreen" style="color:white;">
                            <div class="layui-card-header text-center" style="font-size: 25px;">设置支付密码</div>
                            <div class="layui-card-body">
                                <ul>
                                    <li>
                                        <div class="layui-form-item">
                                            <label class="layui-form-label">支付密码</label>
                                            <div class="layui-input-block">
                                                <asp:TextBox ID="txtPayPsdInit" runat="server" CssClass="layui-input" placeholder="请设置支付密码" TextMode="Password"></asp:TextBox>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="layui-form-item">
                                            <label class="layui-form-label">确认密码</label>
                                            <div class="layui-input-block">
                                                <asp:TextBox ID="txtPayPsdInitConfirm" runat="server" CssClass="layui-input" placeholder="请确认支付密码" TextMode="Password"></asp:TextBox>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblPayPsdInitMsg" runat="server"></asp:Label>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="BtnPayPsdInit" EventName="Click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div>
                            <asp:Button ID="BtnPayPsdInit" runat="server" Text="立即设置" CssClass="layui-btn layui-btn-danger layui-btn-fluid" OnClick="BtnPayPsdInit_Click"/>
                        </div>
                    </div>
                    <!--重置支付密码-->
                    <div class="layui-tab-item">
                        <div class="layui-card bg-lightgreen" style="color:white;">
                            <div class="layui-card-header text-center" style="font-size: 25px;">重置支付密码</div>
                            <div class="layui-card-body">
                                <ul>
                                    <li>
                                        <div class="layui-form-item">
                                            <label class="layui-form-label">
                                                <asp:LinkButton ID="BtnSendVerificationCode" runat="server" BorderStyle="Outset" BackColor="White" OnClick="BtnSendVerificationCode_Click">发送验证码</asp:LinkButton>
                                            </label>
                                            <div class="layui-input-block">
                                                <asp:TextBox ID="txtVerificationCode" runat="server" CssClass="layui-input" placeholder="请输入验证码"></asp:TextBox>
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <ContentTemplate><asp:Label ID="lblVfcMsg" runat="server"></asp:Label></ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="BtnSendVerificationCode" EventName="Click"/>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="layui-form-item">
                                            <label class="layui-form-label">新支付密码</label>
                                            <div class="layui-input-block">
                                                <asp:TextBox ID="txtNewPayPsd" runat="server" CssClass="layui-input" placeholder="请输入新支付密码" TextMode="Password"></asp:TextBox>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="layui-form-item">
                                            <label class="layui-form-label">确认密码</label>
                                            <div class="layui-input-block">
                                                <asp:TextBox ID="txtNewPayPsdConfirm" runat="server" CssClass="layui-input" placeholder="再次输入密码" TextMode="Password"></asp:TextBox>
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblRevisePayPsdMsg" runat="server"></asp:Label>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="BtnPayPsdRevise" EventName="Click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div>
                            <asp:Button ID="BtnPayPsdRevise" runat="server" Text="立即修改" CssClass="layui-btn layui-btn-danger layui-btn-fluid" OnClick="BtnPayPsdRevise_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="layui-col-lg4 layui-col-lg-offset2" style="margin-top:50px;">
            <uc1:UserInfoCard runat="server" ID="UserInfoCard" />
        </div>
    </div>
</asp:Content>

