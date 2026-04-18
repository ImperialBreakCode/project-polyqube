using API.Chats.Application.Features.Chats.Models;
using API.Chats.Domain;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Chats.Application.Features.Chats.Queries.GetProfileChats
{
    internal class GetProfileChatsQueryHandler : IQueryHandler<GetProfileChatsQuery, ICollection<ChatViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProfileChatsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<ChatViewModel>> Handle(GetProfileChatsQuery request, CancellationToken cancellationToken)
        {
            var chatPartcipants = await _unitOfWork.ParticipantRepository
                .GetParticipantsWithChatByProfileId(request.ProfileId);
            
            ICollection<ChatViewModel> chatViewModels = [];
            foreach (var participant in chatPartcipants)
            {
                var chatViewModel = _mapper.Map<ChatViewModel>(participant.Chat);

                if (request.PreloadChatName && chatViewModel.ChatName == null)
                {
                    var topPartcipant = await _unitOfWork.ParticipantRepository
                        .GetChatParticipants(chatViewModel.Id, participantCount: 3);

                    var participantNames = topPartcipant.Select(x => x.ChatNickname ?? x.UserProfile?.FullName ?? "Deleted User");

                    chatViewModel.ChatName = string.Join(", ", participantNames);
                }
            }

            return chatViewModels;
        }
    }
}
