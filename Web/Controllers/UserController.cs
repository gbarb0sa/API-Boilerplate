using Core.Commands;
using Core.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Filters;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [HttpResultActionFilter]
        public async Task<ActionResult> Create([FromBody] CreateUserRequest request)
        {
            var command = new CreateUserCommand(request);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
