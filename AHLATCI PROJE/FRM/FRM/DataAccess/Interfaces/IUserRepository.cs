using Infrastructure.DataAccess;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.DataAccess.Interfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {
        
        Task<User> GetByIdAsync(int userId, params string[] includeList);

        
       
    }
}
