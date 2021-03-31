using Spear.Api.Application.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Spear.Api.Application.ServiceCatalogs.GetServiceDefinition
{
    public class GetServiceCatalogDefinitionQuery : IQuery<IEnumerable<ServiceCatalogDefinitionDto>>, IValidatableObject
    {
        public string? Name { get; set; }
        public string? DataPlane { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrWhiteSpace(DataPlane))
            {
                var dataPlaneValues = Enum.GetNames(typeof(Abstraction.DataPlane));

                if (!dataPlaneValues.Any(t => string.Equals(t, DataPlane, StringComparison.InvariantCultureIgnoreCase)))
                    yield return new ValidationResult($"{nameof(DataPlane)} must be one of {string.Join(',', dataPlaneValues)}.",
                    new[] { nameof(DataPlane) });
            }
        }
    }
}
