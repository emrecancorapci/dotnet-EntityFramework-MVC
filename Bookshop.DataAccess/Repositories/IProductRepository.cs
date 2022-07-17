using System.Collections.Generic;
using System.Threading.Tasks;
using Bookshop.Entities;

namespace Bookshop.DataAccess.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IList<Product>> SearchProductByName(string name);
    }
}