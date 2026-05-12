using API.Chats.Application.Features.Messages.Commands.AddMessage;
using API.Chats.Application.Features.UserProfiles.Factories;
using API.Chats.Feature.Messages.Models.Responses;
using API.Shared.Web.Attributes;
using API.Shared.Web.Extensions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace API.Chats.Feature.Chats.Hubs
{
    [AuthorizeUserScope]
    [AuthorizeModuleAccess]
    public class ChatHub : Hub
    {
        private readonly ISender _sender;
        private readonly IUserProfileQueryFactory _userProfileQueryFactory;
        private readonly IMapper _mapper;

        public ChatHub(
            ISender sender,
            IUserProfileQueryFactory userProfileQueryFactory,
            IMapper mapper)
        {
            _sender = sender;
            _userProfileQueryFactory = userProfileQueryFactory;
            _mapper = mapper;
        }

        public async Task JoinChat(string chatId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
        }

        public async Task LeaveChat(string chatId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
        }

        /// <summary>
        ///     Notifies other connections in the chat that the current user is typing (no payload).
        /// </summary>
        public async Task NotifyTyping(string chatId)
        {
            if (string.IsNullOrWhiteSpace(chatId))
            {
                return;
            }

            await Clients.OthersInGroup(chatId).SendCoreAsync(
                "UserTyping",
                System.Array.Empty<object>(),
                Context.ConnectionAborted);
        }

        /// <summary>
        ///     Persists a user message via <see cref="AddMessageCommand" /> (author = current user profile) and broadcasts it to the chat group.
        /// </summary>
        public async Task SendChatMessage(string chatId, string textContent)
        {
            if (string.IsNullOrWhiteSpace(textContent))
            {
                return;
            }

            var userId = Context.User.GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new HubException("Unauthorized");
            }

            var profileQuery = _userProfileQueryFactory.CreateGetProfileByUserIdQuery(userId);
            var profile = await _sender.Send(profileQuery, Context.ConnectionAborted);

            var command = new AddMessageCommand(
                chatId,
                profile.Id,
                textContent.Trim(),
                AuthorType.UserProfile);

            var message = await _sender.Send(command, Context.ConnectionAborted);
            var dto = _mapper.Map<MessageResponseDTO>(message);

            await Clients.Group(chatId).SendAsync("MessageReceived", dto, Context.ConnectionAborted);
        }
    }
}
