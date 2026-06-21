using API.Shared.Common.Exceptions;

namespace API.Chats.Common.Features.ChatAgents.Exceptions
{
    public class AgentUsernameAlreadyExists : ConflictException
    {
        private const string MESSAGE = "This agent username is already taken";

        public AgentUsernameAlreadyExists() : base(MESSAGE)
        {
        }
    }
}
