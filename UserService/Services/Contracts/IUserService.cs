using UserService.DTOs;

namespace UserService.Services.Contracts
{
    public interface IUserService
    {
        Task GetAssessmentResults(string userId);
        Task GetLearningProgress(string userId);
        Task GetUserProfile(string userId);
        Task LoginUser(UserLoginRequest request);
        Task RegisterUser(UserRegisterRequest request);
        Task UpdateLanguagePreference(string userId, UserPreferenceRequest request);
    }
}
