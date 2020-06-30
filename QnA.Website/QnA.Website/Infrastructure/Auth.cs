using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.DependencyInjection;
using QnA.Application.Users.Events;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QnA.Website.Infrastructure
{
    public static class Auth
    {
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

                options.Events = new OAuthEvents
                {
                    OnTicketReceived = OnTicketReceived
                };
            })
            .AddFacebook(options =>
            {
                options.AppId = "2286438151659905";
                options.AppSecret = "07dff67babb9eaf457678b968f376e6a";
                options.SaveTokens = true;

                options.Events = new OAuthEvents
                {
                    OnTicketReceived = OnTicketReceived
                };
            });
        }

        private static async Task OnTicketReceived(TicketReceivedContext context)
        {
            var principal = context.Principal;

            if (principal != null)
            {
                var mediator = context.HttpContext.RequestServices.GetRequiredService<IMediator>();

                var @event = new UserLoggedInEvent
                {
                    FullName = principal.Identity.Name,
                    Email = principal.Claims
                        .FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value
                };

                await mediator.Publish(@event);
            }
        }
    }
}
