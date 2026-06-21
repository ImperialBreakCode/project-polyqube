using API.Chats.Application.Features.UserProfiles.Factories;
using API.Chats.Feature.UserProfiles.Models.Requests;
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
        private readonly IUserProfileQueryFactory _userProfileQueryFactory;
        private readonly ISender _sender;

        public UserProfileController(IMapper mapper, IUserProfileCommandFactory commandFactory, ISender sender, IUserProfileQueryFactory userProfileQueryFactory)
        {
            _mapper = mapper;
            _commandFactory = commandFactory;
            _sender = sender;
            _userProfileQueryFactory = userProfileQueryFactory;
        }

        [HttpPost("create-user-profile")]
        [AuthorizeUserScope]
        [ProducesResponseType<UserProfileResponseDTO>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(CancellationToken cancellationToken)
        {
            string userId = this.GetUserId();
            var createUserProfileCommand = _commandFactory.CreateUserProfileCommand(userId);
            var userProfile = await _sender.Send(createUserProfileCommand, cancellationToken);
            var userProfileDTO = _mapper.Map<UserProfileResponseDTO>(userProfile);

            return StatusCode(StatusCodes.Status201Created, userProfileDTO);
        }


        [HttpGet("get-current-profile")]
        [AuthorizeUserScope]
        [ProducesResponseType<UserProfileResponseDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCurrentProfile(CancellationToken cancellationToken)
        {
            string userId = this.GetUserId();
            var createUserProfileCommand = _userProfileQueryFactory.CreateGetProfileByUserIdQuery(userId);
            var userProfile = await _sender.Send(createUserProfileCommand, cancellationToken);
            var userProfileDTO = _mapper.Map<UserProfileResponseDTO>(userProfile);

            return Ok(userProfileDTO);
        }

        [HttpGet("search-profiles")]
        [AuthorizeUserScope]
        [AuthorizeModuleAccess]
        [ProducesResponseType<ICollection<UserProfileResponseDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchProfiles([FromQuery] SearchProfileRequestDTO requestDTO, CancellationToken cancellationToken)
        {
            string userId = this.GetUserId();
            var currentProfileQuery = _userProfileQueryFactory.CreateGetProfileByUserIdQuery(userId);
            var currentProfile = await _sender.Send(currentProfileQuery, cancellationToken);

            var query = _userProfileQueryFactory.CreateSearchProfilesByFullNameQuery(
                requestDTO.SearchTerm,
                currentProfile.Id,
                requestDTO.Count);

            var result = await _sender.Send(query, cancellationToken);
            var responseDTO = _mapper.Map<ICollection<UserProfileResponseDTO>>(result.Profiles);

            return Ok(responseDTO);
        }
    }
}
