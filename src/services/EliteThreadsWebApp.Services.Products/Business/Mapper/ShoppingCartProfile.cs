using AutoMapper;
using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Products.Domain.Entities;

namespace EliteThreadsWebApp.Services.Products.Business.Mapper
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ProductAddedToShoppingCartEvent, PopulatedHeader>();
            CreateMap<Product, PopulatedDetails>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(
                    dest => dest.Image,
                    opt => opt.MapFrom(src => src.ImageList.FirstOrDefault())
                )
                .ForMember(
                    dest => dest.PriceAfterDiscount,
                    opt => opt.MapFrom(src => CalculateDiscount(src.Price, src.DiscountAmount))
                );
        }

        private static double? CalculateDiscount(double price, int? discountAmount)
        {
            if (discountAmount is null)
                return null;

            return price - (price * (discountAmount / 100));
        }
    }
}
