using Microsoft.EntityFrameworkCore;
using UserService.Models;
using UserService.Repositories.Contracts;

namespace UserService.Repositories
{
    public class BookmarkRepository : RepositoryBase<Bookmark>, IBookmarkRepository
    {
        public BookmarkRepository(LlpDbContext context, ILogger<LlpDbContext> logger) : base(context, logger)
        {
        }

        public Task<Bookmark> GetBookmarkByUserId(int userId)
        {
            return _context.Bookmarks.FirstOrDefaultAsync(b => b.UserId == userId);
        }
    }
}
