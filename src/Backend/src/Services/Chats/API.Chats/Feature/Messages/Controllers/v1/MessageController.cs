using API.Chats.Application.Features.Messages.Queries.GetMessageHistory;
using API.Chats.Feature.Messages.Models.Requests;
using API.Chats.Feature.Messages.Models.Responses;
using API.Shared.Web.Attributes;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Chats.Feature.Messages.Controllers.v1
{
    [Route("api/v{version:apiVersion}/messages")]
    [ApiController]
    [ApiVersion(1)]
    public class MessageController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public MessageController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet("message-history")]
        [AuthorizeUserScope]
        [ProducesResponseType<ICollection<MessageResponseDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMessageHistory(MessageHistoryRequestDTO messageHistory, CancellationToken cancellationToken)
        {
            var messageHistoryQuery = _mapper.Map<GetMessageHistoryQuery>(messageHistory);
            var history = await _sender.Send(messageHistoryQuery, cancellationToken);
            var messagesDTO = _mapper.Map<ICollection<MessageResponseDTO>>(history);
            
            return Ok(messagesDTO);
        }
    }
}
