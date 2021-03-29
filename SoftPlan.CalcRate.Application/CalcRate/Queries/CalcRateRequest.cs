using MediatR;

namespace SoftPlan.CalcRate.Application.CalcRate.Queries
{
    public class CalcRateRequest : IRequest<CalcRateResponse>
    {
        public decimal Initial { get; set; }
        public int Duration { get; set; }
    }
}
