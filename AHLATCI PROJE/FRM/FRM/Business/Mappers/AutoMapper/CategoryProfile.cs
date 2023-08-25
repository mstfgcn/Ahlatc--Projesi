using AutoMapper;
using FRM.Model.Dto.Articles;
using FRM.Model.Dto.Category;
using FRM.Model.Dto.User;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Business.Mappers.AutoMapper
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Article, ArticleGetDto>();
            CreateMap<Category, CategoryGetDto>()
                .ForMember(dest => dest.CategoryID, opt =>opt.MapFrom(src =>src.CategoryId))
                 .ForMember(dest => dest.CategoryDescription, opt => opt.MapFrom(src => src.CategoryDescription))
                  .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                   .ForMember(dest => dest.Articles, opt => opt.MapFrom(src => src.Articles))
                ;
            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryPutDto, Category>();
        }
    }
}
