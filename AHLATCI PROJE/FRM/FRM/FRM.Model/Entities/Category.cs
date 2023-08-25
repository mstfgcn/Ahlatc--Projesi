using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string?  CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public bool? IsActive { get; set; }

        //navigation 
        public List<Article>? Articles { get; set; }
    }
}
