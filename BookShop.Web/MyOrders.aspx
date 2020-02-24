<%@ Page Title="我的订单" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="MyOrders.aspx.cs" Inherits="MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layui-row" style="text-align:center;font-size:x-large;">我的订单</div>
    <asp:Label ID="lblNullMsg" runat="server" Text="" Font-Size="Larger"></asp:Label>
    <div class="layui-row">
        <asp:GridView ID="gvMyOrders" CssClass="layui-table" style="table-layout:fixed;"  runat="server" AutoGenerateColumns="False" AllowPaging="True" OnRowDataBound="gvMyOrders_RowDataBound">
            <Columns>
                <asp:BoundField DataField="OrderId" HeaderText="订单号">
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="UserAddress" HeaderText="寄送地址" />
                <asp:BoundField DataField="Zip" HeaderText="邮政编号">
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Tel" HeaderText="手机号码">
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="OrderDate" HeaderText="创建时间">
                <HeaderStyle Width="130px" />
                </asp:BoundField>
                <asp:BoundField DataField="Status" HeaderText="订单状态">
                <HeaderStyle Width="60px" />
                </asp:BoundField>
               <asp:HyperLinkField Text="查看详情" DataNavigateUrlFields="OrderId" DataNavigateUrlFormatString="~/MyOrders.aspx?OrderId={0}" >
                <HeaderStyle Width="60px" />
                </asp:HyperLinkField>
            </Columns>
            <HeaderStyle BackColor="#66CCFF" />
        </asp:GridView>
    </div>
    <div class="layui-row">
        <asp:Label ID="lblPageCountMsg" runat="server" Font-Size="Medium" ForeColor="#FF5722"></asp:Label></div>
    <hr class="layui-bg-blue">
    <asp:Label ID="lblDetailMsg" runat="server" Text=""></asp:Label>
    <div class="layui-row">
        <asp:GridView ID="gvOrderItems" CssClass="layui-table" Style="table-layout: fixed;" runat="server" AutoGenerateColumns="False" AllowPaging="True" Visible="false">
            <Columns>
                <asp:BoundField DataField="OrderId" HeaderText="订单号">
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="ProName" HeaderText="书籍名称" />
                <asp:BoundField DataField="ProPrice" HeaderText="书籍单价/元">
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="ProQty" HeaderText="购买数量">
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalPrice" HeaderText="总价/元">
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
            </Columns>
            <HeaderStyle BackColor="#66CCFF" />
        </asp:GridView>
    </div>
   
</asp:Content>

