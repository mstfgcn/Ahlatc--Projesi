using AutoMapper;
using FRM.Business.CustomException;
using FRM.Business.Interfaces;
using FRM.DataAccess.Interfaces;
using FRM.Model.Dto.Articles;
using FRM.Model.Dto.Author;
using FRM.Model.Dto.User;
using FRM.Model.Entities;
using Infrastructure.Utilities.ApiResponse;
using Microsoft.AspNetCore.Http;
using Model.Entities;

namespace FRM.Business.Implementations
{
    public class ArticleBs : IArticleBs
    {
        private readonly IArticleRepository _repo;
        private readonly IMapper _mapper;

        public ArticleBs(IMapper mapper, IArticleRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
                
        }

        public async Task<ApiResponse<List<ArticleGetDto>>> GetByAuthorIdAsync(int authorId, params string[] includeList)
        {
            if (authorId <= 0)
                throw new BadRequestException("AuthorId 0 dan büyük olmalı");

            var article = await _repo.GetByAuthorIdAsync(authorId, includeList);
            if (article != null)
            {
                var dto = _mapper.Map<List<ArticleGetDto>>(article);
                return ApiResponse<List<ArticleGetDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFountException("Kayıt bulunamadı");
        }

        public async Task<ApiResponse<List<ArticleGetDto>>> GetByCategoryAsync(int categoryId, params string[] includeList)
        {
            if(categoryId <=0)
            throw new NotImplementedException();

            var article = await _repo.GetByAuthorIdAsync(categoryId, includeList);
            if (article != null)
            {
                var dto = _mapper.Map<List<ArticleGetDto>>(article);
                return ApiResponse<List<ArticleGetDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFountException("Kayıt bulunamadı");
        }

        public async Task<ApiResponse<ArticleGetDto>> GetByIdAsync(int articleId, params string[] includeList)
        {
            if (articleId <= 0)
                throw new BadRequestException("Id 0 ve ya 0 dan küçük olamaz");


            var article = await _repo.GetByIdAsync(articleId, includeList);
            if (article != null)
            {
                var dto = _mapper.Map<ArticleGetDto>(article);
                return ApiResponse<ArticleGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFountException("Kayıt bulunamadı");
        }

        public async Task<ApiResponse<List<ArticleGetDto>>> GetAllAsync(params string[] includeList)
        {
            var dtoList = await _repo.GetAllAsync(includeList: includeList);
            if (dtoList.Count > 0)
            {
                var returnList = _mapper.Map<List<ArticleGetDto>>(dtoList);
                return ApiResponse<List<ArticleGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            return ApiResponse<List<ArticleGetDto>>.Fail(StatusCodes.Status404NotFound, "Kayıt bulunamadı");

        }
        public async Task<ApiResponse<Article>> InsertAsync(ArticlePostDto dto)
        {
            if (dto.Subtitle.Length < 2)
                return ApiResponse<Article>.Fail(StatusCodes.Status400BadRequest, "Kullanıcı adı 2 karakterden az olamaz");

            if (dto.Text.Length <= 50)
                return ApiResponse<Article>.Fail(StatusCodes.Status400BadRequest, "İçerik 50  karakterden az olamaz");


            var entity = _mapper.Map<Article>(dto);
            var insertedArticle = await _repo.InsertAsync(entity);
            return ApiResponse<Article>.Success(StatusCodes.Status200OK, insertedArticle);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ArticlePutDto dto)
        {
            if (dto.Subtitle.Length < 2)
                return ApiResponse<NoData>.Fail(StatusCodes.Status400BadRequest, "Altbaşlık 2 karakterden az olamaz");

            if (dto.Text.Length <= 50)
                return ApiResponse<NoData>.Fail(StatusCodes.Status400BadRequest, "içerik 50 karakterden küçük olamaz");


            var entity = _mapper.Map<Article>(dto);
            await _repo.UpdateAsync(entity);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                return ApiResponse<NoData>.Fail(StatusCodes.Status400BadRequest, "Id 0 ve ya 0 dan küçük olamaz");

            var entity = await _repo.GetByAuthorIdAsync(id);
            entity.IsActive = false;
            await _repo.UpdateAsync(entity);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
