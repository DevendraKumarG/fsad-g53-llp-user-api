using Microsoft.AspNetCore.Mvc;
using UserService.DTOs;
using UserService.Models;
using UserService.Services.Contracts;

namespace UserService.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            UserRegisterResponse userDetails = await _userService.Register(request);

            return Ok(userDetails);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            UserLoginResponse result = await _userService.Login(request);

            return Ok(result);
        }

        [HttpGet("{userId}/profile")]
        public async Task<IActionResult> GetUserProfile(int userId)
        {
            UserProfileResponse userDetails = await _userService.GetUserProfile(userId);

            return Ok(userDetails);
        }

        [HttpPut("{userId}/preference")]
        public async Task<IActionResult> UpdateLanguagePreference(int userId, UserPreferenceRequest request)
        {
            await _userService.UpdateLanguagePreference(userId, request);

            return Ok("updated language preferences successfully");
        }

        [HttpGet("{userId}/progress")]
        public async Task<IActionResult> GetLearningProgress(int userId)
        {
            Bookmark bookmark = await _userService.GetLearningProgress(userId);
            return Ok(bookmark);
        }

        [HttpPost("{userId}/progress")]
        public async Task<IActionResult> UpdateLearningProgress(int userId, [FromBody] Bookmark bookmark)
        {
            await _userService.UpdateLearningProgress(userId, bookmark);

            return Ok("updated learning progress successfully");
        }

        [HttpGet("{userId}/results")]
        public async Task<IActionResult> GetAssessmentResults(int userId)
        {
            AssessmentResultsResponse results = await _userService.GetAssessmentResults(userId);

            return Ok(results);
        }
    }
}
