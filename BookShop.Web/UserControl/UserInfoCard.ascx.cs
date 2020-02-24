using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

public partial class UserControl_UserInfoCard : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserService us = new UserService();
        if (Session["UserId"] != null && Session["UserName"] != null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            var user = us.GetUserInfoById(uid);
            lblNickName.Text = "欢迎您，" + Session["UserName"].ToString();
            plUserInfo.Visible = true;
            lblInintial.Visible = false;
            lblUserId.Text = (user.UserId-99).ToString();
            lblLoginName.Text= Session["UserName"].ToString();
            lblEmail.Text = user.Email;
            lblUserType.Text = user.UserType;
            lblAmount.Text = user.Amount.ToString();
            lblAddress.Text = user.UserAdd;
        }
        else
        {
            lblNickName.Text = "您好，请登录哦！";
            plUserInfo.Visible = false;
            lblInintial.Visible = true;
        }
    }
}