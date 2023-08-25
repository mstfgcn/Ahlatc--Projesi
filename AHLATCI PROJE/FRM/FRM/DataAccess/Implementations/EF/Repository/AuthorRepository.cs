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
    public class AuthorRepository : BaseRepository<Author, FRMContext>, IAuthorRepository
    {
        public async Task<Author> GetByAuthorIdAsync(int authorId, params string[] includeList)
        {
            return await GetAsync(aut => aut.AuthorId == authorId && aut.IsActive == true, includeList);
        }

       
    }
}
