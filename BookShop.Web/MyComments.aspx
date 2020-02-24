<%@ Page Title="我的评价" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="MyComments.aspx.cs" Inherits="MyComments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="layui-row" style="text-align:center;font-size:x-large;">我的评论</div>
    <asp:Label ID="lblNullMsg" runat="server" Text="" Font-Size="Larger"></asp:Label>
    <div class="layui-row">
        <asp:GridView ID="gvComments" CssClass="layui-table" style="table-layout:fixed;"  runat="server" AutoGenerateColumns="False" DataKeyNames="CommentId" AllowPaging="True" OnRowDataBound="gvComments_RowDataBound" OnRowDeleted="gvComments_RowDeleted">
            <Columns>
                <asp:BoundField DataField="TextContent" HeaderText="评论内容"/>
                <asp:BoundField DataField="ComDateTime" HeaderText="评论时间">
                <HeaderStyle Width="150px" />
                </asp:BoundField>
                <asp:CommandField ShowDeleteButton="True" >
                <HeaderStyle Width="50px" />
                </asp:CommandField>
            </Columns>
            <HeaderStyle BackColor="#66CCFF" />
        </asp:GridView>
        <asp:LinqDataSource ID="LinqComments" runat="server" ContextTypeName="BookShop.DAL.BookShopDataContext" EnableDelete="True" EntityTypeName="" TableName="Comment" OrderBy="ComDateTime desc">    
        </asp:LinqDataSource>
    </div>
    <div class="layui-row"><asp:Label ID="lblPageCountMsg" runat="server" Font-Size="Medium" ForeColor="#FF5722"></asp:Label></div>
    <hr class="layui-bg-blue">
    <div class="layui-row" style="font-size:large;">
        <div class="layui-col-lg2 layui-col-lg-offset10">
            <asp:Button ID="BtnClearAllComments" runat="server" Text="清空评论" CssClass="layui-btn layui-btn-danger layui-btn-fluid" OnClick="BtnClearAllComments_Click"/>
        </div>
    </div>
</asp:Content>

