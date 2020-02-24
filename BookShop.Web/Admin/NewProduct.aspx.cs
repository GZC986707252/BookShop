using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using BookShop.BLL;

public partial class Admin_NewProduct : System.Web.UI.Page
{
    ProductService ProService = new ProductService();
    private string UploadPath;

    protected void Page_Load(object sender, EventArgs e)
    {
        //默认将文件保存到网站根目录下BookImgs文件夹中
        UploadPath = Path.Combine(Server.MapPath("~/"), "BookImgs\\");
      //  lblUploadMsg.Text = UploadPath;
    }

    protected void BtnAddProduct_Click(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            if (Page.IsValid)
            {
                int categoryId = int.Parse(ddlCategoryId.SelectedValue);
                string bookName = txtBookName.Text;
                string isbn = txtISBN.Text;
                string author = txtAuthor.Text;
                string pubHouse = txtPubHouse.Text;
                string bookImg = "";
                string descn = txtDescn.Text;
                decimal listPrice = decimal.Parse(txtListPrice.Text);
                int qty = int.Parse(txtQty.Text);
                if (listPrice >= 0 && qty >= 0)
                {
                    bookImg = UploadImage();  //返回上传后的图片相对路径
                    if(bookImg!="error")
                    {
                        int bid = ProService.AddToBooks(categoryId, bookName, isbn, author, pubHouse, bookImg, descn, listPrice, qty);
                        Response.Write("<script>alert('添加成功！')</script>");
                        Response.Write("<script>window.location.href='ProUpdate.aspx?Book_Id=" + bid + "'</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('检查是否存在非法输入！')</script>");
                }
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        } 
    }

    public string UploadImage()
    {
        //上传图片
        if (BookImgUpload.PostedFile.FileName != "")
        {
            string fileName = BookImgUpload.PostedFile.FileName;   //获取上传文件名称
            string fileExt = Path.GetExtension(fileName);   //获取上传文件扩展名
            switch (fileExt)
            {
                case ".gif":
                case ".jpg":
                case ".png":
                    break;
                default:
                    lblUploadMsg.Text = "文件扩展名必须为jpg、png或gif！";
                    return "error";
            }
            string ResetName = DateTime.Now.ToString("yyyyMMddHHffss") + fileExt;  //重命名文件
            string fullPath = Path.Combine(UploadPath, ResetName);
            BookImgUpload.PostedFile.SaveAs(fullPath);
            lblUploadMsg.Text = "文件上传成功！";
            return "~/BookImgs/" + ResetName;
        }
        else
        {
            return "";
        }
    }

}