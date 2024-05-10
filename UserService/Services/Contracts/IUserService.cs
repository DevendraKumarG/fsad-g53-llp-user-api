using Llp.User.DTOs;
using Llp.User.Models;

namespace Llp.User.Services.Contracts
{
    public interface IUserService
    {
        Task<AssessmentResultsResponse> GetAssessmentResults(int userId);
        Task<Bookmark> GetLearningProgress(int userId);
        Task UpdateLearningProgress(int userId, Bookmark request);
        Task<UserProfileResponse> GetUserProfile(int userId);
        Task<UserLoginResponse> Login(UserLoginRequest request);
        Task<UserRegisterResponse> Register(UserRegisterRequest request);
        Task UpdateLanguagePreference(int userId, UserPreferenceRequest request);
    }
}
