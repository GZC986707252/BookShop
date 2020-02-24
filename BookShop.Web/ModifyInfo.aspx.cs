using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

public partial class ModifyInfo : System.Web.UI.Page
{
    UserService UService = new UserService();
    protected void Page_Load(object sender, EventArgs e)
    {
        //初始化，填充各项信息
        if (!Page.IsPostBack)
        {
            if (Session["UserId"] != null)
            {
                int uid = int.Parse(Session["UserId"].ToString());
                var user = UService.GetUserInfoById(uid);
                txtUserName.Text = user.UserName;
                txtEmail.Text = user.Email;
                txtAddress.Text = user.UserAdd;
                HeadImg.ImageUrl = "HeadImage.aspx?id=" + Session["UserId"];
            }
        }
    }

    //修改信息处理
    protected void BtnModifyInfo_Click(object sender, EventArgs e)
    {
        
        if (Session["UserId"] != null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            if (Page.IsValid)
            {
                UService.UpdataUserInfo(uid, txtUserName.Text, txtEmail.Text, txtAddress.Text);
                Session["UserName"] = txtUserName.Text.ToString();
                Response.Write("<script>alert('修改成功！') </script>");
                Response.Write("<script>window.location.href='ModifyInfo.aspx'</script>");
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void BtnUploadImg_Click(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
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
                UService.SetOrUpdateUserHeadImg(uid, headImgData);
                Response.Write("<script>alert('上传成功！') </script>");
                Response.Write("<script>window.location.href='ModifyInfo.aspx'</script>");
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}