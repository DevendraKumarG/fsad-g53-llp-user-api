//using Microsoft.AspNetCore.Mvc;
//using UserService.DTOs;
//using UserService.Services.Contracts;

//namespace UserService.Controllers
//{
//    [ApiController]
//    [Route("user")]
//    public class UserController : ControllerBase
//    {
//        private readonly IUserService _userService;

//        public UserController(IUserService userService)
//        {
//            _userService = userService;
//        }

//        [HttpPost("register")]
//        public async Task<IActionResult> Register(UserRegisterRequest request)
//        {
//            // Call the UserService to handle the registration logic
//            //var result = await _userService.RegisterUser(request);

//            return result.Success ? Ok(result.Data) : BadRequest(result.ErrorMessage);
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login(UserLoginRequest request)
//        {
//            // Call the UserService to handle the login logic
//            //var result = await _userService.LoginUser(request);

//            return result.Success ? Ok(result.Data) : Unauthorized(result.ErrorMessage);
//        }

//        [HttpGet("{userId}/profile")]
//        public async Task<IActionResult> GetUserProfile(string userId)
//        {
//            // Call the UserService to get the user profile
//            //var result = await _userService.GetUserProfile(userId);

//            //return result.Success ? Ok(result.Data) : NotFound(result.ErrorMessage);
//        }

//        [HttpPut("{userId}/preference")]
//        public async Task<IActionResult> UpdateLanguagePreference(string userId, UserPreferenceRequest request)
//        {
//            // Call the UserService to update the user preference
//            //var result = await _userService.UpdateLanguagePreference(userId, request);

//            //return result.Success ? Ok(result.Data) : BadRequest(result.ErrorMessage);
//        }

//        [HttpGet("{userId}/progress")]
//        public async Task<IActionResult> GetLearningProgress(string userId)
//        {
//            // Call the UserService to get the user progress
//            //var result = await _userService.GetLearningProgress(userId);

//        }

//        [HttpGet("{userId}/results")]
//        public async Task<IActionResult> GetAssessmentResults(string userId)
//        {
//            // Call the UserService to get the user results
//            //var result = await _userService.GetAssessmentResults(userId);

//            //return result.Success ? Ok(result.Data) : NotFound(result.ErrorMessage);
//        }
//    }
//}
