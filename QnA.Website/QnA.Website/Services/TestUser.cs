using Microsoft.AspNetCore.Http;
using QnA.Application.Interfaces;

namespace QnA.Website.Services
{
    public class TestUser : IUser
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TestUser(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string Username => "krzysztof.frydrych@mail.com";
        public string UniqueSource => _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
    }
}
