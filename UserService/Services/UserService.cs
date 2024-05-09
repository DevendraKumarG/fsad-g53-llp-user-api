using UserService.DTOs;
using UserService.Models;
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

        public Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UserRegisterResponse> Register(UserRegisterRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfileResponse> GetUserProfile(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLanguagePreference(int userId, UserPreferenceRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLearningProgress(int userId, Bookmark request)
        {
            throw new NotImplementedException();
        }

        public Task<Bookmark> GetLearningProgress(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<AssessmentResultsResponse> GetAssessmentResults(int userId)
        {
            throw new NotImplementedException();
        }


    }
}
