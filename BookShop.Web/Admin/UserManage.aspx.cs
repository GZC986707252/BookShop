using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

public partial class Admin_UserManage : System.Web.UI.Page
{
    UserService userService = new UserService();

    static int flag = 0;    //功能定位标志 0-显示全部、1-普通用户、2-管理员、3-搜索
    static string Keyword = null;    //搜索关键字
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString.Count != 0)
                {
                    flag = int.Parse(Request.QueryString["type"]);
                    ddlType.SelectedIndex = flag;
                    UserDataBind();
                }
                else
                {
                    flag = 0;
                    UserDataBind();
                }
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
        
    }

    public void UserDataBind()
    {
        //显示全部
        if (flag == 0)
        {
            Bind(userService.GetAllUserInfo());
        }
        //显示普通用户
        else if (flag == 1)
        {
            Bind(userService.GetUserInfosByType("普通用户"));
        }
        //显示管理员
        else if (flag == 2)
        {
            Bind(userService.GetUserInfosByType("管理员"));
        }
        else
        {
            Bind(userService.GetUserInfosByKeyword(Keyword));
        }

     }

    public void Bind(IList list)
    {
        if (list.Count != 0)
        {
            lblMsg.Text = "当前共有" + list.Count + "条数据！";
            gvUserManage.Visible = true;
            gvUserManage.DataSource = list;
            gvUserManage.DataBind();
        }
        else
        {
            lblMsg.Text = "暂时没有任何数据";
            gvUserManage.Visible = false;
        }
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if(txtSearchKey.Text.Length!=0)
        {
            flag = 3;
            Keyword = txtSearchKey.Text;
            UserDataBind();
            txtSearchKey.Text = "";
        }
    }

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
     {
        flag = int.Parse(ddlType.SelectedValue);
        UserDataBind();
    }

    //编辑状态下
    protected void gvUserManage_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvUserManage.EditIndex = e.NewEditIndex;
        UserDataBind();
    }

    protected void gvUserManage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvUserManage.EditIndex = -1;
        UserDataBind();
    }

    //更新操作
    protected void gvUserManage_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            //获取编辑行
            GridViewRow row = gvUserManage.Rows[e.RowIndex];
            //获取编辑数据
            int uid = int.Parse(row.Cells[0].Text);
            string type = ((DropDownList)(row.Cells[4].FindControl("ddlUserType"))).SelectedValue;
            //更新
            userService.ChangeUserTypeById(uid, type);
            gvUserManage.EditIndex = -1;
            UserDataBind();
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
        
    }

    protected void gvUserManage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            //获取编辑行
            GridViewRow row = gvUserManage.Rows[e.RowIndex];
            //获取编辑数据
            int uid = int.Parse(row.Cells[0].Text);
            //从数据库中删除该数据
            userService.DeleteUserById(uid);
            Response.Write("<script>alert('删除成功')</script>");
            UserDataBind();
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
        
    }

    protected void gvUserManage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUserManage.PageIndex = e.NewPageIndex;
        UserDataBind();
    }

    protected void gvUserManage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                //获取删除链接按钮
                LinkButton linkbtnDelete = (LinkButton)e.Row.Cells[7].Controls[0];
                //添加客户端提示
                linkbtnDelete.OnClientClick = "return confirm('确定要删除吗？')";
            }
            catch
            {
            }
        }
    }

}