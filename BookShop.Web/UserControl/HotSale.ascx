<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HotSale.ascx.cs" Inherits="UserControl_HotSale" %>

<asp:Panel ID="Panel1" runat="server">
    <div class="layui-card">
        <div class="layui-card-header" style="text-align: center; font-size: large;">
            <i class="layui-icon layui-icon-fire" style="font-size: 25px; color: red; font-style: italic;">热门推荐</i>
        </div>
        <div>
            <div class="layui-row" style="background-color: white;" id="HotSale" runat="server"></div>
        </div>
    </div>
</asp:Panel>

