using API.Chats.Application.Features.Participants.Models;
using API.Chats.Domain;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Chats.Application.Features.Participants.Queries.GetChatParticipants
{
    internal class GetChatParticipantsQueryHandler : IQueryHandler<GetChatParticipantsQuery, ICollection<ParticipantViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetChatParticipantsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<ParticipantViewModel>> Handle(GetChatParticipantsQuery request, CancellationToken cancellationToken)
        {
            var participants = await _unitOfWork.ParticipantRepository.GetChatParticipants(
                request.ChatId,
                participantCount: request.ParticipantCount,
                includeAgents: request.IncludeAgents);

            return _mapper.Map<ICollection<ParticipantViewModel>>(participants);
        }
    }
}
