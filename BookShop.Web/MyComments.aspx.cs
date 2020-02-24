using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

public partial class MyComments : System.Web.UI.Page
{
    CommentInfo ComInfo = new CommentInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            if (!ComInfo.IsCommentsEmptyByUserId(uid))
            {
                BtnClearAllComments.OnClientClick = "return confirm('确定要清空评论吗？');";
                gvComments.DataSourceID = "LinqComments";
                LinqComments.Where = "UserId == " + uid;
            }
            else
            {
                lblPageCountMsg.Text = "";
                lblNullMsg.Text = "你目前没有任何评论信息！";
                BtnClearAllComments.Enabled = false;
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void BtnClearAllComments_Click(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            ComInfo.ClearCommentsByUserId(uid);
            Response.Write("<script>window.location.href='MyComments.aspx'</script>");
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void gvComments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                //获取删除链接按钮
                LinkButton linkbtnDelete = (LinkButton)e.Row.Cells[2].Controls[0];
                //添加客户端提示
                linkbtnDelete.OnClientClick = "return confirm('确定要删除吗？')";
            }
            catch
            {
            }
        }
        lblPageCountMsg.Text = "当前页为第" + (gvComments.PageIndex + 1).ToString() + "页，共有" + (gvComments.PageCount).ToString() + "页";
    }
    protected void gvComments_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (ComInfo.IsCommentsEmptyByUserId(int.Parse(Session["UserId"].ToString())))
        {
            Response.Write("<script>window.location.href='MyComments.aspx'</script>");
        }
    }
}