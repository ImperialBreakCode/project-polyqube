using API.Accounts.Application.Features.Users.Commands.CreateUser;
using API.Accounts.Application.Features.Users.Commands.LoginUser;
using API.Accounts.Features.Users.Models.Requests;
using API.Accounts.Features.Users.Models.Responses;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Accounts.Features.Users.Controllers.v1
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [ApiVersion(1)]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public UserController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequestDTO registerUserRequest)
        {
            var createUserCommand = _mapper.Map<CreateUserCommand>(registerUserRequest);
            var user = await _sender.Send(createUserCommand);
            var userDTO = _mapper.Map<UserResponseDTO>(user);

            return StatusCode(StatusCodes.Status201Created, userDTO);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserRequestDTO loginUserRequest)
        {
            var loginCommand = _mapper.Map<LoginUserCommand>(loginUserRequest);
            var loginResponse = await _sender.Send(loginCommand);
            var loginResponseDTO = _mapper.Map<LoginResponseDTO>(loginResponse);

            return Ok(loginResponseDTO);
        }

        [Authorize]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}
