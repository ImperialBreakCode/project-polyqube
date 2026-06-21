using API.Chats.Application.Features.Messages.Commands.AddMessage;
using API.Chats.Application.Features.Ollama.Commands.GenerateOllamaAgentReply;
using API.Chats.Application.Features.UserProfiles.Factories;
using API.Chats.Feature.Chats.Ollama;
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
        private readonly IOllamaHubConversationStore _ollamaConversationStore;

        public ChatHub(
            ISender sender,
            IUserProfileQueryFactory userProfileQueryFactory,
            IMapper mapper,
            IOllamaHubConversationStore ollamaConversationStore)
        {
            _sender = sender;
            _userProfileQueryFactory = userProfileQueryFactory;
            _mapper = mapper;
            _ollamaConversationStore = ollamaConversationStore;
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            _ollamaConversationStore.ClearConnection(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task JoinChat(string chatId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
            _ollamaConversationStore.ResetSession(Context.ConnectionId, chatId);
        }

        public async Task LeaveChat(string chatId)
        {
            _ollamaConversationStore.RemoveSession(Context.ConnectionId, chatId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
        }

        public async Task NotifyTyping(string chatId)
        {
            if (string.IsNullOrWhiteSpace(chatId))
            {
                return;
            }

            await Clients.OthersInGroup(chatId).SendCoreAsync(
                "UserTyping",
                Array.Empty<object>(),
                Context.ConnectionAborted);
        }

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

        public async Task<MessageResponseDTO> PromptChatAgent(string chatId, string textContent)
        {
            if (string.IsNullOrWhiteSpace(textContent))
            {
                throw new HubException("Message text is required.");
            }

            var userId = Context.User.GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new HubException("Unauthorized");
            }

            var profileQuery = _userProfileQueryFactory.CreateGetProfileByUserIdQuery(userId);
            var profile = await _sender.Send(profileQuery, Context.ConnectionAborted);

            _ollamaConversationStore.AppendUserMessage(Context.ConnectionId, chatId, $"{profile.FirstName} {profile.LastName}: {textContent.Trim()}");

            var conversation = _ollamaConversationStore.GetConversation(Context.ConnectionId, chatId);

            var generateCommand = new GenerateOllamaAgentReplyCommand(chatId, conversation);
            var generated = await _sender.Send(generateCommand, Context.ConnectionAborted);

            _ollamaConversationStore.AppendAssistantMessage(Context.ConnectionId, chatId, generated.ReplyText);

            var addAgentMessage = new AddMessageCommand(
                chatId,
                generated.ChatAgentId,
                generated.ReplyText,
                AuthorType.ChatAgent);

            var message = await _sender.Send(addAgentMessage, Context.ConnectionAborted);
            var dto = _mapper.Map<MessageResponseDTO>(message);

            await Clients.Group(chatId).SendAsync("MessageReceived", dto, Context.ConnectionAborted);

            return dto;
        }
    }
}
