using SWAPI.Services.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SWAPI.Services
{
    public class HttpClientHandler : IHttpHandler
    {
        private readonly string _baseUrl = "https://swapi.dev/api/";
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _httpClient;
        public HttpClientHandler(HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> GetAsync(string url)
        {
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
            return await _httpClient.GetStringAsync(url);
        }
    }
}
