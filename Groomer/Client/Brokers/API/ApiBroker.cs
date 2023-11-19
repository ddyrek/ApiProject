using System.Net.Http.Json;

namespace Groomer.Client.Brokers.API
{
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
        //public async Task<HttpResponseMessage> DeleteVisitAsync(int visitId)
        //{
        //    // Implementacja usuwania wizyty z użyciem HttpClient
        //    var response = await _httpClient.DeleteAsync($"api/wizyty/{visitId}");
        //    return response;
        //}

    }
}
