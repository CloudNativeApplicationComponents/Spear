using Microsoft.Extensions.DependencyInjection;
using Spear.Abstraction;
using Spear.Persistency.Memory.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spear.Persistency.Memory.Builder
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSpearMemoryPersisterFactory(this IServiceCollection services)
        {
            services.AddSingleton<ISpearPersisterFactory, SpearMemoryPersisterFactory>();
            return services;
        }
    }
}
