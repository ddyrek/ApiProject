using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

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

        private async Task<HttpResponseMessage> PatchAsync<T>(string relativeUrl, T content)
        {
            var jsonContent = JsonSerializer.Serialize(content);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync(relativeUrl, httpContent);

            return response;
        }
    }
}
