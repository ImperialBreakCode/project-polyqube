using API.Shared.Domain.Base;

namespace API.Chats.Domain.Aggregates
{
    public class ChatAgent : AuditableSoftDeleteAggregateRoot
    {
        private ChatAgent()
        {
        }

        private ChatAgent(string agentName, string agentUsername)
        {
            AgentName = agentName;
            AgentUsername = agentUsername;
        }

        public string AgentName { get; set; }
        public string AgentUsername { get; internal set; }
        public string? ProfilePicture { get; set; }

        public static ChatAgent Create(string agentName, string agentUsername)
        {
            return new ChatAgent(agentName, agentUsername);
        }
    }
}
