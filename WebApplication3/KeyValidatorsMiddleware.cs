using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplication3
{
    public class KeyValidatorsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string pattern;
        public KeyValidatorsMiddleware(RequestDelegate next,string pattern)
        {
            _next = next;
            this.pattern = pattern;
        }
        public async Task Invoke(HttpContext context)
        {
            var id = context.Request.Query["id"];
            if (id != pattern)
            {
                context.Response.StatusCode = 400; //Bad Request                
                await context.Response.WriteAsync("Request is denied");
                return;
            }
            await _next.Invoke(context);
        }
    }
}
