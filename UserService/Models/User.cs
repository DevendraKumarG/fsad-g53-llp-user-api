namespace UserService.Models
{
    public class User
    {
        public required int UserId { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; } = "";
        public required string Email { get; set; }
        public required string EncryptedPassword { get; set; }
        public int LanguageId { get; set; }
        public string Contact { get; set; } = "";
        public string Address { get; set; } = "";

        public virtual Language? Language { get; set; }
        public virtual ICollection<Bookmark>? Bookmarks { get; set; }
    }
}
