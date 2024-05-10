using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Repositories
{
    public class LlpDbContext : DbContext
    {
        public LlpDbContext(DbContextOptions<LlpDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Result> Results { get; set; }
    }

}
}
