namespace Llp.User.DTOs
{
    public class UserProfileResponse
    {
        public required int UserId { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; } = "";
        public required string Email { get; set; }
        public int LanguageId { get; set; }
        public string Contact { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
