using WebApi.IntegrationTests.Common;
using Xunit;
using projektApi;
using projektApi.Application.Koontrahenci.Queris.GetKontrahentDetail;
using Shouldly;
//using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace WebApi.IntegrationTests.Controllers.Kontrahenci
{
    public class GetDetails_Tests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public GetDetails_Tests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenKontrahenciId_ReturnsKontrahenciDetail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            string id = "1";
            var response = await client.GetAsync($"/api/kontrahenci/{id}");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<KontrahentDetailVm>(response);
            vm.ShouldNotBeNull();
        }
    }
}
