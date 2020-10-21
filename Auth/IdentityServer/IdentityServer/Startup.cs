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

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.RequireHttpsMetadata = false;
            //        options.SaveToken = true;
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = Configuration["Jwt:Issuer"],
            //            ValidAudience = Configuration["Jwt:Audience"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
            //            ClockSkew = TimeSpan.Zero
            //        };
            //    });

            services.AddAuthorization(config =>
            {
                //do we need to add all policies
                config.AddPolicy(ReRoles.Admin, RePolicies.AdminPolicy());
                config.AddPolicy(ReRoles.Teacher, RePolicies.TeacherPolicy());
                config.AddPolicy(ReRoles.Manager, RePolicies.ManagerPolicy());
                config.AddPolicy(ReRoles.Student, RePolicies.StudentPolicy());
            });
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
