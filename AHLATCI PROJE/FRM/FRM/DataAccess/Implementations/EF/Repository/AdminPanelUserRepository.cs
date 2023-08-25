using FRM.DataAccess.Implementations.EF.Contexts;
using FRM.DataAccess.Interfaces;
using FRM.Model.Entities;
using Infrastructure.DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.DataAccess.Implementations.EF.Repository
{
    public class AdminPanelUserRepository : BaseRepository<AdminPanelUser, FRMContext>, IAdminPanelUserRepository
    {
        public async Task<AdminPanelUser> GetByUserNameAndPasswordAsync(string userName, string password, params string[] includeList)
        {
            return await GetAsync(x => x.UserName == userName && x.Password == password && x.IsActive.Value, includeList);
        }
    }
}
