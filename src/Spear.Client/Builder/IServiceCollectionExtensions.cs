using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spear.Client.Internal.SpearHttpClient;
using Spear.Client.Services;
using System;

namespace Spear.Client.Builder
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSpareHttpClient(this IServiceCollection services,
                                                            Action<SpearHttpClientOption> configureOptions)
        {
            services.Configure(configureOptions);
            return AddSpareHttpClient(services);
        }

        public static IServiceCollection AddSpareHttpClient(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            services.Configure<SpearHttpClientOption>(configuration.Bind);
            return AddSpareHttpClient(services);
        }

        private static IServiceCollection AddSpareHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient<ISpearDiscoveryClient, SpearDiscoveryClient>();
            services.AddHttpClient<ISpearRegistrationClient, SpearRegistrationClient>();

            return services;
        }
    }
}
