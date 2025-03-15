using API.Accounts.Application.Features.Users.Commands.CreateUser;
using API.Accounts.Application.Features.Users.Factories;
using API.Accounts.Features.Users.Models.Requests;
using API.Accounts.Features.Users.Models.Responses;
using API.Shared.Web.Attributes;
using API.Shared.Web.Extensions;
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
        private readonly IUserQueryFactory _userQueryFactory;

        public UserController(IMapper mapper, ISender sender, IUserQueryFactory userQueryFactory)
        {
            _mapper = mapper;
            _sender = sender;
            _userQueryFactory = userQueryFactory;
        }

        [HttpPost("register")]
        [ProducesResponseType<UserResponseDTO>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register(RegisterUserRequestDTO registerUserRequest)
        {
            var createUserCommand = _mapper.Map<CreateUserCommand>(registerUserRequest);
            var user = await _sender.Send(createUserCommand);
            var userDTO = _mapper.Map<UserResponseDTO>(user);

            return StatusCode(StatusCodes.Status201Created, userDTO);
        }

        [HttpGet("get-by-username/{username}")]
        [AuthorizeAdminScope]
        [ProducesResponseType<UserResponseDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await _sender.Send(_userQueryFactory.CreateGetUserByUsernameQuery(username));
            var userDTO = _mapper.Map<UserResponseDTO>(user);

            return Ok(userDTO);
        }

        [HttpGet("get-current-user")]
        [Authorize]
        [ProducesResponseType<UserResponseDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = this.GetUserId();
            var user = await _sender.Send(_userQueryFactory.CreateGetUserByIdQuery(userId));
            var userDTO = _mapper.Map<UserResponseDTO>(user);

            return Ok(userDTO);
        }
    }
}
