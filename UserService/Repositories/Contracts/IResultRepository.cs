using Llp.User.Models;

namespace Llp.User.Repositories.Contracts
{
    public interface IResultRepository : IRepositoryBase<Result>
    {
        Task<IEnumerable<Result>> GetResultsByUserId(int userId);
    }
}
