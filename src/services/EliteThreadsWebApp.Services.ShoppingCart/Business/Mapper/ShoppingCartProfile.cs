using AutoMapper;
using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.ShoppingCart.Business.DTO;
using EliteThreadsWebApp.Services.ShoppingCart.Domain;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Mapper
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<Cart, CartDTO>().ReverseMap();
            CreateMap<CartHeader, CartHeaderDTO>().ReverseMap();
            CreateMap<CartDetail, CartDetailDTO>().ReverseMap();
            ;
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<AddUpdateProductToCartDTO, ProductAddedToShoppingCartEvent>();
            CreateMap<ShoppingCartPopulatedEvent, Product>();
            CreateMap<PopulatedDetails, Product>();
            CreateMap<ProductDTO, OrderProduct>();
        }
    }
}
