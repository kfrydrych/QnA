using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QnA.Application;
using QnA.Application.Interfaces;
using QnA.Infrastructure.Background.Infrastructure;
using QnA.Persistence;
using System.IO;

[assembly: FunctionsStartup(typeof(QnA.Infrastructure.Background.Startup))]
namespace QnA.Infrastructure.Background
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            IConfiguration configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddHttpClient();

            builder.Services.AddApplication();

            builder.Services.AddPersistence(configurationRoot);

            builder.Services.AddInfrastructure();

            builder.Services.AddSingleton<IUser, SystemUser>();
        }
    }
}
