using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Queries.GetUser;
using DevFreela.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid(int id)
        {
            try
            {
                var getUser = new GetUserQuery(id);

                var users = await _mediator.Send(getUser);

                return Ok(users);
            }
            catch(UserNonExistentException ex) 
            {
                return BadRequest(ex.Message);
            }          
        }

        // api/users
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);

                return CreatedAtAction(nameof(GetByid), new { id = id }, command);
            }
            catch(UserAlredyExistException ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // api/users/{id}/login
        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            try
            {
                var loginUserViewModel = await _mediator.Send(command);

                return Ok(loginUserViewModel);
            }
            catch(UserNonExistentException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
