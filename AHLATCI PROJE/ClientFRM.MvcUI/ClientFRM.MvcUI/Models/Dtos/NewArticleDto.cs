namespace ClientFRM.MvcUI.Models.Dtos
{
    public class NewArticleDto
    {
        public string Subtitle { get; set; }
        public string Text { get; set; }
        public DateTime? DateTime { get; set; }

        public int CategoryID { get; set; }
        public int AuthorId { get; set; }
    }
}
