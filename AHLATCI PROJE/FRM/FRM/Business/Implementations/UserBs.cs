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
    public class UserBs :IUserBs
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UserBs(IMapper mapper, IUserRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<UserGetDto>> GetByIdAsync(int userId, params string[] includeList)
        { 
            if (userId <= 0)
                throw new BadRequestException("AuthorId 0 dan büyük olmalı");

            var user = await _repo.GetByIdAsync(userId, includeList);
            if (user != null)
            {
                var dto = _mapper.Map<UserGetDto>(user);
                return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFountException("Kayıt bulunamadı");
        }


        public async Task<ApiResponse<List<UserGetDto>>> GetAllAsync(params string[] includeList)
        {
            var dtoList = await _repo.GetAllAsync(predicate: usr => usr.IsActive == true, includeList: includeList);
            if (dtoList.Count > 0)
            {
                var returnList = _mapper.Map<List<UserGetDto>>(dtoList);
                return ApiResponse<List<UserGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            return ApiResponse<List<UserGetDto>>.Fail(StatusCodes.Status404NotFound, "Kayıt bulunamadı");

        }

        public async Task<ApiResponse<User>> InsertAsync(UserPostDto dto)
        {
            
            
            
            var entity = _mapper.Map<User>(dto);
            var insertedUser = await _repo.InsertAsync(entity);
            return ApiResponse<User>.Success(StatusCodes.Status200OK, insertedUser);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(UserPutDto user)
        {
          
            if (user.UserID <= 0)
                return ApiResponse<NoData>.Fail(StatusCodes.Status400BadRequest, "Id 0 ve ya 0 dan küçük olamaz");

           


            var entity = _mapper.Map<User>(user);
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
    }
}
