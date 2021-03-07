using Spear.Abstraction;
using System;

namespace Spear.Engine.Internal
{
    internal class SpearEngine : ISpearEngine
    {
        private readonly ISpearPersisterFactory _spearPersisterFactory;
        public SpearEngine(ISpearPersisterFactory spearPersisterFactory)
        {
            _spearPersisterFactory = spearPersisterFactory
                ?? throw new ArgumentNullException(nameof(spearPersisterFactory));
        }
        public ISpearRegisterationAgent Registeration()
        {
            return new SpearRegisterationAgent(_spearPersisterFactory.Create());
        }

        public ISpearDiscoveryAgent Discovery()
        {
            throw new System.NotImplementedException();
        }
    }
}
