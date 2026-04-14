using API.Chats.Application.Features.Messages.Models;
using API.Chats.Domain;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Chats.Application.Features.Messages.Queries.GetMessageHistory
{
    internal class GetMessageHistoryQueryHandler : IQueryHandler<GetMessageHistoryQuery, ICollection<MessageViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMessageHistoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<MessageViewModel>> Handle(GetMessageHistoryQuery request, CancellationToken cancellationToken)
        {
            var messages = await _unitOfWork.MessageRepository
                .GetMessageChatHistory(request.ChatId, request.Count, request.Offset);

            return _mapper.Map<ICollection<MessageViewModel>>(messages);
        }
    }
}
