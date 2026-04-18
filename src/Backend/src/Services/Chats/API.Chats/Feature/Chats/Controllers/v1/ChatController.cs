using API.Chats.Application.Features.Chats.Commands.UpdateChatSettings;
using API.Chats.Application.Features.Chats.Factories;
using API.Chats.Application.Features.UserProfiles.Factories;
using API.Chats.Feature.Chats.Models.Requests;
using API.Chats.Feature.Chats.Models.Responses;
using API.Shared.Web.Attributes;
using API.Shared.Web.Extensions;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Chats.Feature.Chats.Controllers.v1
{
    [Route("api/v{version:apiVersion}/chats")]
    [ApiController]
    [ApiVersion(1)]
    public class ChatController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly IChatCommandFactory _chatCommandFactory;
        private readonly IUserProfileQueryFactory _userProfileQueryFactory;
        private readonly IChatQueryFactory _chatQueryFactory;

        public ChatController(ISender sender, IMapper mapper, IChatCommandFactory chatCommandFactory, IUserProfileQueryFactory userProfileQueryFactory, IChatQueryFactory chatQueryFactory)
        {
            _sender = sender;
            _mapper = mapper;
            _chatCommandFactory = chatCommandFactory;
            _userProfileQueryFactory = userProfileQueryFactory;
            _chatQueryFactory = chatQueryFactory;
        }

        [HttpPost("create-peer-chat")]
        [AuthorizeUserScope]
        [AuthorizeModuleAccess]
        [ProducesResponseType<ChatResponseDTO>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreatePeerChat(CreatePeerChatRequestDTO requestDTO, CancellationToken cancellationToken)
        {
            string userId = this.GetUserId();
            var getProfileQuery = _userProfileQueryFactory.CreateGetProfileByUserIdQuery(userId);
            var initiatorProfile = await _sender.Send(getProfileQuery, cancellationToken);

            var createChatCommand = _chatCommandFactory.CreateChatCommand(initiatorProfile.Id, requestDTO.PeerProfileId);
            var result = await _sender.Send(createChatCommand, cancellationToken);
            var chatResponseDTO = _mapper.Map<ChatResponseDTO>(result);

            return StatusCode(StatusCodes.Status201Created, chatResponseDTO);
        }

        [HttpGet("get-current-profile-chats")]
        [AuthorizeUserScope]
        [AuthorizeModuleAccess]
        [ProducesResponseType<ICollection<ChatResponseDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCurrentProfileChats(CancellationToken cancellationToken)
        {
            string userId = this.GetUserId();
            var getProfileQuery = _userProfileQueryFactory.CreateGetProfileByUserIdQuery(userId);
            var currentProfile = await _sender.Send(getProfileQuery, cancellationToken);

            var chatQuery = _chatQueryFactory.CreateGetProfileChatsQuery(currentProfile.Id);
            var result = await _sender.Send(chatQuery, cancellationToken);
            var responseDTO = _mapper.Map<ICollection<ChatResponseDTO>>(result);

            return Ok(responseDTO);
        }

        [HttpPut("update-chat-settings")]
        [AuthorizeUserScope]
        [AuthorizeModuleAccess]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateChatSettings(UpdateChatSettingsRequestDTO chatSettingsRequestDTO, CancellationToken cancellationToken)
        {
            var updateCommand = _mapper.Map<UpdateChatSettingsCommand>(chatSettingsRequestDTO);
            await _sender.Send(updateCommand, cancellationToken);

            return NoContent();
        }
    }
}
