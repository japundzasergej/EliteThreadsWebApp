using AutoMapper;
using EliteThreadsWebApp.Services.Social.Business.DTO.Reviews;
using EliteThreadsWebApp.Services.Social.Domain.Entities;

namespace EliteThreadsWebApp.Services.Social.Business.Mapper
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewsDTO>();
            CreateMap<CreateReviewsDTO, Review>();
            CreateMap<EditReviewDTO, Review>().ReverseMap();
            CreateMap<Product, ProductRatingDTO>().ReverseMap();
            CreateMap<UserRatingDTO, UserRating>().ReverseMap();
        }
    }
}
