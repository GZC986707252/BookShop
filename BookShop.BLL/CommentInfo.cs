using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.SqlClient;

using BookShop.DAL;

namespace BookShop.BLL
{
    public class CommentInfo
    {
        BookShopDataContext db = new BookShopDataContext();

        //根据商品id获取该商品评论信息，根据最新时间排序（降序）
        public List<Comment> GetCommentsByBookId(int bid)
        {
            return (from r in db.Comment
                    where r.BookId == bid
                    orderby r.ComDateTime descending
                    select r).ToList();
        }

        //根据用户id获取该用户的所有评论信息
        public List<Comment> GetCommentsByUserId(int uid)
        {
            return (from r in db.Comment
                    where r.UserId == uid
                    orderby r.ComDateTime descending
                    select r).ToList();
        }

        //向评论信息表添加评论信息
        public void InsertComments(int bookId,int userId,string txtContent)
        {
            Comment comment = new Comment {
                BookId = bookId,
                UserId = userId,
                TextContent = txtContent,
                ComDateTime = DateTime.Now.ToLocalTime(),
            };
            db.Comment.InsertOnSubmit(comment);
            db.SubmitChanges();
        }

        //判断用户是否存在评论信息
        public bool IsCommentsEmptyByUserId(int id)
        {
            if (GetCommentsByUserId(id).Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
     //根据用户id清空评论
     public void ClearCommentsByUserId(int id)
        {
            var result = from r in db.Comment
                         where r.UserId == id
                         select r;
            db.Comment.DeleteAllOnSubmit(result);
            db.SubmitChanges();

        }

        //获取所有评论信息
        public IList GetAllComments()
        {
            return (from r in db.Comment
                    orderby r.ComDateTime descending
                    select new {
                        r.CommentId,
                        r.BookId,
                        r.UserInfo.UserName,
                        r.TextContent,
                        r.ComDateTime
                    }).ToList();
        }

        //根据搜索方式搜索
        public IList GetCommentsByKeyword(string keyword,string type)
        {
            if (type.Equals("Context"))
            {
                return (from r in db.Comment
                        where SqlMethods.Like(r.TextContent,"%"+keyword+"%")
                        orderby r.ComDateTime descending
                        select new
                        {
                            r.CommentId,
                            r.BookId,
                            r.UserInfo.UserName,
                            r.TextContent,
                            r.ComDateTime
                        }).ToList();
            }
            else if(type.Equals("UserName"))
            {
                return (from r in db.Comment
                        where SqlMethods.Like(r.UserInfo.UserName, "%" + keyword + "%")
                        orderby r.ComDateTime descending
                        select new
                        {
                            r.CommentId,
                            r.BookId,
                            r.UserInfo.UserName,
                            r.TextContent,
                            r.ComDateTime
                        }).ToList();
            }
            else if (type.Equals("BookId"))
            {
                return (from r in db.Comment
                        where r.BookId==int.Parse(keyword)
                        orderby r.ComDateTime descending
                        select new
                        {
                            r.CommentId,
                            r.BookId,
                            r.UserInfo.UserName,
                            r.TextContent,
                            r.ComDateTime
                        }).ToList();
            }
            else
            {
                return null;
            }
        }

        //删除评论
        public void DeleteCommentById(int id)
        {
            Comment comment = (from r in db.Comment
                               where r.CommentId == id
                               select r).First();
            db.Comment.DeleteOnSubmit(comment);
            db.SubmitChanges();

        }

    }
}
