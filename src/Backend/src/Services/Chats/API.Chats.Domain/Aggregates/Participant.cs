using API.Chats.Domain.Aggregates.UserProfilesAggregate;
using API.Shared.Domain.Base;

namespace API.Chats.Domain.Aggregates
{
    public class Participant: AuditableSoftDeleteAggregateRoot
    {
        private Participant()
        {
        }

        private Participant(string chatId, string? userProfileId, string? agentId)
        {
            ChatId = chatId;
            UserProfileId = userProfileId;
            ChatAgentId = agentId;
        }

        public string? ChatNickname { get; set; }

        public string? UserProfileId { get; private set; }
        public UserProfile? UserProfile { get; private set; }

        public string ChatId { get; private set; }
        public Chat Chat { get; private set; }

        public string? ChatAgentId { get; set; }
        public ChatAgent? ChatAgent { get; set; }

        public static Participant CreateUserParticipant(string chatId, string userProfileId)
        {
            return new Participant(chatId, userProfileId, null);
        }

        public static Participant CreateAgentParticipant(string chatId, string agentId)
        {
            return new Participant(chatId, null, agentId);
        }
    }
}
