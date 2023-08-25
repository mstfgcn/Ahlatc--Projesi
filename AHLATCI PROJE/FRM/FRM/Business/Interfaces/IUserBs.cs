using FRM.Model.Dto.Category;
using FRM.Model.Dto.User;
using Infrastructure.Utilities.ApiResponse;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Business.Interfaces
{
    public interface IUserBs
    {
        Task<ApiResponse<UserGetDto>> GetByIdAsync(int userId, params string[] includeList);
        Task<ApiResponse<List<UserGetDto>>> GetAllAsync(params string[] includeList);

        Task<ApiResponse<User>> InsertAsync(UserPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(UserPutDto user);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
