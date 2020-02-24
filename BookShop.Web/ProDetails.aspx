<%@ Page Title="商品详情" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="ProDetails.aspx.cs" Inherits="ProDetails"  Theme="MyThemes"%>

<%@ Register Src="~/UserControl/HotSale.ascx" TagPrefix="uc1" TagName="HotSale" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="layui-row layui-col-space10">
        <div class="layui-col-lg8">
            <div class="layui-row layui-col-space10">
                <!--商品图片-->
                <div class="layui-col-lg5">
                   <div class="layui-row"><asp:Image ID="imgBook" runat="server" ImageAlign="AbsMiddle" width="310px"/></div>
                    <div class="layui-row text-center"  style="margin-top:10px;">
                        <div class="layui-col-lg4">
                            <asp:LinkButton ID="BtnAddToCollections" runat="server" OnClick="BtnAddToCollections_Click"><i class="layui-icon layui-icon-star"></i>收藏</asp:LinkButton>
                        </div>
                        <div class="layui-col-lg4 layui-col-lg-offset4">
                            <asp:LinkButton ID="BtnPraise" runat="server" OnClick="BtnPraise_Click"><i class="layui-icon layui-icon-praise"></i>赞一下</asp:LinkButton>
                        </div>
                    </div>
                    <div class="layui-row text-center"><asp:Label ID="lblTipMsg" runat="server" ForeColor="Red"></asp:Label></div>
                </div>
                <!--商品详情-->
                <div class="layui-col-lg7">
                    <div class="layui-row">
                        <div class="layui-card bg-lightgreen" style="color:white;">
                            <div class="layui-card-header text-center" style="font-size: 25px;">商品详情</div>
                            <div class="layui-card-body">
                                书名：<asp:Label ID="lblBookName" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="layui-card-body">
                                ISBN：<asp:Label ID="lblBookISBN" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="layui-card-body">
                                作者：<asp:Label ID="lblBookAuthor" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="layui-card-body">
                                出版社：<asp:Label ID="lblPubHouse" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="layui-card-body">
                                类别：<asp:Label ID="lblCategoryName" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="layui-card-body">
                                描述：<br />
                                <asp:TextBox ID="txtBookDescn" runat="server" ReadOnly="True" Width="400px" Text="" Height="65px" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="layui-card-body">
                                库存：<asp:Label ID="lblQuantity" runat="server" Text=""></asp:Label>&nbsp;&nbsp;件
                            </div>
                            <div class="layui-card-body">
                                售价：<asp:Label ID="lblListPrice" runat="server" Text=""></asp:Label>&nbsp;&nbsp;元
                            </div>
                        </div>
                    </div>
                    <div class="layui-row text-center" style="margin-top:10px;">
                        <div class="layui-col-lg6" style="margin-top: 10px;">
                            购买数量：<asp:TextBox ID="txtPurchaseQty" runat="server" Text="1" TextMode="Number" Width="45px"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" ForeColor="Red">(限购10件)</asp:Label>
                        </div>
                        <div class="layui-col-lg6">
                            <asp:Button ID="BtnAddToCard" runat="server" Text="添加购物车" CssClass="layui-btn layui-btn-fluid layui-btn-danger" OnClick="BtnAddToCard_Click"/>
                        </div>
                    </div>
                    <div class="layui-row"><asp:Label ID="lblAddCartMsg" runat="server" Text="" ForeColor="Red" Font-Size="Large"></asp:Label></div>
                </div>
            </div>
        </div>
        <!--热门推荐区-->
        <div class="layui-col-lg4">
            <uc1:HotSale runat="server" ID="HotSale" />
        </div>
    </div>
    <hr class="layui-bg-blue">
    <div class="layui-row layui-bg-white text-center" style="font-size: 25px;">热门评论</div>
    <hr class="layui-bg-blue">
    <div class="layui-row layui-col-space10">
        <!--评论展示区 局部刷新-->
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="layui-col-lg8">
                    <div id="CommentDisplay" runat="server">null</div>
                </div>
                <!--评论提交区-->
                <div class="layui-col-lg4">
                    <div class="layui-row">
                        <asp:TextBox ID="TxtComment" runat="server" TextMode="MultiLine" placeholder="要不要说点什么？" CssClass="layui-textarea"></asp:TextBox>
                    </div>
                    <div class="layui-row" style="text-align: right; margin-top: 5px;">
                        <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <asp:LinkButton ID="BtnComment" runat="server" CssClass="layui-btn" OnClick="BtnComment_Click"><i class="layui-icon layui-icon-release"></i>发表评论</asp:LinkButton>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BtnComment" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>

