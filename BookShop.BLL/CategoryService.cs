using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.SqlClient;

using BookShop.DAL;

namespace BookShop.BLL
{
    public class CategoryService
    {
        BookShopDataContext db = new BookShopDataContext();

        //添加分类信息  先判断分类名是否存在
        public bool NewCategory(string categoryName)
        {
            Category result = (from r in db.Category
                               where r.CategoryName == categoryName
                               select r).FirstOrDefault();
            if (result == null)
            {
                Category category = new Category
                {
                    CategoryName = categoryName
                };
                db.Category.InsertOnSubmit(category);
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
           
        }

        //更改分类名称
        public void UpdateCategoryNameById(int id,string newCategoryName)
        {
            Category category = (from r in db.Category
                                 where r.CategoryId == id
                                 select r).First();
            category.CategoryName = newCategoryName;
            db.SubmitChanges();

        }

        //删除分类信息
        public void DeleteCategoryById(int id)
        {
            Category category = (from r in db.Category
                                 where r.CategoryId == id
                                 select r).First();
            db.Category.DeleteOnSubmit(category);
            db.SubmitChanges();
        }

        //获取所有分类信息
        public List<Category> GetAllCategories()
        {
            return (from r in db.Category
                    select r).ToList();

        }

        //模糊查找分类名
        public List<Category> GetCategoriesByKeyword(string keyword)
        {
            return (from r in db.Category
                    where SqlMethods.Like(r.CategoryName, "%" + keyword + "%")
                    select r).ToList();

        }

        //根据分类id获得分类名称，返回值为分类名
        public string GetCategoryNameById(int id)
        {
            return (from r in db.Category
                    where r.CategoryId == id
                    select r).First().CategoryName;
        }

    }
}
