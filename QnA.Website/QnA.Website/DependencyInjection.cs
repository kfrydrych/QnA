using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.DependencyInjection;
using QnA.Application.Interfaces;
using QnA.Website.Services;
using System.Reflection;
using System.Security.Claims;

namespace QnA.Website
{
    public static class DependencyInjection
    {
        public static void AddWebsite(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddSingleton<IUser, TestUser>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSignalR();
        }

        public static void AddAuthProviders(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogle(options =>
            {
                options.ClientId = "463569522699-oidt3pt8qi76nmjqjrtvatbs5o8e35ti.apps.googleusercontent.com";
                options.ClientSecret = "t-FOmUYWogLCe1S2CBnzcfVY";
                options.SaveTokens = true;
                options.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
                options.ClaimActions.Clear();
                options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                options.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "given_name");
                options.ClaimActions.MapJsonKey(ClaimTypes.Surname, "family_name");
                options.ClaimActions.MapJsonKey("urn:google:profile", "link");
                options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
                options.ClaimActions.MapJsonKey("picture", "picture");
            })
            .AddFacebook(options =>
            {
                options.AppId = "2286438151659905";
                options.AppSecret = "07dff67babb9eaf457678b968f376e6a";
                options.SaveTokens = true;
            });
        }
    }
}
