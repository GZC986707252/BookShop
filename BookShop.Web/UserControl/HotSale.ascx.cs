using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

public partial class UserControl_HotSale : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ProductService ProService = new ProductService();
        var books = ProService.GetBooksByDescend();
        int count = 0;
        string str = "<div class='layui-card'>";
        foreach (var book in books)
         {
            count++;
            str += "<div class='layui-card-body' style='font-size: large; padding-left: 10px;'>"
                                   + "<a href='ProDetails.aspx?Book_Id=" + book.BookId + "'>" + book.BookName + "</a>"
                                   + "<span style='float:right;color:red;'>¥" + book.ListPrice.ToString() + "</span></div>";
            if (count == 10)
            {
                break;
            }
         }
        HotSale.InnerHtml = str + "</div>";

    }


}