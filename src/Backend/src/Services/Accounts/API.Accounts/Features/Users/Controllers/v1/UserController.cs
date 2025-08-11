using API.Accounts.Application.Features.Users.Commands.CreateUser;
using API.Accounts.Application.Features.Users.Commands.CreateUserDetails;
using API.Accounts.Application.Features.Users.Commands.RequestUserDeletion;
using API.Accounts.Application.Features.Users.Commands.UpdateUserDetails;
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
        private readonly IUserCommandFactory _userCommandFactory;

        public UserController(IMapper mapper, ISender sender, IUserQueryFactory userQueryFactory, IUserCommandFactory userCommandFactory)
        {
            _mapper = mapper;
            _sender = sender;
            _userQueryFactory = userQueryFactory;
            _userCommandFactory = userCommandFactory;
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

        [HttpPut("update-user-details")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsRequestDTO updateUserDetailsRequest, CancellationToken cancellationToken)
        {
            var userId = this.GetUserId();

            var updateUserDetailsCommand = _mapper.Map<UpdateUserDetailsCommand>((updateUserDetailsRequest, userId));
            await _sender.Send(updateUserDetailsCommand);

            return NoContent();
        }

        [HttpPut("set-profile-picture")]
        [RequestSizeLimit(100 * 1024 * 1024)]
        [Authorize]
        [ImageUploadFilter]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SetProfilePicture(SetProfilePictureRequestDTO requestDTO, CancellationToken cancellationToken)
        {
            var formFile = requestDTO.FormFile;

            var command = _userCommandFactory.CreateSetProfilePictureCommand(
                formFile.OpenReadStream(),
                formFile.FileName,
                this.GetUserId());

            await _sender.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("remove-profile-picture")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveProfilePicture(CancellationToken cancellationToken)
        {
            var userId = this.GetUserId();
            var command = _userCommandFactory.CreateRemoveProfilePictureCommand(userId);
            await _sender.Send(command, cancellationToken);

            return NoContent();
        }


        [HttpPost("request-user-deletion")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RequestUserDeletion(RequestUserDeletionRequestDTO requestUserDeletionDTO, CancellationToken cancellationToken)
        {
            var userId = this.GetUserId();
            var command = _mapper.Map<RequestUserDeletionCommand>((requestUserDeletionDTO, userId));
            var result = await _sender.Send(command, cancellationToken);
            var dto = _mapper.Map<UserEmailResponseDTO>(result);

            return Ok(dto);
        }
    }
}
