using FRM.Model;
using FRM.Model.Entities;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class User : IEntity
    {
        public int UserId { get; set; }
       
        public string? City { get; set; }
        public string? Mail { get; set; }
        public bool? IsActive { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
