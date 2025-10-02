using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;Database=MultiShopCommentDb;TrustServerCertificate=true;User=sa;Password=123456789aA.");
        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}
