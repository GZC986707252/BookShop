<%@ Page Title="BookShop--网上书城" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" Theme="MyThemes" %>

<%@ Register Src="~/UserControl/UserInfoCard.ascx" TagPrefix="uc1" TagName="UserInfoCard" %>
<%@ Register Src="~/UserControl/HotSale.ascx" TagPrefix="uc1" TagName="HotSale" %>


 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        //轮播图设置
        layui.use('carousel', function(){
          var carousel = layui.carousel;
          //建造实例
          carousel.render({
            elem: '#test1'  //指向容器选择器，如：elem: '#id'。也可以是DOM对象
            ,width: '100%' //设置容器宽度
              , arrow: 'always' //始终显示箭头
              , autoplay: 'true'  //自动播放
              ,interval:3000  //自动切换的时间间隔，默认值3000ms
              , arrow:'none'  //切换箭头默认显示状态 hover（悬停显示）、always（始终显示）、none（始终不显示）
            ,anim: 'default' //切换动画方式 default（左右切换）、updown（上下切换）、fade（渐隐渐显切换）
          });
        });
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="layui-row layui-col-space10">
        <!--轮播图-->
        <div class="layui-col-lg8">
            <div class="layui-carousel" id="test1">
                <div carousel-item>
                    <div>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/CarouselImages/b01.jpg" Height="280px" Width="760px" />
                    </div>
                    <div>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/CarouselImages/b02.jpg" Height="280px" Width="760px" />
                    </div>
                    <div>
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/CarouselImages/b03.jpg" Height="280px" Width="760px" />
                    </div>
                    <div>
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/CarouselImages/b04.jpg" Height="280px" Width="760px" />
                    </div>
                    <div>
                        <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/CarouselImages/b05.jpg" Height="280px" Width="760px" />
                    </div>
                    <div>
                        <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/CarouselImages/b06.jpg" Height="280px" Width="760px" />
                    </div>
                </div>
            </div>
        </div>
        <!--用户信息卡片-->
        <div class="layui-col-lg4">
            <uc1:UserInfoCard runat="server" ID="UserInfoCard" />
        </div>
    </div>

    <!--商品分类导航-->
    <div class="layui-row layui-col-space10">
        <div class="layui-col-lg8">
            <div class="layui-tab layui-tab-brief" lay-filter="docDemoTabBrief">
                <ul class="layui-tab-title">
                    <li class="layui-this"><asp:LinkButton ID="BtnDisplayAll" runat="server" OnClick="BtnDisplayAll_Click">全部商品</asp:LinkButton></li>
                    <li><asp:LinkButton ID="BtnCategoryId_1" runat="server" OnClick="BtnCategoryId_1_Click">小说</asp:LinkButton></li>
                    <li><asp:LinkButton ID="BtnCategoryId_2" runat="server" OnClick="BtnCategoryId_2_Click">经营</asp:LinkButton></li>
                    <li><asp:LinkButton ID="BtnCategoryId_3" runat="server" OnClick="BtnCategoryId_3_Click">社科</asp:LinkButton></li>
                    <li><asp:LinkButton ID="BtnCategoryId_4" runat="server" OnClick="BtnCategoryId_4_Click">生活</asp:LinkButton></li>
                    <li><asp:LinkButton ID="BtnCategoryId_5" runat="server" OnClick="BtnCategoryId_5_Click">教育</asp:LinkButton></li>
                    <li><asp:LinkButton ID="BtnCategoryId_6" runat="server" OnClick="BtnCategoryId_6_Click">文艺</asp:LinkButton></li>
                </ul>
            </div>
        </div>
        <!--商品搜索框-->
        <div class="layui-col-lg4" style="margin-top: 13px;">
            <asp:TextBox ID="TxtSearchInfo" runat="server" CssClass="layui-input input-search" placeholder="请输入搜索内容" Width="285px"></asp:TextBox>
            <asp:Button ID="BtnSearch" runat="server" Text="搜索" CssClass="layui-btn" Font-Size="Small" Width="80px" OnClick="BtnSearch_Click" />
        </div>
    </div>
    <!--商品展示区-->
    <div class="layui-row layui-col-space10">
        <div class="layui-col-lg12">
            <asp:UpdatePanel ID="ProUpdatePanl" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="layui-row layui-col-space10" runat="server" id="divProDisplay">
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="BtnDisplayAll" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="BtnSearch" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="BtnCategoryId_1" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="BtnCategoryId_2" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="BtnCategoryId_3" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="BtnCategoryId_4" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="BtnCategoryId_5" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="BtnCategoryId_6" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <!--热门推荐区-->
     <!--   <div class="layui-col-lg4">
            <uc1:HotSale runat="server" ID="HotSale" />
        </div>  -->
    </div>
 
</asp:Content>