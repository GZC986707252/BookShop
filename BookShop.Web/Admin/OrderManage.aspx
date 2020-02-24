<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="OrderManage.aspx.cs" Inherits="Admin_OrderManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="layui-card">
        <div class="layui-card-header" style="text-align: center; font-size: large;">订单管理</div>
    </div>
    <div class="layui-card">
        <div class="layui-card-header layui-form" style="padding: 15px 10px;">
                <div class="layui-row">
                    <div class="layui-col-lg2">
                        <asp:DropDownList ID="ddlOrderStatus" runat="server" lay-ignore CssClass="dropdownlist" AutoPostBack="True" OnSelectedIndexChanged="ddlOrderStatus_SelectedIndexChanged">
                            <asp:ListItem Value="0" Selected="True">所有订单</asp:ListItem>
                            <asp:ListItem Value="1">已审核</asp:ListItem>
                            <asp:ListItem Value="2">未审核</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="layui-col-lg2 layui-col-lg-offset6">
                        <asp:TextBox ID="txtSearchKey" runat="server" CssClass="layui-input" placeholder="搜索订单"></asp:TextBox>
                    </div>
                    <div class="layui-col-lg1" style="line-height: initial;margin-left:10px;">
                        <asp:LinkButton ID="BtnSearch" runat="server" CssClass="layui-btn" OnClick="BtnSearch_Click">搜索</asp:LinkButton>
                    </div>
                </div>
            </div>
         <div class="layui-card-body layui-form" font-size: large;">
             <asp:Label ID="lblMsg" runat="server"></asp:Label><br />
             <asp:GridView ID="gvOrders" runat="server" CssClass="layui-table" style="table-layout: fixed;" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="OrderId" OnRowEditing="gvOrders_RowEditing" OnRowCancelingEdit="gvOrders_RowCancelingEdit" OnRowDeleting="gvOrders_RowDeleting" OnPageIndexChanging="gvOrders_PageIndexChanging" OnRowDataBound="gvOrders_RowDataBound" OnRowUpdating="gvOrders_RowUpdating">
                 <Columns>
                     <asp:BoundField DataField="OrderId" HeaderText="订单ID" ReadOnly="True" >
                     <HeaderStyle Width="60px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="UserName" HeaderText="用户名" ReadOnly="True">
                     <HeaderStyle Width="70px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="Zip" HeaderText="邮编" ReadOnly="True">
                     <HeaderStyle Width="60px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="Tel" HeaderText="电话" ReadOnly="True">
                     <HeaderStyle Width="90px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="UserAddress" HeaderText="寄送地址" ReadOnly="True"/>
                     <asp:BoundField DataField="OrderDate" HeaderText="创建时间" ReadOnly="True" />
                     <asp:TemplateField HeaderText="状态">
                         <EditItemTemplate>
                             <asp:DropDownList ID="ddlStatus" runat="server" SelectedValue='<%# Bind("Status") %>'>
                                 <asp:ListItem Value="已审核">已审核</asp:ListItem>
                                 <asp:ListItem Value="待审核">待审核</asp:ListItem>
                             </asp:DropDownList>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                         </ItemTemplate>
                         <HeaderStyle Width="100px" />
                     </asp:TemplateField>
                     <asp:CommandField EditText="审核" ShowEditButton="True" >
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

