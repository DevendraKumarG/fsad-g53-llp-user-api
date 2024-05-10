using System.ComponentModel.DataAnnotations.Schema;

namespace Llp.User.Models
{
    [Table("results")]
    public class Result
    {
        [Column("result_id")]
        public int ResultId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("assessment_id")]
        public int AssessmentId { get; set; }
        [Column("attempts_count")]
        public int AttemptsCount { get; set; }
        [Column("score")]
        public int Score { get; set; }
    }
}
