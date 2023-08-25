namespace ClientFRM.MvcUI.Models.ApiTypes
{
    public class AuthorItem
    {
        public int AuthorId { get; set; }
        public string? UserName { get; set; }
        
        public string? AuthorName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? City { get; set; }
        public string? Mail { get; set; }

        public List<ArticleItem> ArticleItems { get; set; }
    }
}
