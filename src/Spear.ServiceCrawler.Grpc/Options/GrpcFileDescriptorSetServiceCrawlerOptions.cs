using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Spear.ServiceCrawler.Grpc.Options
{
    public class GrpcFileDescriptorSetServiceCrawlerOptions
    {
        [NotNull]
        [DisallowNull]
        public List<string>? Directories { get; set; }
    }
}