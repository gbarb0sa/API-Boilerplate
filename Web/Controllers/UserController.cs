using Core.Commands;
using Core.Models.Filters;
using Core.Models.Requests;
using Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Filters;

namespace Web.Controllers
{
    [Route("api/user")]
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
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            var command = new CreateUserCommand(request);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        [HttpResultActionFilter]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRequest request)
        {
            var command = new UpdateUserCommand(id, request);
            var response = await _mediator.Send(command);
            return Ok(response);
        }


        [HttpDelete("{id:int}")]
        [HttpResultActionFilter]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [HttpResultActionFilter]
        public async Task<IActionResult> GetAll([FromQuery] GetUserRequestFilter filter)
        {
            var command = new GetUserQuery(filter);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        [HttpResultActionFilter]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetUserByIdQuery(id);
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
