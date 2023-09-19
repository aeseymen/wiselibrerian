using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.Business.ViewModels;
using WiseLibrarian.DataAccess.Entities;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.Business
{
    public class CategoryManager
    {
        public List<CategoryViewModel> GetCategories() 
        {
            using (var db = new DapperRepository())
            {
                var category = new Category();
                category.SetRepository(db);
                var sql = "Select * From Categories";
                var categoriesData = category.Repository.GetAll<Category>(sql).Select(s => new CategoryViewModel()
                {
                    CategoryId = s.CategoryId,
                    CategoryName = s.CategoryName
                }).ToList();
                return categoriesData;
            } 
        }

        public CategoryViewModel GetCategory(int id) 
        {
            using (var db = new DapperRepository())
            {
                var category = new Category();
                category.SetRepository(db);
                var sql = "Select * From Categories where CategoryId = @id";
                var categoryData = category.Repository
                    .GetById<Category>(sql, new {id})
                    .Select(s=> new CategoryViewModel()
                {
                    CategoryId=s.CategoryId,
                    CategoryName = s.CategoryName
                }).FirstOrDefault();
                return categoryData;
            }
        }

        public int DeleteCategory(Category category)
        {
            using (var db = new DapperRepository())
            {
                category.SetRepository(db);
                var sql = $"Delete from Categories where CategoryId = {category.CategoryId}";
                return category.Repository.Delete(sql);
            }
        }

        public int DeleteAllCategories()
        {
            using (var db = new DapperRepository())
            {
                var category = new Category();
                category.SetRepository(db);
                var sql = "DELETE FROM Categories";
                var deletedDatas = category.Repository.DeleteAll<Category>(sql);
                return deletedDatas;
            }
        }

        public int InsertCategory(Category category)
        {
            using (var db = new DapperRepository())
            {
                category.SetRepository(db);
                var sql = $"Insert into Category (CategoryName) values ('{category.CategoryName}')";
                return category.Repository.Insert(sql);
            }
        }

        public int UpdateCategory(Category category)
        {
            using (var db = new DapperRepository())
            {
                category.SetRepository(db);
                var sql = $"Update Categories set CategoryName='{category.CategoryName}' Where CategoryId={category.CategoryId}";
                return category.Repository.Update(sql);
            }
        }

    }
}
