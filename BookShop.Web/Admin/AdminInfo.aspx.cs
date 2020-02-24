using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BookShop.BLL;

public partial class Admin_AdminInfo : System.Web.UI.Page
{
    UserService userService = new UserService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if(Session["AdminUserId"]!=null)
            {
                int id = int.Parse(Session["AdminUserId"].ToString());
                var admin = userService.GetUserInfoById(id);
                txtAdminName.Text = admin.UserName;
                txtEmail.Text = admin.Email;
                txtAddress.Text = admin.UserAdd;
                txtType.Text = admin.UserType;
                HeadImg.ImageUrl = "~/HeadImage.aspx?id=" + Session["AdminUserId"];
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }

    protected void BtnRevise_Click(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            txtAdminName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtAddress.ReadOnly = false;
            BtnRevise.Visible = false;
            BtnSubmint.Visible = true;
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
            
    }

    protected void BtnSubmint_Click(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            if (Page.IsValid)
            {
                int id = int.Parse(Session["AdminUserId"].ToString());
                userService.UpdataUserInfo(id, txtAdminName.Text, txtEmail.Text, txtAddress.Text);
                Session["UserName"] = txtAdminName.Text;
                Response.Write("<script> alert('修改成功！')</script>");
                Response.Write("<script>window.location.href='AdminInfo.aspx'</script>");
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void BtnUploadImg_Click(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            int uid = int.Parse(Session["AdminUserId"].ToString());
            if (HeadImgUpload.PostedFile.ContentLength != 0)
            {
                string FileExt = Path.GetExtension(HeadImgUpload.PostedFile.FileName);   //获得上传文件扩展名
                switch (FileExt)
                {
                    case ".jpg":
                    case ".png":
                        break;
                    default:
                        lblUploadMsg.Text = "文件扩展名必须为jpg或png！";
                        return;
                }
                byte[] headImgData = HeadImgUpload.FileBytes;
                userService.SetOrUpdateUserHeadImg(uid, headImgData);
                Response.Write("<script>alert('上传成功！') </script>");
                Response.Write("<script>window.location.href='AdminInfo.aspx'</script>");
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}