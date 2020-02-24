using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.Linq.SqlClient;

using BookShop.DAL;


namespace BookShop.BLL
{
    public class OrderService
    {
        BookShopDataContext db = new BookShopDataContext();
        UserService UserSvi = new UserService();
        //创建订单
        public void CreateOrder(int userId,string userName,string userAdd,string zip ,string tel)
        {
            //使用数据库事务
            using (TransactionScope ts = new TransactionScope())
            {
                //获取购物车商品
                List<CartItem> cartItems = (from r in db.CartItem
                                            where r.UserId == userId
                                            select r).ToList();

                //创建订单头
                Order order = new Order
                {
                    UserId = userId,
                    UserName = userName,
                    UserAddress = userAdd,
                    Zip = zip,
                    Tel = tel,
                    OrderDate = DateTime.Now,
                    Status = "待审核"
                };

                OrderItem orderItem = null;
                Books books = null;

                foreach(CartItem cartItem in cartItems)
                {
                    //依次添加每件商品为订单明细
                    orderItem = new OrderItem();
                    orderItem.OrderId = order.OrderId;
                    orderItem.ProName = cartItem.ProName;
                    orderItem.ProPrice = cartItem.ProPrice;
                    orderItem.ProQty = cartItem.ProQty;
                    orderItem.TotalPrice = cartItem.ProPrice * cartItem.ProQty;
                    order.OrderItem.Add(orderItem);
                    
                    //修改Product表的商品库存
                    books = (from p in db.Books
                             where p.BookId == cartItem.BookId
                               select p).First();
                    books.Quantity = books.Quantity - cartItem.ProQty;

                    //修改用户金额
                    UserSvi.UserAmountPaying(userId, decimal.Parse(orderItem.TotalPrice.ToString()));

                    //从购物车中删除购物项
                    db.CartItem.DeleteOnSubmit(cartItem);
                }
                db.Order.InsertOnSubmit(order);
                db.SubmitChanges();
                ts.Complete(); //提交事务
            }
        }

        //更改订单状态
        public void UpdateOrderStatus(int orderId,string status)
        {
            Order order = (from o in db.Order
                           where o.OrderId == orderId
                           select o).First();
            order.Status = status;
            db.SubmitChanges();
        }

        //获取所有订单信息
        public List<Order> GetAllOrders()
        {
            return (from r in db.Order
                    orderby r.OrderDate descending
                    select r).ToList();

        }

        //根据OrderId获取订单信息
        public Order GetOrderById(int id)
        {
            return (from r in db.Order
                    where r.OrderId == id
                    orderby r.OrderDate descending
                    select r).FirstOrDefault();

        }

        //根据订单状态获取订单信息
        public List<Order> GetOrdersByStatus(string status)
        {
            return (from r in db.Order
                    where r.Status == status
                    orderby r.OrderDate descending
                    select r).ToList();

        }

        //根据用户id获取订单Order信息
        public List<Order> GetOrdersByUserId(int uid)
        {
            return (from o in db.Order
                    where o.UserId == uid
                    orderby o.OrderDate descending
                    select o).ToList();

        }

        //根据OrderId返回OrderItem信息
        public List<OrderItem> GetOrderItemsByOrderId(int oid)
        {
            return (from oi in db.OrderItem
                    where oi.OrderId == oid
                    select oi).ToList();
        }

        //根据OrderId删除订单
        public void DeleteOrderById(int id)
        {
            Order order = (from r in db.Order
                           where r.OrderId == id
                           select r).FirstOrDefault();
            db.Order.DeleteOnSubmit(order);
            db.SubmitChanges();

        }

        //根据用户名模糊查询订单
        public List<Order> GetOrdersByKeyword(string keyword)
        {
            return (from r in db.Order
                    where SqlMethods.Like(r.UserName, "%" + keyword + "%")
                    orderby r.OrderDate descending
                    select r).ToList();

        }


    }
}
