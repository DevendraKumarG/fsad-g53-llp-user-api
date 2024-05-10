namespace UserService.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IBookmarkRepository Bookmark { get; }
        ILanguageRepository Language { get; }
        IResultRepository Result { get; }
    }
}
