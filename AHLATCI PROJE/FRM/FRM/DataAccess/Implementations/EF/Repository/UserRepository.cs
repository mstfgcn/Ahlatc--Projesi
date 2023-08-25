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
    public class UserRepository : BaseRepository<User, FRMContext>, IUserRepository
    {
       

        public async Task<User> GetByIdAsync(int userId, params string[] includeList)
        {
            return await GetAsync(usr => usr.UserId == userId && usr.IsActive == true, includeList);
        }
    }
}
