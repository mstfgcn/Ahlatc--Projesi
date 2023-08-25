using FRM.Model.Dto.Articles;
using FRM.Model.Dto.User;
using Infrastructure.Utilities.ApiResponse;
using Model.Entities;

namespace FRM.Business.Interfaces
{
    public interface IArticleBs
    {
        Task<ApiResponse<ArticleGetDto>>GetByIdAsync(int articleId, params string[] includeList);
        Task<ApiResponse<List<ArticleGetDto>>> GetByAuthorIdAsync(int authorId, params string[] includeList);
        Task<ApiResponse<List<ArticleGetDto>>> GetByCategoryAsync(int categoryId, params string[] includeList);

        Task<ApiResponse<List<ArticleGetDto>>> GetAllAsync(params string[] includeList);
        Task<ApiResponse<Article>> InsertAsync(ArticlePostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(ArticlePutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
