namespace UserService.Models
{
    public class Bookmark
    {
        public int UserId { get; set; }
        public int LanguageId { get; set; }
        public int SectionId { get; set; }

        public virtual User? User { get; set; }
        public virtual Language? Language { get; set; }
    }
}
