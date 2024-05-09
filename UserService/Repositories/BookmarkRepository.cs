using UserService.Models;
using UserService.Repositories.Contracts;

namespace UserService.Repositories
{
    public class BookmarkRepository : RepositoryBase<Bookmark>, IBookmarkRepository
    {
        public BookmarkRepository(LlpDbContext context, ILogger<LlpDbContext> logger) : base(context, logger)
        {
        }
    }
}
