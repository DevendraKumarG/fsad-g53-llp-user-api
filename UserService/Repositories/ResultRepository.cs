using Microsoft.EntityFrameworkCore;
using Llp.User.Models;
using Llp.User.Repositories.Contracts;

namespace Llp.User.Repositories
{
    public class ResultRepository : RepositoryBase<Result>, IResultRepository
    {
        public ResultRepository(LlpDbContext context, ILogger<LlpDbContext> logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<Result>> GetResultsByUserId(int userId)
        {
            return await _context.Results.Where(r => r.UserId == userId).ToListAsync();
        }
    }
}
