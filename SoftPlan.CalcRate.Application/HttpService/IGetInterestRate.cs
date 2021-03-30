using System.Threading.Tasks;

namespace SoftPlan.CalcRate.Application.HttpService
{
    public interface IGetInterestRate
    {
        Task<double> GetAsync(string url);
    }
}
