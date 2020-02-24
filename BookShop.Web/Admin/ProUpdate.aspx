<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ProUpdate.aspx.cs" Inherits="Admin_ProUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="layui-card">
        <div class="layui-card-header" style="text-align: center; font-size: large;">编辑商品</div>
   </div>
   <div class="layui-card">
         <div class="layui-card-body layui-form">
            <div class="layui-row">
                <div class="layui-col-lg4">
                    <asp:Image ID="bookImg" runat="server" ImageUrl="~/Images/null.png" Width="300px" style="margin:20px 30px;" BorderColor="#0066FF" BorderStyle="Solid"/>
                    <div class="layui-form-item">
                         <label class="layui-form-label">
                             <asp:LinkButton ID="BtnUploadImg" runat="server" OnClick="BtnUploadImg_Click" CssClass="layui-btn">上传图片</asp:LinkButton>
                         </label>
                         <div class="layui-input-inline" style="margin-top: 15px;">
                             <asp:FileUpload ID="BookImgUpload" runat="server" Width="180px" />
                         </div>
                     </div>
                     <div class="layui-form-item">
                         <label style="margin-left:15px;">
                             <asp:Label ID="lblUploadMsg" runat="server" ForeColor="Red" Font-Size="Large"></asp:Label>
                         </label>
                    </div>
                </div>
                 <div class="layui-col-lg8">
                     <div class="layui-form-item">
                         <label class="layui-form-label">书籍分类</label>
                         <div class="layui-input-inline">
                             <asp:DropDownList ID="ddlCategoryId" runat="server" DataSourceID="LinqDataSource1" DataTextField="CategoryName" DataValueField="CategoryId"></asp:DropDownList>
                         </div>
                         <div class="layui-form-mid layui-word-aux">
                             <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="BookShop.DAL.BookShopDataContext" EntityTypeName="" TableName="Category"></asp:LinqDataSource>
                         </div>
                     </div>
                     <div class="layui-form-item">
                         <label class="layui-form-label">书籍名称</label>
                         <div class="layui-input-inline">
                             <asp:TextBox ID="txtBookName" runat="server" CssClass="layui-input" autocomplete="off"></asp:TextBox>
                         </div>
                         <div class="layui-form-mid layui-word-aux" style="color: red;">
                             <asp:RequiredFieldValidator ID="rfvtxtBookName" ControlToValidate="txtBookName" runat="server">*必填项！</asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="layui-form-item">
                         <label class="layui-form-label">ISBN</label>
                         <div class="layui-input-inline">
                             <asp:TextBox ID="txtISBN" runat="server" CssClass="layui-input"></asp:TextBox>
                         </div>
                         <div class="layui-form-mid layui-word-aux">
                             <asp:RequiredFieldValidator ID="rfvtxtISBN" ControlToValidate="txtISBN" runat="server">*必填项！</asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="layui-form-item">
                         <label class="layui-form-label">作者</label>
                         <div class="layui-input-inline">
                             <asp:TextBox ID="txtAuthor" runat="server" CssClass="layui-input"></asp:TextBox>
                         </div>
                         <div class="layui-form-mid layui-word-aux">
                             <asp:RequiredFieldValidator ID="rfvtxtAuthor" ControlToValidate="txtAuthor" runat="server">*必填项！</asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="layui-form-item">
                         <label class="layui-form-label">出版社</label>
                         <div class="layui-input-inline">
                             <asp:TextBox ID="txtPubHouse" runat="server" CssClass="layui-input"></asp:TextBox>
                         </div>
                         <div class="layui-form-mid layui-word-aux">
                             <asp:RequiredFieldValidator ID="rfvtxtPubHouse" ControlToValidate="txtPubHouse" runat="server">*必填项！</asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="layui-form-item">
                         <label class="layui-form-label">书籍描述</label>
                         <div class="layui-input-inline">
                             <asp:TextBox ID="txtDescn" runat="server" CssClass="layui-input" TextMode="MultiLine"></asp:TextBox>
                         </div>
                     </div>
                     <div class="layui-form-item">
                         <label class="layui-form-label">单价</label>
                         <div class="layui-input-inline">
                             <asp:TextBox ID="txtListPrice" runat="server" CssClass="layui-input"></asp:TextBox>
                         </div>
                         <div class="layui-form-mid layui-word-aux">
                             <asp:RequiredFieldValidator ID="rfvtxtListPrice" ControlToValidate="txtListPrice" runat="server">*必填项！货币格式：0.00</asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="layui-form-item">
                         <label class="layui-form-label">库存</label>
                         <div class="layui-input-inline">
                             <asp:TextBox ID="txtQty" runat="server" CssClass="layui-input" TextMode="Number"></asp:TextBox>
                         </div>
                         <div class="layui-form-mid layui-word-aux">
                             <asp:RequiredFieldValidator ID="rfvtxtQty" ControlToValidate="txtQty" runat="server" Display="Dynamic">*必填项！大于或等于0</asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="layui-form-item">
                         <div style="margin-left: 110px;">
                             <asp:Button ID="BtnUpdataProduct" runat="server" Text="修改" CssClass="layui-btn" Width="190px" OnClick="BtnUpdataProduct_Click"/>
                         </div>
                     </div>
                 </div>
             </div>
         </div>
    </div>
</asp:Content>

