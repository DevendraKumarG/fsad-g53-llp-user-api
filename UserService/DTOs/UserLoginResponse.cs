namespace UserService.DTOs
{
    public class UserLoginResponse
    {
        public required string Token { get; set; }
        public required string Email { get; set; }
        public required int UserId { get; set; }
    }
}
