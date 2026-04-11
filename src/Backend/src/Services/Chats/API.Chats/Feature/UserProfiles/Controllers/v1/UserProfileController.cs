using API.Chats.Application.Features.UserProfiles.Factories;
using API.Chats.Feature.UserProfiles.Models.Responses;
using API.Shared.Web.Attributes;
using API.Shared.Web.Extensions;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Chats.Feature.UserProfiles.Controllers.v1
{
    [Route("api/v{version:apiVersion}/user-profiles")]
    [ApiController]
    [ApiVersion(1)]
    public class UserProfileController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileCommandFactory _commandFactory;
        private readonly ISender _sender;

        public UserProfileController(IMapper mapper, IUserProfileCommandFactory commandFactory, ISender sender)
        {
            _mapper = mapper;
            _commandFactory = commandFactory;
            _sender = sender;
        }

        [HttpPost("create-user-profile")]
        [AuthorizeUserScope]
        [ProducesResponseType<UserProfileResponseDTO>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register(CancellationToken cancellationToken)
        {
            string userId = this.GetUserId();
            var createUserProfileCommand = _commandFactory.CreateUserProfileCommand(userId);
            var userProfile = await _sender.Send(createUserProfileCommand, cancellationToken);
            var userProfileDTO = _mapper.Map<UserProfileResponseDTO>(userProfile);

            return StatusCode(StatusCodes.Status201Created, userProfileDTO);
        }
    }
}
