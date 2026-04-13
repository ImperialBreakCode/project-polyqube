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

        public ChatController(ISender sender, IMapper mapper, IChatCommandFactory chatCommandFactory, IUserProfileQueryFactory userProfileQueryFactory)
        {
            _sender = sender;
            _mapper = mapper;
            _chatCommandFactory = chatCommandFactory;
            _userProfileQueryFactory = userProfileQueryFactory;
        }

        [HttpPost("create-peer-chat")]
        [AuthorizeUserScope]
        [ProducesResponseType<ChatResponseDTO>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Register(CreatePeerChatRequestDTO requestDTO, CancellationToken cancellationToken)
        {
            string userId = this.GetUserId();
            var getProfileQuery = _userProfileQueryFactory.CreateGetProfileByUserIdQuery(userId);
            var initiatorProfile = await _sender.Send(getProfileQuery, cancellationToken);

            var createChatCommand = _chatCommandFactory.CreateChatCommand(initiatorProfile.Id, requestDTO.PeerProfileId);
            var result = await _sender.Send(createChatCommand, cancellationToken);
            var chatResponseDTO = _mapper.Map<ChatResponseDTO>(result);

            return StatusCode(StatusCodes.Status201Created, chatResponseDTO);
        }
    }
}
