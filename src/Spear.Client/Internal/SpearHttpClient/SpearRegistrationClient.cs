using Microsoft.Extensions.Options;
using Spear.Client.Builder;
using Spear.Client.Internal.SpearHttpClient.Contract;
using Spear.Client.Internal.Utilities;
using Spear.Client.Services;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Spear.Client.Internal.SpearHttpClient
{
    internal class SpearRegistrationClient : SpeareHttpClientBase, ISpearRegistrationClient
    {
        //TODO fix this route
        private const string _serviceRegistrationPath = "/api/ServiceCataloges/";

        public SpearRegistrationClient(
            HttpClient httpClient,
            IOptions<SpearHttpClientOption> option)
            : base(httpClient, option)
        { }

        public async Task<ServiceCatalogDefinition> RegisterServiceCatalogDefinition(
            ServiceCatalogDefinition serviceCatalog)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, _serviceRegistrationPath);
            using var requestContentStream = new MemoryStream();

            await requestContentStream.SerializeToJsonAndWriteAsync(
                TypeMapper.ToServiceCatalogDto(serviceCatalog),
                Encoding.Default,
                Defaults.DefaultBufferSizeOnWrite,
                resetStream: true,
                leaveOpen: true);

            request.Headers.Add("Accept", "application/json");
            request.Content = new StreamContent(requestContentStream, Defaults.DefaultBufferSizeOnWrite);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var httpResponse = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            if (!httpResponse.IsSuccessStatusCode)
                await HandleFailedResponse(httpResponse);

            using var responseStream = await httpResponse.Content.ReadAsStreamAsync();
            var response = await responseStream.ReadAndDeserializeFromJsonAsync<ServiceCatalogDto>();
            return TypeMapper.ToServiceCatalogDefinition(response);
        }
    }
}
