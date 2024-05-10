using System.ComponentModel.DataAnnotations.Schema;

namespace Llp.User.Models
{
    [Table("languages")]
    public class Language
    {
        [Column("language_id")]
        public required int LanguageId { get; set; }
        [Column("name")]
        public required string Name { get; set; }
        [Column("description")]
        public string Description { get; set; } = "";
        [Column("code")]
        public string Code { get; set; } = "";
    }
}
