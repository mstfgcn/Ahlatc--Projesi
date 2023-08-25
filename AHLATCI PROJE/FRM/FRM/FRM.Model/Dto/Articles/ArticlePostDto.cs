using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Model.Dto.Articles
{
    public class ArticlePostDto : IDto
    {
        public string Subtitle { get; set; } //konu başlıgı
        public string Text { get; set; }   // içeirk
        public DateTime? DateTime { get; set; } //yayınlanma tarihi

        public bool? IsActive { get; set; }
        //foregn
        public int CategoryID { get; set; }
    }
}
