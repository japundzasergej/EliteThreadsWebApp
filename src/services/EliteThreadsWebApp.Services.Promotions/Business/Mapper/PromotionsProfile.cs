using AutoMapper;
using EliteThreadsWebApp.Services.Products.Domain.Entities;
using EliteThreadsWebApp.Services.Promotions.Business.DTO;
using EliteThreadsWebApp.Services.Promotions.Domain.Entities;

namespace EliteThreadsWebApp.Services.Promotions.Business.Mapper
{
    public class PromotionsProfile : Profile
    {
        public PromotionsProfile()
        {
            CreateMap<Discount, DiscountDTO>();
            CreateMap<CreateDiscountDTO, Discount>();
            CreateMap<Collections, CollectionsDTO>();
            CreateMap<CreateCollectionDTO, Collections>();
            CreateMap<ActivePromotions, PromotionsDTO>();
        }
    }
}
