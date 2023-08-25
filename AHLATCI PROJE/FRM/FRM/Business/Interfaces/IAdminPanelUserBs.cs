using FRM.Model.Dto.AdminPanelUser;
using Infrastructure.Utilities.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Business.Interfaces
{
    public interface IAdminPanelUserBs
    {
        Task<ApiResponse<AdminPanelUserDto>> LogInAsync(string userName, string password, params string[] includeList);
    }
}
