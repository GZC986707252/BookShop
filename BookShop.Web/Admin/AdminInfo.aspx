<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminInfo.aspx.cs" Inherits="Admin_AdminInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layui-card">
        <div class="layui-card-header" style="text-align: center; font-size: large;">基本资料</div>
    </div>
    <div class="layui-card">
         <div class="layui-card-body layui-form">
             <div class="layui-row">
                 <div class="layui-col-lg4">
                     <asp:Image ID="HeadImg" runat="server" ImageUrl="HeadImage.aspx" BorderStyle="Solid" BorderColor="#66FF99" ImageAlign="AbsMiddle" Height="175px" Width="175px" Style="border-radius: 100px; margin: 15px 80px;" />
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
                 <div class="layui-col-lg8">
                     <div class="layui-form-item">
                         <label class="layui-form-label">管理员名</label>
                         <div class="layui-input-inline">
                             <asp:TextBox ID="txtAdminName" runat="server" CssClass="layui-input" autocomplete="off" placeholder="请输入用户名" ReadOnly="true"></asp:TextBox>
                         </div>
                         <div class="layui-form-mid layui-word-aux" style="color: red;">
                             <asp:RequiredFieldValidator ID="rfvtxtAdminName" ControlToValidate="txtAdminName" runat="server">*必填项！</asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="layui-form-item">
                         <label class="layui-form-label">邮箱</label>
                         <div class="layui-input-inline">
                             <asp:TextBox ID="txtEmail" runat="server" CssClass="layui-input" autocomplete="off" placeholder="请输入邮箱" ReadOnly="true"></asp:TextBox>
                         </div>
                         <div class="layui-form-mid layui-word-aux">
                             <asp:RequiredFieldValidator ID="rfvtxtEmail" ControlToValidate="txtEmail" runat="server">*必填项！</asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="layui-form-item">
                         <label class="layui-form-label">地址</label>
                         <div class="layui-input-inline">
                             <asp:TextBox ID="txtAddress" runat="server" CssClass="layui-input" TextMode="MultiLine" autocomplete="off" placeholder="请输入地址" ReadOnly="true"></asp:TextBox>
                         </div>
                     </div>
                     <div class="layui-form-item">
                         <label class="layui-form-label">类型</label>
                         <div class="layui-input-inline">
                             <asp:TextBox ID="txtType" runat="server" CssClass="layui-input" ReadOnly="true"></asp:TextBox>
                         </div>
                     </div>
                     <div class="layui-form-item">
                         <div style="margin-left: 110px;">
                             <asp:Button ID="BtnRevise" runat="server" Text="修改" CssClass="layui-btn" Width="190px" OnClick="BtnRevise_Click" Visible="true"/>
                             <asp:Button ID="BtnSubmint" runat="server" Text="提交" CssClass="layui-btn" Width="190px" OnClick="BtnSubmint_Click" Visible="false"/>
                         </div>
                     </div>
                 </div>
             </div>
         </div>
    </div>
</asp:Content>

