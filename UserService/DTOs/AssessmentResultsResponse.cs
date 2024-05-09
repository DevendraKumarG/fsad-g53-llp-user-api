namespace UserService.DTOs
{
    public class AssessmentResultsResponse
    {
        public required int UserId { get; set; }
        public required IEnumerable<AssessmentResult> Results { get; set; }

    }

    public class AssessmentResult
    {
        public int AssessmentId { get; set; }
        public int AttemptsCount { get; set; }
        public int Score { get; set; }
    }
}
