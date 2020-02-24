using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.DAL;

namespace BookShop.BLL
{
    public class CartItemService
    {
        BookShopDataContext db = new BookShopDataContext();
         
        //判断用户购物车是否存在该商品
        public bool IsCartItemExist(int bid, int uid)
        {
            CartItem cart = (from r in db.CartItem
                             where r.BookId == bid && r.UserId == uid
                             select r).FirstOrDefault();
            if (cart != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //添加商品到购物车
        public void InsertIntoCartItem(int uid, int bid, string bName, decimal lPrice, int qty)
        {
            CartItem cartItem = new CartItem
            {
                UserId = uid,
                BookId = bid,
                ProName = bName,
                ProPrice = lPrice,
                ProQty = qty
            };
            db.CartItem.InsertOnSubmit(cartItem);
            db.SubmitChanges();

        }

        //根据用户id获取相应的购物车商品
        public List<CartItem> GetCartItemsByUserId(int id)
        {
            return (from r in db.CartItem
                    where r.UserId == id
                    select r).ToList();

        }


        //根据用户id清空相应的购物车数据
        public void ClearCartItemByUserId(int id)
        {
            var cartItems = from r in db.CartItem
                            where r.UserId == id
                            select r;
            db.CartItem.DeleteAllOnSubmit(cartItems);
            db.SubmitChanges();
        }

        //判断用户购物车是否为空
        public bool IsCartItemEmptyByUserId(int uid)
        {
            var cart = from r in db.CartItem
                       where r.UserId == uid
                       select r;
            if (cart.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //获取用户购物车数量
        public int GetTotalCartNum(int uid)
        {
           /* var cartItems = from r in db.CartItem
                            where r.UserId == uid
                            select r;
            return cartItems.Count();*/

            return db.CartItem.Count(c => c.UserId == uid);

        }

        //删除用户购物车单个商品
        public void DeleteCartItemByCartItemId(int bid,int uid)
        {
            CartItem cartItem = (from r in db.CartItem
                                 where r.BookId == bid&&r.UserId==uid
                                 select r).FirstOrDefault();
            db.CartItem.DeleteOnSubmit(cartItem);
            db.SubmitChanges();
        }




    }
}
