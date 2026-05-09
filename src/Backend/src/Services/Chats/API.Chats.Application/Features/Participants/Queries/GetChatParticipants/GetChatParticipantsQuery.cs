using API.Chats.Application.Features.Participants.Models;
using API.Shared.Application.Interfaces;

namespace API.Chats.Application.Features.Participants.Queries.GetChatParticipants
{
    public record GetChatParticipantsQuery(
        string ChatId,
        int? ParticipantCount = null,
        bool IncludeAgents = false
    ) : IQuery<ICollection<ParticipantViewModel>>;
}
