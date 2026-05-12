using API.Chats.Application.Features.Chats.Models;
using API.Chats.Common.Features.Chats.Exceptions;
using API.Chats.Domain;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Chats.Application.Features.Chats.Queries.GetPeerChat
{
    internal class GetPeerChatQueryHandler : IQueryHandler<GetPeerChatQuery, ChatViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPeerChatQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ChatViewModel> Handle(GetPeerChatQuery request, CancellationToken cancellationToken)
        {
            var chat = await _unitOfWork.ParticipantRepository
                .GetPeerChatByProfileIds(request.CurrentProfileId, request.PeerProfileId);

            if (chat is null)
            {
                throw new ChatNotFoundException();
            }

            return _mapper.Map<ChatViewModel>(chat);
        }
    }
}
