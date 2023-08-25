using FRM.Model.Dto.Category;
using FRM.Model.Dto.User;
using Infrastructure.Utilities.ApiResponse;
using Model.Entities;

namespace FRM.Business.Interfaces
{
    public interface ICategoryBs
    {
        Task<ApiResponse<CategoryGetDto>> GetByIdAsync(int articleId, params string[] includeList);
        Task<ApiResponse<List<CategoryGetDto>>> GetAllAsync(params string[] includeList);
        Task<ApiResponse<Category>> InsertAsync(CategoryPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);

    }
}
