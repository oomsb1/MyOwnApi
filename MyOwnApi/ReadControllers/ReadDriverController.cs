using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyOwnAPI.Application.Queries;

namespace MyOwnApi.ReadControllers
{
    //TODO make API 100% RESTful
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
        public async Task<ActionResult> ReadDriversAsync(CancellationToken ct)
        {
            var result = await _mediator.Send(new ReadAllDriversQuery(), ct);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> ReadDriverByIdAsync(int id, CancellationToken ct)
        {
            var result = await _mediator.Send(new ReadDriverQuery(id), ct);
            return result == null ? throw new KeyNotFoundException() : Ok(result);
        }
    }
}
