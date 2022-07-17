using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bookshop.Business.Interfaces;
using Bookshop.DataAccess.Repositories;
using Bookshop.Dtos.Requests;
using Bookshop.Dtos.Responses;
using Bookshop.Entities;

namespace Bookshop.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ICollection<ProductListResponse>> GetProducts()
        {
            var products = await repository.GetAllEntities();

            //products.ToList().ForEach(p=>productListResponses.Add(new ProductListResponse
            //{
            //    CategoryId = p.CategoryId,
            //    Description = p.Description,
            //    Discount = p.Discount,
            //    ImgUrl = p.ImgUrl,
            //    Id = p.Id,
            //    Name = p.Name,
            //    Price = p.Price
            //}));

            var productListResponses = mapper.Map<List<ProductListResponse>>(products);

            return productListResponses;
        }

        public async Task<int> AddProduct(AddProductRequest request)
        {
            //var product = new Product
            //{
            //    Name = request.Name,
            //    CategoryId = request.CategoryId,
            //    Description = request.Description,
            //    ImgUrl = request.ImgUrl,
            //    Price = request.Price,
            //    Discount = request.Discount,
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now
            //};

            var product = mapper.Map<Product>(request);
            return await repository.Add(product);

        }

        public async Task<bool> IsExist(int id)
        {
            return await repository.IsExist(id);
        }

        public async Task<ProductListResponse> GetProductById(int id)
        {
            var product = await repository.GetEntityById(id);
            var response = mapper.Map<ProductListResponse>(product);
            return response;

        }

        public async Task<int> UpdateProduct(UpdateProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            var results = await repository.Update(product);
            return results;
        }

        public async Task DeleteProduct(int id)
        {
            await repository.Delete(id);
        }
    }
}