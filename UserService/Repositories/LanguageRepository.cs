using UserService.Models;
using UserService.Repositories.Contracts;

namespace UserService.Repositories
{
    public class LanguageRepository : RepositoryBase<Language>, ILanguageRepository
    {
        public LanguageRepository(LlpDbContext context, ILogger<LlpDbContext> logger) : base(context, logger)
        {
        }
    }
}
