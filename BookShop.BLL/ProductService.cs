using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.DAL;

namespace BookShop.BLL
{
    public class ProductService
    {
        BookShopDataContext db = new BookShopDataContext();

        //获取所有商品
        public List<Books> GetAllBooks()
        {
            return  (from r in db.Books
                           select r).ToList();
        }

        //根据商品id获取相应的商品信息
        public Books GetBookInfoByBookId(int id)
        {
            return (from r in db.Books
                    where r.BookId == id
                    select r).FirstOrDefault();
        }

        //根据分类id获取该类商品
        public List<Books> GetBooksByCategoryId(int categoryid)
        {
            return (from r in db.Books
                    where r.CategoryId == categoryid
                    select r).ToList();
        }

        //根据不同方式，搜索关键字查找商品 , mode代表搜索方式，按书名、ISBN、作者、出版社方式搜索
        public List<Books> GetBooksByKeyword(string keyword,string mode)
        {
            if (mode.Equals("BookName"))
            {
                return (from r in db.Books
                        where SqlMethods.Like(r.BookName, "%" + keyword + "%")
                        select r).ToList();
            }
            else if (mode.Equals("ISBN"))
            {
                return (from r in db.Books
                        where r.ISBN== keyword
                        select r).ToList();
            }
            else if (mode.Equals("Author"))
            {
                return (from r in db.Books
                        where SqlMethods.Like(r.Author, "%" + keyword + "%")
                        select r).ToList();
            }
            else
            {
                return (from r in db.Books
                        where SqlMethods.Like(r.PubHouse, "%" + keyword + "%")
                        select r).ToList();
            }
        } 

        //根据书籍点赞量降序排序
        public List<Books> GetBooksByDescend()
        {
            return (from r in db.Books
                    orderby r.PraiseQty descending
                    select r).ToList();

          }

        //更新书籍点赞量
        public void UpdataPraiseQty(int bookid,int count)
        {
            Books book = (from r in db.Books
                          where r.BookId == bookid
                          select r).First();
            book.PraiseQty += count;
            db.SubmitChanges();
        }

        //根据id删除数据
        public void DeleteBookById(int id)
        {
            Books book = (from r in db.Books
                          where r.BookId == id
                          select r).FirstOrDefault();
            db.Books.DeleteOnSubmit(book);
            db.SubmitChanges();
        }

        //添加商品信息  返回书籍ID
        public int AddToBooks(int categoryId , string bookName ,string isbn, string author ,string pubHouse ,string bookImage,string descn,decimal listPrice,int qty)
        {
            Books book = new Books
            {
                CategoryId = categoryId,
                BookName = bookName,
                ISBN = isbn,
                Author = author,
                PubHouse = pubHouse,
                BookImage = bookImage,
                BookDescn = descn,
                ListPrice = listPrice,
                Quantity = qty,
                PraiseQty = 100
            };
            db.Books.InsertOnSubmit(book);
            db.SubmitChanges();
            return book.BookId;
        }


        //更新商品信息，图片单独更新
        public void UpdateBookInfoById(int bookId,int categoryId, string bookName, string isbn, string author, string pubHouse, string descn, decimal listPrice, int qty)
        {
            Books book = (from r in db.Books
                          where r.BookId == bookId
                          select r).First();
            book.CategoryId = categoryId;
            book.BookName = bookName;
            book.ISBN = isbn;
            book.Author = author;
            book.PubHouse = pubHouse;
            book.BookDescn = descn;
            book.ListPrice = listPrice;
            book.Quantity = qty;
            db.SubmitChanges();
        }

        //更新商品图片
        public void UpdateBookImageById(int bookId, string imgPath)
        {
            Books book = (from r in db.Books
                          where r.BookId == bookId
                          select r).First();
            book.BookImage = imgPath;
            db.SubmitChanges();
        }


    }
}
