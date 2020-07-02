using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using QnA.Application.Interfaces;
using QnA.Website.Services;

namespace QnA.Website
{
    public static class DependencyInjection
    {
        public static void AddWebsite(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddSingleton<IUser, User>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSignalR();
        }
    }
}
