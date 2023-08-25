using FRM.DataAccess.Implementations.EF.Contexts;
using FRM.DataAccess.Interfaces;
using Infrastructure.DataAccess.EF;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.DataAccess.Implementations.EF.Repository
{
    public class CategoryRepository : BaseRepository<Category, FRMContext>, ICategoryRepository
    {
        public async Task<Category> GetByIdAsync(int categoryId, params string[] includeList)
        {
            return await GetAsync(cat => cat.CategoryId == categoryId && cat.IsActive == true, includeList);
        }
    }
}
