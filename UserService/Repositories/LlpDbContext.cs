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
        // public DbSet<MediaType> MediaTypes { get; set; }
        // public DbSet<LanguageSection> LanguageSections { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        // public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Results> Results { get; set; }
    }

}
}
