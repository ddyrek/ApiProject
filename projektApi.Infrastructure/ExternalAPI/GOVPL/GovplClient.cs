using projektApi.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Infrastructure.ExternalAPI.GOVPL
{
    public partial class GovplClient : IGovplClient
    {
        private string _baseUrl = "https://bdl.stat.gov.pl";
        private readonly HttpClient _httpClient;
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

        public GovplClient(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("GovplClient");
            _baseUrl = _httpClient.BaseAddress.ToString();
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(() =>
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });


        }

        protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);

        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }

        //pobranie konkretnego tu filmu
        public async Task<string> GetMovie(string searchFilter, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("?apikey=4b50bcbc-81c3-4f88-25d8-08db01e842c3");
            urlBuilder.Append("&t=").Append(searchFilter);
            var client = _httpClient;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        return responseData;
                    }
                    else
                    {
                        return "Something bad happened";
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
