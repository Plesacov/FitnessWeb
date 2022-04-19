using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebApplication3
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggerMiddleWare(RequestDelegate next, ILogger<LoggerMiddleWare> loggerFactory)
        {
            _next = next;
            _logger = loggerFactory;
        }

        public async Task Invoke(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            finally
            {
                _logger.LogInformation(
                    "Request {method} {url} => {statusCode}",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response?.StatusCode);
            }
        }
    }
}
