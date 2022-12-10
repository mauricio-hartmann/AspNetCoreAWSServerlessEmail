using ANCASE.MessageBus.AWS;
using ANCASE.MessageBus.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ANCASE.MessageBus.Configuration
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureMessageBus(this IServiceCollection services, string accessKey, string secretKey)
        {
            
            services.AddSingleton<IMessageBus>(new AwsMessageBus(accessKey, secretKey));

            return services;
        }
    }
}
