using AutoMapper;
using FRM.Model.Dto.User;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Business.Mappers.AutoMapper
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserGetDto>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserId))
                
                .ForMember(dest => dest.Mail, opt => opt.MapFrom(src => src.Mail))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                
                .ReverseMap();
            CreateMap<UserPostDto, User>();
            CreateMap<UserPutDto, User>();
        }
    }
}
