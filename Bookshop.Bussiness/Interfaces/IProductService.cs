using System.Collections.Generic;
using System.Threading.Tasks;
using Bookshop.Dtos.Requests;
using Bookshop.Dtos.Responses;
using Bookshop.Entities;

namespace Bookshop.Business.Interfaces
{
    public interface IProductService
    {
        Task<ICollection<ProductListResponse>> GetProducts();
        Task<int> AddProduct(AddProductRequest product);
        Task<bool> IsExist(int id);
        Task<ProductListResponse> GetProductById(int id);
        Task<int> UpdateProduct(UpdateProductRequest request);
        Task DeleteProduct(int id);
    }
}