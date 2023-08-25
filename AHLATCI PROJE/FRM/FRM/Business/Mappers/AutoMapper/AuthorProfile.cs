using AutoMapper;
using FRM.Model.Dto.Author;
using FRM.Model.Entities;

namespace FRM.Business.Mappers.AutoMapper
{
    public class AuthorProfile :Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorGetDto>()
            .ForMember(dest => dest.Articles, opt => opt.MapFrom(src => src.Articles))
           
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.AuthorName == null ? "" : src.AuthorName.ToUpper()))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City == null ? "" : src.City))
            .ForMember(dest => dest.Mail, opt => opt.MapFrom(src => src.Mail == null ? "" : src.Mail))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ReverseMap()
            ;
            CreateMap<AuthorPostDto, Author>();
            CreateMap<AuthorPutDto, Author>();
        }
    }
}
