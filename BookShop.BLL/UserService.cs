using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.SqlClient;

using BookShop.DAL;
using System.Data.Linq;

namespace BookShop.BLL
{
    public class UserService
    {
        BookShopDataContext db = new BookShopDataContext();

        //用户登录验证，验证成功返回用户id，否则返回0
        public int CheckLogin(string name,string password)
        {
            UserInfo user = (from r in db.UserInfo
                         where r.UserName == name && r.UserPsd == password
                         select r).FirstOrDefault();
            //用户名和密码正确
            if (user != null)
            {
                return user.UserId;
            }
            //用户名和密码不正确
            else
            {
                return 0;
            }
        }

        //判断用户名是否存在,存在返回true，否则，返回false
        public bool IsNameExist(string name)
        {
            UserInfo user = (from r in db.UserInfo
                            where r.UserName == name
                            select r).FirstOrDefault();
            if (user!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //判断Customer表中是否存在输入的用户名和邮箱
        //当输入的用户名和邮箱存在时返回true，否则返回false
        public bool IsEmailExist(string name, string email)
        {
            UserInfo user = (from c in db.UserInfo
                                 where c.UserName == name && c.Email == email
                                 select c).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //创建新用户
        public void Insert(string name, string password, string email)
        {
            UserInfo user = new UserInfo {
                UserName = name,
                UserPsd = password,
                Email = email,
                Amount = (decimal)10000.00,
                UserType = "普通用户",
                JoinDate = DateTime.Now
                };
            db.UserInfo.InsertOnSubmit(user);
            db.SubmitChanges();
        }

        //获取用户类型，返回用户类型字符串
        public string GetUserType(int id)
        {
            UserInfo user = (from r in db.UserInfo
                             where r.UserId == id
                             select r).FirstOrDefault();
            if (user != null)
            {
                return user.UserType;
            }
            else
            {
                return null;
            }
        }

        //获取全部用户信息
        public List<UserInfo> GetAllUserInfo()
        {
            return (from r in db.UserInfo
                    select r).ToList();

        }

        //根据id返回相应用户信息
        public UserInfo GetUserInfoById(int id)
        {
            return (from r in db.UserInfo
                    where r.UserId == id
                    select r).FirstOrDefault();
        }


        //支付密码验证
        public bool CheckPayPassword(int id ,string payPsd)
        {
            UserInfo user = (from r in db.UserInfo
                            where r.UserId == id && r.PayPsd == payPsd
                            select r).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //用户余额充值
        public void AmountRecharge(int id,decimal amount)
        {
            UserInfo user = (from r in db.UserInfo
                             where r.UserId == id
                             select r).First();
            user.Amount +=amount;
            db.SubmitChanges();
        }

        //用户付款操作
        public void UserAmountPaying(int uid,decimal payAmount)
        {
            UserInfo user = (from r in db.UserInfo
                                 where r.UserId == uid
                                 select r).First();
            user.Amount = user.Amount - payAmount;
            db.SubmitChanges();

        }

        //更新用户信息
        public void UpdataUserInfo(int id , string name ,string email , string address)
        {
            UserInfo user = (from r in db.UserInfo
                             where r.UserId == id
                             select r).First();
            user.UserName = name;
            user.Email = email;
            user.UserAdd = address;
            db.SubmitChanges();
        }

        //更新登录密码 先判断旧密码是否正确，正确则更改并返回true，反之返回false
        public bool UpdataLoginPsd(int id,string oldPsd,string newPsd)
        {
            UserInfo user = (from r in db.UserInfo
                             where r.UserId == id && r.UserPsd == oldPsd
                             select r).FirstOrDefault();
            if (user != null)
            {
                user.UserPsd = newPsd;
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //初始化支付密码
        public bool PayPsdInit(int id,string newPayPsd)
        {
            UserInfo user = (from r in db.UserInfo
                             where r.UserId == id && r.PayPsd == null
                             select r).FirstOrDefault();
            if (user != null)
            {
                user.PayPsd = newPayPsd;
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //重置支付密码
        public void ResetPayPsd(int id, string newPayPsd)
        {
            UserInfo user = (from r in db.UserInfo
                             where r.UserId == id
                             select r).First();
                user.PayPsd = newPayPsd;
                db.SubmitChanges();
        }

        //重置登录密码
        public string ResetPassword(string name,string email)
        {
            //伪随机数
            Random rand = new Random();
            string  newPsd = rand.Next(100000, 999999).ToString();
            UserInfo user = (from r in db.UserInfo
                             where r.UserName == name && r.Email == email
                             select r).First();
            user.UserPsd = newPsd;
            db.SubmitChanges();
            return newPsd;
        }

     //更改用户类型
     public void ChangeUserTypeById(int id,string type)
        {
            UserInfo user = (from r in db.UserInfo
                             where r.UserId == id
                             select r).First();
            user.UserType = type;
            db.SubmitChanges();
        }

        //删除用户
        public void DeleteUserById(int id)
        {
            UserInfo user = (from r in db.UserInfo
                             where r.UserId == id
                             select r).FirstOrDefault();
            db.UserInfo.DeleteOnSubmit(user);
            db.SubmitChanges();

        }

       //根据用户类型获取该类型用户信息
       public List<UserInfo> GetUserInfosByType(string type)
        {
            return (from r in db.UserInfo
                    where r.UserType == type
                    select r).ToList();

        }

        //根据用户名模糊查找用户
        public List<UserInfo> GetUserInfosByKeyword(string keyword)
        {
            return (from r in db.UserInfo
                    where SqlMethods.Like(r.UserName, "%" + keyword + "%")
                    select r).ToList();
        }

        //更新用户头像
        public void SetOrUpdateUserHeadImg(int id,byte[] data)
        {
            UserInfo user = (from r in db.UserInfo
                             where r.UserId == id
                             select r).First();
            user.UserImage = data;
            db.SubmitChanges();

        }

        //获取用户头像  返回byte[] 字节数组
        public byte[] GetUserHeadImgById(int id)
        {
            UserInfo user = (from r in db.UserInfo
                             where r.UserId == id
                             select r).First();
            if (user.UserImage != null)
            {
                //返回当前二进制对象的字节数组
                return user.UserImage.ToArray();
            }
            else
            {
                return null;
            }
        }

    }
}
