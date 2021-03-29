using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPlan.Application.InterestRate.Queries;
using System.Threading.Tasks;

namespace SoftPlan.Api.Controllers
{
    [ApiController]
    public class InterestRateController : ControllerBase
    {
        private readonly ISender _sender;
        public InterestRateController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Retorna a taxa de juros atual
        /// </summary>
        [HttpGet("taxaJuros")]
        [ProducesResponseType(200, Type = typeof(InterestRateResponse))]
        public async Task<IActionResult> GetInterestRate([FromQuery] InterestRateRequest interestRateRequest)
        {
            return Ok(await _sender.Send(interestRateRequest));
        }
    }
}
