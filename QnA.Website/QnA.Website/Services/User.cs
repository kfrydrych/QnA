using Microsoft.AspNetCore.Http;
using QnA.Application.Interfaces;
using System.Linq;

namespace QnA.Website.Services
{
    public class User : IUser
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public User(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string Username => _contextAccessor?.HttpContext?.User?.Claims?
            .FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

        public string UniqueSource => _contextAccessor.HttpContext.Request.Cookies["audience-id"];
    }
}
