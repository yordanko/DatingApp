using API.Data;
using API.DTOs;
using API.Helpers;
using API.Interfaces;
using API.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        delegate HealthCheckResult CustomHealthCheckDelegate();
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IHealthCheckProvider, HealthCheckProvider>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            //services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static void AddHealthcheckService(this IServiceCollection services, IConfiguration config)
        {
            var serviceProvider = services.BuildServiceProvider();
            var healthProvider = serviceProvider.GetRequiredService<IHealthCheckProvider>();
            CustomHealthCheckDelegate databaseHealthCheckDelegate = healthProvider.DatabaseHealthCheck;
            services.AddHealthChecks().AddCheck("Service health", () =>
            {
                // DO checkes for health. For example healthy.
                return HealthCheckResult.Healthy(" The check for Api service works excelently");
            })
                .AddCheck("Service additional check", () => HealthCheckResult.Healthy("This is healthy"))
                .AddCheck("Database DelegateCheck", ()=>databaseHealthCheckDelegate());
                // another check

        }
    }
}