namespace ClientFRM.MvcUI.Models.ApiTypes
{
    public class ArticleItem
    {
        public int ArticleId { get; set; }
        public string Subtitle { get; set; }
        public string Text { get; set; }
        public DateTime? DateTime { get; set; }

        public int CategoryID { get; set; }
        public int AuthorId { get; set; }

        public AuthorItem authorItem { get; set; }
        public CategoryItem categoryItem { get; set; }


    }
}
