using System;

namespace Spear.Abstraction.Definitions
{
    public class ServiceDefinition : IEquatable<ServiceDefinition>
    {
        public string Name { get; }
        public SpearServiceType MethodType { get; }

        public ServiceDefinition(string name, SpearServiceType methodType)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(name);
            Name = name;
            MethodType = methodType;
        }

        public bool Equals(ServiceDefinition other)
        {
            if (other == null)
                return false;

            return string.Equals(Name, other.Name, StringComparison.InvariantCulture) && MethodType == other.MethodType;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ServiceCatalogDefinition);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, MethodType);
        }

        public override string ToString()
        {
            return $"{Name}-{MethodType}";
        }
    }
}
