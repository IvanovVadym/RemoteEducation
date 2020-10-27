using System;
using System.Text;
using Application;
using Authorization.Library.Roles;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using RE.Application.Library.Filters;
using RE.Application.Library.Interfaces;
using RE.Authorization.Library.DependencyInjection;
using RE.Authorization.Library.Policies;
//using RE.IdentityServer.Filters;
using RE.IdentityServer.Interfaces;
using RE.IdentityServer.Services;

namespace RE.IdentityServer
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
            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddHttpContextAccessor();
            services.AddControllers();

            services.AddControllersWithViews(options =>
                    options.Filters.Add(new ApiExceptionFilterAttribute()))
                .AddFluentValidation();

            services.AddReAuthentication(Configuration["Jwt:Issuer"], Configuration["Jwt:Audience"],
                Configuration["Jwt:SecretKey"]);

            services.AddAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
