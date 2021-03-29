using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPlan.CalcRate.Application.ShowMeTheCode.Queries;
using System.Threading.Tasks;

namespace SoftPlan.CalcRate.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowMeTheCode : ControllerBase
    {
        private readonly ISender _sender;
        public ShowMeTheCode(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Retorna a url do projeto
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ShowMeTheCodeResponse))]
        public async Task<IActionResult> GetGitHub([FromQuery] ShowMeTheCodeRequest showMeTheCodeRequest)
        {
            return Ok(await _sender.Send(showMeTheCodeRequest));
        }
    }
}
