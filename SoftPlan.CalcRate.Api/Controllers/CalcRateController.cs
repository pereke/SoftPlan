using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPlan.CalcRate.Application.CalcRate.Queries;
using System.Threading.Tasks;

namespace SoftPlan.CalcRate.Api.Controllers
{
    [ApiController]
    public class CalcRateController : ControllerBase
    {
        private readonly ISender _sender;
        public CalcRateController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Calcula os juros compostos de acordo com os valor recebido, tempo, e juros atual.
        /// </summary>
        [HttpGet("calculaJuros")]
        [ProducesResponseType(200, Type = typeof(CalcRateResponse))]
        public async Task<IActionResult> GetInterestRate([FromQuery] CalcRateRequest calcRateRequest)
        {
            return Ok(await _sender.Send(calcRateRequest));
        }
    }
}
