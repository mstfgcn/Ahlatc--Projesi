using Infrastructure.Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Model.Entities
{
    public class Author : IEntity
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public DateTime? Birthday { get; set; }

        public string? City { get; set; }
        public string? Mail { get; set; }
        public bool? IsActive { get; set; }

        public List<Article>? Articles { get; set; }
         public List<Comment>? Comments { get; set; }
    }
}
