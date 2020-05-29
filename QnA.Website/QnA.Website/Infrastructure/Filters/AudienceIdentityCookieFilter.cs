using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace QnA.Website.Infrastructure.Filters
{
    public class AudienceIdentityCookieFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var storedCookie = context.HttpContext.Request.Cookies["audience-id"];

            if (storedCookie == null)
            {
                var key = "audience-id";
                var value = Guid.NewGuid().ToString();
                var options = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) };
                context.HttpContext.Response.Cookies.Append(key, value, options);
            }

            await next();
        }
    }
}
