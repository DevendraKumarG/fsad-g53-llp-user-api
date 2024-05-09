using UserService.DTOs;
using UserService.Repositories.Contracts;
using UserService.Services.Contracts;

namespace UserService.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IRepositoryManager _repositoryManager;

        public UserService(ILogger<UserService> logger, IRepositoryManager repositoryManager)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
        }

        public Task GetAssessmentResults(string userId)
        {
            throw new NotImplementedException();
        }

        public Task GetLearningProgress(string userId)
        {
            throw new NotImplementedException();
        }

        public Task GetUserProfile(string userId)
        {
            throw new NotImplementedException();
        }

        public Task Login(UserLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Register(UserRegisterRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLanguagePreference(string userId, UserPreferenceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
