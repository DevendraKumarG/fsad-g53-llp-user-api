using UserService.Models;

namespace UserService.Repositories.Contracts
{
    public interface IResultRepository : IRepositoryBase<Result>
    {
        Task<IEnumerable<Result>> GetResultsByUserId(int userId);
    }
}
