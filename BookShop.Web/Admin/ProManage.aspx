<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ProManage.aspx.cs" Inherits="Admin_ProManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
       

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div class="layui-row">
        <div class="layui-card">
            <div class="layui-card-header" style="text-align:center;font-size:large;">商品管理</div>
        </div>
        <div class="layui-card">
            <div class="layui-card-header layui-form" style="padding: 15px 10px;">
                <div class="layui-row">
                    <div class="layui-col-xs2" style="line-height: initial;">
                        <a href="NewProduct.aspx" class="layui-btn layui-btn-fluid">
                            <i class="layui-icon layui-icon-add-circle"></i>添加商品
                        </a>
                    </div>
                    <div class="layui-col-xs2" style="line-height: initial;padding-left:10px;">
                        <asp:DropDownList ID="ddlCategory" runat="server" lay-ignore CssClass="dropdownlist" AutoPostBack="True" DataSourceID="ldsCategory" DataTextField="CategoryName" DataValueField="CategoryId" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                            <asp:ListItem Value="0" Selected="True">显示全部</asp:ListItem>
                        </asp:DropDownList>
                        <asp:LinqDataSource ID="ldsCategory" runat="server" ContextTypeName="BookShop.DAL.BookShopDataContext" EntityTypeName="" TableName="Category"></asp:LinqDataSource>
                    </div>
                    <div class="layui-col-xs2 layui-col-xs-offset2">
                        <asp:DropDownList ID="ddlType" runat="server" Width="100px">
                            <asp:ListItem Value="" Selected="True">选择搜索方式</asp:ListItem>
                            <asp:ListItem Value="BookName">书籍名称</asp:ListItem>
                            <asp:ListItem Value="ISBN">ISBN</asp:ListItem>
                            <asp:ListItem Value="Author">作者</asp:ListItem>
                            <asp:ListItem Value="PubHouse">出版社</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="layui-col-xs2" style="margin: 0px 10px;">
                        <asp:TextBox ID="txtSearchKey" runat="server" CssClass="layui-input" placeholder="请输入关键字"></asp:TextBox>
                    </div>
                    <div class="layui-col-xs1" style="line-height: initial;">
                        <asp:LinkButton ID="BtnSearch" runat="server" CssClass="layui-btn" OnClick="BtnSearch_Click">搜索</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="layui-card-body">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <asp:GridView ID="gvBooksInfo" runat="server" CssClass="layui-table" lay-size="sm" style="table-layout: fixed;" AutoGenerateColumns="False" DataKeyNames="BookId" AllowPaging="True" OnPageIndexChanging="gvBooksInfo_PageIndexChanging" OnRowDataBound="gvBooksInfo_RowDataBound" OnRowDeleting="gvBooksInfo_RowDeleting" PagerStyle-HorizontalAlign="Center" PagerStyle-ForeColor="Red">
                    <Columns>
                        <asp:BoundField DataField="BookId" HeaderText="编号" >
                        <HeaderStyle Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CategoryId" HeaderText="分类号" >
                        <HeaderStyle Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BookName" HeaderText="书名" />
                        <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                        <asp:BoundField DataField="Author" HeaderText="作者" />
                        <asp:BoundField DataField="PubHouse" HeaderText="出版社" />
                        <asp:BoundField DataField="BookDescn" HeaderText="描述">
                            <ItemStyle CssClass="text-hidden" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ListPrice" HeaderText="单价/元" >
                        <HeaderStyle Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Quantity" HeaderText="库存/件" >
                        <HeaderStyle Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PraiseQty" HeaderText="点赞量" >
                        <HeaderStyle Width="40px" />
                        </asp:BoundField>
                        <asp:HyperLinkField Text="修改" DataNavigateUrlFields="BookId" DataNavigateUrlFormatString="~/Admin/ProUpdate.aspx?Book_Id={0}" ItemStyle-ForeColor="#3399FF">
                        <HeaderStyle Width="30px" />
                        <ItemStyle ForeColor="#3399FF" Font-Underline="True"></ItemStyle>
                        </asp:HyperLinkField>
                        <asp:CommandField ShowDeleteButton="True" >
                            <HeaderStyle Width="30px" />
                            <ItemStyle ForeColor="#3399FF" Font-Underline="True" />
                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle BackColor="Silver" />
                    <PagerStyle HorizontalAlign="Center" ForeColor="Red"></PagerStyle>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

