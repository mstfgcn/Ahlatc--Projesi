using FRM.Model.Dto.Articles;
using Infrastructure.Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Model.Dto.Category
{
    public class CategoryGetDto:IDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public bool? IsActive { get; set; }

        //navigation 
        public List<ArticleGetDto> Articles { get; set; }
    }
}
