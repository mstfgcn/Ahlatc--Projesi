using AutoMapper;
using FRM.Business.CustomException;
using FRM.Business.Interfaces;
using FRM.DataAccess.Interfaces;
using FRM.Model.Dto.Articles;
using FRM.Model.Dto.Category;
using FRM.Model.Dto.User;
using FRM.Model.Entities;
using Infrastructure.Utilities.ApiResponse;
using Microsoft.AspNetCore.Http;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Business.Implementations
{
    public class CategoryBs : ICategoryBs
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public CategoryBs(IMapper mapper, ICategoryRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CategoryGetDto>> GetByIdAsync(int categoryId, params string[] includeList)
        {
            if (categoryId <= 0)
                throw new BadRequestException("CategoryId 0 dan büyük olmalı");

            var category = await _repo.GetByIdAsync(categoryId, includeList);
            if (category != null)
            {
                var dto = _mapper.Map<CategoryGetDto>(category);
                return ApiResponse<CategoryGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFountException("Kayıt bulunamadı");
        }


        public async Task<ApiResponse<Category>> InsertAsync(CategoryPostDto dto)
        {
            if (dto.CategoryName.Length < 2)
                return ApiResponse<Category>.Fail(StatusCodes.Status400BadRequest, "category adı 2 karakterden az olamaz");

            var entity = _mapper.Map<Category>(dto);
            var insertedCategory = await _repo.InsertAsync(entity);
            return ApiResponse<Category>.Success(StatusCodes.Status200OK, insertedCategory);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto dto)
        {
            if (dto.CategoryName.Length < 2)
                return ApiResponse<NoData>.Fail(StatusCodes.Status400BadRequest, "category adı 2 karakterden az olamaz");

            if (dto.CategoryID <= 0)
                return ApiResponse<NoData>.Fail(StatusCodes.Status400BadRequest, "Id 0 ve ya 0 dan küçük olamaz");


            var entity = _mapper.Map<Category>(dto);
            await _repo.UpdateAsync(entity);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                return ApiResponse<NoData>.Fail(StatusCodes.Status400BadRequest, "Id 0 ve ya 0 dan küçük olamaz");

            var entity = await _repo.GetByIdAsync(id);
            entity.IsActive = false;
            await _repo.UpdateAsync(entity);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<CategoryGetDto>>> GetAllAsync(params string[] includeList)
        {
            var dtoList = await _repo.GetAllAsync(predicate: cat => cat.IsActive == true, includeList: includeList);
            if (dtoList.Count > 0)
            {
                var returnList = _mapper.Map<List<CategoryGetDto>>(dtoList);
                return ApiResponse<List<CategoryGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            return ApiResponse<List<CategoryGetDto>>.Fail(StatusCodes.Status404NotFound, "Kayıt bulunamadı");

        }
    }
}
