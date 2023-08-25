using FRM.Model.Dto.Articles;
using Infrastructure.Model;

namespace FRM.Model.Dto.Author
{
    public class AuthorGetDto : IDto
    
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public string UserName { get; set; }
        public DateTime? Birthday { get; set; }

        public string? City { get; set; }
        public string? Mail { get; set; }
        public bool? IsActive { get; set; }

        public List<ArticleGetDto>? Articles { get; set; }

       // List<Comment> Comments { get; set; }
    }
}
