using AutoMapper;
using FRM.Model.Dto.Articles;
using FRM.Model.Dto.Author;
using FRM.Model.Dto.User;
using FRM.Model.Entities;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Business.Mappers.AutoMapper
{
    public class ArticleProfile:Profile
    {
        public ArticleProfile()
        {


            CreateMap<Article, ArticleGetDto>()
            .ForMember(dest => dest.ArticleId, opt => opt.MapFrom(src => src.ArticleId))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text == null ? "" : src.Text))
            .ForMember(dest => dest.Subtitle, opt => opt.MapFrom(src => src.Subtitle == null ? "" : src.Subtitle))
          
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.AuthorName))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName == null ? "" : src.Category.CategoryName))
            .ReverseMap();

            CreateMap<ArticlePostDto, Article>();
            CreateMap<ArticlePutDto, Article>();
        }
    }
}
