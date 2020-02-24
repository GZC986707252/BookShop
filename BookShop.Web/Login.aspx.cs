using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["name"] != null)
        {
            txtUserName.Text = Request.QueryString["name"].ToString();
        }
    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        UserService UService = new UserService();
        if (Page.IsValid)
        {
            Session.Clear();
            int UserId = UService.CheckLogin(txtUserName.Text.Trim(), txtPsd.Text.Trim());
            //验证成功，返回用户id
            if (UserId > 0)
            {
                Session["UserName"] = txtUserName.Text;
                Session.Timeout = 60;
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
                if (LoginType.Checked)
                {
                    //后台登录
                    switch (UService.GetUserType(UserId))
                    {
                        case "普通用户":
                            lblLoginMsg.Text = "抱歉，只有管理员才能登录哦！";
                            LoginType.Checked = false;
                            break;
                        case "管理员":
                            Session["AdminUserId"] = UserId;
                            Response.Redirect("~/Admin/AdminInfo.aspx");
                            break;
                    }
                }
                else
                {
                    //普通登录
                    Session["UserId"] = UserId;
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                lblLoginMsg.Text = "用户名或密码错误！";
            }
        }

    }
}