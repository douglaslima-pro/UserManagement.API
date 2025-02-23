namespace UserManagement.API.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync (HttpContext context)
        {
            Console.WriteLine($"Request path: {context.Request.Path.ToString()}");
            Console.WriteLine($"Request method: {context.Request.Method}");
            Console.WriteLine($"Request content type: {context.Request.ContentType}");
            await _next(context);
            Console.WriteLine($"Response status code: {context.Response.StatusCode}");
            Console.WriteLine($"Response content type: {context.Response.ContentType}");
        }
    }

    public static class LoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
