using API.Accounts.Application.Features.Users.Commands.CreateUser;
using API.Accounts.Application.Features.Users.Commands.CreateUserDetails;
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
        public async Task<IActionResult> Register(RegisterUserRequestDTO registerUserRequest, CancellationToken cancellationToken)
        {
            var createUserCommand = _mapper.Map<CreateUserCommand>(registerUserRequest);
            var user = await _sender.Send(createUserCommand, cancellationToken);
            var userDTO = _mapper.Map<UserResponseDTO>(user);

            return StatusCode(StatusCodes.Status201Created, userDTO);
        }

        [HttpGet("get-by-username/{username}")]
        [AuthorizeAdminScope]
        [ProducesResponseType<UserResponseDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUsername(string username, CancellationToken cancellationToken)
        {
            var user = await _sender.Send(_userQueryFactory.CreateGetUserByUsernameQuery(username), cancellationToken);
            var userDTO = _mapper.Map<UserResponseDTO>(user);

            return Ok(userDTO);
        }

        [HttpGet("get-current-user")]
        [Authorize]
        [ProducesResponseType<UserResponseDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCurrentUser(CancellationToken cancellationToken)
        {
            var userId = this.GetUserId();
            var user = await _sender.Send(_userQueryFactory.CreateGetUserByIdQuery(userId), cancellationToken);
            var userDTO = _mapper.Map<UserResponseDTO>(user);

            return Ok(userDTO);
        }

        [HttpPost("create-user-details")]
        [Authorize]
        [ProducesResponseType<UserResponseDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateUserDetails(CreateUserDetailsRequestDTO createUserDetailsRequest, CancellationToken cancellationToken)
        {
            string userId = this.GetUserId();

            var createUserDetailsCommand = _mapper.Map<CreateUserDetailsCommand>((createUserDetailsRequest, userId));
            var user = await _sender.Send(createUserDetailsCommand, cancellationToken);
            var userDTO = _mapper.Map<UserResponseDTO>(user);

            return StatusCode(StatusCodes.Status201Created, userDTO);
        }
    }
}
