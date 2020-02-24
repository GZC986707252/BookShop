<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfoCard.ascx.cs" Inherits="UserControl_UserInfoCard" %>


<div class="layui-card">
    <div class="layui-card-header text-center text-hidden">
        <asp:Label ID="lblNickName" runat="server" Text="" style="font-size: x-large"></asp:Label>
    </div>
    <div class="layui-card-body" style="font-size: large;color:black;">
        <asp:Panel ID="plUserInfo" runat="server" >
            <ul class="ulCard">
                <li>
                    您是目前第&nbsp;<asp:Label ID="lblUserId"  runat="server" Text="" SkinId="TextOrange"></asp:Label>&nbsp;位注册用户！
                </li>
                <li>
                    用户名：<asp:Label ID="lblLoginName" runat="server" Text="" SkinId="TextOrange"></asp:Label>
                </li>
                <li>
                    邮&nbsp;&nbsp;&nbsp;&nbsp;箱：<asp:Label ID="lblEmail" runat="server" Text="" SkinId="TextOrange"></asp:Label>
                </li>
                <li>
                    用户类型：<asp:Label ID="lblUserType" runat="server" Text="" SkinId="TextOrange"></asp:Label>
                </li>
                <li>
                    账户余额：<asp:Label ID="lblAmount" runat="server" Text="" SkinId="TextOrange"></asp:Label>元 <span style="float:right;"><a href="Recharge.aspx" style="color:#01AAED;">充值>></a></span>
                </li>
                <li>
                   收货地址：<asp:Label ID="lblAddress" runat="server" Text="" SkinId="TextOrange"></asp:Label>
                </li>
            </ul>
        </asp:Panel>
        <asp:Label ID="lblInintial" runat="server" Text="您还没登录呢！" style="font-size: large"></asp:Label>
    </div>
</div>