using System.Text.Json;
using System.Threading.Tasks;

namespace SoftPlan.CalcRate.Application.HttpService
{
    public class GetInterestRate : IGetInterestRate
    {
        public async Task<double> GetAsync(string url)
        {
            var httpClient = GenerateHttpClient.GenareteHttpClient();
            var response = await httpClient.GetAsync(url);

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
