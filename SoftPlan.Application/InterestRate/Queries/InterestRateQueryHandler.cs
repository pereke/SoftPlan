using MediatR;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace SoftPlan.Application.InterestRate.Queries
{
    public class InterestRateQueryHandler : IRequestHandler<InterestRateRequest, InterestRateResponse>
    {
        private readonly IConfiguration _configuration;
        public InterestRateQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<InterestRateResponse> Handle(InterestRateRequest request, CancellationToken cancellationToken)
        {
            var interestRate = double.Parse(_configuration.GetSection("InterestRate").Value);
            return Task.FromResult(
                new InterestRateResponse { 
                    InterestRate = interestRate
                }
            );
        }
    }
}
