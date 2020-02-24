using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

public partial class MyCollections : System.Web.UI.Page
{
    CollectionsInfo CollInfo = new CollectionsInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            if (!CollInfo.IsCollectionsEmptyById(uid))
            {
                BtnClearAllCollections.OnClientClick = "return confirm('确定要清空收藏夹吗？');";
                gvCollections.DataSourceID = "LinqCollections";
                LinqCollections.Where = "UserId == " + uid;
            }
            else
            {
                lblPageCountMsg.Text = "";
                lblNullMsg.Text = "你目前没有收藏任何商品！";
                BtnClearAllCollections.Enabled = false;
                //      gvShopCart.Visible = false;
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }

    }
    protected void gvCollections_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                //获取删除链接按钮
                LinkButton linkbtnDelete = (LinkButton)e.Row.Cells[4].Controls[0];
                //添加客户端提示
                linkbtnDelete.OnClientClick = "return confirm('确定要删除吗？')";
            }
            catch
            {
            }
        }
        lblPageCountMsg.Text = "当前页为第" + (gvCollections.PageIndex + 1).ToString() + "页，共有" + (gvCollections.PageCount).ToString() + "页";
    }

    protected void BtnClearAllCollections_Click(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            CollInfo.ClearCollectionsByUserId(uid);
            Response.Write("<script>window.location.href='MyCollections.aspx'</script>");
        }
        else
        {
            Response.Redirect("Login.aspx");
        }

    }

    protected void gvCollections_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (CollInfo.IsCollectionsEmptyById(int.Parse(Session["UserId"].ToString())))
        {
            Response.Write("<script>window.location.href='MyCollections.aspx'</script>");
        }
    }

}