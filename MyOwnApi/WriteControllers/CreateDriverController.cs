using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyNewAPI.Application.DTOs;
using MyOwnAPI.Application.Commands;
using MyOwnAPI.Application.Queries;

namespace MyOwnApi.WriteControllers
{
    [ApiController]
    [Route("api/create/driver")]
    public class CreateDriverController: ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateDriverController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> CreateDriverAsync(DriverDto driverDto, CancellationToken ct)
        {
            var result = await _mediator.Send(new CreateDriverCommand(driverDto), ct);
            return Ok(result);
        }
    }
}
