using CM.Services.Wallet.Contract.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CM.Services.Wallet.API.Controllers
{
    [Authorize]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteUserCommand
            {
                Id = id
            }));
        }
    }
}