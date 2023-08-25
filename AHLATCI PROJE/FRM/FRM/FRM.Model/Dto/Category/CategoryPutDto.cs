using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Model.Dto.Category
{
    public class CategoryPutDto : IDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public bool? IsActive { get; set; }
    }
}
