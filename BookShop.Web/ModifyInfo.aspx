<%@ Page Title="修改信息" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="ModifyInfo.aspx.cs" Inherits="ModifyInfo" Theme="MyThemes"%>

<%@ Register Src="~/UserControl/UserInfoCard.ascx" TagPrefix="uc1" TagName="UserInfoCard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="layui-row layui-col-space10">
        <div class="layui-col-lg4">
            <asp:Image ID="HeadImg" runat="server" ImageUrl="HeadImage.aspx" BorderStyle="Solid" BorderColor="#66FF99" ImageAlign="AbsMiddle" Height="200px" Width="200px" style="border-radius: 100px;margin: 15px 80px;"/>
            <div class="layui-form-item" style="margin-left: 35px;">
                <label class="layui-form-label">
                    <asp:LinkButton ID="BtnUploadImg" runat="server" OnClick="BtnUploadImg_Click" CssClass="layui-btn">上传头像</asp:LinkButton>
                </label>
                <div class="layui-input-inline" style="margin-top: 15px;">
                    <asp:FileUpload ID="HeadImgUpload" runat="server" Width="180px" />
                </div>
            </div>
            <div class="layui-form-item">
                <label style="margin-left: 15px;">
                    <asp:Label ID="lblUploadMsg" runat="server" ForeColor="Red" Font-Size="Large"></asp:Label>
                </label>
            </div>
        </div>
        <div class="layui-col-lg4">
            <!--修改信息-->
            <div class="layui-card bg-lightgreen" style="color:white;">
                <div class="layui-card-header text-center" style="font-size: 25px;">修改信息</div>
                <div class="layui-card-body">
                    <ul>
                        <li>
                            <div class="layui-form-item">
                                <label class="layui-form-label">用户名</label>
                                <div class="layui-input-block">
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="layui-input" Text=""></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxtUserName" runat="server" ControlToValidate="txtUserName" SetFocusOnError="True" Display="Dynamic">用户名不能为空！</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="layui-form-item">
                                <label class="layui-form-label">电子邮箱</label>
                                <div class="layui-input-block">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="layui-input" TextMode="Email"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" ControlToValidate="txtEmail" SetFocusOnError="True" Display="Dynamic">邮箱不能为空！</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revtxtEmail" runat="server" ControlToValidate="txtEmail" SetFocusOnError="True" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">邮箱格式不正确！</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </li>
                        <li>
                            <div class="layui-form-item">
                                <label class="layui-form-label">收货地址</label>
                                <div class="layui-input-block">
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="layui-input" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </li>
                        <li>
                            <asp:Label ID="lblModifyInfoMsg" runat="server" ForeColor="Red" Font-Size="Large"></asp:Label>
                        </li>
                    </ul>
                </div>
            </div>
            <div>
                <asp:Button ID="BtnModifyInfo" runat="server" Text="修改" CssClass="layui-btn layui-btn-danger layui-btn-fluid" OnClick="BtnModifyInfo_Click"/>
            </div>
            <label style="color:red;">注：修改登录密码和支付密码请前往安全管理进行操作！</label>
        </div>
        <div class="layui-col-lg4">
            <uc1:UserInfoCard runat="server" ID="UserInfoCard" />
        </div>
    </div>
</asp:Content>

