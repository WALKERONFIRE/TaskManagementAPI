using System.Net;
using TaskManagement.LL.Interfaces;

namespace TaskManagement.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;

        public ExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _loggerService.LogError($"Exception caught in middleware: {ex.Message}");
                _loggerService.LogError($"Stack Trace: {ex.StackTrace}");

                if (ex.InnerException != null)
                {
                    _loggerService.LogError($"Inner Exception: {ex.InnerException.Message}");
                    _loggerService.LogError($"Inner Stack Trace: {ex.InnerException.StackTrace}");
                }

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is UnauthorizedAccessException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (exception is KeyNotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            var errorDetails = new
            {
                StatusCode = context.Response.StatusCode,
                Message = exception switch
                {
                    UnauthorizedAccessException => "Unauthorized access.",
                    KeyNotFoundException => "Resource not found.",
                    _ => "An unexpected error occurred. Please check the logs for more details."
                }
            };

            _loggerService.LogError($"Request Path: {context.Request.Path}");
            _loggerService.LogError($"Request Method: {context.Request.Method}");
            _loggerService.LogError($"Response Status Code: {context.Response.StatusCode}");

            return context.Response.WriteAsJsonAsync(errorDetails);
        }
    }
}
