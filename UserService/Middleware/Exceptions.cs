namespace UserService.Middleware
{

    // UnauthorizedException.cs
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }

    // NotFoundException.cs

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }

    // ValidationException.cs

    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }
    }

}
