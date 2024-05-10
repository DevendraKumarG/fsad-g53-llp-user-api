using UserService.Repositories.Contracts;

namespace UserService.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly LlpDbContext _context;
        private readonly ILogger<LlpDbContext> _logger;
        private IResultRepository _resultRepository;
        private IUserRepository _userRepository;
        private IBookmarkRepository _bookmarkRepository;
        private ILanguageRepository _languageRepository;

        public RepositoryManager(LlpDbContext context, ILogger<LlpDbContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IUserRepository User
        {
            get
            {
                _userRepository ??= new UserRepository(_context, _logger);
                return _userRepository;
            }
        }

        public IBookmarkRepository Bookmark
        {
            get
            {
                _bookmarkRepository ??= new BookmarkRepository(_context, _logger);
                return _bookmarkRepository;
            }
        }

        public ILanguageRepository Language
        {
            get
            {
                _languageRepository ??= new LanguageRepository(_context, _logger);
                return _languageRepository;
            }
        }

        public IResultRepository Result
        {
            get
            {
                _resultRepository ??= new ResultRepository(_context, _logger);
                return _resultRepository;
            }
        }
    }
}
