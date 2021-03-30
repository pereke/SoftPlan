using MediatR;
using Microsoft.Extensions.Configuration;
using SoftPlan.CalcRate.Application.HttpService;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SoftPlan.CalcRate.Application.CalcRate.Queries
{
    class CalcRateQueryHandler : IRequestHandler<CalcRateRequest, CalcRateResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IGetInterestRate _getInterestRate;
        public CalcRateQueryHandler(IConfiguration configuration, IGetInterestRate getInterestRate)
        {
            _configuration = configuration;
            _getInterestRate = getInterestRate;
        }

        public async Task<CalcRateResponse> Handle(CalcRateRequest request, CancellationToken cancellationToken)
        {
            var url = _configuration.GetSection("Url").Value;
            var interestRate = await _getInterestRate.GetAsync(url);

            var rate = (double)request.Initial * Math.Pow((double)(1 + interestRate), request.Duration);
            rate = Math.Truncate(rate * Math.Pow(10, 2)) / Math.Pow(10, 2);

            var response = new CalcRateResponse { Result = rate };

            return response;
        }
    }
}
