
using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BookShop.BLL;

public partial class ProCart : System.Web.UI.Page
{
    CartItemService cartService = new CartItemService();
    ProductService ProSvi = new ProductService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            lblTotalPrice.Text =TotalPrice(uid).ToString();
            //判断该用户的购物车是否为空
            if (!cartService.IsCartItemEmptyByUserId(uid))
            {
                BtnClearAll.OnClientClick = "return confirm('确定要清空购物车吗？');";
                gvShopCart.DataSourceID = "LinqCartItem";
                LinqCartItem.Where = "UserId == " + uid;
            }
            else
            {
                lblPageCountMsg.Text = "";
                lblNullMsg.Text = "当前购物车空空如也~~~快去添加点东西吧！";
          //      gvShopCart.Visible = false;
                lblTotalPrice.Text = "0.00";
                BtnAddToOrder.Enabled = false;
                BtnClearAll.Enabled = false;
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }


    protected void gvShopCart_RowDataBound(object sender, GridViewRowEventArgs e)
    {
   //     int uid = int.Parse(Session["UserId"].ToString());
    //    TotalPrice(uid);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                //获取删除链接按钮
                LinkButton linkbtnDelete = (LinkButton)e.Row.Cells[5].Controls[0];
                //添加客户端提示
                linkbtnDelete.OnClientClick = "return confirm('确定要删除吗？')";
            }
            catch
            {
            }
        }
        //显示当前页
        lblPageCountMsg.Text = "当前页为第" + (gvShopCart.PageIndex + 1).ToString() + "页，共有" +(gvShopCart.PageCount).ToString()+ "页";
    }

    //将购物车添加到订单
    protected void BtnAddToOrder_Click(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            Response.Redirect("AddToOrder.aspx?TotalPrice="+TotalPrice(int.Parse(Session["UserId"].ToString())));
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    //清空购物车
    protected void BtnClearAll_Click(object sender, EventArgs e)
    {
        if(Session["UserId"]!=null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            if(!cartService.IsCartItemEmptyByUserId(uid))
            {
                cartService.ClearCartItemByUserId(uid);
                Response.Write("<script>window.location.href='ProCart.aspx'</script>");
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }

    }

    //根据用户购物车商品计算总价
    public decimal TotalPrice(int uid)
    {
        decimal totalPrice = 0;
        var cartItems = cartService.GetCartItemsByUserId(uid);
        if(cartItems.Count!=0)
        {
            foreach(var cart in cartItems)
            {
                totalPrice += decimal.Parse((cart.ProPrice * cart.ProQty).ToString());
            }
        }
        return totalPrice;
    }



    protected void gvShopCart_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        Response.Write("<script>window.location.href='ProCart.aspx'</script>");
    }

    protected void gvShopCart_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        Response.Write("<script>window.location.href='ProCart.aspx'</script>");
    }

    protected void gvShopCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtBox = (TextBox)gvShopCart.Rows[e.RowIndex].FindControl("txtUpdataQty");
        int bid = int.Parse(gvShopCart.Rows[e.RowIndex].Cells[0].Text);
        int pQty = ProSvi.GetBookInfoByBookId(bid).Quantity;
        if (int.Parse(txtBox.Text) <= 0)
        {
            e.Cancel = true;
            Response.Write("<script>alert('购买数量必须要大于0！')</script>");
        }
        else if(int.Parse(txtBox.Text)>pQty)
        {
            e.Cancel = true;
            Response.Write("<script>alert('当前书籍库存仅剩"+ pQty + "件！')</script>");
        }
    }
}