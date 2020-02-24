using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using BookShop.BLL;

public partial class Admin_ProManage : System.Web.UI.Page
{
    ProductService ProService = new ProductService();
    static int flag = 0;  //功能定位 0执行显示全部 ，-1表示执行搜索，其他表示执行分类显示
    static string keyword = null;
    static string type = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            //Page.IsPostBack这个属性很重要！没有这个，搜索到相关数据后执行删除操作会删除错误数据
            if (!Page.IsPostBack)
            {
                flag = 0;
                BookDataBind();
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
       
    }

    //自定义绑定数据
    public void Bind(IList list)
    {
        if (list.Count != 0)
        {
            lblMsg.Text = "当前共有" + list.Count + "条数据！";
            gvBooksInfo.Visible = true;
            gvBooksInfo.DataSource = list;
            gvBooksInfo.DataBind();
        }
        else
        {
            lblMsg.Text = "暂时没有任何数据";
            gvBooksInfo.Visible = false;
        }

    }

   public void BookDataBind()
    {
        if (flag == 0)
        {
            //显示所有评论
            Bind(ProService.GetAllBooks());
        }
        else if(flag==-1)
        {
            //显示搜索的评论
            Bind(ProService.GetBooksByKeyword(keyword, type));
        }
        else
        {
            //显示分类的书籍数据
            Bind(ProService.GetBooksByCategoryId(flag));
        }
    }

    //按方式搜索
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearchKey.Text.Length != 0 && ddlType.SelectedValue.Length != 0)
        {
            keyword = txtSearchKey.Text;
            type = ddlType.SelectedValue;
            flag = -1;
            BookDataBind();
        }
    }

    protected void gvBooksInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBooksInfo.PageIndex = e.NewPageIndex;
        BookDataBind(); //重新绑定GridView数据的函数

    }

    protected void gvBooksInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                //获取删除链接按钮
                LinkButton linkbtnDelete = (LinkButton)e.Row.Cells[11].Controls[0];
                //添加客户端提示
                linkbtnDelete.OnClientClick = "return confirm('确定要删除吗？')";
            }
            catch
            {
            }
        }
    }

    protected void gvBooksInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            //获取当前行
            GridViewRow row = gvBooksInfo.Rows[e.RowIndex];
            //获取删除行的数据的ID
            int bid = int.Parse(row.Cells[0].Text.ToString());
            //删除前先获取图片路径
            string targetPath = Server.MapPath("~/") + ProService.GetBookInfoByBookId(bid).BookImage.Substring(2);
            //从数据库中删除该数据
            ProService.DeleteBookById(bid);
            //删除相应图片
            File.Delete(targetPath);
            Response.Write("<script>alert('删除成功')</script>");
            BookDataBind();
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        flag = int.Parse(ddlCategory.SelectedValue);
        BookDataBind();
    }
}