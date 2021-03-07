using CloudNativeApplicationComponents.Utils;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Options;
using Spear.Abstraction;
using Spear.Abstraction.Definitions;
using Spear.Abstraction.ServiceCrawler;
using Spear.ServiceCrawler.Grpc.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Spear.ServiceCrawler.Grpc
{
    public class GrpcFileDescriptorSetServiceCrawler : ISpearServiceCrawler
    {
        private readonly GrpcFileDescriptorSetServiceCrawlerOptions _options;
        public GrpcFileDescriptorSetServiceCrawler(IOptions<GrpcFileDescriptorSetServiceCrawlerOptions> options)
        {
            _options = options?.Value
                ?? throw new ArgumentNullException(nameof(options));
        }

        public IEnumerable<ServiceCatalogDefinition> Crawl()
        {
            var services = new Dictionary<ValueTuple<string, DataPlane>, ServiceCatalogDefinition>();
            foreach (var directory in _options.Directories)
            {
                var files = new DirectoryInfo(directory)
                     .GetFiles("*.desc", SearchOption.TopDirectoryOnly)
                     .Where(t => string.Equals(t.Extension, ".desc"));

                foreach (var file in files)
                {
                    var bytes = File.ReadAllBytes(file.FullName);
                    FileDescriptorSet set = FileDescriptorSet.Parser.ParseFrom(bytes);
                    foreach (var fileDescriptor in set.File)
                    {
                        var package = fileDescriptor.HasPackage ? fileDescriptor.Package : "";
                        foreach (var service in fileDescriptor.Service)
                        {
                            var key = ($"{package}.{service.Name}", DataPlane.Grpc);
                            var serviceCatalog = services.GetOrAdd(key, k => new ServiceCatalogDefinition(k.Item1, k.Item2));
                            foreach (var method in service.Method)
                            {
                                SpearServiceType serviceType = GetServiceType(method);

                                serviceCatalog.Services.Add(new ServiceDefinition(method.Name, serviceType));
                            }
                        }
                    }
                }
            }
            return services.Values;
        }
        private SpearServiceType GetServiceType(MethodDescriptorProto method)
        {
            SpearServiceType serviceType;
            if (!method.HasClientStreaming && !method.HasServerStreaming)
            {
                if (method.OutputType == Empty.Descriptor.Name)
                    serviceType = SpearServiceType.Event;
                else
                    serviceType = SpearServiceType.Unary;
            }
            else if (method.HasClientStreaming && !method.HasServerStreaming)
            {
                serviceType = SpearServiceType.ClientStreaming;
            }
            else if (!method.HasClientStreaming && method.HasServerStreaming)
            {
                serviceType = SpearServiceType.ServerStreaming;
            }
            else
            {
                serviceType = SpearServiceType.DuplexStreaming;
            }

            return serviceType;
        }
    }
}
