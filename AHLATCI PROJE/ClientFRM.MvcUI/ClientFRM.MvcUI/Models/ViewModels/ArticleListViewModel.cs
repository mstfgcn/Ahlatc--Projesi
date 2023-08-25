using ClientFRM.MvcUI.Models.ApiTypes;

namespace ClientFRM.MvcUI.Models.ViewModels
{
    public class ArticleListViewModel
    {
        public List<CategoryItem> CategoryList { get; set; }
        public List<ArticleItem> ArticleList { get; set; }

        public int? ActiveCategoryId { get; set; }
    }
}
