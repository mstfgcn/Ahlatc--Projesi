using FRM.Model.Dto.Articles;
using FRM.Model.Dto.Author;
using FRM.Model.Dto.Category;
using FRM.Model.Dto.User;
using FRM.Model.Entities;
using Infrastructure.Utilities.ApiResponse;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Business.Interfaces
{
    public interface IAuthorBs
    {
        
        Task<ApiResponse<AuthorGetDto>>GetByAuthorIdAsync(int authorId, params string[] includeList);
        Task<ApiResponse<List<AuthorGetDto>>> GetAllAsync(params string[] includeList);
        Task<ApiResponse<Author>> InsertAsync(AuthorPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(AuthorPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);

    }
}
