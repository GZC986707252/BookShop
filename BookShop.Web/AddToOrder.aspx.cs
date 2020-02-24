using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;


public partial class AddToOrder : System.Web.UI.Page
{
    UserService UserSvi = new UserService();
    OrderService OrderSvi = new OrderService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            if(!Page.IsPostBack)
            {
                int uid = int.Parse(Session["UserId"].ToString());
                txtUserName.Text = UserSvi.GetUserInfoById(uid).UserName;
                txtUserAdd.Text = UserSvi.GetUserInfoById(uid).UserAdd;
                lblTotalPrice.Text = Request.QueryString["TotalPrice"];
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void BtnSubmitOrder_Click(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            if (Page.IsValid)
            {
                if (UserSvi.CheckPayPassword(uid, txtPayPsd.Text))
                {
                    if (decimal.Parse(Request.QueryString["TotalPrice"]) < UserSvi.GetUserInfoById(uid).Amount)
                    {
                        OrderSvi.CreateOrder(uid, txtUserName.Text, txtUserAdd.Text, txtZip.Text, txtTel.Text);
                        Response.Write("<script> alert('提交订单成功！')</script>");
                        Response.Write("<script>window.location.href='MyOrders.aspx'</script>");
                    }
                    else  
                    {
                        //余额不足
                            Response.Write("<script> alert('当前余额不足！')</script>");
                    }
                }
                else if(UserSvi.GetUserInfoById(uid).PayPsd==null)
                {
                    lblErrorMsg.Text = "请先前往\"安全管理\"设置支付密码！";
                }
                else
                {
                    lblErrorMsg.Text = "支付密码错误！";
                }
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}