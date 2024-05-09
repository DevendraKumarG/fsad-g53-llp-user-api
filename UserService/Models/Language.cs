namespace UserService.Models
{
    public class Language
    {
        public required int LanguageId { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = "";
        public string Code { get; set; } = "";
    }
}
