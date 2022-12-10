using ANCASE.API.Application.Services.Implementations;
using ANCASE.API.Application.Services.Interfaces;
using ANCASE.MessageBus.Configuration;

namespace ANCASE.API.Configuration
{
    public static class IoCConfiguration
    {
        public static IServiceCollection AddIoCConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Services
            services.AddScoped<IEmailService, EmailService>();

            // Infra
            services.ConfigureMessageBus(configuration.GetValue<string>("AWS:AccessKey"), configuration.GetValue<string>("AWS:SecretKey"));

            return services;
        }
    }
}
