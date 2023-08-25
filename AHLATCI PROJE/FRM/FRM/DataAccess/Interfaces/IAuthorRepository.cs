using FRM.Model.Entities;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.DataAccess.Interfaces
{
    public interface IAuthorRepository:IBaseRepository<Author>
    {
        Task<Author> GetByAuthorIdAsync(int authorId, params string[] includeList);
    }
}
