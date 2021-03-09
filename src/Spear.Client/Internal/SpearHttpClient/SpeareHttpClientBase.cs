using Microsoft.Extensions.Options;
using Spear.Client.Builder;
using Spear.Client.Internal.Utilities;
using Spear.Client.Services.Exceptions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Spear.Client.Internal.SpearHttpClient
{
    internal abstract class SpeareHttpClientBase
    {
        protected readonly HttpClient _httpClient;
        protected readonly SpearHttpClientOption _options;

        public SpeareHttpClientBase(HttpClient httpClient,
                                    IOptions<SpearHttpClientOption> options)
        {
            _options =
                options?.Value ?? throw new ArgumentNullException(nameof(options));

            _httpClient =
                httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            _httpClient.BaseAddress = _options?.BaseAddress ??
                throw new ArgumentNullException(nameof(httpClient.BaseAddress));
        }

        //TODO handle connection refuese problem
        protected virtual async Task HandleFailedResponse(HttpResponseMessage responseMessage)
        {
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new ArgumentException((await TryGetErrorDetails(responseMessage)).ToString());

            throw new InternalException();
        }

        protected async Task<ProblemDetailError> TryGetErrorDetails(HttpResponseMessage responseMessage)
        {
            try
            {
                using var responseStream = await responseMessage.Content.ReadAsStreamAsync();
                return await responseStream.ReadAndDeserializeFromJsonAsync<ProblemDetailError>();
            }
            catch (Exception)
            {
                return new ProblemDetailError();
            }
        }
    }
}
