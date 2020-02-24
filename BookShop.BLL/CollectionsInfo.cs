using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.DAL;

namespace BookShop.BLL
{
    public class CollectionsInfo
    {
        BookShopDataContext db = new BookShopDataContext();

        //将商品添加到用户收藏
        public void AddToCollections(int bid, int uid, string bName, decimal lPrice)
        {
            Collections collection = new Collections
            {
                BookId = bid,
                UserId = uid,
                BookName = bName,
                ListPrice = lPrice
            };
            db.Collections.InsertOnSubmit(collection);
            db.SubmitChanges();
        }

        //查询用户是否已经收藏该商品
        public bool IsBookInCollections(int bid,int uid)
        {
            Collections collection = (from r in db.Collections
                                      where r.BookId == bid && r.UserId == uid
                                      select r).FirstOrDefault();
            if (collection != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //判断用户收藏是否为空
        public bool IsCollectionsEmptyById(int id)
        {
            var result = from r in db.Collections
                         where r.UserId == id
                         select r;
            if (result.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //清空用户收藏夹
        public void ClearCollectionsByUserId(int id)
        {
            var result = from r in db.Collections
                         where r.UserId == id
                         select r;
            db.Collections.DeleteAllOnSubmit(result);
            db.SubmitChanges();

                        
        }

    }
}
