using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

public partial class Admin_OrderManage : System.Web.UI.Page
{
    OrderService orderService = new OrderService();

    static int flag = 0;    //功能定位标志 0-所有订单、1-已审核、2-待审核  3-搜索订单
    static string Keyword = null;    //搜索关键字

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            if (!Page.IsPostBack)
            {
                flag = 0;
                OrdersDataBind();
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    //自定义数据绑定
    public void Bind(IList list)
    {
        if (list.Count != 0)
        {
            lblMsg.Text = "当前共有" + list.Count + "条数据！";
            gvOrders.Visible = true;
            gvOrders.DataSource = list;
            gvOrders.DataBind();
        }
        else
        {
            lblMsg.Text = "暂时没有任何数据";
            gvOrders.Visible = false;
        }
    }

    //自定义功能定位
    public void OrdersDataBind()
    {
        if (flag == 0)
        {
            //显示所有订单
            Bind(orderService.GetAllOrders());
        }
        else if (flag == 1)
        {
            //显示已审核订单
            Bind(orderService.GetOrdersByStatus("已审核"));
        }
        else if (flag == 2)
        {
            //显示未审核订单
            Bind(orderService.GetOrdersByStatus("待审核"));
        }
        else
        {
            //搜索订单
            Bind(orderService.GetOrdersByKeyword(Keyword));
        }
    }


    protected void gvOrders_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvOrders.EditIndex = e.NewEditIndex;
        OrdersDataBind();
    }

    protected void gvOrders_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvOrders.EditIndex = -1;
        OrdersDataBind();
    }

    protected void gvOrders_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            //获取编辑行
            GridViewRow row = gvOrders.Rows[e.RowIndex];
            //获取编辑数据
            int oid = int.Parse(row.Cells[0].Text);
            string status = ((DropDownList)(row.Cells[6].FindControl("ddlStatus"))).SelectedValue;
            //更新
            orderService.UpdateOrderStatus(oid, status);
            gvOrders.EditIndex = -1;
            OrdersDataBind();
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
        
    }

    protected void gvOrders_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            //获取编辑行
            GridViewRow row = gvOrders.Rows[e.RowIndex];
            //获取编辑数据
            int oid = int.Parse(row.Cells[0].Text);
            //从数据库中删除该数据
            orderService.DeleteOrderById(oid);
            Response.Write("<script>alert('删除成功')</script>");
            OrdersDataBind();
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
        

    }

    protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                //获取删除链接按钮
                LinkButton linkbtnDelete = (LinkButton)e.Row.Cells[8].Controls[0];
                //添加客户端提示
                linkbtnDelete.OnClientClick = "return confirm('确定要删除吗？')";
            }
            catch
            {
            }
        }
    }

    protected void gvOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOrders.PageIndex = e.NewPageIndex;
        OrdersDataBind();
    }

    protected void ddlOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        flag = int.Parse(ddlOrderStatus.SelectedValue);
        OrdersDataBind();
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearchKey.Text.Length != 0)
        {
            flag = 3;
            Keyword = txtSearchKey.Text;
            OrdersDataBind();
            txtSearchKey.Text = "";
        }
    }
}