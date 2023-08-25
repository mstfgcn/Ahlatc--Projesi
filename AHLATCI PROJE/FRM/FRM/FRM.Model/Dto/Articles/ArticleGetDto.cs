using FRM.Model.Dto.Author;
using FRM.Model.Dto.Category;
using FRM.Model.Entities;
using Infrastructure.Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Model.Dto.Articles
{
    public class ArticleGetDto : IDto
    {
        public int ArticleId { get; set; }
        public string Subtitle { get; set; } //konu başlıgı
        public string Text { get; set; }   // içeirk
        public DateTime? DateTime { get; set; }
        public bool? IsActive { get; set; }


        public string? CategoryName { get; set; }
        public string? AuthorName { get; set; }

        public AuthorGetDto? Author { get; set; }
        public CategoryGetDto? Category { get; set; }





    }
}
