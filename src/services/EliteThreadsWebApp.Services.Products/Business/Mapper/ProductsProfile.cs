using AutoMapper;
using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Products.Business.DTO;
using EliteThreadsWebApp.Services.Products.Business.DTO.Products;
using EliteThreadsWebApp.Services.Products.Domain.Entities;
using EliteThreadsWebApp.Services.Products.Infrastructure;
using EliteThreadsWebApp.Services.Products.Infrastructure.Helpers;

namespace EliteThreadsWebApp.Services.Products.Business.Mapper
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<PaginatedList, PaginatedListDTO>();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<QueryObject, QueryObjectDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<EditProductDTO, Product>().ReverseMap();
            CreateMap<Categories, CategoriesDTO>().ReverseMap();
            CreateMap<Subcategories, SubcategoriesDTO>().ReverseMap();
            CreateMap<Product, ShoppingCartPopulatedEvent>();
        }
    }
}
