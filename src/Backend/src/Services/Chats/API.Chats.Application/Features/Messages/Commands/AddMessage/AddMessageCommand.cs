using API.Chats.Application.Features.Messages.Models;
using API.Shared.Application.Interfaces;

namespace API.Chats.Application.Features.Messages.Commands.AddMessage
{
    public enum AuthorType
    {
        ChatAgent,
        UserProfile
    }

    /// <summary>
    ///     Command for creating a new message
    /// </summary>
    /// <param name="ChatId"></param>
    /// <param name="AuthorId">Could be UserId or ChatAgentId</param>
    /// <param name="TextContent"></param>
    /// <param name="AuthorType"></param>
    public record AddMessageCommand(
        string ChatId,
        string AuthorId,
        string TextContent,
        AuthorType AuthorType = AuthorType.UserProfile) : ICommand<MessageViewModel>;
}
