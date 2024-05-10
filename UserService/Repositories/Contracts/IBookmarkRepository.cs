﻿using UserService.Models;

namespace UserService.Repositories.Contracts
{
    public interface IBookmarkRepository : IRepositoryBase<Bookmark>
    {
        Task<Bookmark> GetBookmarkByUserId(int userId);
    }
}
