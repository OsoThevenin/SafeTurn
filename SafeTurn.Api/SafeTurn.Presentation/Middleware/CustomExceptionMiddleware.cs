using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PriceManager.Api.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)

        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                int statusCode = (int)HttpStatusCode.InternalServerError;
                if (statusCode == (int)HttpStatusCode.InternalServerError) _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ex.Message));
                    await context.Response.Body.WriteAsync(data, 0, data.Length);
                }
            }
        }
    }
}
