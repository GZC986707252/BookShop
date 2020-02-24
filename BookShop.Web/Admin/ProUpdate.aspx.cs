using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

public partial class Admin_ProUpdate : System.Web.UI.Page
{
    ProductService ProService = new ProductService();
    CategoryService categoryService = new CategoryService();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            if (!Page.IsPostBack)
            {
                int bid = int.Parse(Request.QueryString["Book_Id"].ToString());
                var book = ProService.GetBookInfoByBookId(bid);
                if (book != null)
                {
                    ddlCategoryId.SelectedValue = book.CategoryId.ToString();
                    txtBookName.Text = book.BookName;
                    txtISBN.Text = book.ISBN;
                    txtAuthor.Text = book.Author;
                    txtPubHouse.Text = book.PubHouse;
                    txtDescn.Text = book.BookDescn;
                    txtListPrice.Text = book.ListPrice.ToString();
                    txtQty.Text = book.Quantity.ToString();
                    if (book.BookImage.Length != 0)
                    {
                        bookImg.ImageUrl = book.BookImage;
                    }
                    else
                    {
                        bookImg.ImageUrl = "~/Images/null.png";
                    }
                }
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
        
    }

    protected void BtnUpdataProduct_Click(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            if (Page.IsValid)
            {
                int bookId = int.Parse(Request.QueryString["Book_Id"].ToString());
                int categoryId = int.Parse(ddlCategoryId.SelectedValue);
                string bookName = txtBookName.Text;
                string isbn = txtISBN.Text;
                string author = txtAuthor.Text;
                string pubHouse = txtPubHouse.Text;
                string descn = txtDescn.Text;
                decimal listPrice = decimal.Parse(txtListPrice.Text);
                int qty = int.Parse(txtQty.Text);
                if (listPrice >= 0 && qty >= 0)
                {
                    ProService.UpdateBookInfoById(bookId, categoryId, bookName, isbn, author, pubHouse, descn, listPrice, qty);
                    Response.Write("<script>alert('修改成功！')</script>");
                    Response.Write("<script>window.location.href='ProUpdate.aspx?Book_Id=" + bookId + "'</script>");
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

    //上传图片-----待完善
    protected void BtnUploadImg_Click(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] != null)
        {
            int bookId = int.Parse(Request.QueryString["Book_Id"].ToString());
            string bookImage = ProService.GetBookInfoByBookId(bookId).BookImage;
            string newFileExt = Path.GetExtension(BookImgUpload.PostedFile.FileName);   //获得上传文件扩展名
            switch (newFileExt)
            {
                case ".gif":
                case ".jpg":
                case ".png":
                    break;
                default:
                    lblUploadMsg.Text = "文件扩展名必须为jpg、png或gif！";
                    return;
            }
            if (bookImage.Length != 0)
            {
                
                string oldFilePath = Server.MapPath("~/") + bookImage.Substring(2);
                string newFilePath = Server.MapPath("~/")+bookImage.Substring(2);
                //删除原有图片
                File.Delete(oldFilePath);
                //上传文件
                BookImgUpload.PostedFile.SaveAs(newFilePath);
                Response.Buffer = true;   //清空页面缓存
                Response.Write("<script>alert('上传成功！')</script>");
                Response.Write("<script>window.location.href='ProUpdate.aspx?Book_Id=" + bookId + "'</script>");
            }
            else
            {
                string newFileName = DateTime.Now.ToString("yyyyMMddHHffss") + newFileExt;
                string newPath = Server.MapPath("~/") + "BookImgs//" + newFileName;
                bookImage = "~/BookImgs/" + newFileName;
                ProService.UpdateBookImageById(bookId, bookImage);
                BookImgUpload.PostedFile.SaveAs(newPath);
                Response.Write("<script>alert('上传成功！')</script>");
                Response.Write("<script>window.location.href='ProUpdate.aspx?Book_Id=" + bookId + "'</script>");
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}