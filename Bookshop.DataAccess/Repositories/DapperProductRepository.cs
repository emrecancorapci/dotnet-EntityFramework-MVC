using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshop.DataAccess.Data;
using Bookshop.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Bookshop.DataAccess.Repositories
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly string connectionString;
        private readonly SqlConnection con;

        public DapperProductRepository(DbContext context)
        {
            connectionString = context.Database.GetConnectionString();
            con = new SqlConnection(connectionString);
        }

        public async Task<IList<Product>> GetAllEntities()
        {
            return (await con.GetAllAsync<Product>()).ToList();
        }

        public async Task<Product> GetEntityById(int id)
        {
            return await con.GetAsync<Product>(id);
        }

        public async Task<int> Add(Product entity)
        {
            // con.Insert(entity);
            const string sql = "insert into Products(Id,Name,Price,Discount,CategoryId,ImgUrl) " +
                               "values (@Id,@Name,@Price,@Discount,@CategoryId,@ImgUrl)";
            await con.OpenAsync();
            await con.ExecuteAsync(sql, new[]
            { 
                new
                {
                    Id=entity.Id,
                    Name=entity.Name,
                    Price=entity.Price,
                    Discount=entity.Discount,
                    CategoryId=entity.CategoryId,
                    ImgUrl=entity.ImgUrl
                }
            });
            return entity.Id;


        }

        public async Task<int> Update(Product entity)
        {
            return await con.UpdateAsync(entity) ? entity.Id : 0;
        }

        public async Task Delete(int id)
        {
            var product = 
                (await con.GetAllAsync<Product>())
                .FirstOrDefault(p => p.Id == id);

            await con.DeleteAsync(product);
        }

        public Task<bool> IsExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Product>> SearchProductByName(string name)
        {
            return  (await con.GetAllAsync<Product>())
                .Where(p => p.Name.Contains(name))
                .ToList();
        }
    }
}