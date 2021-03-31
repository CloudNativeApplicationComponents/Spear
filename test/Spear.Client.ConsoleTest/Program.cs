using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Spear.Client.Builder;
using Spear.Client.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Spear.Client.Services.ServiceCatalogDefinition;

namespace Spear.Client.ConsoleTest
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging(t => t.AddConsole())
                .AddSpareHttpClient(t => { t.BaseAddress = new System.Uri("https://localhost:5001"); })
                .BuildServiceProvider();


            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogDebug("Starting application");
            try
            {
                var discoveryClient = serviceProvider.GetRequiredService<ISpearDiscoveryClient>();
                var registreationClient = serviceProvider.GetRequiredService<ISpearRegistrationClient>();


                var discoveryResult = await discoveryClient.GetServiceCatalogDefinition();

                var registreationResult =
                    await registreationClient.RegisterServiceCatalogDefinition(
                        new ServiceCatalogDefinition(
                            "GrpcCatalogs",
                            "Grpc",
                            new List<ServiceDefinition>()
                            {
                                new ServiceDefinition("ServiceName","Event")

                            }));

                var afterRegistrationResultWithDataPlanFilter =
                    await discoveryClient.GetServiceCatalogDefinition(
                        new ServiceCatalogDefinitionFilter
                        { DataPlane = "Grpc" });

                var afterRegistrationResultWithNameFilter =
                    await discoveryClient.GetServiceCatalogDefinition(
                        new ServiceCatalogDefinitionFilter { Name = "GrpcCatalogs" });

                var afterRegistrationResultWithAllFilter =
                    await discoveryClient.GetServiceCatalogDefinition(
                        new ServiceCatalogDefinitionFilter { Name = "GrpcCatalogs", DataPlane = "Rest" });
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
            }

            logger.LogDebug("All done!");
            Console.ReadLine();
        }
    }
}
