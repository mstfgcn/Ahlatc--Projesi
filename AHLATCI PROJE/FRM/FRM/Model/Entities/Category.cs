using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string  CategoryName { get; set; }
        public string? CategoryDescription { get; set; }

        //navigation 
        public List<Article> Articles { get; set; }
    }
}
