using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BookShop.BLL;

public partial class Admin_CategoryManage : System.Web.UI.Page
{
    CategoryService categoryService = new CategoryService();

    static int flag = 0;   //0-表示显示全部数据 ，1-表示显示搜索数据
    static string keyword = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            if (!Page.IsPostBack)
            {
                flag = 0;
                CategoryDataBind();
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
        if(list.Count != 0)
        {
            lblMsg.Text = "当前共有" + list.Count + "条数据！";
            gvCategory.Visible = true;
            gvCategory.DataSource = list;
            gvCategory.DataBind();
        }
        else
        {
            lblMsg.Text = "暂时没有任何数据";
            gvCategory.Visible = false;
        }
    }

    public void CategoryDataBind()
    {
        if (flag == 0)
        {
            //显示所有分类
            Bind(categoryService.GetAllCategories());
        }
        else
        {
            //显示搜索的分类
            Bind(categoryService.GetCategoriesByKeyword(keyword));
        }
    }

    protected void BtnAddCategory_Click(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            if (txtAddCategoryName.Text.Length != 0)
            {
                if (categoryService.NewCategory(txtAddCategoryName.Text))
                {
                    flag = 0;
                    Response.Write("<script>alert('添加成功')</script>");
                    CategoryDataBind();
                    txtAddCategoryName.Text = "";
                }
                else
                {
                    txtAddCategoryName.Text = "";
                    Response.Write("<script>alert('已存在该分类名！')</script>");
                }
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
        
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearchKey.Text.Length != 0)
        {
            flag = 1;
            keyword = txtSearchKey.Text;
            CategoryDataBind();
            txtSearchKey.Text = "";
        }
    }

    protected void gvCategory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCategory.EditIndex = e.NewEditIndex;
        CategoryDataBind();
    }

    protected void gvCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCategory.EditIndex = -1;
        CategoryDataBind();

    }

    protected void gvCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            //获取编辑行
            GridViewRow row = gvCategory.Rows[e.RowIndex];
            //获取编辑数据id
            int cid = int.Parse(row.Cells[0].Text);
            //从数据库中删除该数据
            categoryService.DeleteCategoryById(cid);
            Response.Write("<script>alert('删除成功')</script>");
            CategoryDataBind();
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
        
    }

    protected void gvCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCategory.PageIndex = e.NewPageIndex;
        CategoryDataBind();

    }

    protected void gvCategory_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void gvCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            //获取编辑行
            GridViewRow row = gvCategory.Rows[e.RowIndex];
            //获取编辑数据
            int cid = int.Parse(row.Cells[0].Text);
            string newName = ((TextBox)(row.Cells[1].FindControl("txtNewCategoryName"))).Text;
            //更新
            categoryService.UpdateCategoryNameById(cid, newName);
            gvCategory.EditIndex = -1;
            CategoryDataBind();
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}