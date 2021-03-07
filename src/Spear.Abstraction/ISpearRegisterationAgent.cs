using Spear.Abstraction.Definitions;
using System;

namespace Spear.Abstraction
{
    public interface ISpearRegisterationAgent : IDisposable
    {
        void Register(ServiceCatalogDefinition serviceDefinition);
    }
}
