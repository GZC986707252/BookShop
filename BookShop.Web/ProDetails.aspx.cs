using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

public partial class ProDetails : System.Web.UI.Page
{
    ProductService ProService = new ProductService();
    CommentInfo commentInfo = new CommentInfo();
    UserService UService = new UserService();
    CartItemService cartService = new CartItemService();
    CollectionsInfo collInfo = new CollectionsInfo();
    CategoryService categoryService = new CategoryService();


    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Book_Id"] != null)
            {
                int bid = int.Parse(Request.QueryString["Book_Id"].ToString());
                ProDetailsInit(bid);
                CommentDisplayInit(bid);
            }
        }
    }

    //商品详情初始化
    public void ProDetailsInit(int bookId)
    {
        var book = ProService.GetBookInfoByBookId(bookId);
        if (book != null)
        {
            if (book.BookImage.Length==0)
            {
                imgBook.ImageUrl = "~/Images/null.png";
            }
            else
            {
                imgBook.ImageUrl = book.BookImage;
            }
            lblBookName.Text = book.BookName;
            lblBookISBN.Text = book.ISBN;
            lblBookAuthor.Text = book.Author;
            lblPubHouse.Text = book.PubHouse;
            lblCategoryName.Text = categoryService.GetCategoryNameById(book.CategoryId);
            txtBookDescn.Text = book.BookDescn;
            lblQuantity.Text = book.Quantity.ToString();
            lblListPrice.Text= book.ListPrice.ToString();
            Page.Title = book.BookName;
        }
    }

    //评论区初始化
    public void CommentDisplayInit(int bookId)
    {
        string str = "";
        var comments = commentInfo.GetCommentsByBookId(bookId);
        if (comments.Count != 0)
        {
            foreach(var com in comments)
            {
                str += "<div class='layui-card' style='margin-right:10px;'>" +
                    "<div class='layui-card-header' style='color:#FF5722;'>" +
                        "<label>" +UService.GetUserInfoById(com.UserId).UserName + 
                        "</label><label style = 'float: right;'>" + com.ComDateTime + 
                        "</label>" +"</div><div class='layui-card-body' style='color: black;'>" + 
                        com.TextContent + "</div></div>";
                CommentDisplay.InnerHtml = str;
            }
        }
        else
        {
            CommentDisplay.InnerHtml = "<label style='font-size:larger;'>该商品下暂时没有评论！快来抢占沙发吧！</label>";
        }
    }


    //添加商品到购物车
    protected void BtnAddToCard_Click(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            int bid = int.Parse(Request.QueryString["Book_Id"].ToString());
            int uid = int.Parse(Session["UserId"].ToString());
            int qty = int.Parse(txtPurchaseQty.Text);
            //先判断购物车是否存在该商品，若不存在，则添加；存在，则提示已添加
            if (qty > 0 && qty <= 10)
            {
                if (!cartService.IsCartItemExist(bid, uid))
                {
                    var book = ProService.GetBookInfoByBookId(bid);
                    cartService.InsertIntoCartItem(uid, bid, book.BookName, decimal.Parse(book.ListPrice.ToString()), qty);
                    Response.Write("<script> alert('添加成功！')</script>");
                    Response.Write("<script>window.location.href='ProDetails.aspx?Book_Id="+ bid+"'</script>");
                }
                else
                {
                    lblAddCartMsg.Text = "你已经添加过该商品了！";
                }
            }
            else
            {
                lblAddCartMsg.Text = "购买数量必须大于0并且不能大于10！";
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }


    //评论提交
    protected void BtnComment_Click(object sender, EventArgs e)
    {
        //判断登录状态，在线才能评论，直接调用评论初始化函数，遍历数据库评论信息表
        if (Session["UserId"] != null)
        {
            if (Request.QueryString["Book_Id"] != null)
            {
                if (TxtComment.Text.Length != 0)
                {
                    int bid = int.Parse(Request.QueryString["Book_Id"].ToString());
                    int uid = int.Parse(Session["UserId"].ToString());
                    commentInfo.InsertComments(bid, uid, TxtComment.Text);
                    CommentDisplayInit(bid);
                    lblErrorMsg.Text= "发表成功！";
                    TxtComment.Text = "";
                }
                else
                {
                    lblErrorMsg.Text = "有什么就直说嘛，别藏在心里哦！";
                }
            }
        }
        else
        {
            lblErrorMsg.Text = "你还没登录呢！请登录后再吐槽吧！";
        }
    }

    //点赞
    protected void BtnPraise_Click(object sender, EventArgs e)
    {
        int bid = int.Parse(Request.QueryString["Book_Id"].ToString());
        if (Session["praiseCount"] != null)
        {
            int count = int.Parse(Session["praiseCount"].ToString());
            if (count >= 10)
            {
                lblTipMsg.Text = "最多只能点赞10次！";
            }
            else
            {
                count++;
                Session["praiseCount"] = count;
                ProService.UpdataPraiseQty(bid, 1);
                lblTipMsg.Text = "谢谢点赞&nbsp;+&nbsp;" + count+"！";
            }
        }
        else
        {
            Session["praiseCount"] = 1;
            ProService.UpdataPraiseQty(bid, 1);
            lblTipMsg.Text = "谢谢点赞&nbsp;+&nbsp;" + 1 + "！";
        }
    }

    //收藏
    protected void BtnAddToCollections_Click(object sender, EventArgs e)
    {
        int bid = int.Parse(Request.QueryString["Book_Id"].ToString());
        if (Session["UserId"] != null)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            if (!collInfo.IsBookInCollections(bid, uid))
            {
                var book = ProService.GetBookInfoByBookId(bid);
                collInfo.AddToCollections(bid, uid, book.BookName, decimal.Parse(book.ListPrice.ToString()));
                lblTipMsg.Text = "收藏成功！可到\"我的收藏\"查看！";
            }
            else
            {
                lblTipMsg.Text = "你已经收藏过该商品了！";
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }


}