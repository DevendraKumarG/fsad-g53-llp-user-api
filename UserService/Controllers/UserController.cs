using Llp.User.DTOs;
using Llp.User.Models;
using Llp.User.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Llp.User.Controllers
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
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            UserRegisterResponse userDetails = await _userService.Register(request);

            return Ok(userDetails);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            UserLoginResponse result = await _userService.Login(request);

            return Ok(result);
        }

        [HttpGet("{userId}/profile")]
        [Authorize]
        public async Task<IActionResult> GetUserProfile(int userId)
        {
            UserProfileResponse userDetails = await _userService.GetUserProfile(userId);

            return Ok(userDetails);
        }

        [HttpPut("{userId}/preference")]
        [Authorize]
        public async Task<IActionResult> UpdateLanguagePreference(int userId, UserPreferenceRequest request)
        {
            await _userService.UpdateLanguagePreference(userId, request);

            return Ok("updated language preferences successfully");
        }

        [HttpGet("{userId}/progress")]
        [Authorize]
        public async Task<IActionResult> GetLearningProgress(int userId)
        {
            Bookmark bookmark = await _userService.GetLearningProgress(userId);
            return Ok(bookmark);
        }

        [HttpPost("{userId}/progress")]
        [Authorize]
        public async Task<IActionResult> UpdateLearningProgress(int userId, [FromBody] Bookmark bookmark)
        {
            await _userService.UpdateLearningProgress(userId, bookmark);

            return Ok("updated learning progress successfully");
        }

        [HttpGet("{userId}/results")]
        [Authorize]
        public async Task<IActionResult> GetAssessmentResults(int userId)
        {
            AssessmentResultsResponse results = await _userService.GetAssessmentResults(userId);

            return Ok(results);
        }
    }
}
