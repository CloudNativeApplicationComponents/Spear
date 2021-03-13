using Microsoft.Extensions.DependencyInjection;
using Spear.Abstraction;
using Spear.Engine.Internal;

namespace Spear.Engine.Builder
{
    public static class IServiceCollectionExtensions
    {

        public static IServiceCollection AddDefaultSpareEngine(this IServiceCollection services)
        {
            services.AddSingleton<ISpearEngine, SpearEngine>();
            return services;
        }


    }
}
