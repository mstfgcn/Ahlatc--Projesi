namespace ClientFRM.MvcUI.Models.ApiTypes
{
    public class CategoryItem
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public List<ArticleItem>  ArticleItems { get; set; }
    }
}
