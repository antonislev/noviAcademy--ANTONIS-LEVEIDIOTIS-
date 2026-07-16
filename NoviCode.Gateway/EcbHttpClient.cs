using NoviCode;
using NoviCode.Gateway;
using NoviCode.Gateway.Dtos;
using System.Xml.Serialization;

namespace Novicode.Gateway
{
    public class EcbHttpClient : IEcbHttpClient
    {
        private readonly HttpClient _httpClient;

        public EcbHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IReadOnlyList<CurrencyRateDto>> GetLatestRatesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}