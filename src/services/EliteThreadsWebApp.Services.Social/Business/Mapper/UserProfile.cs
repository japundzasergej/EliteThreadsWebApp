﻿using Auth0.ManagementApi.Models;
using AutoMapper;
using EliteThreadsWebApp.Services.Social.Business.DTO.User;

namespace EliteThreadsWebApp.Services.Social.Business.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, UserUpdateRequest>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            ;
        }
    }
}
