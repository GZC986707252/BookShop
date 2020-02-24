using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;


public partial class Security : System.Web.UI.Page
{
    UserService UService = new UserService();
    static string code = null;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    //修改登录密码
    protected void BtnPsdRevise_Click(object sender, EventArgs e)
    {
        //登录密码一旦修改后，删除当前用户会话并重定向到登录页面
        if (Session["UserId"] != null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            if (txtOldPsd.Text.Length != 0 && txtNewPsd.Text.Length != 0 && txtNewPsdConfirm.Text.Length != 0)
            {
                if (txtNewPsd.Text.ToString().Trim().Equals(txtNewPsdConfirm.Text.ToString().Trim()))
                {
                    if(UService.UpdataLoginPsd(uid, txtOldPsd.Text, txtNewPsd.Text)){
                        Session.Clear();
                        lblRevisePsdMsg.Text = "密码修改成功！请重新登录！";
                    }
                    else
                    {
                        lblRevisePsdMsg.Text = "请检查原密码是否正确！";
                    }
                }
                else
                {
                   lblRevisePsdMsg.Text = "两次新密码不一致！";
                }
            }
            else
            {
                 lblRevisePsdMsg.Text = "输入不能为空！";
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    //设置支付密码
    protected void BtnPayPsdInit_Click(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            if (txtPayPsdInit.Text.Length != 0 && txtPayPsdInitConfirm.Text.Length != 0)
            {
                if (txtPayPsdInit.Text.ToString().Trim().Equals(txtPayPsdInitConfirm.Text.ToString().Trim()))
                {
                    if (UService.PayPsdInit(uid,txtPayPsdInit.Text))
                    {
                        lblPayPsdInitMsg.Text = "支付密码设置成功！";
                    }
                    else
                    {
                        lblPayPsdInitMsg.Text = "你已经设置过支付密码了！如果你忘了密码，请试着重置！";
                    }
                }
                else
                {
                   lblPayPsdInitMsg.Text = "两次密码不一致！";
                }
            }
            else
            {
                lblPayPsdInitMsg.Text = "输入不能为空！";
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    //重置支付密码
    protected void BtnPayPsdRevise_Click(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            if (txtVerificationCode.Text.Length != 0 && txtNewPayPsd.Text.Length != 0&& txtNewPayPsdConfirm.Text.Length != 0)
            {
                if (txtNewPayPsd.Text.ToString().Trim().Equals(txtNewPayPsdConfirm.Text.ToString().Trim()))
                {
                    //用EmailSender的方法返回的验证码字符串code
                    if (txtVerificationCode.Text.ToString().Equals(code)){
                        UService.ResetPayPsd(uid, txtNewPayPsd.Text);
                        code = null;
                        lblRevisePayPsdMsg.Text = "支付密码重置成功！";
                    }
                    else
                    {
                           lblRevisePayPsdMsg.Text = "验证码不正确！";
                    }
                }
                else
                {
                       lblRevisePayPsdMsg.Text = "两次密码不一致！";
                }
            }
            else
            {
                lblRevisePayPsdMsg.Text = "输入不能为空！";
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    //向用户邮箱发送验证码
    protected void BtnSendVerificationCode_Click(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            string email = UService.GetUserInfoById(uid).Email;
            EmailSender emailSender = new EmailSender();
            code = emailSender.VerificationCodeSend(email);
            lblVfcMsg.Text = "验证码已发至邮箱，请及时查看！";
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
        
    }


}