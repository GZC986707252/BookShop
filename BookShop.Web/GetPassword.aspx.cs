using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BookShop.BLL;

public partial class GetPassword : System.Web.UI.Page
{
    UserService userService = new UserService();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnGetPsd_Click(object sender, EventArgs e)
    {
        if(Page.IsValid)
        {
            if (!userService.IsNameExist(txtUserName.Text.Trim()))
            {
                lblMsg.Text = "用户名不存在！";
            }
            else 
            {
                if (!userService.IsEmailExist(txtUserName.Text.Trim(), txtEmail.Text.Trim()))
                {
                    lblMsg.Text = "邮箱不正确！";
                }
                else
                {
                    string newPsd = userService.ResetPassword(txtUserName.Text.Trim(), txtEmail.Text.Trim());
                    EmailSender emailSender = new EmailSender();
                    emailSender.PsdSend(txtEmail.Text.Trim(), newPsd);
                    lblMsg.Text = "重置密码已发送至邮箱！";
                }
            }
        }
    }
}