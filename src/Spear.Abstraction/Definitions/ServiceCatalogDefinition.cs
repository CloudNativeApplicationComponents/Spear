﻿using System;
using System.Collections.Generic;

namespace Spear.Abstraction.Definitions
{
    public class ServiceCatalogDefinition : IEquatable<ServiceCatalogDefinition>
    {
        public string Name { get; }
        public DataPlane DataPlane { get; }

        //TOOD add init only
        public IList<ServiceDefinition> Services { get; }

        public ServiceCatalogDefinition(string name, DataPlane dataPlane)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
            DataPlane = dataPlane;
            Services = new List<ServiceDefinition>();
        }

        public bool Equals(ServiceCatalogDefinition? other)
        {
            if (other == null)
                return false;

            return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase) &&
                DataPlane == other.DataPlane;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ServiceCatalogDefinition);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, DataPlane);
        }

        public override string ToString()
        {
            return $"{Name}-{DataPlane}";
        }
    }
}
