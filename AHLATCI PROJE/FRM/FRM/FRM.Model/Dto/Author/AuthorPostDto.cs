using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Model.Dto.Author
{
    public class AuthorPostDto :  IDto
    
    {
        public string AuthorName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? City { get; set; }
        public string? Mail { get; set; }
        public bool? IsActive { get; set; }

    }
}
