using Infrastructure.Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Model.Entities
{
    public class Comment:IEntity
    {
        public int CommentId { get; set; }
        public DateTime? DateTime { get; set; }
        public string? CommentText { get; set; }



        public int UserId { get; set; }
        public int ArticleId { get; set; }


        public User User { get; set; }

    }
}
