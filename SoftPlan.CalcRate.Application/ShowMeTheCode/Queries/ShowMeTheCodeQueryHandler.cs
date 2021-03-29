using MediatR;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace SoftPlan.CalcRate.Application.ShowMeTheCode.Queries
{
    public class ShowMeTheCodeQueryHandler : IRequestHandler<ShowMeTheCodeRequest, ShowMeTheCodeResponse>
    {
        private readonly IConfiguration _configuration;
        public ShowMeTheCodeQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<ShowMeTheCodeResponse> Handle(ShowMeTheCodeRequest request, CancellationToken cancellationToken)
        {
            var gitHub = _configuration.GetSection("GitHub").Value;
            return Task.FromResult(
                new ShowMeTheCodeResponse
                {
                    Url = gitHub
                }
            );
        }
    }
}
