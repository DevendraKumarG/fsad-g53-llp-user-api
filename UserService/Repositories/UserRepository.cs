using Microsoft.EntityFrameworkCore;
using UserService.Models;
using UserService.Repositories.Contracts;

namespace UserService.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(LlpDbContext context, ILogger<LlpDbContext> logger) : base(context, logger)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email) ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
