using Infrastructure.DataAccess;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.DataAccess.Interfaces
{
    public interface IArticleRepository : IBaseRepository<Article>
    {
        Task<Article> GetByIdAsync(int articleId, params string[] includeList);
        Task<Article> GetByCategoryAsync(int categoryId, params string[] includeList);
        Task<Article> GetByAuthorIdAsync(int authorId, params string[] includeList);

    }
}
