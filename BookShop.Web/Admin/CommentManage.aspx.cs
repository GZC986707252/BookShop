using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq.SqlClient;

using BookShop.BLL;
using System.Collections;

public partial class Admin_CommentManage : System.Web.UI.Page
{
    CommentInfo commentInfo = new CommentInfo();

    static int flag = 0;   //0-表示显示全部数据 ，1-表示显示搜索数据
    static string keyword = null;  //搜索关键字
    static string type = null;  //搜索方式

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            if (!Page.IsPostBack)
            {
                flag = 0;
                CommentDataBind();
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }   
    }

    public void Bind(IList list)
    {
        if (list.Count != 0)
        {
            lblMsg.Text = "当前共有" + list.Count + "条数据！";
            gvComment.Visible = true;
            gvComment.DataSource = list;
            gvComment.DataBind();
        }
        else
        {
            lblMsg.Text = "暂时没有任何数据";
            gvComment.Visible = false;
        }
    }

    public void CommentDataBind()
    {
        if (flag == 0)
        {
            //显示所有评论
            Bind(commentInfo.GetAllComments());
        }
        else
        {
            //显示搜索的评论
            Bind(commentInfo.GetCommentsByKeyword(keyword, type));
        }
    }


    protected void BtnSearch_Click(object sender, EventArgs e)
    {

        if (txtSearchKey.Text.Length != 0 && ddlSearchType.SelectedValue != "")
        {
            keyword = txtSearchKey.Text;
            type = ddlSearchType.SelectedValue;
            flag = 1;
            CommentDataBind();
        }
    }

    protected void gvComment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            //获取编辑行
            GridViewRow row = gvComment.Rows[e.RowIndex];
            //获取编辑数据id
            int cid = int.Parse(row.Cells[0].Text);
            //从数据库中删除该数据
            commentInfo.DeleteCommentById(cid);
            Response.Write("<script>alert('删除成功')</script>");
            CommentDataBind();
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void gvComment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvComment.PageIndex = e.NewPageIndex;
        CommentDataBind();

    }

    protected void gvComment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                //获取删除链接按钮
                LinkButton linkbtnDelete = (LinkButton)e.Row.Cells[3].Controls[0];
                //添加客户端提示
                linkbtnDelete.OnClientClick = "return confirm('该分类下的商品也会被一起删除，确定要删除吗？')";
            }
            catch
            {
            }
        }
    }

}