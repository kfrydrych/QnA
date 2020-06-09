using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QnA.Application;
using QnA.Infrastructure;
using QnA.Persistence;
using QnA.Website.Infrastructure.Filters;
using QnA.Website.Services;

namespace QnA.Website
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(config =>
                {
                    config.Filters.Add(new AudienceIdentityCookieFilter());
                })
            .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<ApplicationMarker>();
                });

            services.AddApplication();

            services.AddAuthProviders();

            services.AddInfrastructure();

            services.AddPersistence(Configuration);

            services.AddWebsite();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.InitializeDatabase();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHub<ApplicationHub>("/applicationHub");
            });
        }
    }
}
