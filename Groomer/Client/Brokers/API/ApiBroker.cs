using System.Net.Http.Json;

namespace Groomer.Client.Brokers.API
{
    //ApiBroker - obsługa tylko żadąń HTTP
    public partial class ApiBroker : IApiBroker
    {
        private readonly HttpClient _httpClient;

        public ApiBroker(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private async Task<T> GetAsync<T>(string relativeUrl) =>
            await _httpClient.GetFromJsonAsync<T>(relativeUrl);

        private async Task<HttpResponseMessage> PostAsync<T>(string relativeUrl, T content)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<T>(relativeUrl, content);
            // Zwróć wynik
            return response;
        }
        private async Task<HttpResponseMessage> DeleteAsync(string relativeUrl)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(relativeUrl);
            // Zwróć wynik
            return response;
        }

    }
}
