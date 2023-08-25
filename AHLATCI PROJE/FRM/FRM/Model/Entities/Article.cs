using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }
        public string Subtitle { get; set; } //konu başlıgı
        public string Text { get; set; }   // içeirk
        public DateTime DateTime { get; set; } //yayınlanma tarihi

        //foregn
        public int CategoryID { get; set; }

        //navigation
        public Category Category { get; set; }
    }
}
