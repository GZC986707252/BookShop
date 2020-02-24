using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BookShop.BLL;

public partial class MainPage : System.Web.UI.MasterPage
{
    CartItemService CartSiv = new CartItemService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            LBtnToLogin.Visible = false;
            LoginStatus.Visible = true;
            lblUserName.Text= Session["UserName"].ToString();
            cartNum.InnerHtml = CartSiv.GetTotalCartNum(int.Parse(Session["UserId"].ToString())).ToString();
            HeadImage.ImageUrl = "HeadImage.aspx?id=" + Session["UserId"];
        }
        else
        {
            LBtnToLogin.Visible = true;
            LoginStatus.Visible = false;
        }
    }

    protected void LBtnLogOut_Click(object sender, EventArgs e)
    {
        //删除用户登录会话。。。
        Session.Clear();
        Response.Redirect("Default.aspx");
        //   Response.Redirect("Login.aspx");
        
    }

}
