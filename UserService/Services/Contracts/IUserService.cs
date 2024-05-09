using UserService.DTOs;

namespace UserService.Services.Contracts
{
    public interface IUserService
    {
        Task GetAssessmentResults(string userId);
        Task GetLearningProgress(string userId);
        Task GetUserProfile(string userId);
        Task Login(UserLoginRequest request);
        Task Register(UserRegisterRequest request);
        Task UpdateLanguagePreference(string userId, UserPreferenceRequest request);
    }
}
