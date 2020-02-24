<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="UserManage.aspx.cs" Inherits="Admin_UserManage" EnableViewState="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layui-card">
        <div class="layui-card-header" style="text-align: center; font-size: large;">用户管理</div>
    </div>
    <div class="layui-card">
        <div class="layui-card-header layui-form" style="padding: 15px 10px;">
                <div class="layui-row">
                    <div class="layui-col-lg2">
                        <asp:DropDownList ID="ddlType" runat="server" lay-ignore CssClass="dropdownlist" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="0" Selected="True">显示全部</asp:ListItem>
                            <asp:ListItem Value="1">普通用户</asp:ListItem>
                            <asp:ListItem Value="2">管理员</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="layui-col-lg2 layui-col-lg-offset6">
                        <asp:TextBox ID="txtSearchKey" runat="server" CssClass="layui-input" placeholder="搜索用户名"></asp:TextBox>
                    </div>
                    <div class="layui-col-lg1" style="line-height: initial;margin-left:10px;">
                        <asp:LinkButton ID="BtnSearch" runat="server" CssClass="layui-btn" OnClick="BtnSearch_Click">搜索</asp:LinkButton>
                    </div>
                </div>
            </div>
         <div class="layui-card-body layui-form" font-size: large;">
             <asp:Label ID="lblMsg" runat="server"></asp:Label><br />
             <asp:GridView ID="gvUserManage" runat="server" CssClass="layui-table" style="table-layout: fixed;" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="UserId" OnRowEditing="gvUserManage_RowEditing" OnRowCancelingEdit="gvUserManage_RowCancelingEdit" OnRowDeleting="gvUserManage_RowDeleting" OnPageIndexChanging="gvUserManage_PageIndexChanging" OnRowDataBound="gvUserManage_RowDataBound" OnRowUpdating="gvUserManage_RowUpdating">
                 <Columns>
                     <asp:BoundField DataField="UserId" HeaderText="用户ID" ReadOnly="True" >
                     <HeaderStyle Width="60px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="UserName" HeaderText="用户名" ReadOnly="True" >
                      <HeaderStyle Width="90px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="Email" HeaderText="邮箱" ReadOnly="True" />
                     <asp:BoundField DataField="UserAdd" HeaderText="地址" ReadOnly="True" />
                     <asp:BoundField DataField="JoinDate" HeaderText="注册时间" ReadOnly="True" >
                     <HeaderStyle Width="125px" />
                     </asp:BoundField>
                     <asp:TemplateField HeaderText="用户类型">
                         <EditItemTemplate>
                             <asp:DropDownList ID="ddlUserType" runat="server" SelectedValue='<%# Bind("UserType") %>'>
                                 <asp:ListItem Value="普通用户">普通用户</asp:ListItem>
                                 <asp:ListItem Value="管理员">管理员</asp:ListItem>
                             </asp:DropDownList>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lblUserType" runat="server" Text='<%# Bind("UserType") %>'></asp:Label>
                         </ItemTemplate>
                         <HeaderStyle Width="100px" />
                     </asp:TemplateField>
                     <asp:CommandField EditText="授权" ShowEditButton="True" >
                     <HeaderStyle Width="70px" />
                     <ItemStyle ForeColor="#3399FF" Font-Underline="True" />
                     </asp:CommandField>
                     <asp:CommandField ShowDeleteButton="True" >
                     <HeaderStyle Width="60px" />
                     <ItemStyle ForeColor="#3399FF" Font-Underline="True" />
                     </asp:CommandField>
                 </Columns>
                 <HeaderStyle BackColor="Silver" />
                 <PagerStyle HorizontalAlign="Center" />
             </asp:GridView>
         </div>
    </div>
</asp:Content>

