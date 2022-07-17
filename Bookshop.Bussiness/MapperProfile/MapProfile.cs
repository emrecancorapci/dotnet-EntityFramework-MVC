using AutoMapper;
using Bookshop.Dtos.Requests;
using Bookshop.Dtos.Responses;
using Bookshop.Entities;

namespace Bookshop.Business.MapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductListResponse>();
            CreateMap<AddProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
        }
    }
}