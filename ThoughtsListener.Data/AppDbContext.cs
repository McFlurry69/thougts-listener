using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using ThoughtsListener.Models;

namespace ThoughtsListener.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<MediaContent> MediaContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PostCategory>()
                .HasKey(x => new { x.PostId, x.CategoryId });
        }
    }
}