using Microsoft.Extensions.Options;
using Spear.Client.Builder;
using Spear.Client.Internal.SpearHttpClient.Contract;
using Spear.Client.Internal.Utilities;
using Spear.Client.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Spear.Client.Internal.SpearHttpClient
{
    internal class SpearDiscoveryClient : SpeareHttpClientBase, ISpearDiscoveryClient
    {
        //TODO fix this route
        private const string _serviceCatalogRoute = "/api/ServiceCatalogDefinitions";

        public SpearDiscoveryClient(HttpClient httpClient,
                                    IOptions<SpearHttpClientOption> option)
            : base(httpClient, option)
        { }

        public async Task<IEnumerable<ServiceCatalogDefinition>> GetServiceCatalogDefinition(
            ServiceCatalogDefinitionFilter? filter = null)
        {
            var urlFilter = filter?.GetAsUrlFilter();
            var urlParameter = string.IsNullOrWhiteSpace(urlFilter) == true ? string.Empty : "?" + urlFilter;

            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, _serviceCatalogRoute + $"{urlParameter}");
            httpRequest.Headers.Add("Accept", "application/json");

            using var response = await _httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead);

            if (!response.IsSuccessStatusCode)
                await HandleFailedResponse(response);

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var spearCatalogeDtos = await responseStream
                .ReadAndDeserializeFromJsonAsync<IList<ServiceCatalogDefinitionDto>>();

            return spearCatalogeDtos.Select(t => TypeMapper.ToServiceCatalogDefinition(t));
        }
    }
}
