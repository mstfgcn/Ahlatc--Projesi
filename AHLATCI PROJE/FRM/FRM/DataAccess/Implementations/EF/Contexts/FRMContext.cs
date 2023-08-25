using FRM.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.DataAccess.Implementations.EF.Contexts
{
    public class FRMContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\MGSERVER;database=FRM;trusted_connection=true; TrustServerCertificate=True");
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AdminPanelUser> AdminPanelUsers { get; set; }
    }
}
