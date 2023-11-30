using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyOwnAPI.Application.Queries;

namespace MyOwnApi.ReadControllers
{
    [ApiController]
    [Route("api/read/driver")]
    public class ReadDriverController: ControllerBase
    {
        private readonly IMediator _mediator;

        public ReadDriverController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult> ReadChauffeursAsync(CancellationToken ct)
        {
            var result = await _mediator.Send(new ReadAllDriversQuery(), ct);
            return Ok(result);
        }
    }
}
