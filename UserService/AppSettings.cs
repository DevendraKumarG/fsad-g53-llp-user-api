namespace Llp.User
{
    public class AppSettings
    {
        public required string S3BucketName { get; set; }
        public required string AWSAccessKey { get; set; }
        public required string AWSSecretKey { get; set; }
        public required string SecretKey { get; set; }
        public required string DbConnectionString { get; set; }
    }

}
