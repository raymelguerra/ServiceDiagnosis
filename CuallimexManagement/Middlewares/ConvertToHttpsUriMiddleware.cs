
namespace CuallimexManagement.Middlewares
{
    public class ConvertToHttpsUriMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Headers["X-Forwarded-Proto"] == "https")
            {
                context.Request.Scheme = "https";
            }
            await next(context);
        }
    }
}
