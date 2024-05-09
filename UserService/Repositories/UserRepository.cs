using UserService.Models;
using UserService.Repositories.Contracts;

namespace UserService.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(LlpDbContext context, ILogger<LlpDbContext> logger) : base(context, logger)
        {
        }
    }
}
