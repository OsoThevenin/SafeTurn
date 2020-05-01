using Microsoft.AspNetCore.Builder;
using PriceManager.Api.Middleware;

namespace PriceManager.Api.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseHttpException(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
