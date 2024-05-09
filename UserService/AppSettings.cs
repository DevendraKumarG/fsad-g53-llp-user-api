namespace UserService
{
    public class AppSettings
    {
        public required string S3BucketName { get; set; }
        public required string AccessKey { get; set; }
        public required string SecretKey { get; set; }
        public required string DbConnectionString { get; set; }
    }

}
