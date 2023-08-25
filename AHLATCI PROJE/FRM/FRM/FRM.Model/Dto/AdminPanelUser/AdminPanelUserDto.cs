using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Model.Dto.AdminPanelUser
{
    public class AdminPanelUserDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
