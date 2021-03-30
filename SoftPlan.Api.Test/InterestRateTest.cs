using SoftPlan.Api.Test.Fixture;
using SoftPlan.CalcRate.Application.HttpService;
using System.Net.Http;
using System.Text.Json;
using Xunit;

namespace SoftPlan.Api.Test
{
    public class InterestRateTest : IClassFixture<SoftPlanTestFixture>
    {
        private readonly SoftPlanTestFixture _fixture;
        readonly HttpClient _client;

        public InterestRateTest(SoftPlanTestFixture fixture)
        {
            _fixture = fixture;
            _client = fixture.CreateClient();
        }

        [Fact]
        public async void GetInterestRateTest()
        {
            var result = await _client.GetAsync("/taxaJuros");
            result.EnsureSuccessStatusCode();

            var content = await result.Content.ReadAsStringAsync();

            var interestRate = JsonSerializer.Deserialize<InterestRateResponse>(content);

            Assert.True(interestRate.interestRate == 0.01);
        }
    }
}
