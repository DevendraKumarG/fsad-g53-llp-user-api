using System.Net;
using System.Text.Json;

namespace Llp.User.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error. " + ex.Message;

            if (ex is UnauthorizedException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                message = "Unauthorized. " + ex.Message;
            }
            else if (ex is NotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                message = "Not Found. " + ex.Message;
            }
            else if (ex is ValidationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                message = "Validation Error. " + ex.Message;
            }
            // Add more exception types and corresponding status codes and messages here

            var response = new
            {
                context.Response.StatusCode,
                Message = message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
