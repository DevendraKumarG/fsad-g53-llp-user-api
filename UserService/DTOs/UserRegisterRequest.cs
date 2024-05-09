namespace UserService.DTOs
{
    public class UserRegisterRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public int? LanguageId { get; set; }
        public string? Contact { get; set; }
        public string? Address { get; set; }
    }
}
