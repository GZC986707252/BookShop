using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

public partial class Default : System.Web.UI.Page
{
    ProductService ProService = new ProductService();

    protected void Page_Load(object sender, EventArgs e)
    {
        ProDisplayInit();
    }

    

   //商品搜索
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string str = "";
        if (TxtSearchInfo.Text.Length != 0)
        {
            string keyword = TxtSearchInfo.Text.ToString().Trim();
            var sBooks = ProService.GetBooksByKeyword(keyword,"BookName");
            if (sBooks.Count != 0)
            {
                foreach (var book in sBooks)
                {
                    str += ProDisplay.GetProInfoCard(book.BookId, book.BookName, book.ListPrice.ToString(), book.BookImage);
                }
                divProDisplay.InnerHtml = str;
            }
            else
            {
                divProDisplay.InnerHtml = "<label style='font-size:larger;'>暂时找不到你想要的书籍！</label>";
            }
        }
        else
        {
            divProDisplay.InnerHtml = "<label style='font-size:larger;'>请输入搜索关键字！</label>";
        }
    }

   //商品展示初始化,即先展示全部商品
   public void ProDisplayInit()
    {
        string str = "";
        var allBooks = ProService.GetAllBooks();
        foreach(var book in allBooks)
        {
            str += ProDisplay.GetProInfoCard(book.BookId, book.BookName, book.ListPrice.ToString(), book.BookImage);
        }
        divProDisplay.InnerHtml = str;
    }

    //根据分类id展示相应商品
    public void ProDisplayByCategoryId(int cid)
    {
        string str = "";
        var allBooks = ProService.GetBooksByCategoryId(cid);
        foreach (var book in allBooks)
        {
            str += ProDisplay.GetProInfoCard(book.BookId, book.BookName, book.ListPrice.ToString(), book.BookImage);
        }
        divProDisplay.InnerHtml = str;
    }

    /*  以下是商品分类展示   */
    //显示全部商品
    protected void BtnDisplayAll_Click(object sender, EventArgs e)
    {
        ProDisplayInit();
    }
    //小说
    protected void BtnCategoryId_1_Click(object sender, EventArgs e)
    {
        ProDisplayByCategoryId(1);
    }
    //经营
    protected void BtnCategoryId_2_Click(object sender, EventArgs e)
    {
        ProDisplayByCategoryId(2);
    }
    //社科
    protected void BtnCategoryId_3_Click(object sender, EventArgs e)
    {
        ProDisplayByCategoryId(3);
    }
    //生活
    protected void BtnCategoryId_4_Click(object sender, EventArgs e)
    {
        ProDisplayByCategoryId(4);
    }
    //教育
    protected void BtnCategoryId_5_Click(object sender, EventArgs e)
    {
        ProDisplayByCategoryId(5);
    }
    //文艺
    protected void BtnCategoryId_6_Click(object sender, EventArgs e)
    {
        ProDisplayByCategoryId(6);
    }
}
    