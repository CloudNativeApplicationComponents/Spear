using Spear.Api.Application.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Spear.Api.Application.ServiceCatalogs.ServiceCatalogDefinitionDto;

namespace Spear.Api.Application.ServiceCatalogs.RegisterServiceDefinition
{
    public class ServiceCatalogDefinitionRegisterCommand : CommandBase<ServiceCatalogDefinitionDto>, IValidatableObject
    {
        [NotNull]
        [DisallowNull]
        public string Name { get; set; } = default!;
        
        [NotNull]
        [DisallowNull]
        public string DataPlane { get; set; } = default!;
        public IEnumerable<ServiceDefinitionDto> Services { get; set; } = new List<ServiceDefinitionDto>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var dataPlaneEnums = Enum.GetNames(typeof(Abstraction.DataPlane));

            if (!dataPlaneEnums.Any(t => string.Equals(DataPlane, t, StringComparison.InvariantCultureIgnoreCase)))
                yield return new ValidationResult($"{nameof(DataPlane)} must be one of {string.Join(',', dataPlaneEnums)}.",
               new[] { nameof(DataPlane) });

            if (Services.Any())
            {
                var methodTypes = Enum.GetNames(typeof(Abstraction.Definitions.SpearServiceType));

                if (Services.Select(t => t.MethodType)
                    .Any(t => !methodTypes.Any(r =>
                        string.Equals(t, r, StringComparison.InvariantCultureIgnoreCase))))
                    yield return new ValidationResult($"{nameof(ServiceDefinitionDto.MethodType)} must be one of {string.Join(',', methodTypes)}.",
                    new[] { nameof(ServiceDefinitionDto.MethodType) });
            }
        }
    }
}
