using System.ComponentModel.DataAnnotations.Schema;

namespace Llp.User.Models
{
    [Table("bookmarks")]
    public class Bookmark
    {
        [Column("bookmark_id")]
        public int BookmarkId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("language_id")]
        public int LanguageId { get; set; }
        [Column("section_id")]
        public int SectionId { get; set; }
    }
}
