using FRM.Model.Entities;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Article : IEntity
    {
        public int ArticleId { get; set; }
        
        public string? Subtitle { get; set; } //konu başlıgı
        public string? Text { get; set; }   // içeirk
        public DateTime? DateTime { get; set; } //yayınlanma tarihi
        public bool? IsActive { get; set; }

        //foregn
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        //public int CommentID { get; set; }

        //navigation
        public Category? Category { get; set; }
        public Author? Author { get; set; }
        //public List<Comment>? Comment { get; set; }
    }
}
