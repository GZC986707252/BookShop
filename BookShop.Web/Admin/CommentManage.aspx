<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="CommentManage.aspx.cs" Inherits="Admin_CommentManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layui-card">
        <div class="layui-card-header" style="text-align: center; font-size: large;">评论管理</div>
    </div>
    <div class="layui-card">
        <div class="layui-card-header layui-form" style="padding: 15px 10px;">
                <div class="layui-row">
                    <div class="layui-col-lg1" style="line-height: initial;padding-left:10px;">
                        <a href="CommentManage.aspx" class="layui-btn">显示全部</a>
                    </div>
                    <div class="layui-col-lg2 layui-col-lg-offset5">
                        <asp:DropDownList ID="ddlSearchType" runat="server" Width="100px">
                            <asp:ListItem Value="">选择搜索方式</asp:ListItem>
                            <asp:ListItem Value="Context">评论内容</asp:ListItem>
                            <asp:ListItem Value="UserName">用户名</asp:ListItem>
                            <asp:ListItem Value="BookId">书籍ID</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="layui-col-lg2">
                        <asp:TextBox ID="txtSearchKey" runat="server" CssClass="layui-input" placeholder="搜索评论"></asp:TextBox>
                    </div>
                    <div class="layui-col-lg1" style="line-height: initial;margin-left:10px;">
                        <asp:LinkButton ID="BtnSearch" runat="server" CssClass="layui-btn" OnClick="BtnSearch_Click">搜索</asp:LinkButton>
                    </div>
                </div>
            </div>
         <div class="layui-card-body layui-form" font-size: large;">
             <asp:Label ID="lblMsg" runat="server"></asp:Label><br />
             <asp:GridView ID="gvComment" runat="server" CssClass="layui-table" style="table-layout: fixed;" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="CommentId" OnRowDeleting="gvComment_RowDeleting" OnPageIndexChanging="gvComment_PageIndexChanging" OnRowDataBound="gvComment_RowDataBound">
                 <Columns>
                     <asp:BoundField DataField="CommentId" HeaderText="评论ID">
                     <HeaderStyle Width="60px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="BookId" HeaderText="书籍ID">
                     <HeaderStyle Width="60px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="UserName" HeaderText="用户名">
                     <HeaderStyle Width="100px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="TextContent" HeaderText="评论内容"/>
                     <asp:BoundField DataField="ComDateTime" HeaderText="评论时间">
                     <HeaderStyle Width="125px" />
                     </asp:BoundField>
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

