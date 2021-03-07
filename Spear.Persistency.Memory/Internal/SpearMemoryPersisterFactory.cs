using Spear.Abstraction;

namespace Spear.Persistency.Memory.Internal
{
    public class SpearMemoryPersisterFactory : ISpearPersisterFactory
    {
        public ISpearPersister Create()
        {
            return new SpearMemoryPersister();
        }
    }
}
