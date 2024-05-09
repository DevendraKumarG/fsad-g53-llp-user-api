namespace UserService.DTOs
{
    public class UserPreferenceRequest
    {
        public required int UserId { get; set; }
        public required int LanguageId { get; set; }
    }
}
