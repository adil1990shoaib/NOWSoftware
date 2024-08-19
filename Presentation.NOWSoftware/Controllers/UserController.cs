using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Command;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Services;

namespace NOW_Software.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtTokenService _jwtTokenService;

        public UsersController(IMediator mediator, IJwtTokenService jwtTokenService)
        {
            _mediator = mediator;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupUserCommand command)
        {
            var userId = await _mediator.Send(command);
            if (userId == 0)
            {
                return BadRequest("User registration failed");
            }
            return Ok();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserCommand command)
        {
            var user = await _mediator.Send(command);
            if (user == null)
            {
                return Unauthorized();
            }

            var token = _jwtTokenService.GenerateToken(user);
            return Ok(new
            {
                user.FirstName,
                user.LastName,
                Token = token
            });
        }
    }

}
