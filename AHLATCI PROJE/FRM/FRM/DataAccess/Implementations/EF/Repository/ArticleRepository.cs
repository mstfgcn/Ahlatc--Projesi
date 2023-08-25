using FRM.DataAccess.Implementations.EF.Contexts;
using FRM.DataAccess.Interfaces;
using FRM.Model.Entities;
using Infrastructure.DataAccess.EF;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.DataAccess.Implementations.EF.Repository
{
    public class ArticleRepository : BaseRepository<Article, FRMContext>, IArticleRepository
    {
        public async Task<Article> GetByAuthorIdAsync(int authorId, params string[] includeList)
        {
            return await GetAsync(art => art.AuthorId == authorId && art.IsActive == true, includeList);
        }

        public async Task<Article> GetByCategoryAsync(int categoryId, params string[] includeList)
        {
            return await GetAsync(art => art.CategoryId == categoryId && art.IsActive == true, includeList);
        }

        public async Task<Article> GetByIdAsync(int articleId, params string[] includeList)
        {
            return await GetAsync(art => art.ArticleId == articleId && art.IsActive == true, includeList);
        }

        //tarihe göre sıralama yapılabilir. 
    }
}
