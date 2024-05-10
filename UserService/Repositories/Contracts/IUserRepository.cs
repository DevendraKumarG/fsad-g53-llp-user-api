using Llp.User.Models;

namespace Llp.User.Repositories.Contracts
{
    public interface IUserRepository : IRepositoryBase<Models.User>
    {
        Task<Models.User> GetUserByEmail(string email);
    }
}
