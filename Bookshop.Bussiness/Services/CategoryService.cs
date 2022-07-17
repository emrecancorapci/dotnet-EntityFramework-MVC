using System.Collections.Generic;
using System.Linq;
using Bookshop.Business.Interfaces;
using Bookshop.DataAccess.Data;
using Bookshop.Entities;

namespace Bookshop.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private BookShopDbContext dbContext;

        public CategoryService(BookShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<Category> GetCategories()
        {
            return dbContext.Categories.ToList();
        }
    }
}