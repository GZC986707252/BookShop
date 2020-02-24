using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;


public partial class MyOrders : System.Web.UI.Page
{
    OrderService OrderSvi = new OrderService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["UserId"]!=null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            var orders = OrderSvi.GetOrdersByUserId(uid);
            if (orders.Count != 0)
            {
                gvMyOrders.DataSource = orders;
                gvMyOrders.DataBind();
                if (Request.QueryString["OrderId"] != null)
                {
                    int oid = int.Parse(Request.QueryString["OrderId"]);
                    lblDetailMsg.Text = "订单号" + oid + "的详细信息如下：";
                   gvOrderItems.Visible = true;
                    gvOrderItems.DataSource = OrderSvi.GetOrderItemsByOrderId(oid);
                    gvOrderItems.DataBind();
                }
            }
            else
            {
                lblPageCountMsg.Visible=false;
                lblNullMsg.Text = "你目前还没有任何订单信息！";
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void gvMyOrders_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        lblPageCountMsg.Text = "当前页为第" + (gvMyOrders.PageIndex + 1).ToString() + "页，共有" + (gvMyOrders.PageCount).ToString() + "页";
    }

}