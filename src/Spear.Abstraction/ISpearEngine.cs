using System;

namespace Spear.Abstraction
{
    public interface ISpearEngine
    {
        ISpearDiscoveryAgent Discovery();
        ISpearRegisterationAgent Registeration();
    }
}
