using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Spear.Api.Application.ServiceCatalogs;
using Spear.Api.Application.ServiceCatalogs.RegisterServiceDefinition;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static Spear.Api.Application.ServiceCatalogs.ServiceCatalogDefinitionDto;

namespace Spear.Api.Helpers
{
    internal static class IApplicationBuilderExtensions
    {

        public static IApplicationBuilder RegisterSpearCatalogs(this IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            _ = configuration ??
                throw new ArgumentNullException(nameof(configuration));

            var spearConfigurationSection = configuration.GetSection("ServiceCatalogConfigurations");

            List<ServiceCatalogDefinitionConfiguration> serviceCatalogConfigurations = new();
            spearConfigurationSection.Bind(serviceCatalogConfigurations);

            var mediator = applicationBuilder.ApplicationServices.GetRequiredService<IMediator>();

            foreach (var serviceCatalogConfiguration in serviceCatalogConfigurations)
            {
                var registrationCommand = new ServiceCatalogDefinitionRegisterCommand()
                {
                    Name = serviceCatalogConfiguration.Name,
                    DataPlane = serviceCatalogConfiguration.DataPlane,
                    Services = serviceCatalogConfiguration.Services.Select(r => new ServiceDefinitionDto(r.Name, r.MethodType))
                };

                var errors = registrationCommand.Validate(new ValidationContext(registrationCommand));

                if (errors.Any())
                {
                    //TODO throw exception
                    continue;
                    throw new Exception(string.Join(',', errors));
                }

                _ = mediator.Send(registrationCommand).Result;
            }

            return applicationBuilder;
        }
    }
}
