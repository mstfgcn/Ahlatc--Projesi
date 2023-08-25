using AutoMapper;
using FRM.Business.CustomException;
using FRM.Business.Interfaces;
using FRM.DataAccess.Interfaces;
using FRM.Model.Dto.Author;
using FRM.Model.Dto.Category;
using FRM.Model.Dto.User;
using FRM.Model.Entities;
using Infrastructure.Utilities.ApiResponse;
using Microsoft.AspNetCore.Http;
using Model.Entities;

namespace FRM.Business.Implementations
{
    public class AuthorBs : IAuthorBs
    {
        private readonly IAuthorRepository _repo;
        private readonly IMapper _mapper;

        public AuthorBs(IMapper mapper, IAuthorRepository repo)
        {
            _repo = repo;
            _mapper = mapper;

        }
        public async Task<ApiResponse<AuthorGetDto>> GetByAuthorIdAsync(int authorId, params string[] includeList)
        {
            if (authorId <= 0)
                throw new BadRequestException("AuthorId o dan küçük olamaz");

            var author = await _repo.GetByAuthorIdAsync(authorId, includeList);

            if (author != null)
            {
                var dto = _mapper.Map<AuthorGetDto>(author);
                return ApiResponse<AuthorGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFountException("Author bulunamadı");


        }

        public async Task<ApiResponse<List<AuthorGetDto>>> GetAllAsync(params string[] includeList)
        {
            var dtoList = await _repo.GetAllAsync( includeList: includeList);

            if (dtoList.Count > 0)
            {
                var returnList = _mapper.Map<List<AuthorGetDto>>(dtoList);
                return ApiResponse<List<AuthorGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            return ApiResponse<List<AuthorGetDto>>.Fail(StatusCodes.Status404NotFound, "Kayıt bulunamadı");

        }

        public async Task<ApiResponse<Author>> InsertAsync(AuthorPostDto dto)
        {
            if (dto.AuthorName.Length < 2)
                return ApiResponse<Author>.Fail(StatusCodes.Status400BadRequest, "Kullanıcı adı 2 karakterden az olamaz");

            

            var entity = _mapper.Map<Author>(dto);
            var insertedAuthor = await _repo.InsertAsync(entity);
            return ApiResponse<Author>.Success(StatusCodes.Status200OK, insertedAuthor);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(AuthorPutDto dto)
        {
            if (dto.AuthorName.Length < 2)
                return ApiResponse<NoData>.Fail(StatusCodes.Status400BadRequest, "Kullanıcı adı 2 karakterden az olamaz");

            

            var entity = _mapper.Map<Author>(dto);
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
