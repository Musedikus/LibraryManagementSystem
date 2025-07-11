using Infrastructure.Persistence;
using System.Security.Claims;

namespace API.Middleware
{
    public class TokenVersionValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenVersionValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext dbContext)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var tokenVersion = context.User.FindFirst("tokenVersion")?.Value;

                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(tokenVersion))
                {
                    var user = await dbContext.Users.FindAsync(int.Parse(userId));
                    if (user == null || user.TokenVersion != tokenVersion)
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("Unauthorized: Token is invalid or expired.");
                        return;
                    }
                }
            }

            await _next(context);
        }
    }

}
