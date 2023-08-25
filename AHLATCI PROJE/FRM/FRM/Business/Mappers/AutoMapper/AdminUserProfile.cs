using AutoMapper;
using FRM.Model.Dto.AdminPanelUser;
using FRM.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Business.Mappers.AutoMapper
{
    public class AdminUserProfile : Profile
    {
        public AdminUserProfile()
        {
            CreateMap<AdminPanelUser, AdminPanelUserDto>();
        }
    }
}
