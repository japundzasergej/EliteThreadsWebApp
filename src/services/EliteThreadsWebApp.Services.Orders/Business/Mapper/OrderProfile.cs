using AutoMapper;
using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Orders.Business.DTO;
using EliteThreadsWebApp.Services.Orders.Domain;
using EliteThreadsWebApp.Services.Orders.Infrastructure.Helpers;

namespace EliteThreadsWebApp.Services.Orders.Business.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDetail, OrderDetailEntity>().ReverseMap();
            CreateMap<OrderHeader, OrderHeaderEntity>().ReverseMap();
            CreateMap<OrderProduct, OrderProductEntity>().ReverseMap();
            CreateMap<OrderPlacedEvent, Order>().ReverseMap();
            CreateMap<OrderDetailEntity, OrderDetailDTO>().ReverseMap();
            CreateMap<OrderHeaderEntity, OrderHeaderDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderProductEntity, OrderProductDTO>().ReverseMap();
            CreateMap<PersonalInfoDTO, PersonalInfo>().ReverseMap();
            CreateMap<PaginatedOrderList, PaginatedOrderListDTO>();
        }
    }
}
