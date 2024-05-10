using Llp.User.Models;

namespace Llp.User.Repositories.Contracts
{
    public interface IBookmarkRepository : IRepositoryBase<Bookmark>
    {
        Task<Bookmark> GetBookmarkByUserId(int userId);
    }
}
