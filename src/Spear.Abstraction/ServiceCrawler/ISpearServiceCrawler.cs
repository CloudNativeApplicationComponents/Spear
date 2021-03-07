using Spear.Abstraction.Definitions;
using System.Collections.Generic;

namespace Spear.Abstraction.ServiceCrawler
{
    public interface ISpearServiceCrawler
    {
        IEnumerable<ServiceCatalogDefinition> Crawl();
    }
}
