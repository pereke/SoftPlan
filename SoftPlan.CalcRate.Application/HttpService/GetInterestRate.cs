using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoftPlan.CalcRate.Application.HttpService
{
    public class GetInterestRate : IGetInterestRate
    {
        private readonly HttpClient _httpClient;
        public GetInterestRate(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<double> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

            var rate = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var InterestRate = JsonSerializer.Deserialize<InterestRateResponse>(rate);

            return InterestRate.interestRate;
        }
    }

    public class InterestRateResponse
    {
        public double interestRate { get; set; }
    }
}
