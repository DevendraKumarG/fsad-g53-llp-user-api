using System.ComponentModel.DataAnnotations.Schema;

namespace Llp.User.Models
{
    [Table("users")]
    public class User
    {
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("first_name")]
        public required string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; } = "";
        [Column("email")]
        public required string Email { get; set; }
        [Column("encrypted_password")]
        public required string EncryptedPassword { get; set; }
        [Column("language_id")]
        public int LanguageId { get; set; }
        [Column("contact")]
        public string Contact { get; set; } = "";
        [Column("address")]
        public string Address { get; set; } = "";
    }
}
