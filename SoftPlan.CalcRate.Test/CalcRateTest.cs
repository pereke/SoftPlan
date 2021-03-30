using SoftPlan.CalcRate.Test.Fixture;
using System.Net.Http;
using System.Text.Json;
using Xunit;

namespace SoftPlan.CalcRate.Test
{
    public class CalcRateTest : IClassFixture<SoftPlanCalcFixture>
    {
        private readonly SoftPlanCalcFixture _fixture;
        readonly HttpClient _client;

        public CalcRateTest(SoftPlanCalcFixture fixture)
        {
            _fixture = fixture;
            _client = fixture.CreateClient();
        }

        [Theory]
        [InlineData(100, 5, 105.10)]
        [InlineData(100, 20, 122.01)]
        [InlineData(300, 20, 366.05)]
        public async void GetRateTest(decimal initial, int duration, double rate)
        {
            var result = await _client.GetAsync($"/calculaJuros?Initial={initial}&Duration={duration}");
            result.EnsureSuccessStatusCode();

            var content = await result.Content.ReadAsStringAsync();

            var calcRate = JsonSerializer.Deserialize<CalcRateResponseCamelCase>(content);

            Assert.Equal(calcRate.result, rate);
        }

        private class CalcRateResponseCamelCase
        {
            public double result { get; set; }
        }
    }
}
