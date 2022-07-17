using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshop.DataAccess.Data;
using Bookshop.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookshop.DataAccess.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly BookShopDbContext context;

        public EFProductRepository(BookShopDbContext context)
        {
            this.context = context;
        }

        public async Task<IList<Product>> GetAllEntities()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetEntityById(int id)
        {
            // If searched object is already tracked by another, it can't find it.
            return await context.Products.FindAsync(id);
        }

        public async Task<int> Add(Product entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;

            await context.Products.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<int> Update(Product entity)
        {
            entity.ModifiedDate = DateTime.Now;

            context.Products.Update(entity);
            return await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            // When we use "SingleOrDefault" it throws exception if a collection returns
            // but "FirstOrDefault" doesn't.
            var product = await context.Products.FirstOrDefaultAsync(p=> p.Id == id);
            context.Products.Remove(product);

            await context.SaveChangesAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await context.Products.AnyAsync(p => p.Id == id);
        }

        public async Task<IList<Product>> SearchProductByName(string name)
        {
            return await context.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }
    }
}