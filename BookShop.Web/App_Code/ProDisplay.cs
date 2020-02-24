using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ProDisplay 的摘要说明
/// </summary>
public class ProDisplay
{

    public static string GetProInfoCard(int bookId, string bookName, string bookPrice, string bookPath)
    {
        if (bookPath.Length==0)
        {
            bookPath = "~/Images/null.png";
        }
        string str1 = "<div class='layui-col-lg2'><div class='layui-card text-center'><div class='layui-card-header text-hidden'><a href='ProDetails.aspx?Book_Id=" + bookId + "'>" + bookName + "</a></div>";  //卡片头部标题
        string str2 = "<div class='layui-card-body'><a href='ProDetails.aspx?Book_Id=" + bookId + "' target='_blank'><img src='" + 
            bookPath.Substring(2) + "' width='150px' height='150px'/></a>";  //卡片图片显示
        string str3 = "<div style='color: red; font-size:medium; '>¥" + bookPrice + "</div></div></div></div>";   //卡片价格显示
        return str1 + str2 + str3;
    }
}