using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.DTOs;
using UserService.Middleware;
using UserService.Models;
using UserService.Repositories.Contracts;
using UserService.Services.Contracts;

namespace UserService.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IConfiguration _configuration;

        public UserService(ILogger<UserService> logger, IRepositoryManager repositoryManager, IConfiguration configuration)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
            _configuration = configuration;
        }

        public async Task<UserRegisterResponse> Register(UserRegisterRequest request)
        {
            // Create a new User object based on the request data
            User user = new()
            {
                Email = request.Email,
                EncryptedPassword = EncryptPassword(request.Password),
                FirstName = request.FirstName,
                LastName = request.LastName!,
                LanguageId = request.LanguageId!.Value,
                Contact = request.Contact!,
                Address = request.Address!
            };

            // Add the user to the database
            // TODO: check populating of user id
            await _repositoryManager.User.AddAsync(user);

            // Generate JWT token
            string? secretKey = _configuration["SecretKey"];
            if (secretKey == null)
            {
                throw new Exception("SecretKey is not configured.");
            }

            string token = GenerateJwtToken(user.UserId, secretKey);

            // Create UserRegisterResponse object with user details and token
            UserRegisterResponse response = new()
            {
                UserId = user.UserId,
                Email = user.Email,
                Token = token
            };

            return response;
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            // Retrieve user from the database based on the provided email
            User user = await _repositoryManager.User.GetUserByEmail(request.Email);

            // Check if the user exists
            if (user == null)
            {
                throw new NotFoundException("User with given email not found.");
            }

            //check if password is valid
            if (!VerifyPassword(request.Password, user.EncryptedPassword))
            {
                throw new UnauthorizedException("Invalid password, please try again.");
            }

            // Generate JWT token
            string? secretKey = _configuration["SecretKey"];
            if (secretKey == null)
            {
                throw new Exception("SecretKey is not configured.");
            }

            string token = GenerateJwtToken(user.UserId, secretKey);

            // Create UserLoginResponse object with user details and token
            UserLoginResponse response = new()
            {
                UserId = user.UserId,
                Email = user.Email,
                Token = token
            };

            return response;
        }

        public async Task<UserProfileResponse> GetUserProfile(int userId)
        {
            // Retrieve user from the database based on the provided userId
            User user = await _repositoryManager.User.GetByIdAsync(userId);

            // Check if the user exists
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            // Create UserProfileResponse object with user details
            UserProfileResponse response = new()
            {
                UserId = user.UserId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                LanguageId = user.LanguageId,
                Contact = user.Contact,
                Address = user.Address
            };

            return response;
        }

        public async Task<Bookmark> GetLearningProgress(int userId)
        {
            // Retrieve the bookmark record from the repository based on the provided userId
            Bookmark bookmark = await _repositoryManager.Bookmark.GetBookmarkByUserId(userId);

            // Check if the bookmark record exists
            return bookmark ?? throw new NotFoundException("Bookmark not found.");
        }
        public async Task UpdateLanguagePreference(int userId, UserPreferenceRequest request)
        {
            // Retrieve user from the database based on the provided userId
            User user = await _repositoryManager.User.GetByIdAsync(userId);

            // Check if the user exists
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            // Update the user's language preference
            user.LanguageId = request.LanguageId;

            // Save the changes to the database
            await _repositoryManager.User.UpdateAsync(user);
        }
        public async Task<AssessmentResultsResponse> GetAssessmentResults(int userId)
        {
            // Retrieve user from the database based on the provided userId
            User user = await _repositoryManager.User.GetByIdAsync(userId);

            // Check if the user exists
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            AssessmentResultsResponse response = new()
            {
                UserId = userId,
                Results = []
            };
            IEnumerable<Result> results = await _repositoryManager.Result.GetResultsByUserId(userId);

            // Populate the AssessmentResultsResponse model with the retrieved assessment records
            results.ToList().ForEach(result =>
            {
                response.Results.Add(new AssessmentResult
                {
                    AssessmentId = result.AssessmentId,
                    AttemptsCount = result.AttemptsCount,
                    Score = result.Score
                });
            });

            return response;

        }


        public async Task UpdateLearningProgress(int userId, Bookmark request)
        {
            // Retrieve user from the database based on the provided userId
            User user = await _repositoryManager.User.GetByIdAsync(userId);

            // Check if the user exists
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            // Retrieve the bookmark record from the repository based on the provided userId
            Bookmark bookmark = await _repositoryManager.Bookmark.GetBookmarkByUserId(userId);


            if (bookmark == null)
            {
                //  if the bookmark record does not exist add new record
                bookmark = new Bookmark
                {
                    UserId = userId,
                    LanguageId = request.LanguageId,
                    SectionId = request.SectionId,
                };
                await _repositoryManager.Bookmark.AddAsync(bookmark);
            }
            else
            {
                // Update the bookmark record
                bookmark.LanguageId = request.LanguageId;
                bookmark.SectionId = request.SectionId;
                await _repositoryManager.Bookmark.UpdateAsync(bookmark);
            }
        }


        // Private methods...

        private bool VerifyPassword(string password, string hashedPassword)
        {
            string encryptedPassword = EncryptPassword(password);
            return hashedPassword == encryptedPassword;
        }

        private string EncryptPassword(string password)
        {
            // Base64 encode the password
            // can use salt here storing it in db and using it to hash the password
            string encodedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            return encodedPassword;
        }

        private string GenerateJwtToken(int userId, string secretKey)
        {
            // Create the claims for the JWT token
            Claim[] claims = [new Claim(ClaimTypes.NameIdentifier, userId.ToString())];

            // Create the JWT token
            JwtSecurityToken token = new(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), SecurityAlgorithms.HmacSha256)
            );

            // Serialize the JWT token to a string
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
