using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;


public partial class Register : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        UserService UService = new UserService();
        if (Page.IsValid)
        {
            if (UService.IsNameExist(txtUserName.Text.ToString())){
                lblRegisterMsg.Text = "用户名已存在！";
            }
            else
            {
                Session.Clear();
                UService.Insert(txtUserName.Text, txtPsd.Text, TxtEmail.Text);
                Response.Write("<script>alert('注册成功！') </script>");
                Response.Write("<script>window.location.href='Login.aspx?name="+ txtUserName.Text +"'</script>");
          //      Response.Redirect("Login.aspx?name=" + txtUserName.Text);
            }
        }
    }

}