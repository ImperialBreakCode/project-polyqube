using API.Accounts.Application.Features.Users.Commands.CreateUser;
using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Features.Users.Models.Requests;
using API.Accounts.Features.Users.Models.Responses;
using Asp.Versioning;
using AutoMapper;
using MediatR;
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

        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser(RegisterUserRequestDTO registerUserRequest)
        {
            var createUserCommand = _mapper.Map<CreateUserCommand>(registerUserRequest);
            var user = await _sender.Send(createUserCommand);
            var userDTO = _mapper.Map<UserResponseDTO>(user);

            return StatusCode(StatusCodes.Status201Created, userDTO);
        }
    }
}
