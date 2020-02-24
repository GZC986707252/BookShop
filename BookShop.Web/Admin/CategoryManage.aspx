<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="CategoryManage.aspx.cs" Inherits="Admin_CategoryManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layui-card">
        <div class="layui-card-header" style="text-align: center; font-size: large;">分类管理</div>
    </div>
    <div class="layui-card">
        <div class="layui-card-header layui-form" style="padding: 15px 10px;">
                <div class="layui-row">
                    <div class="layui-col-lg2">
                        <asp:TextBox ID="txtAddCategoryName" runat="server" CssClass="layui-input" placeholder="新建分类名称"></asp:TextBox>
                    </div>
                    <div class="layui-col-lg2" style="line-height: initial;margin-left:10px;">
                         <asp:LinkButton ID="BtnAddCategory" runat="server" CssClass="layui-btn layui-btn-fluid" OnClick="BtnAddCategory_Click">
                             <i class="layui-icon layui-icon-add-circle"></i>添加分类
                         </asp:LinkButton>
                    </div>
                    <div class="layui-col-lg1" style="line-height: initial;padding-left:10px;">
                        <a href="CategoryManage.aspx" class="layui-btn">显示全部</a>
                    </div>
                    <div class="layui-col-lg2 layui-col-lg-offset3">
                        <asp:TextBox ID="txtSearchKey" runat="server" CssClass="layui-input" placeholder="搜索分类"></asp:TextBox>
                    </div>
                    <div class="layui-col-lg1" style="line-height: initial;margin-left:10px;">
                        <asp:LinkButton ID="BtnSearch" runat="server" CssClass="layui-btn" OnClick="BtnSearch_Click">搜索</asp:LinkButton>
                    </div>
                </div>
            </div>
         <div class="layui-card-body layui-form" font-size: large;">
             <asp:Label ID="lblMsg" runat="server"></asp:Label><br />
             <asp:GridView ID="gvCategory" runat="server" CssClass="layui-table" style="table-layout: fixed;" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="CategoryId" OnRowEditing="gvCategory_RowEditing" OnRowCancelingEdit="gvCategory_RowCancelingEdit" OnRowDeleting="gvCategory_RowDeleting" OnPageIndexChanging="gvCategory_PageIndexChanging" OnRowDataBound="gvCategory_RowDataBound" OnRowUpdating="gvCategory_RowUpdating">
                 <Columns>
                     <asp:BoundField DataField="CategoryId" HeaderText="分类ID" ReadOnly="True" >
                     <HeaderStyle Width="100px"/>
                     </asp:BoundField>
                     <asp:TemplateField HeaderText="分类名称">
                         <EditItemTemplate>
                             <asp:TextBox ID="txtNewCategoryName" runat="server" CssClass="layui-input" Text='<%# Bind("CategoryName") %>'></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lblCategoryName" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                         </ItemTemplate>
                         <ControlStyle Width="200px" />
                     </asp:TemplateField>
                     <asp:CommandField EditText="编辑" ShowEditButton="True" >
                     <HeaderStyle Width="100px"/>
                     <ItemStyle ForeColor="#3399FF" Font-Underline="True" />
                     </asp:CommandField>
                     <asp:CommandField ShowDeleteButton="True">
                     <HeaderStyle Width="100px"/>
                     <ItemStyle ForeColor="#3399FF" Font-Underline="True" />
                     </asp:CommandField>
                 </Columns>
                 <HeaderStyle BackColor="Silver"/>
                 <PagerStyle HorizontalAlign="Center"/>
             </asp:GridView>
         </div>
    </div>
</asp:Content>

