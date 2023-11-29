using System.Net;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("[controller]")]
    public class AuthController : ApiController
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public AuthController(
            ISender sender,
            IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            var registerResult = await _sender.Send(command);

            return registerResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var command = _mapper.Map<LoginQuery>(request);
            //var command = new LoginQuery(request.Email, request.Password);
            var loginResult = await _sender.Send(command);

            return loginResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }
    }
}