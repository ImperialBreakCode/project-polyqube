using API.Chats.Application.Features.Participants.Models;
using API.Shared.Common.MediatorResponse;

namespace API.Chats.Application.Features.Participants.Queries.GetChatParticipants
{
    public record GetChatParticipantsResponse(
        ICollection<ParticipantViewModel> Participants) : IInterceptableResponse;
}
