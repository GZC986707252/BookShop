<%@ Page Title="我的收藏" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="MyCollections.aspx.cs" Inherits="MyCollections" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layui-row" style="text-align:center;font-size:x-large;">我的收藏</div>
    <asp:Label ID="lblNullMsg" runat="server" Text="" Font-Size="Larger"></asp:Label>
    <div class="layui-row">
        <asp:GridView ID="gvCollections" CssClass="layui-table" style="table-layout:fixed;" runat="server" AutoGenerateColumns="False" DataKeyNames="CollectionId" AllowPaging="True" OnRowDataBound="gvCollections_RowDataBound" OnRowDeleted="gvCollections_RowDeleted">
            <Columns>
                <asp:BoundField DataField="BookId" HeaderText="书籍编号" ReadOnly="True" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="BookName" HeaderText="书籍名称" ReadOnly="True" />
                <asp:BoundField DataField="ListPrice" HeaderText="书籍单价/元" ReadOnly="True" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:HyperLinkField Text="查看" DataNavigateUrlFields="BookId" DataNavigateUrlFormatString="~/ProDetails.aspx?Book_Id={0}" >
                <HeaderStyle Width="100px" />
                </asp:HyperLinkField>
                <asp:CommandField ShowDeleteButton="True" >
                <HeaderStyle Width="100px" />
                </asp:CommandField>
            </Columns>
            <HeaderStyle BackColor="#66CCFF" />
        </asp:GridView>
        <asp:LinqDataSource ID="LinqCollections" runat="server" ContextTypeName="BookShop.DAL.BookShopDataContext" EnableDelete="True" EntityTypeName="" TableName="Collections">    
        </asp:LinqDataSource>
    </div>
    <div class="layui-row"><asp:Label ID="lblPageCountMsg" runat="server" Font-Size="Medium" ForeColor="#FF5722"></asp:Label></div>
    <hr class="layui-bg-blue">
    <div class="layui-row" style="font-size:large;">
        <div class="layui-col-lg2 layui-col-lg-offset10">
            <asp:Button ID="BtnClearAllCollections" runat="server" Text="清空收藏夹" CssClass="layui-btn layui-btn-danger layui-btn-fluid" OnClick="BtnClearAllCollections_Click"/>
        </div>
    </div>
</asp:Content>

